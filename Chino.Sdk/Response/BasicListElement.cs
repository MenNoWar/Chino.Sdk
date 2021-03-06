﻿//-----------------------------------------------------------------------
// <copyright file="BasicListElement.cs" company="Chino.IO and NursIt.Institute" />
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

    /// <summary>
    /// a basic description for a standard list response from the api server
    /// </summary>
    public class BasicListElement
    {
        /// <summary>
        /// Get a value indicating the the amount of records returned
        /// </summary>
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }

        /// <summary>
        /// Gets a value indicating how many records are aviable on the server
        /// </summary>
        [JsonProperty(PropertyName = "total_count")]
        public int Total { get; set; }

        /// <summary>
        /// Gets a value indicating how many records are max returned in this request (aka PageSize)
        /// </summary>
        [JsonProperty(PropertyName = "limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Gets a value where the resulting list startet
        /// </summary>
        [JsonProperty(PropertyName = "offset")]
        public int Start { get; set; }
    }
}
