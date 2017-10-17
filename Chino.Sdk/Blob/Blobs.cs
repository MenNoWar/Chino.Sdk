//-----------------------------------------------------------------------
// <copyright file="Blobs.cs" company="Chino.IO and NursIt.Institute" />
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
    using RestSharp;

    /// <summary>
    /// Defines the <see cref="Blobs" />
    /// </summary>
    public class Blobs
    {
        /// <summary>
        /// Defines the client
        /// </summary>
        private RestClient client = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Blobs"/> class.
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        public Blobs(RestClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// Upload a document to the server
        /// </summary>
        /// <param name="uploadFilePath">The <see cref="string"/></param>
        /// <param name="documentId">The <see cref="string"/></param>
        /// <param name="field">The <see cref="string"/></param>
        /// <param name="fileName">The <see cref="string"/></param>
        /// <returns>a new instance of the <see cref="Blob"/></returns>
        public Blob Upload(string uploadFilePath, string documentId, string field, string fileName)
        {
            return Blob.Upload(client, uploadFilePath, documentId, field, fileName);
        }

        /// <summary>
        /// Upload a document to the server
        /// </summary>
        /// <param name="data">The byte array to upload to the server</param>
        /// <param name="documentId">The <see cref="string"/></param>
        /// <param name="field">The <see cref="string"/></param>
        /// <returns>a new instance of the <see cref="Blob"/></returns>
        public Blob Upload(byte[] data, string documentId, string field)
        {
            return Blob.Upload(client, data, documentId, field);
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="blobId">The <see cref="string"/></param>
        public void Delete(string blobId)
        {
            Blob.Delete(client, blobId);
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="blobId">The <see cref="string"/></param>
        /// <returns>The <see cref="Blob"/></returns>
        public Blob Get(string blobId)
        {
            return Blob.Get(client, blobId);
        }
    }
}
