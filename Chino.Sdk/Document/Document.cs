//-----------------------------------------------------------------------
// <copyright file="document.cs" company="Chino.IO and NursIt.Institute" />
// Copyright (c) Chino.IO and NursIt.Institute. All rights reserved.
// </copyright>
// <author>P. Kaatz, Kaatz@nursit.institute</author>
// <warranty>
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </warranty>
//-----------------------------------------------------------------------

namespace Chino.Sdk
{
    using Chino.Sdk.Response;
    using Newtonsoft.Json;
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Represents a Chino Document Node
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Initializes a new instance of the Document class
        /// </summary>
        public Document()
        {
            Content = new Dictionary<string, object>();
        }

        public object Cast(Type t)
        {
            var document = this;
            var obj = Activator.CreateInstance(t);
            var props = obj.GetType().GetProperties();
            foreach (var kvp in document.Content)
            {
                var prop = props.FirstOrDefault(o => string.Compare(o.Name, kvp.Key, true) == 0);
                if (prop != null)
                {
                    if (prop.PropertyType == typeof(byte[])) continue;

                    var val = kvp.Value;
                    if (val is Int64)
                    {
                        val = Convert.ToInt32(val);
                    }
                    
                    prop.SetValue(obj, val);
                }
            }

            var propDocId = props.FirstOrDefault(o => o.Name == "DocumentId");
            if (propDocId != null)
            {
                var ignore = propDocId.GetCustomAttribute<Attributes.IgnorePropertyAttribute>();
                if (ignore != null)
                {
                    propDocId.SetValue(obj, document.Id);
                }
            }

            return obj;
        }

        /// <summary>
        /// Casts the <see cref="Document" /> to another class
        /// </summary>
        /// <typeparam name="T">the type to cast the document into</typeparam>
        /// <returns>a new instance of the given type</returns>
        public T Cast<T>()
        {
            return (T)Cast(typeof(T));
        }

        /// <summary>
        /// Returns a list of <see cref="Document"/>s with default Chino settings
        /// </summary>
        /// <param name="client">the <see cref="RestClient"/> to use for the request</param>
        /// <param name="start">the offset of the first record to return</param>
        /// <param name="limit">the amount of maximum records</param>
        /// <param name="schemaId">the schema under which the documents reside</param>
        /// <param name="includeContent">indicating whether the document content should be returned</param>
        /// <returns>a response including a list of <see cref="Document"/>s</returns>
        internal static ListDocumentsResponse List(RestClient client, int start, int limit, string schemaId, bool includeContent)
        {
            var uri = string.Format("/schemas/{0}/documents", schemaId);
            var request = new RestRequest(uri, Method.GET);
            request.AddQueryParameter("full_document", includeContent.ToString().ToLower());
            request.AddQueryParameter("offset", start.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            var result = Rest.Execute<ListDocumentsResponse>(client, request);
            return result;
        }

        /// <summary>
        /// Retrieves a single Document from the API-Server
        /// </summary>
        /// <param name="client">the <see cref="RestClient"/> to use</param>
        /// <param name="documentId">the id of the document to download</param>
        /// <returns>a new instance of the <see cref="Document"/> class</returns>
        internal static Document Get(RestClient client, string documentId)
        {
            var uri = string.Format("documents/{0}", documentId);
            var request = new RestRequest(uri, Method.GET);
            var result = Rest.Execute<GetDocumentResponse>(client, request);
            return result.Data.Document;
        }

        /// <summary>
        /// Updates an existing <see cref="Document"/> on the server
        /// </summary>
        /// <param name="client">the <see cref="RestClient"/> to use</param>
        /// <param name="document">the <see cref="Document"/> to update</param>
        /// <returns>the id of the updated document</returns>
        internal static void Update(RestClient client, Document document)
        {
            var uri = string.Format("documents/{0}", document.Id);
            var request = new RestRequest(uri, Method.PUT);

            Rest.Execute<UpdateDocumentResponse>(client, request, new { content = document.Content });
        }

        /// <summary>
        /// Creates a new Document on the API-Server and returns the new Id
        /// </summary>
        /// <param name="client">the <see cref="RestClient"/> to use</param>
        /// <param name="schemaId">the schema-Id to store the document to</param>
        /// <param name="document">the document to store</param>
        /// <returns>the Id of the new generated documents</returns>
        internal static string Create(RestClient client, string schemaId, Document document)
        {
            var uri = string.Format("schemas/{0}/documents", schemaId);
            var request = new RestRequest(uri, Method.POST);
            var result = Rest.Execute<UpdateDocumentResponse>(client, request, new { content = document.Content });

            return result.Data.Document.Id;
        }

        /// <summary>
        /// Deletes a Document on the API-Server (set parameter deactivateOnly to true to only deactivate rather than delete the document)
        /// </summary>
        /// <param name="client">the <see cref="RestClient"/> to use</param>        
        /// <param name="documentId">the document-id to delete</param>        
        /// <param name="deactivateOnly">whether the document should really be deleted or only deactivated</param>
        internal static void Delete(RestClient client, string documentId, bool deactivateOnly)
        {
            var force = !deactivateOnly;

            var uri = string.Format("/documents/{0}", documentId);
            var request = new RestRequest(uri, Method.DELETE);

            if (force)
            {
                request.AddQueryParameter("force", force.ToString().ToLower());
            }

            Rest.Execute<UpdateDocumentResponse>(client, request);
        }

        /// <summary>
        /// Gets or sets the id of the document
        /// </summary>
        [JsonProperty(PropertyName = "document_id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets the content of the document
        /// </summary>
        [JsonProperty(PropertyName = "content")]
        public Dictionary<string, object> Content { get; internal set; }

        /// <summary>
        /// Gets a value containg the date the Document was last updated
        /// </summary>
        [JsonProperty(PropertyName = "last_update")]
        public DateTime Updated { get; internal set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Documt is active or deactived
        /// </summary>
        [JsonProperty(PropertyName = "is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating when the Document was created
        /// </summary>
        [JsonProperty(PropertyName = "insert_date")]
        public DateTime Created { get; internal set; }
    }
}
