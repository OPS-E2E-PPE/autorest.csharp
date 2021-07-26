// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing collection of ProximityPlacementGroup and their operations over a ResourceGroup. </summary>
    public partial class ProximityPlacementGroupContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, ProximityPlacementGroup, ProximityPlacementGroupData>
    {
        /// <summary> Initializes a new instance of the <see cref="ProximityPlacementGroupContainer"/> class for mocking. </summary>
        protected ProximityPlacementGroupContainer()
        {
        }

        /// <summary> Initializes a new instance of ProximityPlacementGroupContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ProximityPlacementGroupContainer(OperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private ProximityPlacementGroupsRestOperations _restClient => new ProximityPlacementGroupsRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <summary> Create or update a proximity placement group. </summary>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="parameters"> Parameters supplied to the Create Proximity Placement Group operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="proximityPlacementGroupName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual Response<ProximityPlacementGroup> CreateOrUpdate(string proximityPlacementGroupName, ProximityPlacementGroupData parameters, CancellationToken cancellationToken = default)
        {
            if (proximityPlacementGroupName == null)
            {
                throw new ArgumentNullException(nameof(proximityPlacementGroupName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(proximityPlacementGroupName, parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update a proximity placement group. </summary>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="parameters"> Parameters supplied to the Create Proximity Placement Group operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="proximityPlacementGroupName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<ProximityPlacementGroup>> CreateOrUpdateAsync(string proximityPlacementGroupName, ProximityPlacementGroupData parameters, CancellationToken cancellationToken = default)
        {
            if (proximityPlacementGroupName == null)
            {
                throw new ArgumentNullException(nameof(proximityPlacementGroupName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(proximityPlacementGroupName, parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update a proximity placement group. </summary>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="parameters"> Parameters supplied to the Create Proximity Placement Group operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="proximityPlacementGroupName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ProximityPlacementGroupsCreateOrUpdateOperation StartCreateOrUpdate(string proximityPlacementGroupName, ProximityPlacementGroupData parameters, CancellationToken cancellationToken = default)
        {
            if (proximityPlacementGroupName == null)
            {
                throw new ArgumentNullException(nameof(proximityPlacementGroupName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.CreateOrUpdate(Id.ResourceGroupName, proximityPlacementGroupName, parameters, cancellationToken);
                return new ProximityPlacementGroupsCreateOrUpdateOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update a proximity placement group. </summary>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="parameters"> Parameters supplied to the Create Proximity Placement Group operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="proximityPlacementGroupName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ProximityPlacementGroupsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string proximityPlacementGroupName, ProximityPlacementGroupData parameters, CancellationToken cancellationToken = default)
        {
            if (proximityPlacementGroupName == null)
            {
                throw new ArgumentNullException(nameof(proximityPlacementGroupName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, proximityPlacementGroupName, parameters, cancellationToken).ConfigureAwait(false);
                return new ProximityPlacementGroupsCreateOrUpdateOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="includeColocationStatus"> includeColocationStatus=true enables fetching the colocation status of all the resources in the proximity placement group. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<ProximityPlacementGroup> Get(string proximityPlacementGroupName, string includeColocationStatus = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.Get");
            scope.Start();
            try
            {
                if (proximityPlacementGroupName == null)
                {
                    throw new ArgumentNullException(nameof(proximityPlacementGroupName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, proximityPlacementGroupName, includeColocationStatus, cancellationToken: cancellationToken);
                return Response.FromValue(new ProximityPlacementGroup(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="includeColocationStatus"> includeColocationStatus=true enables fetching the colocation status of all the resources in the proximity placement group. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<ProximityPlacementGroup>> GetAsync(string proximityPlacementGroupName, string includeColocationStatus = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.Get");
            scope.Start();
            try
            {
                if (proximityPlacementGroupName == null)
                {
                    throw new ArgumentNullException(nameof(proximityPlacementGroupName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, proximityPlacementGroupName, includeColocationStatus, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ProximityPlacementGroup(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="includeColocationStatus"> includeColocationStatus=true enables fetching the colocation status of all the resources in the proximity placement group. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual ProximityPlacementGroup TryGet(string proximityPlacementGroupName, string includeColocationStatus = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.TryGet");
            scope.Start();
            try
            {
                if (proximityPlacementGroupName == null)
                {
                    throw new ArgumentNullException(nameof(proximityPlacementGroupName));
                }

                return Get(proximityPlacementGroupName, includeColocationStatus, cancellationToken: cancellationToken).Value;
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="includeColocationStatus"> includeColocationStatus=true enables fetching the colocation status of all the resources in the proximity placement group. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<ProximityPlacementGroup> TryGetAsync(string proximityPlacementGroupName, string includeColocationStatus = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.TryGet");
            scope.Start();
            try
            {
                if (proximityPlacementGroupName == null)
                {
                    throw new ArgumentNullException(nameof(proximityPlacementGroupName));
                }

                return await GetAsync(proximityPlacementGroupName, includeColocationStatus, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="includeColocationStatus"> includeColocationStatus=true enables fetching the colocation status of all the resources in the proximity placement group. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual bool DoesExist(string proximityPlacementGroupName, string includeColocationStatus = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.DoesExist");
            scope.Start();
            try
            {
                if (proximityPlacementGroupName == null)
                {
                    throw new ArgumentNullException(nameof(proximityPlacementGroupName));
                }

                return TryGet(proximityPlacementGroupName, includeColocationStatus, cancellationToken: cancellationToken) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="includeColocationStatus"> includeColocationStatus=true enables fetching the colocation status of all the resources in the proximity placement group. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<bool> DoesExistAsync(string proximityPlacementGroupName, string includeColocationStatus = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.DoesExist");
            scope.Start();
            try
            {
                if (proximityPlacementGroupName == null)
                {
                    throw new ArgumentNullException(nameof(proximityPlacementGroupName));
                }

                return await TryGetAsync(proximityPlacementGroupName, includeColocationStatus, cancellationToken: cancellationToken).ConfigureAwait(false) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all proximity placement groups in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ProximityPlacementGroup" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<ProximityPlacementGroup> List(CancellationToken cancellationToken = default)
        {
            Page<ProximityPlacementGroup> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.List");
                scope.Start();
                try
                {
                    var response = _restClient.ListByResourceGroup(Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ProximityPlacementGroup(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ProximityPlacementGroup> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.List");
                scope.Start();
                try
                {
                    var response = _restClient.ListByResourceGroupNextPage(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ProximityPlacementGroup(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists all proximity placement groups in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ProximityPlacementGroup" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<ProximityPlacementGroup> ListAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ProximityPlacementGroup>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.List");
                scope.Start();
                try
                {
                    var response = await _restClient.ListByResourceGroupAsync(Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ProximityPlacementGroup(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ProximityPlacementGroup>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.List");
                scope.Start();
                try
                {
                    var response = await _restClient.ListByResourceGroupNextPageAsync(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ProximityPlacementGroup(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="ProximityPlacementGroup" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ProximityPlacementGroupOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ProximityPlacementGroup" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ProximityPlacementGroupOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<ResourceGroupResourceIdentifier, ProximityPlacementGroup, ProximityPlacementGroupData> Construct() { }
    }
}
