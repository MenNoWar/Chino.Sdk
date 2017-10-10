//-----------------------------------------------------------------------
// <copyright file="CreateApplicationRequest.cs" company="Chino.IO and NursIt.Institute" />
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
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;    

    /// <summary>
    /// Defines the <see cref="CreateApplicationRequest" />
    /// </summary>
    public class CreateApplicationRequest
    {
        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the GrantType
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "grant_type")]
        public ApplicationGrantType GrantType { get; set; }

        /// <summary>
        /// Gets or sets the RedirectUrl
        /// </summary>
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; set; }
    }
}
