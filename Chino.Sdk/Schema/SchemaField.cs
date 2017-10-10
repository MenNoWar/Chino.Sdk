//-----------------------------------------------------------------------
// <copyright file="SchemaField.cs" company="Chino.IO and NursIt.Institute" />
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
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;

    /// <summary>
    /// Defines the <see cref="SchemaField" />
    /// </summary>
    public class SchemaField
    {
        /// <summary>
        /// Defines the _type
        /// </summary>
        internal SchemaFieldType _type = SchemaFieldType.@string;

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Type
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SchemaFieldType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsIndexed
        /// </summary>
        [JsonProperty(PropertyName = "indexed")]
        public bool IsIndexed { get; set; }

        /// <summary>
        /// Gets or sets the ClrType
        /// </summary>
        [JsonIgnoreAttribute]
        public Type ClrType
        {
            get
            {
                return Utils.FieldTypeToCLRType(_type);
            }

            set
            {
                _type = Utils.CLRTypeToFieldType(value);
            }
        }
    }
}
