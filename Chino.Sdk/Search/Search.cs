//-----------------------------------------------------------------------
// <copyright file="Search.cs" company="Chino.IO and NursIt.Institute" />
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
    using RestSharp;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class for performing a search on the CHINO.IO api
    /// </summary>
    public class Search
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Search"/> class.
        /// </summary>
        /// <param name="api">the SDK <see cref="Api"/> to use for retrieving the search data</param>
        public Search(Api api) : this(api.Client, SearchResultType.FULL_CONTENT)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Search"/> class.
        /// </summary>
        /// <param name="client">the <see cref="RestSharp.RestClient"/> to use for communication</param>
        public Search(RestClient client) : this(client, SearchResultType.FULL_CONTENT)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Search"/> class.
        /// </summary>
        /// <param name="client">the <see cref="RestSharp.RestClient"/> to use for communication</param>
        /// <param name="resultType">specifies which kind <see cref="SearchResultType"/> should be returned</param>
        public Search(RestClient client, SearchResultType resultType)
        {
            this.client = client;
            ResultType = resultType;
            Filters = new List<SearchFilter>();
            Sortings = new List<SearchSort>();
        }

        /// <summary>
        /// the <see cref="SearchFilterType"/> the search is performed for
        /// </summary>
        public SearchFilterType FilterType { get; set; }

        /// <summary>
        /// the <see cref="RestSharp.RestClient"/> to use for communication
        /// </summary>
        private RestClient client { get; set; }

        /// <summary>
        /// specifies which kind <see cref="SearchResultType"/> should be returned
        /// </summary>
        public SearchResultType ResultType { get; set; }

        /// <summary>
        /// specifies a list of <see cref="SearchFilter"/> that should be applied to the search
        /// </summary>
        public List<SearchFilter> Filters { get; set; }

        /// <summary>
        /// specifies a list of <see cref="SearchSort"/> that should be applied to the search
        /// </summary>
        public List<SearchSort> Sortings { get; set; }

        /// <summary>
        /// performs a search with the current settings on the api server and returns the result with a list of converterd items
        /// </summary>
        /// <typeparam name="T">the class type to convert the resulting documents into</typeparam>
        /// <param name="schemaId">the Id of the Schema</param>
        /// <param name="offset">from which starting record should the result be returned</param>
        /// <param name="limit">indicates how many records should be returned</param>
        /// <returns>a new instance of the <see cref="SearchObjectData"/> class</returns>
        public SearchObjectData SearchDocumentsSpecialized<T>(string schemaId, int offset, int limit)
        {
            var searchResult = SearchDocuments(schemaId, offset, limit);
            var result = new SearchObjectData
            {
                Count = searchResult.Count,
                Limit = searchResult.Limit,
                Start = searchResult.Start,
                Total = searchResult.Total
            };

            var resultList = new List<T>();
            foreach (var document in searchResult.Documents)
            {
                resultList.Add(document.Cast<T>());
            }

            result.Items = resultList;

            return result;
        }

        /// <summary>
        /// performs a search with the current settings on the api server
        /// </summary>
        /// <param name="schemaId">the Id of the Schema</param>
        /// <param name="offset">from which starting record should the result be returned</param>
        /// <param name="limit">indicates how many records should be returned</param>
        /// <returns>a new instance of the <see cref="SearchData"/> class</returns>
        public SearchData SearchDocuments(string schemaId, int offset, int limit)
        {
            var body = new
            {
                result_type = ResultType.ToString(),
                filter_type = FilterType.ToString(),
                sort = Sortings,
                filter = Filters
            };

            var jSon = Utils.SerializeObject(body);
            var uriString = string.Format("/search/documents/{0}", schemaId);
            var searchUri = new Uri(uriString, UriKind.Relative);

            RestRequest request = new RestRequest(searchUri, Method.POST);
            request.AddQueryParameter("offset", offset.ToString());
            request.AddQueryParameter("limit", limit.ToString());
            var result = Rest.Execute<SearchResult>(client, request, body);

            return result.Data;
        }

        /// <summary>
        /// performs a search with the current settings on the api server
        /// </summary>
        /// <param name="schemaId">the Id of the Schema</param>
        /// <returns>a new instance of the <see cref="SearchData"/> class</returns>
        public SearchData SearchDocuments(string schemaId)
        {
            return SearchDocuments(schemaId, 0, 50);
        }

        /// <summary>
        /// performs a search with the current settings on the api server and returns the result with a list of converterd items
        /// </summary>
        /// <typeparam name="T">the class type to convert the resulting documents into</typeparam>
        /// <param name="schemaId">the Id of the Schema</param>
        /// <param name="offset">from which starting record should the result be returned</param>
        /// <param name="limit">indicates how many records should be returned</param>
        /// <returns>a new instance of the <see cref="SearchObjectData"/> class</returns>
        public SearchObjectData SearchDocumentsSpecialized<T>(string schemaId)
        {
            return SearchDocumentsSpecialized<T>(schemaId, 0, 50);
        }
    }
}
