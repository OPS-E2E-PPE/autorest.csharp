// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace required_optional
{
    /// <summary> The Implicit service client. </summary>
    public partial class ImplicitClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal ImplicitRestClient RestClient { get; }

        /// <summary> Initializes a new instance of ImplicitClient for mocking. </summary>
        protected ImplicitClient()
        {
        }

        /// <summary> Initializes a new instance of ImplicitClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="requiredGlobalPath"> number of items to skip. </param>
        /// <param name="requiredGlobalQuery"> number of items to skip. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="optionalGlobalQuery"> number of items to skip. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/>, <paramref name="requiredGlobalPath"/> or <paramref name="requiredGlobalQuery"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="requiredGlobalPath"/> is an empty string, and was expected to be non-empty. </exception>
        internal ImplicitClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string requiredGlobalPath, string requiredGlobalQuery, Uri endpoint = null, int? optionalGlobalQuery = null)
        {
            RestClient = new ImplicitRestClient(clientDiagnostics, pipeline, requiredGlobalPath, requiredGlobalQuery, endpoint, optionalGlobalQuery);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Test implicitly required path parameter. </summary>
        /// <param name="pathParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetRequiredPathAsync(string pathParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImplicitClient.GetRequiredPath");
            scope.Start();
            try
            {
                return await RestClient.GetRequiredPathAsync(pathParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test implicitly required path parameter. </summary>
        /// <param name="pathParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetRequiredPath(string pathParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImplicitClient.GetRequiredPath");
            scope.Start();
            try
            {
                return RestClient.GetRequiredPath(pathParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test implicitly optional query parameter. </summary>
        /// <param name="queryParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutOptionalQueryAsync(string queryParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImplicitClient.PutOptionalQuery");
            scope.Start();
            try
            {
                return await RestClient.PutOptionalQueryAsync(queryParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test implicitly optional query parameter. </summary>
        /// <param name="queryParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutOptionalQuery(string queryParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImplicitClient.PutOptionalQuery");
            scope.Start();
            try
            {
                return RestClient.PutOptionalQuery(queryParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test implicitly optional header parameter. </summary>
        /// <param name="queryParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutOptionalHeaderAsync(string queryParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImplicitClient.PutOptionalHeader");
            scope.Start();
            try
            {
                return await RestClient.PutOptionalHeaderAsync(queryParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test implicitly optional header parameter. </summary>
        /// <param name="queryParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutOptionalHeader(string queryParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImplicitClient.PutOptionalHeader");
            scope.Start();
            try
            {
                return RestClient.PutOptionalHeader(queryParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test implicitly optional body parameter. </summary>
        /// <param name="bodyParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutOptionalBodyAsync(string bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImplicitClient.PutOptionalBody");
            scope.Start();
            try
            {
                return await RestClient.PutOptionalBodyAsync(bodyParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test implicitly optional body parameter. </summary>
        /// <param name="bodyParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutOptionalBody(string bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImplicitClient.PutOptionalBody");
            scope.Start();
            try
            {
                return RestClient.PutOptionalBody(bodyParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test implicitly optional body parameter. </summary>
        /// <param name="bodyParameter"> The Stream to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutOptionalBinaryBodyAsync(Stream bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImplicitClient.PutOptionalBinaryBody");
            scope.Start();
            try
            {
                return await RestClient.PutOptionalBinaryBodyAsync(bodyParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test implicitly optional body parameter. </summary>
        /// <param name="bodyParameter"> The Stream to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutOptionalBinaryBody(Stream bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImplicitClient.PutOptionalBinaryBody");
            scope.Start();
            try
            {
                return RestClient.PutOptionalBinaryBody(bodyParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test implicitly required path parameter. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetRequiredGlobalPathAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImplicitClient.GetRequiredGlobalPath");
            scope.Start();
            try
            {
                return await RestClient.GetRequiredGlobalPathAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test implicitly required path parameter. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetRequiredGlobalPath(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImplicitClient.GetRequiredGlobalPath");
            scope.Start();
            try
            {
                return RestClient.GetRequiredGlobalPath(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test implicitly required query parameter. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetRequiredGlobalQueryAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImplicitClient.GetRequiredGlobalQuery");
            scope.Start();
            try
            {
                return await RestClient.GetRequiredGlobalQueryAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test implicitly required query parameter. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetRequiredGlobalQuery(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImplicitClient.GetRequiredGlobalQuery");
            scope.Start();
            try
            {
                return RestClient.GetRequiredGlobalQuery(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test implicitly optional query parameter. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetOptionalGlobalQueryAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImplicitClient.GetOptionalGlobalQuery");
            scope.Start();
            try
            {
                return await RestClient.GetOptionalGlobalQueryAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test implicitly optional query parameter. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetOptionalGlobalQuery(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImplicitClient.GetOptionalGlobalQuery");
            scope.Start();
            try
            {
                return RestClient.GetOptionalGlobalQuery(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
