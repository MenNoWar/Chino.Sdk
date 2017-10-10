//-----------------------------------------------------------------------
// <copyright file="SearchObjectData.cs" company="Chino.IO and NursIt.Institute" />
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
    using Chino.Sdk.Response;

    /// <summary>
    /// Defines the <see cref="SearchObjectData" />
    /// </summary>
    public class SearchObjectData : BasicListElement
    {
        /// <summary>
        /// a list containing the converted items of a search result. Used in <see cref="Search.SearchDocumentsSpecialized{T}(string, int, int)"/>.
        /// </summary>
        public System.Collections.IEnumerable Items { get; set; }
    }
}
