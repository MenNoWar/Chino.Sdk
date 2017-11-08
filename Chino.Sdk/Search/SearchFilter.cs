//-----------------------------------------------------------------------
// <copyright file="SearchFilter.cs" company="Chino.IO and NursIt.Institute" />
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
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Defines the <see cref="SearchFilter" />
    /// </summary>
    public class SearchFilter
    {

        public override string ToString()
        {
            return string.Format("{0} {1} \"{2}\"", Field, Type, Value);
        }
        /// <summary>
        /// the field which should be filtered
        /// </summary>
        [JsonProperty(PropertyName = "field")]
        public string Field { get; set; }

        /// <summary>
        /// how the comparison should be performed
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type")]
        public SearchQueryCompare Type { get; set; }

        /// <summary>
        /// the value to perform the compare with
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public object Value { get; set; }
    }
}
