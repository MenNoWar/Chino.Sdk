//-----------------------------------------------------------------------
// <copyright file="Applications.cs" company="Chino.IO and NursIt.Institute" />
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
    /// parent class for Chino Applications
    /// </summary>
    public class Applications
    {
        /// <summary>
        /// Defines the client
        /// </summary>
        private RestClient client = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Applications"/> class
        /// </summary>
        /// <param name="client">the <see cref="RestSharp.RestClient"/> to use for communication</param>
        public Applications(RestClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// Gets specific Application details for a given application id
        /// </summary>
        /// <param name="applicationId">the id of the application to return</param>
        /// <returns>a new instance of the <see cref="ChinoApplication"/> class</returns>
        /// <exception cref="ChinoApiException">thrown by the api server, when recieving incorrect request data</exception>
        public ChinoApplication Read(string applicationId)
        {
            return ChinoApplication.Read(this.client, applicationId);
        }

        /// <summary>
        /// Get a list of the first 100 Chino Applications from the server
        /// </summary>
        /// <returns>a new instance of the <see cref="ApplicationList"/></returns>
        /// <exception cref="ChinoApiException">thrown by the api server, when recieving incorrect request data</exception>
        public ApplicationList List()
        {
            return this.List(0, 100);
        }

        /// <summary>
        /// Gets a list of Chino Applications from the server
        /// </summary>
        /// <param name="start">where to start the list</param>
        /// <param name="limit">amount of records to return</param>
        /// <returns>a new instance of the <see cref="ApplicationList"/></returns>
        /// <exception cref="ChinoApiException">thrown by the api server, when recieving incorrect request data</exception>
        public ApplicationList List(int start, int limit)
        {
            return ChinoApplication.List(this.client, start, limit);
        }

        /// <summary>
        /// Creates a new Chino Application on the api server
        /// </summary>
        /// <param name="name">the name or description of the application</param>
        /// <param name="grantType">the <see cref="ApplicationGrantType"/> to use for user logins</param>
        /// <param name="redirectUrl">the url to return after successful login. Requires <see cref="ApplicationGrantType.authorization_code"/>.</param>
        /// <returns>the newly generated <see cref="ChinoApplication"/></returns>
        /// <exception cref="ChinoApiException">thrown by the api server, when recieving incorrect request data</exception>
        public ChinoApplication Create(string name, ApplicationGrantType grantType, string redirectUrl)
        {
            return ChinoApplication.Create(this.client, name, grantType, redirectUrl);
        }

        /// <summary>
        /// Deletes a Chino Application from the server
        /// </summary>
        /// <param name="id">the id of the application to delete</param>
        /// <exception cref="ChinoApiException">thrown by the api server, when recieving incorrect request data</exception>
        public void Delete(string id)
        {
            ChinoApplication.Delete(this.client, id);
        }

        /// <summary>
        /// Updates the name and <see cref="ApplicationGrantType"/> of an application
        /// </summary>
        /// <param name="id">the id of the application to update</param>
        /// <param name="name">the new name to set</param>
        /// <param name="grantType">the grant type to set for the application</param>
        /// <returns>the updated <see cref="ChinoApplication"/></returns>
        /// <exception cref="ChinoApiException">thrown by the api server, when recieving incorrect request data</exception>
        public ChinoApplication Update(string id, string name, ApplicationGrantType grantType)
        {
            return this.Update(id, name, grantType, string.Empty);
        }

        /// <summary>
        /// Updates the name and <see cref="ApplicationGrantType"/> of an application
        /// </summary>
        /// <param name="id">the id of the application to update</param>
        /// <param name="name">the new name to set</param>
        /// <param name="grantType">the grant type to set for the application</param>
        /// <returns>the updated <see cref="ChinoApplication"/></returns>
        /// <param name="redirectUrl">the url the api server returns after successful login</param>
        /// <exception cref="ChinoApiException">thrown by the api server, when recieving incorrect request data</exception>
        public ChinoApplication Update(string id, string name, ApplicationGrantType grantType, string redirectUrl)
        {
            return ChinoApplication.Update(this.client, id, name, grantType, redirectUrl);
        }
    }
}
