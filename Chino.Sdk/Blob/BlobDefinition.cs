//-----------------------------------------------------------------------
// <copyright file="BlobDefinition.cs" company="Chino.IO and NursIt.Institute" />
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
    using System;

    /// <summary>
    /// Defines the <see cref="BlobDefinition" />
    /// </summary>
    public class BlobDefinition
    {
        /// <summary>
        /// Gets or sets the ExpireDate
        /// </summary>
        [JsonProperty(PropertyName = "expire_date")]
        public DateTime ExpireDate { get; set; }

        /// <summary>
        /// Gets or sets the UploadId
        /// </summary>
        [JsonProperty(PropertyName = "upload_id")]
        public string UploadId { get; set; }

        /// <summary>
        /// Gets or sets the Offset
        /// </summary>
        [JsonProperty(PropertyName = "offset")]
        public int Offset { get; set; }
    }
}
