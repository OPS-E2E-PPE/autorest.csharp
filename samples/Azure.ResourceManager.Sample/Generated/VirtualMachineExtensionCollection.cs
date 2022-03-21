// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing collection of VirtualMachineExtension and their operations over its parent. </summary>
    public partial class VirtualMachineExtensionCollection : ArmCollection, IEnumerable<VirtualMachineExtension>, IAsyncEnumerable<VirtualMachineExtension>
    {
        private readonly ClientDiagnostics _virtualMachineExtensionClientDiagnostics;
        private readonly VirtualMachineExtensionsRestOperations _virtualMachineExtensionRestClient;

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineExtensionCollection"/> class for mocking. </summary>
        protected VirtualMachineExtensionCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineExtensionCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal VirtualMachineExtensionCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _virtualMachineExtensionClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sample", VirtualMachineExtension.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(VirtualMachineExtension.ResourceType, out string virtualMachineExtensionApiVersion);
            _virtualMachineExtensionRestClient = new VirtualMachineExtensionsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, virtualMachineExtensionApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != VirtualMachine.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, VirtualMachine.ResourceType), nameof(id));
        }

        /// <summary>
        /// The operation to create or update the extension.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{vmExtensionName}
        /// Operation Id: VirtualMachineExtensions_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create Virtual Machine Extension operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmExtensionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> or <paramref name="extensionParameters"/> is null. </exception>
        public virtual async Task<ArmOperation<VirtualMachineExtension>> CreateOrUpdateAsync(WaitUntil waitUntil, string vmExtensionName, VirtualMachineExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmExtensionName, nameof(vmExtensionName));
            Argument.AssertNotNull(extensionParameters, nameof(extensionParameters));

            using var scope = _virtualMachineExtensionClientDiagnostics.CreateScope("VirtualMachineExtensionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _virtualMachineExtensionRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmExtensionName, extensionParameters, cancellationToken).ConfigureAwait(false);
                var operation = new SampleArmOperation<VirtualMachineExtension>(new VirtualMachineExtensionOperationSource(Client), _virtualMachineExtensionClientDiagnostics, Pipeline, _virtualMachineExtensionRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmExtensionName, extensionParameters).Request, response, OperationFinalStateVia.Location);
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
        /// The operation to create or update the extension.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{vmExtensionName}
        /// Operation Id: VirtualMachineExtensions_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create Virtual Machine Extension operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmExtensionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> or <paramref name="extensionParameters"/> is null. </exception>
        public virtual ArmOperation<VirtualMachineExtension> CreateOrUpdate(WaitUntil waitUntil, string vmExtensionName, VirtualMachineExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmExtensionName, nameof(vmExtensionName));
            Argument.AssertNotNull(extensionParameters, nameof(extensionParameters));

            using var scope = _virtualMachineExtensionClientDiagnostics.CreateScope("VirtualMachineExtensionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _virtualMachineExtensionRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmExtensionName, extensionParameters, cancellationToken);
                var operation = new SampleArmOperation<VirtualMachineExtension>(new VirtualMachineExtensionOperationSource(Client), _virtualMachineExtensionClientDiagnostics, Pipeline, _virtualMachineExtensionRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmExtensionName, extensionParameters).Request, response, OperationFinalStateVia.Location);
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

        /// <summary>
        /// The operation to get the extension.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{vmExtensionName}
        /// Operation Id: VirtualMachineExtensions_Get
        /// </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmExtensionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> is null. </exception>
        public virtual async Task<Response<VirtualMachineExtension>> GetAsync(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmExtensionName, nameof(vmExtensionName));

            using var scope = _virtualMachineExtensionClientDiagnostics.CreateScope("VirtualMachineExtensionCollection.Get");
            scope.Start();
            try
            {
                var response = await _virtualMachineExtensionRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmExtensionName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualMachineExtension(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to get the extension.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{vmExtensionName}
        /// Operation Id: VirtualMachineExtensions_Get
        /// </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmExtensionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> is null. </exception>
        public virtual Response<VirtualMachineExtension> Get(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmExtensionName, nameof(vmExtensionName));

            using var scope = _virtualMachineExtensionClientDiagnostics.CreateScope("VirtualMachineExtensionCollection.Get");
            scope.Start();
            try
            {
                var response = _virtualMachineExtensionRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmExtensionName, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualMachineExtension(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to get all extensions of a Virtual Machine.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions
        /// Operation Id: VirtualMachineExtensions_List
        /// </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineExtension" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineExtension> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<VirtualMachineExtension>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualMachineExtensionClientDiagnostics.CreateScope("VirtualMachineExtensionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualMachineExtensionRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineExtension(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// The operation to get all extensions of a Virtual Machine.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions
        /// Operation Id: VirtualMachineExtensions_List
        /// </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineExtension" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineExtension> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            Page<VirtualMachineExtension> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualMachineExtensionClientDiagnostics.CreateScope("VirtualMachineExtensionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualMachineExtensionRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineExtension(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{vmExtensionName}
        /// Operation Id: VirtualMachineExtensions_Get
        /// </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmExtensionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmExtensionName, nameof(vmExtensionName));

            using var scope = _virtualMachineExtensionClientDiagnostics.CreateScope("VirtualMachineExtensionCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(vmExtensionName, expand: expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{vmExtensionName}
        /// Operation Id: VirtualMachineExtensions_Get
        /// </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmExtensionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> is null. </exception>
        public virtual Response<bool> Exists(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmExtensionName, nameof(vmExtensionName));

            using var scope = _virtualMachineExtensionClientDiagnostics.CreateScope("VirtualMachineExtensionCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(vmExtensionName, expand: expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{vmExtensionName}
        /// Operation Id: VirtualMachineExtensions_Get
        /// </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmExtensionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> is null. </exception>
        public virtual async Task<Response<VirtualMachineExtension>> GetIfExistsAsync(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmExtensionName, nameof(vmExtensionName));

            using var scope = _virtualMachineExtensionClientDiagnostics.CreateScope("VirtualMachineExtensionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _virtualMachineExtensionRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmExtensionName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<VirtualMachineExtension>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualMachineExtension(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{vmExtensionName}
        /// Operation Id: VirtualMachineExtensions_Get
        /// </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmExtensionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> is null. </exception>
        public virtual Response<VirtualMachineExtension> GetIfExists(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmExtensionName, nameof(vmExtensionName));

            using var scope = _virtualMachineExtensionClientDiagnostics.CreateScope("VirtualMachineExtensionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _virtualMachineExtensionRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmExtensionName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<VirtualMachineExtension>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualMachineExtension(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<VirtualMachineExtension> IEnumerable<VirtualMachineExtension>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<VirtualMachineExtension> IAsyncEnumerable<VirtualMachineExtension>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
