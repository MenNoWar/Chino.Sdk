//-----------------------------------------------------------------------
// <copyright file="Authentication.cs" company="Chino.IO and NursIt.Institute" />
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
    using RestSharp;

    /// <summary>
    /// Class for covering Authentication issues
    /// </summary>
    public class Authentication
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Authentication"/> class
        /// </summary>
        /// <param name="client">the <see cref="RestSharp.RestClient"/> used for communication</param>
        public Authentication(RestClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// Defines the client
        /// </summary>
        private RestClient client = null;

        /// <summary>
        /// Refreshes an access-token at the login server
        /// </summary>
        /// <param name="refreshToken">the refresh token returned after logging in</param>
        /// <param name="appId">the id of the application the login occured</param>
        /// <param name="appSecret">the <see cref="ChinoApplication.Secret"/> to use</param>
        /// <returns>a new instance of the <see cref="TokenData"/> class</returns>
        /// <exception cref="ChinoApiException">thrown by the api server, when recieving incorrect request data</exception>
        public TokenData Token(string refreshToken, string appId, string appSecret)
        {
            return AuthenticationMethod.Token(client, refreshToken, appId, appSecret);
        }

        /// <summary>
        /// Tries to authenticate the user against the api server
        /// </summary>
        /// <param name="userName">the username to login with</param>
        /// <param name="password">the password for the login</param>
        /// <param name="appId">the id of the application containing the user</param>
        /// <param name="appSecret">the <see cref="ChinoApplication.Secret"/> to use</param>
        /// <returns>a new instance of the <see cref="TokenData" /> class</returns>
        /// <exception cref="ChinoApiException">thrown by the api server, when login failed</exception>
        public TokenData Login(string userName, string password, string appId, string appSecret)
        {
            return AuthenticationMethod.Login(client, userName, password, appId, appSecret);
        }

        /// <summary>
        /// Logs a user out from the api server
        /// </summary>
        /// <param name="bearerToken">the current access token</param>
        /// <param name="appId">the id of the application the user logged in to</param>
        /// <param name="appSecret">the <see cref="ChinoApplication.Secret"/> to use</param>
        /// <exception cref="ChinoApiException">thrown by the api server, when logout fails</exception>
        public void Logout(string bearerToken, string appId, string appSecret)
        {
            AuthenticationMethod.Logout(client, bearerToken, appId, appSecret);
        }

        /// <summary>
        /// Gets the current status of the user, identified by the bearer token
        /// </summary>
        /// <param name="bearerToken">the bearer/access token of the user</param>
        /// <returns>a new instance of the <see cref="User"/> class</returns>
        /// <exception cref="ChinoApiException">thrown by the api server, when recieving incorrect request data</exception>
        public User Status(string bearerToken)
        {
            return AuthenticationMethod.Status(client, bearerToken);
        }
    }
}
