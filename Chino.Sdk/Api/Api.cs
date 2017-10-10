//-----------------------------------------------------------------------
// <copyright file="Api.cs" company="Chino.IO and NursIt.Institute" />
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
    using System.Text;
    using RestSharp;    

    /// <summary>
    /// The master class for all interactions with a Chino api server
    /// </summary>
    public partial class Api
    {
        /// <summary>
        /// Gets the currently used <see cref="RestSharp.RestClient"/>
        /// </summary>
        public RestClient Client
        {
            get { return this.client; }
        }

        /// <summary>
        /// Gets the basic server url the client uses for requests
        /// </summary>
        public string BaseUrl
        {
            get
            {
                return this.baseUrl;
            }
        }

        /// <summary>
        /// Defines the baseUrl
        /// </summary>
        private string baseUrl = string.Empty;

        /// <summary>
        /// Gets or sets the client
        /// </summary>
        private RestClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="Api"/> class.
        /// </summary>
        /// <param name="baseUrl">the Chino server url</param>
        public Api(string baseUrl)
        {
            this.baseUrl = baseUrl;
            this.client = new RestClient(baseUrl);
            CreateClasses();
        }

        /// <summary>
        /// Initializes a new instance of the Api class
        /// </summary>
        /// <param name="baseUrl">the Uhino server url</param>
        /// <param name="token">the access token when OAuth grant type is set to authorization-code</param>
        public Api(string baseUrl, string token) : this(baseUrl)
        {
            this.SetCredentials(token);
        }

        /// <summary>
        /// Initializes a new instance of the Api class
        /// </summary>
        /// <param name="baseUrl">the Uhino server url</param>
        /// <param name="id">the customer Id</param>
        /// <param name="key">the customer Key</param>
        public Api(string baseUrl, string id, string key) : this(baseUrl)
        {
            this.SetCredentials(id, key);
        }

        /// <summary>
        /// Set the credentials using username and password for a user or globally customerId and customerKey for the application. Requires the Authorization set to "password" on Chino.io
        /// </summary>
        /// <param name="id">the username or customerid to login with</param>
        /// <param name="key">the customerkey or user password to login with</param>
        public void SetCredentials(string id, string key)
        {
            // create an encoded string for the authentication
            var tot = id + ":" + key;
            byte[] bytesToEncode = Encoding.UTF8.GetBytes(tot);
            string encodedText = Convert.ToBase64String(bytesToEncode);

            this.SetClientAuthorizationHeader("Basic " + encodedText);
        }

        /// <summary>
        /// Sets the default authorisation to a user. Requires the Authorization set to "authorization-code" on Chino.io
        /// </summary>
        /// <param name="token">the token to set</param>
        public void SetCredentials(string token)
        {
            this.SetClientAuthorizationHeader("Bearer " + token);
        }

        /// <summary>
        /// set a default header that exists in every call with the client
        /// </summary>
        /// <param name="headerValue">the header value to set</param>
        private void SetClientAuthorizationHeader(string headerValue)
        {
            this.client.RemoveDefaultParameter("Authorization");
            this.client.AddDefaultHeader("Authorization", headerValue);
        }
    }
}
