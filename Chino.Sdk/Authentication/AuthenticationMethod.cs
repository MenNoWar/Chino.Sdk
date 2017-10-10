//-----------------------------------------------------------------------
// <copyright file="AuthenticationMethod.cs" company="Chino.IO and NursIt.Institute" />
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
    using System.Text;

    /// <summary>
    /// Defines the <see cref="AuthenticationMethod" />
    /// </summary>
    public static class AuthenticationMethod
    {
        /// <summary>
        /// The Token
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="refreshToken">The <see cref="string"/></param>
        /// <param name="appId">The <see cref="string"/></param>
        /// <param name="appSecret">The <see cref="string"/></param>
        /// <returns>The <see cref="TokenData"/></returns>
        public static TokenData Token(RestClient client, string refreshToken, string appId, string appSecret)
        {
            var grantType = "refresh_token";
            var request = new RestRequest("/auth/token", Method.POST);
            var tot = appId + ":" + appSecret;
            var bytesToEncode = Encoding.UTF8.GetBytes(tot);
            var encodedText = Convert.ToBase64String(bytesToEncode);
            client.RemoveDefaultParameter("Authorization");
            client.AddDefaultHeader("Authorization", "Basic " + encodedText);
            request.AddHeader("Content-Type", "multipart/form-data");
            request.AddParameter("grant_type", grantType);
            request.AddParameter("refresh_token", refreshToken);
            request.AddParameter("client_id", appId);
            request.AddParameter("client_secret", appSecret);

            var result = Rest.Execute<TokenResponse>(client, request);
            return result.Data;
        }

        /// <summary>
        /// The Login
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="username">The <see cref="string"/></param>
        /// <param name="password">The <see cref="string"/></param>
        /// <param name="appId">The <see cref="string"/></param>
        /// <param name="appSecret">The <see cref="string"/></param>
        /// <returns>The <see cref="TokenData"/></returns>
        public static TokenData Login(RestClient client, string username, string password, string appId, string appSecret)
        {
            var grantType = "password";
            var request = new RestRequest("/auth/token", Method.POST);
            var tot = appId + ":" + appSecret;
            var bytesToEncode = Encoding.UTF8.GetBytes(tot);
            var encodedText = Convert.ToBase64String(bytesToEncode);
            client.RemoveDefaultParameter("Authorization");
            client.AddDefaultHeader("Authorization", "Basic " + encodedText);
            request.AddHeader("Content-Type", "multipart/form-data");
            request.AddParameter("grant_type", grantType);
            request.AddParameter("username", username);
            request.AddParameter("password", password);

            var result = Rest.Execute<TokenResponse>(client, request);

            return result.Data;
        }

        /// <summary>
        /// The Logout
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="bearerToken">The <see cref="string"/></param>
        /// <param name="appId">The <see cref="string"/></param>
        /// <param name="appSecret">The <see cref="string"/></param>
        public static void Logout(RestClient client, string bearerToken, string appId, string appSecret)
        {
            var request = new RestRequest("/auth/revoke_token/", Method.POST);
            request.AddHeader("Content-Type", "multipart/form-data");
            request.AddParameter("token", bearerToken);
            request.AddParameter("client_id", appId);
            request.AddParameter("client_secret", appSecret);
            Rest.Execute<BasicResponse>(client, request);
        }

        /// <summary>
        /// The Status
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="bearerToken">The <see cref="string"/></param>
        /// <returns>The <see cref="User"/></returns>
        public static User Status(RestClient client, string bearerToken)
        {
            var request = new RestRequest("/users/me", Method.GET);
            client.RemoveDefaultParameter("Authorization");
            client.AddDefaultHeader("Authorization", "Bearer " + bearerToken);
            var result = Rest.Execute<StatusResponse>(client, request);

            return result.Data.User;
        }
    }
}
