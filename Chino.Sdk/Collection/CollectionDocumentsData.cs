//-----------------------------------------------------------------------
// <copyright file="CollectionDocumentsData.cs" company="Chino.IO and NursIt.Institute" />
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
    /// Defines the <see cref="CollectionDocumentsData" />
    /// </summary>
    public class CollectionDocumentsData : BasicListElement
    {
        /// <summary>
        /// Gets or sets the Documents
        /// </summary>
        [JsonProperty(PropertyName = "documents")]
        public IEnumerable<Document> Documents { get; set; }
    }
}
