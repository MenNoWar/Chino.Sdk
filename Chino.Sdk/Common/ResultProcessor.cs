//-----------------------------------------------------------------------
// <copyright file="ResultProcessor.cs" company="Chino.IO and NursIt.Institute" />
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
    using Newtonsoft.Json;
    using RestSharp;

    /// <summary>
    /// Defines the <see cref="Rest" />
    /// </summary>
    public static class Rest
    {
        /// <summary>
        /// The Execute
        /// </summary>
        /// <typeparam name="T">the Type to use</typeparam>
        /// <param name="client">The <see cref="IRestClient"/></param>
        /// <param name="request">The <see cref="IRestRequest"/></param>
        /// <param name="body">The <see cref="object"/></param>
        /// <returns>a new object with type T</returns>
        public static T Execute<T>(IRestClient client, IRestRequest request, object body)
        {
            Utils.SetJsonBody(request, body);
            return Execute<T>(client, request);
        }

        /// <summary>
        /// The Execute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client">The <see cref="IRestClient"/></param>
        /// <param name="request">The <see cref="IRestRequest"/></param>
        /// <returns>The <see cref="T"/></returns>
        public static T Execute<T>(IRestClient client, IRestRequest request)
        {
            var response = client.Execute(request);
            if (response.ErrorException != null)
            {
                throw new ChinoApiException(response.ErrorMessage);
            }

            var obj = JsonConvert.DeserializeObject<T>(response.Content);

            if (obj is BasicResponse)
            {
                var br = obj as BasicResponse;
                switch (br.StatusCode)
                {
                    case 400:
                    case 401:
                    case 402:
                    case 403:
                        throw new ChinoUnauthorizedException(br.StatusMessage);
                    case 200:
                    default:
                        if (br.StatusCode != 200)
                        {
                            throw new ChinoApiException(br.StatusMessage);
                        }
                        else
                        {
                            return obj;
                        }
                };
            }
            else
            {
                return obj;
            }
        }
    }
}
