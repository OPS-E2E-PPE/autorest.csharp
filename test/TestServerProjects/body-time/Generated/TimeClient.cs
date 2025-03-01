// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace body_time
{
    /// <summary> The Time service client. </summary>
    public partial class TimeClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal TimeRestClient RestClient { get; }

        /// <summary> Initializes a new instance of TimeClient for mocking. </summary>
        protected TimeClient()
        {
        }

        /// <summary> Initializes a new instance of TimeClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal TimeClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new TimeRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Get time value &quot;11:34:56&quot;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TimeSpan>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TimeClient.Get");
            scope.Start();
            try
            {
                return await RestClient.GetAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get time value &quot;11:34:56&quot;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TimeSpan> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TimeClient.Get");
            scope.Start();
            try
            {
                return RestClient.Get(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put time value &quot;08:07:56&quot;. </summary>
        /// <param name="timeBody"> Put time value &quot;08:07:56&quot; in parameter to pass testserver. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<string>> PutAsync(TimeSpan timeBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TimeClient.Put");
            scope.Start();
            try
            {
                return await RestClient.PutAsync(timeBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put time value &quot;08:07:56&quot;. </summary>
        /// <param name="timeBody"> Put time value &quot;08:07:56&quot; in parameter to pass testserver. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<string> Put(TimeSpan timeBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TimeClient.Put");
            scope.Start();
            try
            {
                return RestClient.Put(timeBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
