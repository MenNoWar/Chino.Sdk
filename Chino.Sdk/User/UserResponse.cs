//-----------------------------------------------------------------------
// <copyright file="UserResponse.cs" company="Chino.IO and NursIt.Institute" />
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

    /// <summary>
    /// Defines the <see cref="UserResponse" />
    /// </summary>
    public class UserResponse : BasicResponse
    {
        /// <summary>
        /// Gets or sets the Data
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public UserData Data { get; set; }
    }
}
