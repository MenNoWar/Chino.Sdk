//-----------------------------------------------------------------------
// <copyright file="Schema.cs" company="Chino.IO and NursIt.Institute" />
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
    /// Defines the <see cref="Schema" />
    /// </summary>
    public class Schema
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Schema"/> class.
        /// </summary>
        public Schema()
        {
            Structure = new SchemaFieldStructure();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Schema"/> class.
        /// </summary>
        /// <param name="description">The <see cref="string"/></param>
        public Schema(string description) : this()
        {
            Description = description.Trim();
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="schemaId">The <see cref="string"/></param>
        /// <returns>The <see cref="Schema"/></returns>
        public static Schema Get(RestClient client, string schemaId)
        {
            var uri = string.Format("/schemas/{0}", schemaId);
            var request = new RestRequest(uri, Method.GET);
            var result = Rest.Execute<SchemaResponse>(client, request);
            return result.Data.Schema;
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="schema">The <see cref="Schema"/></param>
        /// <returns>The <see cref="Schema"/></returns>
        public static Schema Update(RestClient client, Schema schema)
        {
            var uri = string.Format("/schemas/{0}", schema.Id);
            var body = new
            {
                description = schema.Description,
                structure = schema.Structure
            };

            var request = new RestRequest(uri, Method.PUT);
            var result = Rest.Execute<SchemaResponse>(client, request, body);
            return result.Data.Schema;
        }

        /// <summary>
        /// The List
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="repositoryId">The <see cref="string"/></param>
        /// <param name="start">The <see cref="int"/></param>
        /// <param name="limit">The <see cref="int"/></param>
        /// <returns>The <see cref="SchemaList"/></returns>
        public static SchemaList List(RestClient client, string repositoryId, int start, int limit)
        {
            var uri = string.Format("/repositories/{0}/schemas", repositoryId);
            var request = new RestRequest(uri, Method.GET);
            request.AddQueryParameter("offset", start.ToString());
            request.AddQueryParameter("limit", limit.ToString());
            var result = Rest.Execute<ListSchemaResponse>(client, request);
            return result.Data;
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="repositoryId">The <see cref="string"/></param>
        /// <param name="schema">The <see cref="Schema"/></param>
        /// <returns>The <see cref="Schema"/></returns>
        public static Schema Create(RestClient client, string repositoryId, Schema schema)
        {
            var uri = string.Format("/repositories/{0}/schemas", repositoryId);
            var request = new RestRequest(uri, Method.POST);

            var body = new
            {
                description = schema.Description,
                structure = schema.Structure
            };

            var s = JsonConvert.SerializeObject(body);
            var result = Rest.Execute<SchemaResponse>(client, request, body);
            return result.Data.Schema;
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="schemaId">The <see cref="string"/></param>
        /// <param name="disableOnly">The <see cref="bool"/></param>
        public static void Delete(RestClient client, string schemaId, bool disableOnly)
        {
            var uri = string.Format("/schemas/{0}", schemaId); //  {?force}{&all_content}")
            var request = new RestRequest(uri, Method.DELETE);

            var force = !disableOnly;
            if (force)
            {
                request.AddQueryParameter("force", "true");
                request.AddQueryParameter("all_content", "true");
            }

            Rest.Execute<BasicResponse>(client, request);
        }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [JsonProperty(PropertyName = "schema_id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the RepositoryId
        /// </summary>
        [JsonProperty(PropertyName = "repository_id")]
        public string RepositoryId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsActive
        /// </summary>
        [JsonProperty(PropertyName = "is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the Created
        /// </summary>
        [JsonProperty(PropertyName = "insert_date")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the Updated
        /// </summary>
        [JsonProperty(PropertyName = "last_update")]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Gets or sets the Structure
        /// </summary>
        [JsonProperty(PropertyName = "structure")]
        public SchemaFieldStructure Structure { get; set; }

        /// <summary>
        /// Gets the Fields
        /// </summary>
        public IEnumerable<SchemaField> Fields
        {
            get { return Structure.Fields; }
        }
    }
}
