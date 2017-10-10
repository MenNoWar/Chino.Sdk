//-----------------------------------------------------------------------
// <copyright file="ChinoApplication.cs" company="Chino.IO and NursIt.Institute" />
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
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using RestSharp;

    /// <summary>
    /// Handler- and Describing class for an Application
    /// </summary>
    public class ChinoApplication
    {
        /// <summary>
        ///  Gets or sets the api server secret
        /// </summary>
        [JsonProperty(PropertyName = "app_secret")]
        public string Secret { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ApplicationGrantType"/> to use for authentication
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "grant_type")]
        public ApplicationGrantType GrantType { get; set; }

        /// <summary>
        /// Gets or sets the name of the application
        /// </summary>
        [JsonProperty(PropertyName = "app_name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Url to return after a successful login
        /// </summary>
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; set; }

        /// <summary>
        /// Gets or sets the id of the application
        /// </summary>
        [JsonProperty(PropertyName = "app_id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets a list of Applications from the api server
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/> to use for communication</param>
        /// <param name="start">where the list should start</param>
        /// <param name="limit">the amount of records to read</param>
        /// <returns>a new instance of the <see cref="ApplicationList"/> class</returns>
        public static ApplicationList List(RestClient client, int start, int limit)
        {
            var request = new RestRequest("/auth/applications", Method.GET);
            request.AddQueryParameter("offset", start.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            var response = Rest.Execute<ListApplicationsResponse>(client, request);
            return response.Data;
        }

        /// <summary>
        /// Reads a specified Application
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/> to use for communication</param>
        /// <param name="applicationId">The <see cref="ChinoApplication.Id"/> to identify the application</param>
        /// <returns>a new instance of the <see cref="ChinoApplication"/> class</returns>
        public static ChinoApplication Read(RestClient client, string applicationId)
        {
            var request = new RestRequest("/auth/applications/" + applicationId, Method.GET);
            var response = Rest.Execute<ReadApplicationResponse>(client, request);
            return response.Data.Application;
        }

        /// <summary>
        /// Updates a Chino Application on the server
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/> tp use for communication</param>
        /// <param name="id">The <see cref="ChinoApplication.Id"/> of the application to update</param>
        /// <param name="name">The new <see cref="ChinoApplication.Name"/></param>
        /// <param name="grantType">The <see cref="ApplicationGrantType"/> to set</param>
        /// <param name="redirectUrl">The Uri to return after successful login</param>
        /// <returns>a new instance of the <see cref="ChinoApplication"/> class</returns>
        public static ChinoApplication Update(RestClient client, string id, string name, ApplicationGrantType grantType, string redirectUrl)
        {
            var request = new RestRequest("/auth/applications/" + id, Method.PUT);
            var updateApplicationRequest = new CreateApplicationRequest
            {
                Name = name,
                GrantType = grantType,
                RedirectUrl = redirectUrl
            };

            var response = Rest.Execute<ReadApplicationResponse>(client, request, updateApplicationRequest);
            return response.Data.Application;
        }

        /// <summary>
        /// Creates a new Chino Application on the server
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/> to use for communication</param>
        /// <param name="name">The <see cref="ChinoApplication.Name"/> of the application</param>
        /// <param name="grantType">The <see cref="ApplicationGrantType"/> for the ne application</param>
        /// <param name="redirectUrl">The Uri to return after successful login</param>
        /// <returns>The <see cref="ChinoApplication"/></returns>
        public static ChinoApplication Create(RestClient client, string name, ApplicationGrantType grantType, string redirectUrl)
        {
            var request = new RestRequest("/auth/applications", Method.POST);
            var createApplicationRequest = new CreateApplicationRequest
            {
                Name = name,
                GrantType = grantType,
                RedirectUrl = redirectUrl
            };

            var response = Rest.Execute<ReadApplicationResponse>(client, request, createApplicationRequest);

            return response.Data.Application;
        }

        /// <summary>
        /// Deletes a Chino Application on the server
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/> to use for communication</param>
        /// <param name="id">The <see cref="ChinoApplication.Id"/> of the application to delete</param>
        public static void Delete(RestClient client, string id)
        {
            var request = new RestRequest("/auth/applications/" + id, Method.DELETE);
            Rest.Execute<ReadApplicationResponse>(client, request);
        }
    }
}
