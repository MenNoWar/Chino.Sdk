//-----------------------------------------------------------------------
// <copyright file="Collections.cs" company="Chino.IO and NursIt.Institute" />
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
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Collections" />
    /// </summary>
    public class Collections
    {
        /// <summary>
        /// Defines the client
        /// </summary>
        internal RestClient client;

        //The client is passed in the constructor and is saved in the "client" variable
        /// <summary>
        /// Initializes a new instance of the <see cref="Collections"/> class.
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        public Collections(RestClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// The List
        /// </summary>
        /// <returns>The <see cref="CollectionList"/></returns>
        public CollectionList List()
        {
            return List(0, 100);
        }

        /// <summary>
        /// The List
        /// </summary>
        /// <param name="start">The <see cref="int"/></param>
        /// <param name="limit">The <see cref="int"/></param>
        /// <returns>The <see cref="CollectionList"/></returns>
        public CollectionList List(int start, int limit)
        {
            return Collection.List(client, start, limit);
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="name">The <see cref="string"/></param>
        /// <returns>The <see cref="Collection"/></returns>
        public Collection Create(string name)
        {
            return Collection.Create(client, name);
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The <see cref="string"/></param>
        /// <param name="disableOnly">The <see cref="bool"/></param>
        public void Delete(string id, bool disableOnly)
        {
            Collection.Delete(client, id, disableOnly);
        }

        /// <summary>
        /// The Documents
        /// </summary>
        /// <param name="id">The <see cref="string"/></param>
        /// <param name="start">The <see cref="int"/></param>
        /// <param name="limit">The <see cref="int"/></param>
        /// <returns>The <see cref="IEnumerable{Document}"/></returns>
        public IEnumerable<Document> Documents(string id, int start, int limit)
        {
            return Collection.Documents(client, id, start, limit);
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="id">The <see cref="string"/></param>
        /// <returns>The <see cref="Collection"/></returns>
        public Collection Get(string id)
        {
            return Collection.Get(client, id);
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="id">The <see cref="string"/></param>
        /// <param name="newName">The <see cref="string"/></param>
        /// <returns>The <see cref="Collection"/></returns>
        public Collection Update(string id, string newName)
        {
            return Collection.Update(client, id, newName);
        }

        /// <summary>
        /// The AddDocument
        /// </summary>
        /// <param name="collectionId">The <see cref="string"/></param>
        /// <param name="documentId">The <see cref="string"/></param>
        public void AddDocument(string collectionId, string documentId)
        {
            Collection.AddDocument(client, collectionId, documentId);
        }

        /// <summary>
        /// The DeleteDocument
        /// </summary>
        /// <param name="collectionId">The <see cref="string"/></param>
        /// <param name="documentId">The <see cref="string"/></param>
        public void DeleteDocument(string collectionId, string documentId)
        {
            Collection.DeleteDocument(client, collectionId, documentId);
        }

        /// <summary>
        /// The Search
        /// </summary>
        /// <param name="name">The <see cref="string"/></param>
        /// <param name="contains">The <see cref="bool"/></param>
        /// <returns>The <see cref="CollectionList"/></returns>
        public CollectionList Search(string name, bool contains)
        {
            return Collection.Search(client, name, contains);
        }
    }
}
