//-----------------------------------------------------------------------
// <copyright file="chinoapiexception.cs" company="Chino.IO and NursIt.Institute" />
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

    /// <summary>
    /// an exception type that is thrown whenever an exception in the api or the communication occures
    /// </summary>
    [SerializableAttribute]
    public class ChinoApiException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChinoApiException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="System.Runtime.Serialization.SerializationInfo"/></param>
        /// <param name="context">The <see cref="System.Runtime.Serialization.StreamingContext"/></param>
        public ChinoApiException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChinoApiException"/> class.
        /// </summary>
        public ChinoApiException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChinoApiException"/> class.
        /// </summary>
        /// <param name="message">The <see cref="string"/></param>
        public ChinoApiException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChinoApiException"/> class.
        /// </summary>
        /// <param name="message">The <see cref="string"/></param>
        /// <param name="innerException">The <see cref="Exception"/></param>
        public ChinoApiException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class ChinoUnauthorizedException : ChinoApiException
    {
        public ChinoUnauthorizedException() : base() { }
        public ChinoUnauthorizedException(string message) : base(message) { }

    }
}
