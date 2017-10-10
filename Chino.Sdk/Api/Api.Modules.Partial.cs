//-----------------------------------------------------------------------
// <copyright file="Api.Modules.Partial.cs" company="Chino.IO and NursIt.Institute" />
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
    /// <summary>
    /// Defines the <see cref="Api" />
    /// </summary>
    public partial class Api
    {
        /// <summary>
        /// Defines the documents
        /// </summary>
        private Documents documents;

        /// <summary>
        /// Defines the authentication
        /// </summary>
        private Authentication authentication;

        /// <summary>
        /// Defines the applications
        /// </summary>
        private Applications applications;

        /// <summary>
        /// Defines the blobs
        /// </summary>
        private Blobs blobs;

        /// <summary>
        /// Defines the collections
        /// </summary>
        private Collections collections;

        /// <summary>
        /// Defines the repos
        /// </summary>
        private Repositories repos;

        /// <summary>
        /// Defines the schemas
        /// </summary>
        private Schemas schemas;

        /// <summary>
        /// Defines the users
        /// </summary>
        private Users users;

        /// <summary>
        /// Defines the userSchemas
        /// </summary>
        private UserSchemas userSchemas;

        /// <summary>
        /// Defines the groups
        /// </summary>
        private Groups groups;

        /// <summary>
        /// Defines the permissions
        /// </summary>
        private Permissions permissions;

        /// <summary>
        /// The CreateClasses
        /// </summary>
        private void CreateClasses()
        {
            this.documents = new Documents(this.client);
            this.authentication = new Authentication(this.client);
            this.applications = new Applications(this.client);
            this.blobs = new Blobs(this.client);
            this.collections = new Collections(client);
            this.repos = new Repositories(client);
            this.schemas = new Schemas(client);
            this.users = new Users(client);
            this.userSchemas = new UserSchemas(client);
            this.groups = new Groups(client);
            this.permissions = new Permissions(client);
        }

        /// <summary>
        /// Gets the wrapper for Users
        /// </summary>
        public Users Users
        {
            get { return this.users; }
        }

        /// <summary>
        /// Gets the wrapper for UserSchemas
        /// </summary>
        public UserSchemas UserSchemas
        {
            get { return this.userSchemas; }
        }

        /// <summary>
        /// Gets the wrapper for Schemas
        /// </summary>
        public Schemas Schemas
        {
            get { return this.schemas; }
        }

        /// <summary>
        /// Gets the wrapper for Documents
        /// </summary>
        public Documents Documents
        {
            get { return this.documents; }
        }

        /// <summary>
        /// Gets the wrapper for Authentication
        /// </summary>
        public Authentication Authentication
        {
            get { return this.authentication; }
        }

        /// <summary>
        /// Gets the wrapper for Applications
        /// </summary>
        public Applications Applications
        {
            get { return this.applications; }
        }

        /// <summary>
        /// Gets the wrapper for Blobs
        /// </summary>
        public Blobs Blobs
        {
            get { return this.blobs; }
        }

        /// <summary>
        /// Gets the wrapper for Collections
        /// </summary>
        public Collections Collections
        {
            get { return this.collections; }
        }

        /// <summary>
        /// Gets the wrapper for Repositories
        /// </summary>
        public Repositories Repositories
        {
            get { return this.repos; }
        }

        /// <summary>
        /// Gets the wrapper for Groups
        /// </summary>
        public Groups Groups
        {
            get { return this.groups; }
        }

        /// <summary>
        /// Gets the wrapper for Permissions
        /// </summary>
        public Permissions Permissions
        {
            get { return this.permissions; }
        }
    }
}
