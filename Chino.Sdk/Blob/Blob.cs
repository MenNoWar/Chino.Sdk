//-----------------------------------------------------------------------
// <copyright file="Blob.cs" company="Chino.IO and NursIt.Institute" />
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
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Defines the <see cref="Blob" />
    /// </summary>
    public class Blob
    {
        /// <summary>
        /// Gets or sets the Id of the blob object
        /// </summary>
        [JsonProperty(PropertyName = "blob_id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "bytes")]
        public long ByteSize { get; set; }

        /// <summary>
        /// Gets or sets the Id of the associated <seealso cref="Document"/>
        /// </summary>
        [JsonProperty(PropertyName = "document_id")]
        public string DocumentId { get; set; }

        /// <summary>
        /// Defines the chunkSize
        /// </summary>
        private static int chunkSize = 1048576;// 1024 * 1024;

        /// <summary>
        /// Gets or sets the FileName
        /// </summary>
        [JsonProperty(PropertyName = "file_name")]
        public string FileName { get; set; }

        /* /// <summary>
        /// Gets or sets the Size
        /// </summary>
         [JsonProperty(PropertyName = "size")]
        public long Size { get; set; } */

        /// <summary>
        /// Gets or sets the Sha1
        /// </summary>
        [JsonProperty(PropertyName = "sha1")]
        public string Sha1 { get; set; }

        /// <summary>
        /// Gets or sets the Md5
        /// </summary>
        [JsonProperty(PropertyName = "md5")]
        public string Md5 { get; set; }

        /// <summary>
        /// Gets the blob contents
        /// </summary>
        public byte[] Bytes { get; private set; }        

        /// <summary>
        /// The HashOf
        /// </summary>
        /// <typeparam name="TP"></typeparam>
        /// <param name="bytes">The bytes</param>
        /// <param name="enc">The <see cref="Encoding"/></param>
        /// <returns>The <see cref="string"/></returns>
        protected static string HashOf<TP>(byte[] bytes, Encoding enc)
        where TP : HashAlgorithm, new()
        {
            var provider = new TP();
            return BitConverter.ToString(provider.ComputeHash(bytes)).Replace("-", "");
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="blobId">The <see cref="string"/></param>
        /// <returns>The <see cref="Blob"/></returns>
        public static Blob Get(RestClient client, string blobId)
        {
            var request = new RestRequest("/blobs/" + blobId, Method.GET);
            var response = client.Execute(request);
            string fileName = string.Empty;
            if (response.ErrorException != null)
            {
                throw new ChinoApiException(response.ErrorMessage);
            }

            foreach (Parameter p in response.Headers)
            {
                if (p.Name == "Content-Disposition")
                {
                    fileName = ((String)p.Value).Substring(((String)p.Value).IndexOf("=") + 1);
                    break;
                }
            }

            var bytes = client.DownloadData(request);
            string md5 = HashOf<MD5CryptoServiceProvider>(bytes, Encoding.Default).ToLower();
            string sha1 = HashOf<SHA1CryptoServiceProvider>(bytes, Encoding.Default).ToLower();

            var result = new Blob
            {
                Id = blobId,
                FileName = fileName,
                Md5 = md5,
                Sha1 = sha1,
                ByteSize = bytes.Length,
                Bytes = bytes
            };

            return result;
        }

        /// <summary>
        /// Uploads a file to the server
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="bytes">the byte-array to upload to the server</param>
        /// <param name="documentId">The <see cref="string"/></param>
        /// <param name="field">The <see cref="string"/></param>       
        /// <returns>a new instance of the <see cref="Blob"/></returns>        
        internal static Blob Upload(RestClient client, byte[] bytes, string documentId, string field)
        {
            var blobResponse = InitUpload(client, documentId, field, DateTime.Now.ToString());

            var file = new MemoryStream(bytes);
            int currentFilePosition = 0;

            file.Seek(currentFilePosition, SeekOrigin.Begin);
            while (currentFilePosition < file.Length)
            {
                int distanceFromEnd = (int)file.Length - currentFilePosition;
                if (distanceFromEnd > chunkSize)
                {
                    bytes = new byte[chunkSize];
                    file.Read(bytes, 0, chunkSize);
                }
                else
                {
                    bytes = new byte[distanceFromEnd];
                    file.Read(bytes, 0, distanceFromEnd);
                }

                UploadChunk(client, blobResponse.UploadId, bytes, currentFilePosition, bytes.Length);
                currentFilePosition = currentFilePosition + bytes.Length;
                file.Seek(currentFilePosition, SeekOrigin.Begin);
            }

            file.Close();

            return CommitUpload(client, blobResponse.UploadId);
        }

        /// <summary>
        /// Uploads a file to the server
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="uploadFilePath">The <see cref="string"/></param>
        /// <param name="documentId">The <see cref="string"/></param>
        /// <param name="field">The <see cref="string"/></param>
        /// <param name="fileName">The <see cref="string"/></param>
        /// <returns>a new instance of the <see cref="Blob"/></returns>        
        public static Blob Upload(RestClient client, string uploadFilePath, string documentId, string field, string fileName)
        {
            var blobResponse = InitUpload(client, documentId, field, fileName);

            byte[] bytes;
            var file = new FileStream(uploadFilePath + Path.DirectorySeparatorChar + fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            int currentFilePosition = 0;

            file.Seek(currentFilePosition, SeekOrigin.Begin);
            while (currentFilePosition < file.Length)
            {
                int distanceFromEnd = (int)file.Length - currentFilePosition;
                if (distanceFromEnd > chunkSize)
                {
                    bytes = new byte[chunkSize];
                    file.Read(bytes, 0, chunkSize);
                }
                else
                {
                    bytes = new byte[distanceFromEnd];
                    file.Read(bytes, 0, distanceFromEnd);
                }

                UploadChunk(client, blobResponse.UploadId, bytes, currentFilePosition, bytes.Length);
                currentFilePosition = currentFilePosition + bytes.Length;
                file.Seek(currentFilePosition, SeekOrigin.Begin);
            }

            file.Close();

            return CommitUpload(client, blobResponse.UploadId);
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="blobId">The <see cref="string"/></param>
        public static void Delete(RestClient client, string blobId)
        {
            var request = new RestRequest("/blobs/" + blobId, Method.DELETE);
            Rest.Execute<BasicResponse>(client, request);
        }

        /// <summary>
        /// The InitUpload
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="documentId">The <see cref="string"/></param>
        /// <param name="field">The <see cref="string"/></param>
        /// <param name="fileName">The <see cref="string"/></param>
        /// <returns>The <see cref="BlobDefinition"/></returns>
        private static BlobDefinition InitUpload(RestClient client, string documentId, string field, string fileName)
        {
            var request = new RestRequest("/blobs", Method.POST);
            var createBlobUploadRequest = new CreateBlobUploadRequest
            {
                DocumentId = documentId,
                Field = field,
                FileName = "foobar" //fileName
            };

            var result = Rest.Execute<CreateBlobUploadResponse>(client, request, createBlobUploadRequest);
            return result.Data.Blob;
        }

        /// <summary>
        /// The UploadChunk
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="upload_id">The <see cref="string"/></param>
        /// <param name="chunkData">The chunkdata to upload</param>
        /// <param name="offset">The <see cref="int"/></param>
        /// <param name="length">The <see cref="int"/></param>
        /// <returns>The <see cref="BlobDefinition"/></returns>
        private static BlobDefinition UploadChunk(RestClient client, string upload_id, byte[] chunkData, int offset, int length)
        {
            var request = new RestRequest("/blobs/" + upload_id, Method.PUT);

            request.AddParameter("text/json", chunkData, ParameterType.RequestBody);
            request.AddHeader("offset", offset.ToString());
            request.AddHeader("length", length.ToString());

            var result = Rest.Execute<CreateBlobUploadResponse>(client, request);
            return result.Data.Blob;
        }

        /// <summary>
        /// The CommitUpload
        /// </summary>
        /// <param name="client">The <see cref="RestClient"/></param>
        /// <param name="uploadId">The <see cref="string"/></param>
        /// <returns>The <see cref="Blob"/></returns>
        private static Blob CommitUpload(RestClient client, string uploadId)
        {
            var request = new RestRequest("/blobs/commit", Method.POST);
            var commitBlobUploadRequest = new CommitBlobUploadRequest();
            commitBlobUploadRequest.UploadId = uploadId;

            var result = Rest.Execute<CommitBlobUploadResponse>(client, request, commitBlobUploadRequest);            
            return result.Data.Blob;
        }
    }
}
