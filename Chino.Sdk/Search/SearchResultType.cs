//-----------------------------------------------------------------------
// <copyright file="SearchResultType.cs" company="Chino.IO and NursIt.Institute" />
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
    /// enumeration of aviable result types for a <see cref="SearchResult"/>
    /// </summary>
    public enum SearchResultType
    {
        /// <summary>
        /// for full docs
        /// </summary>
        FULL_CONTENT,
        /// <summary>
        /// for headers only
        /// </summary>
        NO_CONTENT,
        /// <summary>
        /// for list of ids
        /// </summary>
        ONLY_ID,
        /// <summary>
        /// for the number of records only.
        /// </summary>
        COUNT
    }
}
