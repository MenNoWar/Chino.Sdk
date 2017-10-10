//-----------------------------------------------------------------------
// <copyright file="users.cs" company="Chino.IO and NursIt.Institute" />
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
    /// Encapsulates handling User actions
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Defines the client
        /// </summary>
        private RestClient client = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Users" /> class
        /// </summary>
        /// <param name="client">the <see cref="RestSharp.RestClient" /> to use for communication</param>
        public Users(RestClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// Gets the current used <see cref="User" /> from the server
        /// </summary>
        /// <returns>a new instance of the <see cref="User" /> class</returns>
        /// <exception cref="ChinoApiException">thrown by the api server, when recieving incorrect request data</exception>
        public User Current()
        {
            return User.Current(client);
        }

        /// <summary>
        /// Creates a new user on the server
        /// </summary>
        /// <param name="user">the template user to generate from</param>
        /// <param name="password">the users password</param>
        /// <returns>a new instance of the <see cref="User" /> class</returns>
        /// <exception cref="ChinoApiException">thrown by the api server, when recieving incorrect request data</exception>
        public User Create(User user, string password)
        {
            return User.Create(client, user, password);
        }

        /// <summary>
        /// Deletes a <see cref="User" /> from the server
        /// </summary>
        /// <param name="id">the Id of the user to delete</param>
        /// <exception cref="ChinoApiException">thrown by the api server, when recieving incorrect request data</exception>
        public void Delete(string id)
        {
            User.Delete(client, id, false);
        }

        /// <summary>
        /// Deactivates a user on the server to deny further logins
        /// </summary>
        /// <param name="id">the Id of the <see cref="User" /> to deactivate</param>
        /// <exception cref="ChinoApiException">thrown by the api server, when recieving incorrect request data</exception>
        public void Deactivate(string id)
        {
            User.Delete(client, id, true);
        }

        /// <summary>
        /// Gets a list containting the first 100 users
        /// </summary>
        /// <param name="userSchemaId">the Id of the <see cref="UserSchema" /> to read the users from</param>
        /// <returns>a new instance of the <see cref="UserList" /> class</returns>
        /// <exception cref="ChinoApiException">thrown by the api server, when recieving incorrect request data</exception>
        public UserList List(string userSchemaId)
        {
            return List(userSchemaId, 0, 100);
        }

        /// <summary>
        /// Gets a list of users for a schema
        /// </summary>
        /// <param name="userSchemaId">the Id of the <see cref="UserSchema" /> to read the users from</param>
        /// <param name="start">where the list should start</param>
        /// <param name="limit">the number of records to return</param>        
        /// <returns>a new instance of the <see cref="UserList" /> class</returns>
        /// <exception cref="ChinoApiException">thrown by the api server, when recieving incorrect request data</exception>
        public UserList List(string userSchemaId, int start, int limit)
        {
            return User.List(client, userSchemaId, start, limit);
        }

        /// <summary>
        /// Reads a single <see cref="User" /> from the server
        /// </summary>
        /// <param name="userId">the Id of the <see cref="User" /> to read</param>
        /// <returns>a new instance of the <see cref="User" /> class</returns>
        /// <exception cref="ChinoApiException">thrown by the api server, when recieving incorrect request data</exception>
        public User Get(string userId)
        {
            return User.Get(client, userId);
        }

        /// <summary>
        /// Updates a <see cref="User" /> on the server
        /// </summary>
        /// <param name="user">the userdata to update</param>
        /// <exception cref="ChinoApiException">thrown by the api server, when recieving incorrect request data</exception>
        public void Update(User user)
        {
            User.Update(client, user);
        }
    }
}
