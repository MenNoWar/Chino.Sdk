//-----------------------------------------------------------------------
// <copyright file="SchemaList.cs" company="Chino.IO and NursIt.Institute" />
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
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="SchemaList" />
    /// </summary>
    public class SchemaList : BasicListElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaList"/> class.
        /// </summary>
        public SchemaList()
        {
        }

        /// <summary>
        /// Gets or sets the Schemas
        /// </summary>
        [JsonProperty(PropertyName = "schemas")]
        public IEnumerable<Schema> Schemas { get; set; }
    }
}
