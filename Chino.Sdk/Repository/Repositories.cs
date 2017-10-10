//-----------------------------------------------------------------------
// <copyright file="Repositories.cs" company="Chino.IO and NursIt.Institute" />
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
    /// Defines the <see cref="Repositories" />
    /// </summary>
    public class Repositories
    {
        /// <summary>
        /// Defines the client
        /// </summary>
        private RestClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repositories"/> class.
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        public Repositories(RestClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="description">The <see cref="string"/></param>
        /// <returns>The <see cref="Repository"/></returns>
        public Repository Create(string description)
        {
            return Repository.Create(client, description);
        }

        /// <summary>
        /// The Deactivate
        /// </summary>
        /// <param name="id">The <see cref="string"/></param>
        public void Deactivate(string id)
        {
            Repository.Delete(client, id, true);
        }

        /// <summary>
        /// The Activate
        /// </summary>
        /// <param name="id">The <see cref="string"/></param>
        public void Activate(string id)
        {
            var repo = Repository.Get(client, id);
            Repository.Update(client, id, repo.Description, true);
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The <see cref="string"/></param>
        public void Delete(string id)
        {
            Repository.Delete(client, id, false);
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="id">The <see cref="string"/></param>
        /// <returns>The <see cref="Repository"/></returns>
        public Repository Get(string id)
        {
            return Repository.Get(client, id);
        }

        /// <summary>
        /// The List
        /// </summary>
        /// <returns>The <see cref="RepositoryList"/></returns>
        public RepositoryList List()
        {
            return List(0, 100);
        }

        /// <summary>
        /// The List
        /// </summary>
        /// <param name="start">The <see cref="int"/></param>
        /// <param name="limit">The <see cref="int"/></param>
        /// <returns>The <see cref="RepositoryList"/></returns>
        public RepositoryList List(int start, int limit)
        {
            return Repository.List(client, start, limit);
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="id">The <see cref="string"/></param>
        /// <param name="description">The <see cref="string"/></param>
        /// <param name="isActive">The <see cref="bool"/></param>
        public void Update(string id, string description, bool isActive)
        {
            Repository.Update(client, id, description, isActive);
        }
    }
}
