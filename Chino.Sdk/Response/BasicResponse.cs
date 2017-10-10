//-----------------------------------------------------------------------
// <copyright file="BasicResponse.cs" company="Chino.IO and NursIt.Institute" />
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
    /// a basic description for a standard response from the api server
    /// </summary>
    public class BasicResponse
    {
        /// <summary>
        /// Get the text status returned from the api server
        /// </summary>
        [JsonProperty(PropertyName = "result")]
        public string StatusText { get; internal set; }

        /// <summary>
        /// Gets the api http result code return
        /// </summary>
        [JsonProperty(PropertyName = "result_code")]
        public int StatusCode { get; internal set; }

        /// <summary>
        /// Gets the text message returned from the api server
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string StatusMessage { get; internal set; }
    }
}
