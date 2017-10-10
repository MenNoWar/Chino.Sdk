//-----------------------------------------------------------------------
// <copyright file="ApplicationDefinition.cs" company="Chino.IO and NursIt.Institute" />
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

    /// <summary>
    /// Contains the definition of a chino application
    /// </summary>
    public class ApplicationDefinition
    {
        /// <summary>
        /// Gets or sets the Id of the application
        /// </summary>
        [JsonProperty(PropertyName = "app_id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name/description of the application
        /// </summary>
        [JsonProperty(PropertyName = "app_name")]
        public string Name { get; set; }
    }
}
