//-----------------------------------------------------------------------
// <copyright file="Schemas.cs" company="Chino.IO and NursIt.Institute" />
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
    /// Defines the <see cref="Schemas" />
    /// </summary>
    public class Schemas
    {
        /// <summary>
        /// Defines the client
        /// </summary>
        private RestClient client = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Schemas"/> class.
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        public Schemas(RestClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// The List
        /// </summary>
        /// <param name="repositoryId">The <see cref="string"/></param>
        /// <returns>The <see cref="SchemaList"/></returns>
        public SchemaList List(string repositoryId)
        {
            return List(repositoryId, 0, 100);
        }

        /// <summary>
        /// The List
        /// </summary>
        /// <param name="repositoryId">The <see cref="string"/></param>
        /// <param name="start">The <see cref="int"/></param>
        /// <param name="limit">The <see cref="int"/></param>
        /// <returns>The <see cref="SchemaList"/></returns>
        public SchemaList List(string repositoryId, int start, int limit)
        {
            return Schema.List(client, repositoryId, start, limit);
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="repositoryId">The <see cref="string"/></param>
        /// <param name="schema">The <see cref="Schema"/></param>
        /// <returns>The <see cref="Schema"/></returns>
        public Schema Create(string repositoryId, Schema schema)
        {
            return Schema.Create(client, repositoryId, schema);
        }

        /// <summary>
        /// The Deactivate
        /// </summary>
        /// <param name="schemaId">The <see cref="string"/></param>
        public void Deactivate(string schemaId)
        {
            Schema.Delete(client, schemaId, true);
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="schemaId">The <see cref="string"/></param>
        public void Delete(string schemaId)
        {
            Schema.Delete(client, schemaId, false);
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="schemaId">The <see cref="string"/></param>
        /// <returns>The <see cref="Schema"/></returns>
        public Schema Get(string schemaId)
        {
            return Schema.Get(client, schemaId);
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="schema">The <see cref="Schema"/></param>
        public void Update(Schema schema)
        {
            Schema.Update(client, schema);
        }
    }
}
