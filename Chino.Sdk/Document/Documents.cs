//-----------------------------------------------------------------------
// <copyright file="Documents.cs" company="Chino.IO and NursIt.Institute" />
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

    /// <summary>
    /// Encapsulates the handling of Documents
    /// </summary>
    public class Documents
    {
        /// <summary>
        /// Defines the client
        /// </summary>
        internal RestClient client;

        /// <summary>
        /// Initializes a new instance of the Documents class
        /// </summary>
        /// <param name="restClient"></param>
        public Documents(RestClient restClient)
        {
            this.client = restClient;
        }

        /// <summary>
        /// Returns a list of <see cref="Document"/>s with default Chino settings
        /// </summary>
        /// <param name="schemaId">the schema under which the documents reside</param>        
        /// <returns>a list of <see cref="Document"/>s</returns>
        public DocumentList List(string schemaId)
        {
            return List(schemaId, false);
        }

        /// <summary>
        /// Returns a list of <see cref="Document"/>s with default Chino settings
        /// </summary>
        /// <param name="schemaId">the schema under which the documents reside</param>
        /// <param name="includeContent">indicating whether the document content should be returned</param>
        /// <returns>a list of <see cref="Document"/>s</returns>
        public DocumentList List(string schemaId, bool includeContent)
        {
            return List(0, schemaId, includeContent).Data;
        }

        /// <summary>
        /// Returns a list of <see cref="Document"/>s with default Chino settings
        /// </summary>
        /// <param name="start">the offset of the first record to return</param>        
        /// <param name="schemaId">the schema under which the documents reside</param>
        /// <param name="includeContent">indicating whether the document content should be returned</param>
        /// <returns>a list of <see cref="Document"/>s</returns>
        public ListDocumentsResponse List(int start, string schemaId, bool includeContent)
        {
            return List(start, 50, schemaId, includeContent);
        }

        /// <summary>
        /// Returns a list of <see cref="Document"/>s with default Chino settings
        /// </summary>
        /// <param name="start">the offset of the first record to return</param>
        /// <param name="limit">the amount of maximum records</param>
        /// <param name="schemaId">the schema under which the documents reside</param>
        /// <param name="includeContent">indicating whether the document content should be returned</param>
        /// <returns>a list of <see cref="Document"/>s</returns>
        public ListDocumentsResponse List(int start, int limit, string schemaId, bool includeContent)
        {
            return Document.List(client, start, limit, schemaId, includeContent);
        }

        /// <summary>
        /// Retrieves a single Document from the API-Server
        /// </summary>        
        /// <param name="documentId">the id of the document to download</param>
        /// <returns>a new <see cref="Document"/></returns>
        public Document Get(string documentId)
        {
            return Document.Get(client, documentId);
        }

        /// <summary>
        /// Updates an existing <see cref="Document"/> on the server
        /// </summary>
        /// <param name="document">the <see cref="Document"/> to update</param>
        /// <returns>the id of the updated document</returns>
        public void Update(Document document)
        {
            Document.Update(client, document);
        }

        /// <summary>
        /// Creates a new Document on the API-Server and returns the new Id
        /// </summary>
        /// <param name="schemaId">the schema-Id to store the document to</param>
        /// <param name="document">the document to store</param>
        /// <returns>the Id of the new generated documents</returns>
        public string Create(string schemaId, Document document)
        {
            return Document.Create(client, schemaId, document);
        }

        /// <summary>
        /// Deactivates a Document on the API-Server
        /// </summary>        
        /// <param name="documentId">the document-id to deactivate</param>
        public void DeActivate(string documentId)
        {
            Document.Delete(client, documentId, true);
        }

        /// <summary>
        /// Deletes a Document on the API-Server
        /// </summary>        
        /// <param name="documentId">the document-id to delete</param>
        public void Delete(string documentId)
        {
            Document.Delete(client, documentId, false);
        }
    }
}
