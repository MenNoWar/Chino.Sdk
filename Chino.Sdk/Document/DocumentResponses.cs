//-----------------------------------------------------------------------
// <copyright file="DocumentResponses.cs" company="Chino.IO and NursIt.Institute" />
// Copyright (c) Chino.IO and NursIt.Institute. All rights reserved.
// </copyright>
// <author>P. Kaatz, Kaatz@nursit.institute</author>
// <warranty>
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </warranty>
//-----------------------------------------------------------------------

namespace Chino.Sdk.Response
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="DocumentList" />
    /// </summary>
    public class DocumentList : BasicResponse
    {
        /// <summary>
        /// Gets or sets the Data
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public DocumentListDataElement Data { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="DocumentListDataElement" />
    /// </summary>
    public class DocumentListDataElement : BasicListElement
    {
        /// <summary>
        /// Gets or sets the Documents
        /// </summary>
        [JsonProperty(PropertyName = "documents")]
        public IEnumerable<Document> Documents { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="GetDocumentDataResponse" />
    /// </summary>
    public class GetDocumentDataResponse
    {
        /// <summary>
        /// Gets or sets the Document
        /// </summary>
        [JsonProperty(PropertyName = "document")]
        public Document Document { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="GetDocumentResponse" />
    /// </summary>
    public class GetDocumentResponse : BasicResponse
    {
        /// <summary>
        /// Gets or sets the Data
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public GetDocumentDataResponse Data { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="UpdateDocumentResponse" />
    /// </summary>
    public class UpdateDocumentResponse : GetDocumentResponse
    {
    }
}
