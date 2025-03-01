// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace MgmtResourceName
{
    /// <summary>
    /// A Class representing a Network along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="NetworkResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetNetworkResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetNetwork method.
    /// </summary>
    public partial class NetworkResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="NetworkResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkResourceName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/networkResources/{networkResourceName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _networkNetworkResourcesClientDiagnostics;
        private readonly NetworkResourcesRestOperations _networkNetworkResourcesRestClient;
        private readonly NetworkData _data;

        /// <summary> Initializes a new instance of the <see cref="NetworkResource"/> class for mocking. </summary>
        protected NetworkResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "NetworkResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal NetworkResource(ArmClient client, NetworkData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="NetworkResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal NetworkResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _networkNetworkResourcesClientDiagnostics = new ClientDiagnostics("MgmtResourceName", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string networkNetworkResourcesApiVersion);
            _networkNetworkResourcesRestClient = new NetworkResourcesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, networkNetworkResourcesApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/networkResources";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual NetworkData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/networkResources/{networkResourceName}
        /// Operation Id: networkResources_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<NetworkResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _networkNetworkResourcesClientDiagnostics.CreateScope("NetworkResource.Get");
            scope.Start();
            try
            {
                var response = await _networkNetworkResourcesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NetworkResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/networkResources/{networkResourceName}
        /// Operation Id: networkResources_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<NetworkResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _networkNetworkResourcesClientDiagnostics.CreateScope("NetworkResource.Get");
            scope.Start();
            try
            {
                var response = _networkNetworkResourcesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NetworkResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/networkResources/{networkResourceName}
        /// Operation Id: NetworkResources_Put
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The Network to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<NetworkResource>> UpdateAsync(WaitUntil waitUntil, NetworkData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _networkNetworkResourcesClientDiagnostics.CreateScope("NetworkResource.Update");
            scope.Start();
            try
            {
                var response = await _networkNetworkResourcesRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtResourceNameArmOperation<NetworkResource>(Response.FromValue(new NetworkResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/networkResources/{networkResourceName}
        /// Operation Id: NetworkResources_Put
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The Network to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<NetworkResource> Update(WaitUntil waitUntil, NetworkData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _networkNetworkResourcesClientDiagnostics.CreateScope("NetworkResource.Update");
            scope.Start();
            try
            {
                var response = _networkNetworkResourcesRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data, cancellationToken);
                var operation = new MgmtResourceNameArmOperation<NetworkResource>(Response.FromValue(new NetworkResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
