﻿//-----------------------------------------------------------------------
// <copyright file="BlobDefinitionData.cs" company="Chino.IO and NursIt.Institute" />
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

    /// <summary>
    /// Defines the <see cref="BlobDefinitionData" />
    /// </summary>
    public class BlobDefinitionData
    {
        /// <summary>
        /// Gets or sets the Blob
        /// </summary>
        [JsonProperty(PropertyName = "blob")]
        public BlobDefinition Blob { get; set; }
    }
}
