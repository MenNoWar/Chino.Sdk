//-----------------------------------------------------------------------
// <copyright file="SearchQueryCompare.cs" company="Chino.IO and NursIt.Institute" />
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
    /// the possible comparisations for a <see cref="SearchFilter"/>
    /// </summary>
    public enum SearchQueryCompare
    {
        /// <summary>
        /// equal, if the value is the same as the one specified.
        /// </summary>
        eq,
        /// <summary>
        /// less than
        /// </summary>
        lt,
        /// <summary>
        /// less than or equal
        /// </summary>
        lte,
        /// <summary>
        /// greater than
        /// </summary>
        gt,
        /// <summary>
        /// greater than or equal
        /// </summary>
        gte,
        /// <summary>
        /// only for boolean
        /// </summary>
        @is,
        /// <summary>
        /// not equal
        /// </summary>
        ne
    }
}
