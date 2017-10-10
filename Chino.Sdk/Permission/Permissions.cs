//-----------------------------------------------------------------------
// <copyright file="Permissions.cs" company="Chino.IO and NursIt.Institute" />
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
    using System.Collections.Generic;

    /// <summary>
    /// Encapsulates the handling of Permissions
    /// </summary>
    public class Permissions
    {
        /// <summary>
        /// Defines the client
        /// </summary>
        private RestClient client = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Permissions"/> class.
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        public Permissions(RestClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// The Grant
        /// </summary>
        /// <param name="grants">The <see cref="PermissionSet"/></param>
        /// <param name="resourceType">The <see cref="PermissionResourceType"/></param>
        /// <param name="subjectType">The <see cref="PermissionSubjectType"/></param>
        /// <param name="subjectId">The <see cref="string"/></param>
        public void Grant(PermissionSet grants, PermissionResourceType resourceType, PermissionSubjectType subjectType, string subjectId)
        {
            Grant(grants, resourceType, string.Empty, subjectType, subjectId);
        }

        /// <summary>
        /// The Grant
        /// </summary>
        /// <param name="grants">The <see cref="PermissionSet"/></param>
        /// <param name="resourceType">The <see cref="PermissionResourceType"/></param>
        /// <param name="resourceId">The <see cref="string"/></param>
        /// <param name="subjectType">The <see cref="PermissionSubjectType"/></param>
        /// <param name="subjectId">The <see cref="string"/></param>
        public void Grant(PermissionSet grants, PermissionResourceType resourceType, string resourceId, PermissionSubjectType subjectType, string subjectId)
        {
            Grant(grants, resourceType, resourceId, PermissionResourceType.none, subjectType, subjectId);
        }

        /// <summary>
        /// The Grant
        /// </summary>
        /// <param name="grants">The <see cref="PermissionSet"/></param>
        /// <param name="resourceType">The <see cref="PermissionResourceType"/></param>
        /// <param name="resourceId">The <see cref="string"/></param>
        /// <param name="childType">The <see cref="PermissionResourceType"/></param>
        /// <param name="subjectType">The <see cref="PermissionSubjectType"/></param>
        /// <param name="subjectId">The <see cref="string"/></param>
        public void Grant(PermissionSet grants, PermissionResourceType resourceType, string resourceId, PermissionResourceType childType, PermissionSubjectType subjectType, string subjectId)
        {
            Permission.Grant(client, grants, resourceType, resourceId, childType, subjectType, subjectId);
        }

        //
        /// <summary>
        /// The Revoke
        /// </summary>
        /// <param name="grants">The <see cref="PermissionSet"/></param>
        /// <param name="resourceType">The <see cref="PermissionResourceType"/></param>
        /// <param name="subjectType">The <see cref="PermissionSubjectType"/></param>
        /// <param name="subjectId">The <see cref="string"/></param>
        public void Revoke(PermissionSet grants, PermissionResourceType resourceType, PermissionSubjectType subjectType, string subjectId)
        {
            Revoke(grants, resourceType, string.Empty, subjectType, subjectId);
        }

        /// <summary>
        /// The Revoke
        /// </summary>
        /// <param name="grants">The <see cref="PermissionSet"/></param>
        /// <param name="resourceType">The <see cref="PermissionResourceType"/></param>
        /// <param name="resourceId">The <see cref="string"/></param>
        /// <param name="subjectType">The <see cref="PermissionSubjectType"/></param>
        /// <param name="subjectId">The <see cref="string"/></param>
        public void Revoke(PermissionSet grants, PermissionResourceType resourceType, string resourceId, PermissionSubjectType subjectType, string subjectId)
        {
            Revoke(grants, resourceType, resourceId, PermissionResourceType.none, subjectType, subjectId);
        }

        /// <summary>
        /// The Revoke
        /// </summary>
        /// <param name="grants">The <see cref="PermissionSet"/></param>
        /// <param name="resourceType">The <see cref="PermissionResourceType"/></param>
        /// <param name="resourceId">The <see cref="string"/></param>
        /// <param name="childType">The <see cref="PermissionResourceType"/></param>
        /// <param name="subjectType">The <see cref="PermissionSubjectType"/></param>
        /// <param name="subjectId">The <see cref="string"/></param>
        public void Revoke(PermissionSet grants, PermissionResourceType resourceType, string resourceId, PermissionResourceType childType, PermissionSubjectType subjectType, string subjectId)
        {
            Permission.Revoke(client, grants, resourceType, resourceId, childType, subjectType, subjectId);
        }
    }

    /// <summary>
    /// Defines the <see cref="PermissionSet" />
    /// </summary>
    public class PermissionSet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionSet"/> class.
        /// </summary>
        public PermissionSet()
        {
            Manage = new List<PermissionGrants>();
            Authorize = new List<PermissionGrants>();
            CreatedDocument = new CreateDocumentPermissions();
        }

        /// <summary>
        /// Gets or sets the Manage
        /// </summary>
        [JsonProperty(PropertyName = "manage")]
        public IEnumerable<PermissionGrants> Manage { get; set; }

        /// <summary>
        /// Gets or sets the Authorize
        /// </summary>
        [JsonProperty(PropertyName = "authorize")]
        public IEnumerable<PermissionGrants> Authorize { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDocument
        /// </summary>
        [JsonProperty(PropertyName = "created_document")]
        public CreateDocumentPermissions CreatedDocument { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="CreateDocumentPermissions" />
    /// </summary>
    public class CreateDocumentPermissions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateDocumentPermissions"/> class.
        /// </summary>
        public CreateDocumentPermissions()
        {
            Manage = new List<PermissionGrants>();
            Authorize = new List<PermissionGrants>();
        }

        /// <summary>
        /// Gets or sets the Manage
        /// </summary>
        [JsonProperty(PropertyName = "manage")]
        public List<PermissionGrants> Manage { get; set; }

        /// <summary>
        /// Gets or sets the Authorize
        /// </summary>
        [JsonProperty(PropertyName = "authorize")]
        public List<PermissionGrants> Authorize { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="Permission" />
    /// </summary>
    public class Permission
    {
        /// <summary>
        /// Gets or sets the Permissions
        /// </summary>
        [JsonProperty(PropertyName = "permissions")]
        public PermissionSet Permissions { get; set; }

        /// <summary>
        /// The ChangePermissionsion
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="action">The <see cref="PermissionAction"/></param>
        /// <param name="grants">The <see cref="PermissionSet"/></param>
        /// <param name="resourceType">The <see cref="PermissionResourceType"/></param>
        /// <param name="resourceId">The <see cref="string"/></param>
        /// <param name="childType">The <see cref="PermissionResourceType"/></param>
        /// <param name="subjectType">The <see cref="PermissionSubjectType"/></param>
        /// <param name="subjectId">The <see cref="string"/></param>
        private static void ChangePermissionsion(RestClient client, PermissionAction action, PermissionSet grants,
            PermissionResourceType resourceType, string resourceId, PermissionResourceType childType,
            PermissionSubjectType subjectType, string subjectId)
        {
            var uri = string.Format("/perms/{0}/{1}/{2}/{3}/{4}/{5}",
                action.ToString().ToLower(),
                resourceType.ToString().ToLower(),
                resourceId,
                childType == PermissionResourceType.none ? string.Empty : childType.ToString(),
                subjectType.ToString().ToLower(),
                subjectId
            );

            uri = uri.Replace("//", "/");

            var request = new RestRequest(uri, Method.POST);
            Rest.Execute<BasicResponse>(client, request, grants);
        }

        /// <summary>
        /// The Grant
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="grants">The <see cref="PermissionSet"/></param>
        /// <param name="resourceType">The <see cref="PermissionResourceType"/></param>
        /// <param name="subjectType">The <see cref="PermissionSubjectType"/></param>
        /// <param name="subjectId">The <see cref="string"/></param>
        public static void Grant(RestClient client, PermissionSet grants, PermissionResourceType resourceType, PermissionSubjectType subjectType, string subjectId)
        {
            Grant(client, grants, resourceType, string.Empty, subjectType, subjectId);
        }

        /// <summary>
        /// The Grant
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="grants">The <see cref="PermissionSet"/></param>
        /// <param name="resourceType">The <see cref="PermissionResourceType"/></param>
        /// <param name="resourceId">The <see cref="string"/></param>
        /// <param name="subjectType">The <see cref="PermissionSubjectType"/></param>
        /// <param name="subjectId">The <see cref="string"/></param>
        public static void Grant(RestClient client, PermissionSet grants, PermissionResourceType resourceType, string resourceId, PermissionSubjectType subjectType, string subjectId)
        {
            Grant(client, grants, resourceType, resourceId, PermissionResourceType.none, subjectType, subjectId);
        }

        /// <summary>
        /// The Grant
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="grants">The <see cref="PermissionSet"/></param>
        /// <param name="resourceType">The <see cref="PermissionResourceType"/></param>
        /// <param name="resourceId">The <see cref="string"/></param>
        /// <param name="childType">The <see cref="PermissionResourceType"/></param>
        /// <param name="subjectType">The <see cref="PermissionSubjectType"/></param>
        /// <param name="subjectId">The <see cref="string"/></param>
        public static void Grant(RestClient client, PermissionSet grants, PermissionResourceType resourceType, string resourceId, PermissionResourceType childType, PermissionSubjectType subjectType, string subjectId)
        {
            ChangePermissionsion(client, PermissionAction.grant, grants, resourceType, resourceId, childType, subjectType, subjectId);
        }

        /// <summary>
        /// The Revoke
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="grants">The <see cref="PermissionSet"/></param>
        /// <param name="resourceType">The <see cref="PermissionResourceType"/></param>
        /// <param name="subjectType">The <see cref="PermissionSubjectType"/></param>
        /// <param name="subjectId">The <see cref="string"/></param>
        public static void Revoke(RestClient client, PermissionSet grants, PermissionResourceType resourceType, PermissionSubjectType subjectType, string subjectId)
        {
            Revoke(client, grants, resourceType, string.Empty, subjectType, subjectId);
        }

        /// <summary>
        /// The Revoke
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="grants">The <see cref="PermissionSet"/></param>
        /// <param name="resourceType">The <see cref="PermissionResourceType"/></param>
        /// <param name="resourceId">The <see cref="string"/></param>
        /// <param name="subjectType">The <see cref="PermissionSubjectType"/></param>
        /// <param name="subjectId">The <see cref="string"/></param>
        public static void Revoke(RestClient client, PermissionSet grants, PermissionResourceType resourceType, string resourceId, PermissionSubjectType subjectType, string subjectId)
        {
            Revoke(client, grants, resourceType, resourceId, PermissionResourceType.none, subjectType, subjectId);
        }

        /// <summary>
        /// The Revoke
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="grants">The <see cref="PermissionSet"/></param>
        /// <param name="resourceType">The <see cref="PermissionResourceType"/></param>
        /// <param name="resourceId">The <see cref="string"/></param>
        /// <param name="childType">The <see cref="PermissionResourceType"/></param>
        /// <param name="subjectType">The <see cref="PermissionSubjectType"/></param>
        /// <param name="subjectId">The <see cref="string"/></param>
        public static void Revoke(RestClient client, PermissionSet grants, PermissionResourceType resourceType, string resourceId, PermissionResourceType childType, PermissionSubjectType subjectType, string subjectId)
        {
            ChangePermissionsion(client, PermissionAction.revoke, grants, resourceType, resourceId, childType, subjectType, subjectId);
        }
    }

    /// <summary>
    /// Defines the PermissionGrants
    /// </summary>
    public enum PermissionGrants
    {
        /// <summary>
        /// Defines the Create
        /// </summary>
        Create = 'C',

        /// <summary>
        /// Defines the List
        /// </summary>
        List = 'L',

        /// <summary>
        /// Defines the Read
        /// </summary>
        Read = 'R',

        /// <summary>
        /// Defines the Update
        /// </summary>
        Update = 'U',

        /// <summary>
        /// Defines the Delete
        /// </summary>
        Delete = 'D',

        /// <summary>
        /// Defines the Search
        /// </summary>
        Search = 'S',

        /// <summary>
        /// Defines the Admin
        /// </summary>
        Admin = 'A'
    }

    /// <summary>
    /// Defines the PermissionResourceType
    /// </summary>
    public enum PermissionResourceType
    {
        /// <summary>
        /// Defines the none
        /// </summary>
        none,

        /// <summary>
        /// Defines the repository
        /// </summary>
        repository,

        /// <summary>
        /// Defines the schema
        /// </summary>
        schema,

        /// <summary>
        /// Defines the group
        /// </summary>
        group,

        /// <summary>
        /// Defines the user
        /// </summary>
        user,

        /// <summary>
        /// Defines the document
        /// </summary>
        document,

        /// <summary>
        /// Defines the user_schemas
        /// </summary>
        user_schemas
    }

    /// <summary>
    /// Defines the PermissionAction
    /// </summary>
    public enum PermissionAction
    {
        /// <summary>
        /// Defines the grant
        /// </summary>
        grant,

        /// <summary>
        /// Defines the revoke
        /// </summary>
        revoke
    }

    /// <summary>
    /// Defines the PermissionSubjectType
    /// </summary>
    public enum PermissionSubjectType
    {
        /// <summary>
        /// Defines the users
        /// </summary>
        users,

        /// <summary>
        /// Defines the groups
        /// </summary>
        groups
    }
}
