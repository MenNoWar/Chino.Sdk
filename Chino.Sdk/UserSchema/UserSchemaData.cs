﻿//-----------------------------------------------------------------------
// <copyright file="UserSchemaData.cs" company="Chino.IO and NursIt.Institute" />
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
    /// Defines the <see cref="UserSchemaData" />
    /// </summary>
    public class UserSchemaData
    {
        /// <summary>
        /// Gets or sets the Schema
        /// </summary>
        [JsonProperty(PropertyName = "user_schema")]
        public UserSchema Schema { get; set; }
    }
}
