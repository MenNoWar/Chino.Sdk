//-----------------------------------------------------------------------
// <copyright file="ApplicationsList.cs" company="Chino.IO and NursIt.Institute" />
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
    using System.Collections.Generic;
    using Chino.Sdk.Response;
    using Newtonsoft.Json;    

    /// <summary>
    /// a list of registered chino applications
    /// </summary>
    public class ApplicationList : BasicListElement
    {
        /// <summary>
        /// Gets or sets the returned list of applications
        /// </summary>
        [JsonProperty(PropertyName = "applications")]
        public IEnumerable<ApplicationDefinition> Applications { get; set; }
    }
}
