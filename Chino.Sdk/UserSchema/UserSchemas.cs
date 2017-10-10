//-----------------------------------------------------------------------
// <copyright file="UserSchemas.cs" company="Chino.IO and NursIt.Institute" />
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
    /// Defines the <see cref="UserSchemas" />
    /// </summary>
    public class UserSchemas
    {
        /// <summary>
        /// Defines the client
        /// </summary>
        private RestClient client = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserSchemas"/> class.
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        public UserSchemas(RestClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="schema">The <see cref="UserSchema"/></param>
        /// <returns>The <see cref="UserSchema"/></returns>
        public UserSchema Create(UserSchema schema)
        {
            return UserSchema.Create(client, schema);
        }

        /// <summary>
        /// The List
        /// </summary>
        /// <returns>The <see cref="UserSchemaList"/></returns>
        public UserSchemaList List()
        {
            return List(0, 100);
        }

        /// <summary>
        /// The List
        /// </summary>
        /// <param name="start">The <see cref="int"/></param>
        /// <param name="limit">The <see cref="int"/></param>
        /// <returns>The <see cref="UserSchemaList"/></returns>
        public UserSchemaList List(int start, int limit)
        {
            return UserSchema.List(client, start, limit);
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="userSchemaId">The <see cref="string"/></param>
        public void Delete(string userSchemaId)
        {
            UserSchema.Delete(client, userSchemaId, false);
        }

        /// <summary>
        /// The Deactivate
        /// </summary>
        /// <param name="userSchemaId">The <see cref="string"/></param>
        public void Deactivate(string userSchemaId)
        {
            UserSchema.Delete(client, userSchemaId, true);
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="userSchemaId">The <see cref="string"/></param>
        /// <returns>The <see cref="UserSchema"/></returns>
        public UserSchema Get(string userSchemaId)
        {
            var uri = string.Format("/user_schemas/{0}", userSchemaId);
            var request = new RestRequest(uri, Method.GET);
            var result = Rest.Execute<UserSchemaResponse>(client, request);

            return result.Data.Schema;
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="schema">The <see cref="UserSchema"/></param>
        public void Update(UserSchema schema)
        {
            UserSchema.Update(client, schema);
        }
    }
}
