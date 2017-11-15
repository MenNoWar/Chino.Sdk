//-----------------------------------------------------------------------
// <copyright file="Schema.cs" company="Chino.IO and NursIt.Institute" />
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
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Defines the <see cref="Schema" />
    /// </summary>
    public class Schema
    {
        public class OnSchemaCreatedEventArgs
        {
            public Schema Schema { get; set; }
            public int Total { get; set; }
            public int Index { get; set; }
        }

        public delegate void OnSchemaCreatedDelegate(OnSchemaCreatedEventArgs args);
        public static event OnSchemaCreatedDelegate OnSchemaCreated = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Schema"/> class.
        /// </summary>
        public Schema()
        {
            Structure = new SchemaFieldStructure();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Schema"/> class.
        /// </summary>
        /// <param name="description">The <see cref="string"/></param>
        public Schema(string description) : this()
        {
            Description = description.Trim();
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="schemaId">The <see cref="string"/></param>
        /// <returns>The <see cref="Schema"/></returns>
        public static Schema Get(RestClient client, string schemaId)
        {
            var uri = string.Format("/schemas/{0}", schemaId);
            var request = new RestRequest(uri, Method.GET);
            var result = Rest.Execute<SchemaResponse>(client, request);
            return result.Data.Schema;
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="schema">The <see cref="Schema"/></param>
        /// <returns>The <see cref="Schema"/></returns>
        public static Schema Update(RestClient client, Schema schema)
        {
            var uri = string.Format("/schemas/{0}", schema.Id);
            var body = new
            {
                description = schema.Description,
                structure = schema.Structure
            };

            var request = new RestRequest(uri, Method.PUT);
            var result = Rest.Execute<SchemaResponse>(client, request, body);
            return result.Data.Schema;
        }

        /// <summary>
        /// The List
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="repositoryId">The <see cref="string"/></param>
        /// <param name="start">The <see cref="int"/></param>
        /// <param name="limit">The <see cref="int"/></param>
        /// <returns>The <see cref="SchemaList"/></returns>
        public static SchemaList List(RestClient client, string repositoryId, int start, int limit)
        {
            var uri = string.Format("/repositories/{0}/schemas", repositoryId);
            var request = new RestRequest(uri, Method.GET);
            request.AddQueryParameter("offset", start.ToString());
            request.AddQueryParameter("limit", limit.ToString());
            var result = Rest.Execute<ListSchemaResponse>(client, request);
            return result.Data;
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="repositoryId">The <see cref="string"/></param>
        /// <param name="schema">The <see cref="Schema"/></param>
        /// <returns>The <see cref="Schema"/></returns>
        public static Schema Create(RestClient client, string repositoryId, Schema schema)
        {
            var uri = string.Format("/repositories/{0}/schemas", repositoryId);
            var request = new RestRequest(uri, Method.POST);

            var body = new
            {
                description = schema.Description,
                structure = schema.Structure
            };

            var s = JsonConvert.SerializeObject(body);
            var result = Rest.Execute<SchemaResponse>(client, request, body);
            return result.Data.Schema;
        }

        /// <summary>
        /// Creates a <see cref="Schema"/> for all classes in the assembly, regarding the <see cref="Attributes.IgnorePropertyAttribute "/> and <see cref="Attributes.ChinoAttribute"/>
        /// </summary>
        /// <param name="client">the <see cref="RestSharp.RestClient"/> to use for communication</param>
        /// <param name="repositoryId">the <see cref="Repository.Id"/> of the <see cref="Repository"/> to store the generated <see cref="Schema"/></param>
        /// <param name="assembly">The <see cref="System.Type.Assembly"/> that contains the classes</param>
        /// <param name="useClassNameAsDescription">Indicated whether the ClassName should be used as primary source, or the given description in the <see cref="Attributes.ChinoAttribute"/></param>
        public static void CreateSchemaForAssembly(RestClient client, string repositoryId, Assembly assembly, bool useClassNameAsDescription = false)
        {
            var typeList = assembly.GetTypes(); // .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
            var idx = 1;
            var count = typeList.Count();
            foreach (var t in typeList)
            {
                var cAttrib = t.GetCustomAttribute<Attributes.ChinoAttribute>();
                if (cAttrib != null && cAttrib.Generate)
                {
                    var description = string.IsNullOrEmpty(cAttrib.Description) ? t.FullName : cAttrib.Description;
                    if (useClassNameAsDescription)
                    {
                        description = t.Name;
                    }

                    var schemaResponse = CreateSchemaForType(client, repositoryId, description, t);
                    OnSchemaCreated?.Invoke(new OnSchemaCreatedEventArgs
                    {
                        Index = idx,
                        Schema = schemaResponse,
                        Total = count
                    });

                    idx++;
                }
            }
        }

        /// <summary>
        /// Creates a Schema for an <see cref="System.Type"/>.
        /// </summary>
        /// <param name="client">the <see cref="RestSharp.RestClient"/> to use for communication</param>
        /// <param name="repositoryId">the <see cref="Repository.Id"/> of the <see cref="Repository"/> to store the generated <see cref="Schema"/></param>
        /// <param name="classType">the <see cref="System.Type"/> to create the schema for</param>
        /// <returns>the new generated <see cref="Schema"/></returns>
        public static Schema CreateSchemaForType(RestClient client, string repositoryId, Type classType)
        {
            return CreateSchemaForType(client, repositoryId, classType.Name, classType);
        }

        /// <summary>
        /// Creates a Schema for a <see cref="System.Type"/>.
        /// </summary>
        /// <param name="client">the <see cref="RestSharp.RestClient"/> to use for communication</param>
        /// <param name="repositoryId">the <see cref="Repository.Id"/> of the <see cref="Repository"/> to store the generated <see cref="Schema"/></param>
        /// <param name="description">the <see cref="Schema.Description"/> to use on the new created schema</param>
        /// <param name="classType">the <see cref="System.Type"/> to create the schema for</param>
        /// <returns>the new generated <see cref="Schema"/></returns>
        public static Schema CreateSchemaForType(RestClient client, string repositoryId, string description, Type classType)
        {
            if (string.IsNullOrEmpty(description))
            {
                description = classType.Name;
            }

            var schema = GetSchemaForType(description, classType);

            schema.Description = description;
            schema.RepositoryId = repositoryId;
            schema.IsActive = true;

            return Schema.Create(client, repositoryId, schema);
        }

        /// <summary>
        /// Generates a <see cref="Schema"/> for the given <see cref="System.Type"/>.
        /// </summary>
        /// <param name="description">the <see cref="Schema.Description"/> to use on the new Schema</param>
        /// <param name="classType">the <see cref="System.Type"/> to create the schema for</param>
        /// <returns>a schema definition for the given class</returns>
        public static Schema GetSchemaForType(string description, Type classType)
        {
            var fields = new List<SchemaField>();
            var typeSchema = new Schema();

            foreach (var property in classType.GetProperties().Where(oobj => !oobj.IsSpecialName && oobj.CanRead && oobj.CanWrite).ToList())
            {
                var addField = true;
                // only use properties that are sealed, should lead to strings, ints, bools, datetimes
                // and limiting to canWrite removes the Get-only properties.
                var ignoreAttrib = property.GetCustomAttribute<Attributes.IgnorePropertyAttribute>();
                if (ignoreAttrib == null)
                {
                    bool isSealed = property.PropertyType.IsSealed;
                    if (isSealed)
                    {                        
                        var type = Utils.CLRTypeToFieldType(property.PropertyType);
                        SchemaField f = new SchemaField { Name = property.Name, Type = type };

                        var fieldTypeAttrib = property.GetCustomAttribute<Attributes.ChinoAttribute>();
                        if (fieldTypeAttrib != null)
                        {                            
                            if (fieldTypeAttrib.OverrideAutomaticFieldType)
                            {
                                f.Type = fieldTypeAttrib.FieldType;
                            }

                            if (fieldTypeAttrib.Indexed)
                            {
                                f.IsIndexed = true;
                            }

                            if (fieldTypeAttrib.Generate == false)
                            {
                                addField = false;
                            }

                            if (!string.IsNullOrEmpty(fieldTypeAttrib.Name))
                            {
                                f.Name = fieldTypeAttrib.Name;
                            }
                        }

                        if (addField) // may be overridden by Generate = false
                        {
                            fields.Add(f);
                        }
                    }
                }
            }

            typeSchema.Structure.Fields = fields;

            return typeSchema;
        }

        /// <summary>
        /// Deletes a <see cref="Schema"/> from the server
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/> to use for communication</param>
        /// <param name="schemaId">The Id of the Schema to delete</param>
        /// <param name="disableOnly">Indicates whether the Schema should only be deactivated rather than deleted</param>
        public static void Delete(RestClient client, string schemaId, bool disableOnly)
        {
            var uri = string.Format("/schemas/{0}", schemaId); //  {?force}{&all_content}")
            var request = new RestRequest(uri, Method.DELETE);

            var force = !disableOnly;
            if (force)
            {
                request.AddQueryParameter("force", "true");
                request.AddQueryParameter("all_content", "true");
            }

            Rest.Execute<BasicResponse>(client, request);
        }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [JsonProperty(PropertyName = "schema_id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the RepositoryId
        /// </summary>
        [JsonProperty(PropertyName = "repository_id")]
        public string RepositoryId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Schema is active
        /// </summary>
        [JsonProperty(PropertyName = "is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date the Schema was created
        /// </summary>
        [JsonProperty(PropertyName = "insert_date")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the Schema was updated
        /// </summary>
        [JsonProperty(PropertyName = "last_update")]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Gets or sets the Structure
        /// </summary>
        [JsonProperty(PropertyName = "structure")]
        public SchemaFieldStructure Structure { get; set; }

        /// <summary>
        /// Gets the Fields
        /// </summary>
        public IEnumerable<SchemaField> Fields
        {
            get { return Structure.Fields; }
        }
    }
}
