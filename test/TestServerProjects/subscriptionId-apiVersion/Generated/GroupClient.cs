// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using subscriptionId_apiVersion.Models;

namespace subscriptionId_apiVersion
{
    /// <summary> The Group service client. </summary>
    public partial class GroupClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal GroupRestClient RestClient { get; }

        /// <summary> Initializes a new instance of GroupClient for mocking. </summary>
        protected GroupClient()
        {
        }

        /// <summary> Initializes a new instance of GroupClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="subscriptionId"> Subscription Id. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/>, <paramref name="subscriptionId"/> or <paramref name="apiVersion"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        internal GroupClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string subscriptionId, Uri endpoint = null, string apiVersion = "2014-04-01-preview")
        {
            RestClient = new GroupRestClient(clientDiagnostics, pipeline, subscriptionId, endpoint, apiVersion);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Provides a resouce group with name &apos;testgroup101&apos; and location &apos;West US&apos;. </summary>
        /// <param name="resourceGroupName"> Resource Group name &apos;testgroup101&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SampleResourceGroup>> GetSampleResourceGroupAsync(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GroupClient.GetSampleResourceGroup");
            scope.Start();
            try
            {
                return await RestClient.GetSampleResourceGroupAsync(resourceGroupName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Provides a resouce group with name &apos;testgroup101&apos; and location &apos;West US&apos;. </summary>
        /// <param name="resourceGroupName"> Resource Group name &apos;testgroup101&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SampleResourceGroup> GetSampleResourceGroup(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GroupClient.GetSampleResourceGroup");
            scope.Start();
            try
            {
                return RestClient.GetSampleResourceGroup(resourceGroupName, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
