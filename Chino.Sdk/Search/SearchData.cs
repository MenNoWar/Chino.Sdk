//-----------------------------------------------------------------------
// <copyright file="SearchData.cs" company="Chino.IO and NursIt.Institute" />
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
    /// HelperClass for the data result in <see cref="SearchResult"/>. See Api docu for details
    /// </summary>
    public class SearchData : BasicListElement
    {
        /// <summary>
        /// Gets or sets the Documents
        /// </summary>
        [JsonProperty(PropertyName = "documents")]
        public List<Document> Documents { get; set; }
    }
}
