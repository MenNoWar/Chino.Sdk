//-----------------------------------------------------------------------
// <copyright file="CreateBlobUploadRequest.cs" company="Chino.IO and NursIt.Institute" />
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
    /// Defines the <see cref="CreateBlobUploadRequest" />
    /// </summary>
    public class CreateBlobUploadRequest
    {
        /// <summary>
        /// Gets or sets the DocumentId
        /// </summary>
        [JsonProperty(PropertyName = "document_id")]
        public string DocumentId { get; set; }

        /// <summary>
        /// Gets or sets the Field
        /// </summary>
        [JsonProperty(PropertyName = "field")]
        public string Field { get; set; }

        /// <summary>
        /// Gets or sets the FileName
        /// </summary>
        [JsonProperty(PropertyName = "file_name")]
        public string FileName { get; set; }
    }
}
