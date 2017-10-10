//-----------------------------------------------------------------------
// <copyright file="UserSchema.cs" company="Chino.IO and NursIt.Institute" />
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

    /// <summary>
    /// Defines the <see cref="UserSchema" />
    /// </summary>
    public class UserSchema
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserSchema"/> class.
        /// </summary>
        public UserSchema()
        {
            Structure = new SchemaFieldStructure();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserSchema"/> class.
        /// </summary>
        /// <param name="description">The <see cref="string"/></param>
        public UserSchema(string description) : this()
        {
            Description = description;
        }

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [JsonProperty(PropertyName = "user_schema_id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the Structure
        /// </summary>
        [JsonProperty(PropertyName = "structure")]
        public SchemaFieldStructure Structure { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Groups
        /// </summary>
        [JsonProperty(PropertyName = "groups")]
        public string[] Groups { get; set; }

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
        /// The Update
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="schema">The <see cref="UserSchema"/></param>
        public static void Update(RestClient client, UserSchema schema)
        {
            var uri = string.Format("/user_schemas/{0}", schema.Id);
            var body = new
            {
                description = schema.Description,
                structure = schema.Structure
            };

            var request = new RestRequest(uri, Method.PUT);
            Rest.Execute<UserSchemaResponse>(client, request, body);
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="schema">The <see cref="UserSchema"/></param>
        /// <returns>The <see cref="UserSchema"/></returns>
        public static UserSchema Create(RestClient client, UserSchema schema)
        {
            var uri = "/user_schemas";
            var request = new RestRequest(uri, Method.POST);
            var body = new
            {
                description = schema.Description,
                structure = schema.Structure
            };

            var result = Rest.Execute<UserSchemaResponse>(client, request, body);
            return result.Data.Schema;
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="userSchemaId">The <see cref="string"/></param>
        /// <param name="disableOnly">The <see cref="bool"/></param>
        public static void Delete(RestClient client, string userSchemaId, bool disableOnly)
        {
            var force = !disableOnly;
            var uri = string.Format("/user_schemas/{0}", userSchemaId);
            var request = new RestRequest(uri, Method.DELETE);
            if (force)
            {
                request.AddQueryParameter("force", "true");
            }

            Rest.Execute<BasicResponse>(client, request);
        }

        /// <summary>
        /// The List
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="start">The <see cref="int"/></param>
        /// <param name="limit">The <see cref="int"/></param>
        /// <returns>The <see cref="UserSchemaList"/></returns>
        public static UserSchemaList List(RestClient client, int start, int limit)
        {
            var uri = "/user_schemas";
            var request = new RestRequest(uri, Method.GET);
            request.AddQueryParameter("offset", start.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            var result = Rest.Execute<ListUserSchemaResponse>(client, request);
            return result.Data;
        }
    }
}
