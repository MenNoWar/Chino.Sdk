//-----------------------------------------------------------------------
// <copyright file="SchemaFieldType.cs" company="Chino.IO and NursIt.Institute" />
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
    /// <summary>
    /// Defines the SchemaFieldType
    /// </summary>
    public enum SchemaFieldType
    {
        /// <summary>
        /// Defines the integer
        /// </summary>
        integer,

        /// <summary>
        /// Defines the @float
        /// </summary>
        @float,

        /// <summary>
        /// Defines the @string
        /// </summary>
        @string,

        /// <summary>
        /// Defines the text
        /// </summary>
        text,

        /// <summary>
        /// Defines the boolean
        /// </summary>
        boolean,

        /// <summary>
        /// Defines the date
        /// </summary>
        date,

        /// <summary>
        /// Defines the time
        /// </summary>
        time,

        /// <summary>
        /// Defines the datetime
        /// </summary>
        datetime,

        /// <summary>
        /// Defines the base64
        /// </summary>
        base64,

        /// <summary>
        /// Defines the json
        /// </summary>
        json,

        /// <summary>
        /// Defines the blob
        /// </summary>
        blob
    }
}
