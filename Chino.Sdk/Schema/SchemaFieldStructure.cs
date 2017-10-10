//-----------------------------------------------------------------------
// <copyright file="SchemaFieldStructure.cs" company="Chino.IO and NursIt.Institute" />
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
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="SchemaFieldStructure" />
    /// </summary>
    public class SchemaFieldStructure
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaFieldStructure"/> class.
        /// </summary>
        public SchemaFieldStructure()
        {
            Fields = new List<SchemaField>();
        }

        /// <summary>
        /// Gets or sets the Fields
        /// </summary>
        [JsonProperty(PropertyName = "fields")]
        public List<SchemaField> Fields { get; set; }
    }
}
