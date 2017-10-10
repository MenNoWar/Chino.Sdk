//-----------------------------------------------------------------------
// <copyright file="Groups.cs" company="Chino.IO and NursIt.Institute" />
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
    using RestSharp;

    /// <summary>
    /// Class for handling user Groups
    /// </summary>
    public class Groups
    {
        /// <summary>
        /// Defines the client
        /// </summary>
        private RestClient client = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Groups" /> class
        /// </summary>
        /// <param name="client">the <see cref="RestSharp.RestClient" /> to use for communication</param>
        public Groups(RestClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// Creates a new user group on the server
        /// </summary>
        /// <param name="group">the template group to generate from</param>
        /// <returns>a new instance of the <see cref="Group" /> class generated on the server</returns>
        public Group Create(Group group)
        {
            return Group.Create(client, group);
        }

        /// <summary>
        /// Deletes a user group from the server
        /// </summary>
        /// <param name="groupId">the id of the group to delete</param>
        public void Delete(string groupId)
        {
            Group.Delete(client, groupId, false);
        }

        /// <summary>
        /// Deactivates a user group on the server
        /// </summary>
        /// <param name="groupId">the id of the group to deactivate</param>
        public void Deactivate(string groupId)
        {
            Group.Delete(client, groupId, true);
        }

        /// <summary>
        /// Reads a user group from the server
        /// </summary>
        /// <param name="groupId">the id of the group to read</param>
        /// <returns>a new instance of the <see cref="Group" /> class</returns>
        public Group Get(string groupId)
        {
            return Group.Get(client, groupId);
        }

        /// <summary>
        /// Reads a list of the first 100 user groups from the server
        /// </summary>
        /// <returns>a new instance of the <see cref="GroupList" /> class</returns>
        public GroupList List()
        {
            return List(0, 100);
        }

        /// <summary>
        /// Reads a list of user groups from the server
        /// </summary>
        /// <param name="start">where to start the list</param>
        /// <param name="limit">the amount of records to retrieve</param>
        /// <returns>a new instance of the <see cref="GroupList" /> class</returns>
        public GroupList List(int start, int limit)
        {
            return Group.List(client, start, limit);
        }

        /// <summary>
        /// Updates a groupo on the server from the given template
        /// </summary>
        /// <param name="group">the group definition to update</param>
        public void Update(Group group)
        {
            Group.Update(client, group);
        }

        /// <summary>
        /// Adds a user to a group
        /// </summary>
        /// <param name="groupId">the Id of the <see cref="Group" /> to add the user to</param>
        /// <param name="userId">the Id of the <see cref="User"/> to add</param>
        public void AddUser(string groupId, string userId)
        {
            Group.AddUser(client, groupId, userId); ;
        }

        /// <summary>
        /// Removes a <see cref="User" /> from a <see cref="Group" />
        /// </summary>
        /// <param name="groupId">the Id of the <see cref="Group" /> to remove the user from</param>
        /// <param name="userId">the Id of the <see cref="User"/> to remove</param>
        public void RemoveUser(string groupId, string userId)
        {
            Group.RemoveUser(client, groupId, userId); ;
        }
    }
}
