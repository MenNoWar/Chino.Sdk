//-----------------------------------------------------------------------
// <copyright file="Group.cs" company="Chino.IO and NursIt.Institute" />
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
    /// Defines the <see cref="Group" />
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Group"/> class.
        /// </summary>
        public Group()
        {
            Attributes = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [JsonProperty(PropertyName = "group_id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        [JsonProperty(PropertyName = "group_name")]
        public string Name { get; set; }

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
        /// Gets or sets the Attributes
        /// </summary>
        [JsonProperty(PropertyName = "attributes")]
        public Dictionary<string, object> Attributes { get; set; }

        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="groupId">The <see cref="string"/></param>
        /// <returns>The <see cref="Group"/></returns>
        public static Group Get(RestClient client, string groupId)
        {
            var uri = string.Format("/groups/{0}", groupId);
            var request = new RestRequest(uri, Method.GET);
            var result = Rest.Execute<GroupResponse>(client, request);
            return result.Data.Group;
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="group">The <see cref="Group"/></param>
        /// <returns>The <see cref="Group"/></returns>
        public static Group Create(RestClient client, Group group)
        {
            var uri = "/groups";
            var request = new RestRequest(uri, Method.POST);
            var body = new
            {
                group_name = group.Name,
                attributes = group.Attributes
            };

            var result = Rest.Execute<GroupResponse>(client, request, body);
            return result.Data.Group;
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="groupId">The <see cref="string"/></param>
        /// <param name="disableOnly">The <see cref="bool"/></param>
        public static void Delete(RestClient client, string groupId, bool disableOnly)
        {
            var uri = string.Format("/groups/{0}", groupId);
            var request = new RestRequest(uri, Method.DELETE);
            var force = !disableOnly;
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
        /// <returns>The <see cref="GroupList"/></returns>
        public static GroupList List(RestClient client, int start, int limit)
        {
            var uri = "/groups";
            var request = new RestRequest(uri, Method.GET);
            request.AddQueryParameter("offset", start.ToString());
            request.AddQueryParameter("limit", limit.ToString());
            var result = Rest.Execute<ListGroupResponse>(client, request);

            return result.Data;
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="group">The <see cref="Group"/></param>
        public static void Update(RestClient client, Group group)
        {
            var uri = string.Format("/groups/{0}", group.Id);
            var request = new RestRequest(uri, Method.PUT);
            var body = new
            {
                group_name = group.Name,
                is_active = group.IsActive,
                attributes = group.Attributes
            };

            Rest.Execute<BasicResponse>(client, request, body);
        }

        /// <summary>
        /// The ChangeUsers
        /// </summary>
        /// <param name="method">The <see cref="RestSharp.Method"/></param>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="groupId">The <see cref="string"/></param>
        /// <param name="userId">The <see cref="string"/></param>
        private static void ChangeUsers(RestSharp.Method method, RestClient client, string groupId, string userId)
        {
            var uri = string.Format("/groups/{0}/users/{1}", groupId, userId);
            var request = new RestRequest(uri, method);
            Rest.Execute<BasicResponse>(client, request);
        }

        /// <summary>
        /// The AddUser
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="groupId">The <see cref="string"/></param>
        /// <param name="userId">The <see cref="string"/></param>
        public static void AddUser(RestClient client, string groupId, string userId)
        {
            ChangeUsers(Method.POST, client, groupId, userId);
        }

        /// <summary>
        /// The RemoveUser
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="groupId">The <see cref="string"/></param>
        /// <param name="userId">The <see cref="string"/></param>
        public static void RemoveUser(RestClient client, string groupId, string userId)
        {
            ChangeUsers(Method.DELETE, client, groupId, userId);
        }
    }
}
