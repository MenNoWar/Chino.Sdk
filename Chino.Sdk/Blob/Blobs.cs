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

        //public Blob CommitUpload(string uploadId)
        //{
        //    return Blob.CommitUpload(client, uploadId);
        //}

        //public BlobDefinition UploadChunk(string upload_id, byte[] chunkData, int offset, int length)
        //{
        //    return Blob.UploadChunk(client, upload_id, chunkData, offset, length);
        //}

        //public BlobDefinition InitUpload(string documentId, string field, string fileName)
        //{
        //    return Blob.InitUpload(client, documentId, field, fileName);
        //}
        /// <summary>
        /// The Upload
        /// </summary>
        /// <param name="uploadFilePath">The <see cref="string"/></param>
        /// <param name="documentId">The <see cref="string"/></param>
        /// <param name="field">The <see cref="string"/></param>
        /// <param name="fileName">The <see cref="string"/></param>
        /// <returns>The <see cref="Blob"/></returns>
        public Blob Upload(string uploadFilePath, string documentId, string field, string fileName)
        {
            return Blob.Upload(client, uploadFilePath, documentId, field, fileName);
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
