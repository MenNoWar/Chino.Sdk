//-----------------------------------------------------------------------
// <copyright file="Collection.cs" company="Chino.IO and NursIt.Institute" />
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

    /// <summary>
    /// Defines the <see cref="Collection" />
    /// </summary>
    public class Collection
    {
        /// <summary>
        /// Initializes a new instance of the Collection class.
        /// </summary>
        public Collection()
        {
            this.Documents = new List<Document>();
        }
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [JsonProperty(PropertyName = "collection_id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the Updated
        /// </summary>
        [JsonProperty(PropertyName = "last_update")]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsActive
        /// </summary>
        [JsonProperty(PropertyName = "is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Created
        /// </summary>
        [JsonProperty(PropertyName = "insert_date")]
        public DateTime Created { get; set; }

        /// <summary>
        /// The List
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="start">The <see cref="int"/></param>
        /// <param name="limit">The <see cref="int"/></param>
        /// <param name="readDocuments">Indicates whether the documentlist should be read from the server</param>
        /// <returns>The <see cref="CollectionList"/></returns>
        public static CollectionList List(RestClient client, int start, int limit, bool readDocuments = false)
        {
            var request = new RestRequest("/collections", Method.GET);
            request.AddQueryParameter("offset", start.ToString());
            request.AddQueryParameter("limit", limit.ToString());
            var result = Rest.Execute<CollectionsListResponse>(client, request);

            if (readDocuments)
            {
                foreach (var c in result.Data.Collections)
                {
                    c.ReadDocuments(client);
                }
            }

            return result.Data;
        }

        /// <summary>
        /// The Search
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="name">The <see cref="string"/></param>
        /// <param name="contains">The <see cref="bool"/></param>
        /// <returns>The <see cref="CollectionList"/></returns>
        public static CollectionList Search(RestClient client, string name, bool contains)
        {
            var request = new RestRequest("/collections/search", Method.POST);
            Utils.SetJsonBody(request, new { name = name, contains = contains });
            var result = Rest.Execute<CollectionsListResponse>(client, request);
            return result.Data;
        }

        /// <summary>
        /// The Documents
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="collectionId">The <see cref="string"/></param>
        /// <param name="start">The <see cref="int"/></param>
        /// <param name="limit">The <see cref="int"/></param>
        /// <returns>The <see cref="IEnumerable{Document}"/></returns>
        public static IEnumerable<Document> GetDocuments(RestClient client, string collectionId, int start, int limit)
        {
            var request = new RestRequest(string.Format("/collections/{0}/documents", collectionId));
            request.AddQueryParameter("offset", start.ToString());
            request.AddQueryParameter("limit", limit.ToString());            
            var result = Rest.Execute<CollectionDocumentsResponse>(client, request);
            return result.Data.Documents;
        }

        /// <summary>
        /// The AddDocument
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/> to use for communication</param>
        /// <param name="collectionId">The id of the collection to add the document to</param>
        /// <param name="documentId">The id of the <see cref="Document"/> to add</param>
        public static void AddDocument(RestClient client, string collectionId, string documentId)
        {
            var uri = string.Format("/collections/{0}/documents/{1}", collectionId, documentId);
            var request = new RestRequest(uri, Method.POST);
            Rest.Execute<BasicResponse>(client, request);
        }

        /// <summary>
        /// Sets the Documents contained in the collection
        /// </summary>
        public IEnumerable<Document> Documents { get; private set; }

        /// <summary>
        /// Reads the documents contained in this collection
        /// </summary>
        /// <param name="api">The Api to use for communication</param>
        public void ReadDocuments(Api api)
        {
            this.ReadDocuments(api.Client);
        }

        /// <summary>
        /// Reads the documents contained in this collection
        /// </summary>
        /// <param name="client">The Restclient to use for communication</param>
        public void ReadDocuments(RestClient client)
        {
            this.Documents = GetDocuments(client, this.Id, 0, 100);
        }

        /// <summary>
        /// The AddDocument
        /// </summary>
        /// <param name="api">The <see cref="Api"/> to use for communication</param>
        /// <param name="documentId">The id of the <see cref="Document"/> to add</param>
        public void AddDocument(Api api, string documentId)
        {            
            AddDocument(api.Client, this.Id, documentId);
            this.Documents = GetDocuments(api.Client, this.Id, 0, 100);
        }

        /// <summary>
        /// Delete a document from a collection
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/> to use for communication</param>
        /// <param name="collectionId">The id of the collection to delete the document from</param>
        /// <param name="documentId">The id of the document to delete</param>
        public static void DeleteDocument(RestClient client, string collectionId, string documentId)
        {
            var uri = string.Format("/collections/{0}/documents/{1}", collectionId, documentId);
            var request = new RestRequest(uri, Method.DELETE);
            Rest.Execute<BasicResponse>(client, request);
        }

        public void DeleteDocument(Api api, string documentId)
        {
            DeleteDocument(api.Client, this.Id, documentId);
            this.Documents = GetDocuments(api.Client, this.Id, 0, 100);
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="collectionName">The <see cref="string"/></param>
        /// <returns>The <see cref="Collection"/></returns>
        public static Collection Create(RestClient client, string collectionName)
        {
            var request = new RestRequest("/collections", Method.POST);
            Utils.SetJsonBody(request, new { name = collectionName });

            var resultSet = Rest.Execute<CreateCollectionResponse>(client, request);
            return resultSet.Data.Collection;
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="id">The <see cref="string"/></param>
        /// <param name="disableOnly">The <see cref="bool"/></param>
        public static void Delete(RestClient client, string id, bool disableOnly)
        {
            var request = new RestRequest("/collections/" + id, Method.DELETE);
            if (!disableOnly)
            {
                request.AddQueryParameter("force", "true");
            }

            Rest.Execute<BasicResponse>(client, request);
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="id">The <see cref="string"/></param>
        /// <param name="readDocuments">Specifies whether the documents should be read from the server</param>
        /// <returns>The <see cref="Collection"/></returns>
        public static Collection Get(RestClient client, string id, bool readDocuments = false)
        {
            var request = new RestRequest("/collections/" + id, Method.GET);
            var result = Rest.Execute<GetCollectionResponse>(client, request);

            if (readDocuments)
            {
                result.Data.Collection.ReadDocuments(client);
            }

            return result.Data.Collection;
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="id">The <see cref="string"/></param>
        /// <param name="newName">The <see cref="string"/></param>
        /// <returns>The <see cref="Collection"/></returns>
        public static Collection Update(RestClient client, string id, string newName)
        {
            var request = new RestRequest("/collections/" + id, Method.PUT);
            Utils.SetJsonBody(request, new { name = newName });
            var result = Rest.Execute<CreateCollectionResponse>(client, request);
            return result.Data.Collection;
        }
    }
}
