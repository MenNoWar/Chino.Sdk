//-----------------------------------------------------------------------
// <copyright file="User.cs" company="Chino.IO and NursIt.Institute" />
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
    /// a class representing a Chino Application User
    /// </summary>
    public class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class
        /// </summary>
        public User()
        {
            Attributes = new Dictionary<string, object>();
        }

        /// <summary>
        /// The Current
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <returns>The <see cref="User"/></returns>
        public static User Current(RestClient client)
        {
            var uri = "/users/me";
            var result = Rest.Execute<UserResponse>(client, new RestRequest(uri, Method.GET));
            return result.Data.User;
        }

        /// <summary>
        /// The List
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="userSchemaId">The <see cref="string"/></param>
        /// <param name="start">The <see cref="int"/></param>
        /// <param name="limit">The <see cref="int"/></param>
        /// <returns>The <see cref="UserList"/></returns>
        public static UserList List(RestClient client, string userSchemaId, int start, int limit)
        {
            var uri = string.Format("/user_schemas/{0}/users", userSchemaId);
            var request = new RestRequest(uri, Method.GET);
            request.AddQueryParameter("offset", start.ToString());
            request.AddQueryParameter("limit", limit.ToString());
            var result = Rest.Execute<ListUserResponse>(client, request);
            return result.Data;
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="user">The <see cref="User"/></param>
        /// <param name="password">The <see cref="string"/></param>
        /// <returns>The <see cref="User"/></returns>
        public static User Create(RestClient client, User user, string password)
        {
            if (string.IsNullOrEmpty(user.SchemaId)) throw new ChinoApiException("SchemaId for User not set");
            var uri = string.Format("/user_schemas/{0}/users", user.SchemaId);
            var request = new RestRequest(uri, Method.POST);
            var body = new
            {
                username = user.Name,
                password = password,
                attributes = user.Attributes,
                is_active = user.IsActive
            };

            var result = Rest.Execute<UserResponse>(client, request, body);
            return result.Data.User;
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="id">The <see cref="string"/></param>
        /// <param name="disableOnly">The <see cref="bool"/></param>
        public static void Delete(RestClient client, string id, bool disableOnly)
        {
            var force = !disableOnly;
            var uri = string.Format("/users/{0}", id);
            var request = new RestRequest(uri, Method.DELETE);

            if (force)
            {
                request.AddQueryParameter("force", "true");
            }

            Rest.Execute<BasicResponse>(client, request);
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="userId">The <see cref="string"/></param>
        /// <returns>The <see cref="User"/></returns>
        public static User Get(RestClient client, string userId)
        {
            var uri = string.Format("/users/{0}", userId);
            var request = new RestRequest(uri, Method.GET);
            var result = Rest.Execute<UserResponse>(client, request);
            return result.Data.User;
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="user">The <see cref="User"/></param>
        public static void Update(RestClient client, User user)
        {
            var uri = string.Format("/users/{0}", user.Id);
            var request = new RestRequest(uri, Method.PATCH);
            var body = new
            {
                is_active = user.IsActive,
                username = user.Name,
                attributes = user.Attributes
            };

            Rest.Execute<UserResponse>(client, request, body);
        }

        /// <summary>
        /// Gets or sets a value indicating the UserId
        /// </summary>
        [JsonProperty(PropertyName = "user_id")]
        public String Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the User's Username
        /// </summary>
        [JsonProperty(PropertyName = "username")]
        public String Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating when the <see cref="User" /> has been created
        /// </summary>
        [JsonProperty(PropertyName = "insert_date")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets a list containing the ids of the groups the user belongs to
        /// </summary>
        [JsonProperty(PropertyName = "groups")]
        public List<string> Groups { get; internal set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is active
        /// </summary>
        [JsonProperty(PropertyName = "is_active")]
        public Boolean IsActive { get; set; }

        /// <summary>
        /// Gets a value indicating when the <see cref="User" /> has been updated
        /// </summary>
        [JsonProperty(PropertyName = "last_update")]
        public DateTime Updated { get; internal set; }

        /// <summary>
        /// Gets or sets a Dictionary containing the Attributeset for this user. <see cref="UserSchema"/>
        /// </summary>
        [JsonProperty(PropertyName = "attributes")]
        public IDictionary<string, object> Attributes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the id of the user schema
        /// </summary>
        [JsonProperty(PropertyName = "schema_id")]
        public string SchemaId { get; set; }
    }
}
