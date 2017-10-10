//-----------------------------------------------------------------------
// <copyright file="Repository.cs" company="Chino.IO and NursIt.Institute" />
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
    /// Defines the <see cref="Repository" />
    /// </summary>
    public class Repository
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [JsonProperty(PropertyName = "repository_id")]
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
        /// Gets or sets the Description
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Created
        /// </summary>
        [JsonProperty(PropertyName = "insert_date")]
        public DateTime Created { get; set; }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="description">The <see cref="string"/></param>
        /// <returns>The <see cref="Repository"/></returns>
        public static Repository Create(RestClient client, string description)
        {
            var request = new RestRequest("/repositories", Method.POST);
            var result = Rest.Execute<RepositoryDefaultResponse>(client, request, new { description = description });
            return result.Data.Repository;
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="id">The <see cref="string"/></param>
        /// <param name="deactivateOnly">The <see cref="bool"/></param>
        public static void Delete(RestClient client, string id, bool deactivateOnly)
        {
            var request = new RestRequest("/repositories/" + id, Method.DELETE);
            if (!deactivateOnly)
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
        /// <returns>The <see cref="Repository"/></returns>
        public static Repository Get(RestClient client, string id)
        {
            var request = new RestRequest("/repositories/" + id, Method.GET);
            var result = Rest.Execute<RepositoryDefaultResponse>(client, request);
            return result.Data.Repository;
        }

        /// <summary>
        /// The List
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="start">The <see cref="int"/></param>
        /// <param name="limit">The <see cref="int"/></param>
        /// <returns>The <see cref="RepositoryList"/></returns>
        public static RepositoryList List(RestClient client, int start, int limit)
        {
            var request = new RestRequest("/repositories", Method.GET);
            request.AddQueryParameter("offset", start.ToString());
            request.AddQueryParameter("limit", limit.ToString());
            var result = Rest.Execute<RepositoryListResponse>(client, request);
            return result.Data;
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="id">The <see cref="string"/></param>
        /// <param name="description">The <see cref="string"/></param>
        /// <param name="isActive">The <see cref="bool"/></param>
        public static void Update(RestClient client, string id, string description, bool isActive)
        {
            var request = new RestRequest("/repositories/" + id, Method.PUT);
            var result = Rest.Execute<RepositoryListResponse>(client, request,
                new
                {
                    description = description,
                    is_active = isActive
                });
            Rest.Execute<BasicResponse>(client, request);
        }
    }
}
