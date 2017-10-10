//-----------------------------------------------------------------------
// <copyright file="CommitBlobUploadResponseContent.cs" company="Chino.IO and NursIt.Institute" />
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
    /// Defines the <see cref="CommitBlobUploadResponseContent" />
    /// </summary>
    public class CommitBlobUploadResponseContent
    {
        /// <summary>
        /// Gets or sets the Bytes
        /// </summary>
        [JsonProperty(PropertyName = "bytes")]
        public int Bytes { get; set; }

        /// <summary>
        /// Gets or sets the BlobId
        /// </summary>
        [JsonProperty(PropertyName = "blob_id")]
        public string BlobId { get; set; }

        /// <summary>
        /// Gets or sets the DocumentId
        /// </summary>
        [JsonProperty(PropertyName = "document_id")]
        public string DocumentId { get; set; }

        /// <summary>
        /// Gets or sets the Sha1
        /// </summary>
        [JsonProperty(PropertyName = "sha1")]
        public string Sha1 { get; set; }

        /// <summary>
        /// Gets or sets the Md5
        /// </summary>
        [JsonProperty(PropertyName = "md5")]
        public string Md5 { get; set; }
    }
}
