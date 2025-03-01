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

namespace MgmtDiscriminator
{
    /// <summary>
    /// A Class representing a DeliveryRule along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="DeliveryRuleResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetDeliveryRuleResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetDeliveryRule method.
    /// </summary>
    public partial class DeliveryRuleResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="DeliveryRuleResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/deliveryRules/{name}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _deliveryRuleClientDiagnostics;
        private readonly DeliveryRulesRestOperations _deliveryRuleRestClient;
        private readonly DeliveryRuleData _data;

        /// <summary> Initializes a new instance of the <see cref="DeliveryRuleResource"/> class for mocking. </summary>
        protected DeliveryRuleResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "DeliveryRuleResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal DeliveryRuleResource(ArmClient client, DeliveryRuleData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="DeliveryRuleResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal DeliveryRuleResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _deliveryRuleClientDiagnostics = new ClientDiagnostics("MgmtDiscriminator", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string deliveryRuleApiVersion);
            _deliveryRuleRestClient = new DeliveryRulesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, deliveryRuleApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Cdn/deliveryRules";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual DeliveryRuleData Data
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
        /// Gets an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/deliveryRules/{name}
        /// Operation Id: DeliveryRules_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DeliveryRuleResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _deliveryRuleClientDiagnostics.CreateScope("DeliveryRuleResource.Get");
            scope.Start();
            try
            {
                var response = await _deliveryRuleRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeliveryRuleResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/deliveryRules/{name}
        /// Operation Id: DeliveryRules_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DeliveryRuleResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _deliveryRuleClientDiagnostics.CreateScope("DeliveryRuleResource.Get");
            scope.Start();
            try
            {
                var response = _deliveryRuleRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeliveryRuleResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/deliveryRules/{name}
        /// Operation Id: DeliveryRules_Delete
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _deliveryRuleClientDiagnostics.CreateScope("DeliveryRuleResource.Delete");
            scope.Start();
            try
            {
                var response = await _deliveryRuleRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtDiscriminatorArmOperation(_deliveryRuleClientDiagnostics, Pipeline, _deliveryRuleRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/deliveryRules/{name}
        /// Operation Id: DeliveryRules_Delete
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _deliveryRuleClientDiagnostics.CreateScope("DeliveryRuleResource.Delete");
            scope.Start();
            try
            {
                var response = _deliveryRuleRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new MgmtDiscriminatorArmOperation(_deliveryRuleClientDiagnostics, Pipeline, _deliveryRuleRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a new CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/deliveryRules/{name}
        /// Operation Id: DeliveryRules_Create
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Endpoint properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<DeliveryRuleResource>> UpdateAsync(WaitUntil waitUntil, DeliveryRuleData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _deliveryRuleClientDiagnostics.CreateScope("DeliveryRuleResource.Update");
            scope.Start();
            try
            {
                var response = await _deliveryRuleRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtDiscriminatorArmOperation<DeliveryRuleResource>(new DeliveryRuleOperationSource(Client), _deliveryRuleClientDiagnostics, Pipeline, _deliveryRuleRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data).Request, response, OperationFinalStateVia.Location);
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
        /// Creates a new CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/deliveryRules/{name}
        /// Operation Id: DeliveryRules_Create
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Endpoint properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<DeliveryRuleResource> Update(WaitUntil waitUntil, DeliveryRuleData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _deliveryRuleClientDiagnostics.CreateScope("DeliveryRuleResource.Update");
            scope.Start();
            try
            {
                var response = _deliveryRuleRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data, cancellationToken);
                var operation = new MgmtDiscriminatorArmOperation<DeliveryRuleResource>(new DeliveryRuleOperationSource(Client), _deliveryRuleClientDiagnostics, Pipeline, _deliveryRuleRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data).Request, response, OperationFinalStateVia.Location);
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
