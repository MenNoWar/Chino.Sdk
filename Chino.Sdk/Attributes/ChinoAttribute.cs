//-----------------------------------------------------------------------
// <copyright file="chinoattribute.cs" company="Chino.IO and NursIt.Institute" />
// Copyright (c) Chino.IO and NursIt.Institute. All rights reserved.
// </copyright>
// <author>P. Kaatz, Kaatz@nursit.institute</author>
// <warranty>
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </warranty>
//-----------------------------------------------------------------------

namespace Chino.Sdk.Attributes
{
    using System;

    /// <summary>
    /// Attribute class to use when specifying a class for automatic schema creation 
    /// </summary>
    public class ChinoAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChinoAttribute"/> class
        /// </summary>
        public ChinoAttribute()
        {
            Generate = true;
        }

        /// <summary>
        /// the schema description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to generate or ignore a property
        /// </summary>
        public bool Generate { get; set; }
    }
}
