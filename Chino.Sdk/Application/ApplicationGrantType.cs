//-----------------------------------------------------------------------
// <copyright file="ApplicationGrantType.cs" company="Chino.IO and NursIt.Institute" />
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
    /// an enumeration of the possible grant types for chino application logins
    /// </summary>
    public enum ApplicationGrantType
    {
        /// <summary>
        /// user requires login and password
        /// </summary>
        password,

        /// <summary>
        /// user uses oauth with redirect url
        /// </summary>
        authorization_code
    }
}
