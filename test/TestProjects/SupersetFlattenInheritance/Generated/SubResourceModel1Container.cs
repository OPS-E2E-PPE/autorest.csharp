// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace SupersetFlattenInheritance
{
    /// <summary> A class representing collection of SubResourceModel1 and their operations over a ResourceGroup. </summary>
    public partial class SubResourceModel1Container : ResourceContainerBase<ResourceGroupResourceIdentifier, SubResourceModel1, SubResourceModel1Data>
    {
        /// <summary> Initializes a new instance of the <see cref="SubResourceModel1Container"/> class for mocking. </summary>
        protected SubResourceModel1Container()
        {
        }

        /// <summary> Initializes a new instance of SubResourceModel1Container class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal SubResourceModel1Container(OperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private SubResourceModel1SRestOperations _restClient => new SubResourceModel1SRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <param name="subResourceModel1SName"> The String to use. </param>
        /// <param name="parameters"> The SubResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subResourceModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual Response<SubResourceModel1> CreateOrUpdate(string subResourceModel1SName, SubResourceModel1Data parameters, CancellationToken cancellationToken = default)
        {
            if (subResourceModel1SName == null)
            {
                throw new ArgumentNullException(nameof(subResourceModel1SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("SubResourceModel1Container.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(subResourceModel1SName, parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="subResourceModel1SName"> The String to use. </param>
        /// <param name="parameters"> The SubResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subResourceModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<SubResourceModel1>> CreateOrUpdateAsync(string subResourceModel1SName, SubResourceModel1Data parameters, CancellationToken cancellationToken = default)
        {
            if (subResourceModel1SName == null)
            {
                throw new ArgumentNullException(nameof(subResourceModel1SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("SubResourceModel1Container.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(subResourceModel1SName, parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="subResourceModel1SName"> The String to use. </param>
        /// <param name="parameters"> The SubResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subResourceModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual SubResourceModel1SPutOperation StartCreateOrUpdate(string subResourceModel1SName, SubResourceModel1Data parameters, CancellationToken cancellationToken = default)
        {
            if (subResourceModel1SName == null)
            {
                throw new ArgumentNullException(nameof(subResourceModel1SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("SubResourceModel1Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.Put(Id.ResourceGroupName, subResourceModel1SName, parameters, cancellationToken);
                return new SubResourceModel1SPutOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="subResourceModel1SName"> The String to use. </param>
        /// <param name="parameters"> The SubResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subResourceModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<SubResourceModel1SPutOperation> StartCreateOrUpdateAsync(string subResourceModel1SName, SubResourceModel1Data parameters, CancellationToken cancellationToken = default)
        {
            if (subResourceModel1SName == null)
            {
                throw new ArgumentNullException(nameof(subResourceModel1SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("SubResourceModel1Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.PutAsync(Id.ResourceGroupName, subResourceModel1SName, parameters, cancellationToken).ConfigureAwait(false);
                return new SubResourceModel1SPutOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="subResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<SubResourceModel1> Get(string subResourceModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubResourceModel1Container.Get");
            scope.Start();
            try
            {
                if (subResourceModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(subResourceModel1SName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, subResourceModel1SName, cancellationToken: cancellationToken);
                return Response.FromValue(new SubResourceModel1(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="subResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<SubResourceModel1>> GetAsync(string subResourceModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubResourceModel1Container.Get");
            scope.Start();
            try
            {
                if (subResourceModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(subResourceModel1SName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, subResourceModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new SubResourceModel1(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="subResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual SubResourceModel1 TryGet(string subResourceModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubResourceModel1Container.TryGet");
            scope.Start();
            try
            {
                if (subResourceModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(subResourceModel1SName));
                }

                return Get(subResourceModel1SName, cancellationToken: cancellationToken).Value;
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
        /// <param name="subResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<SubResourceModel1> TryGetAsync(string subResourceModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubResourceModel1Container.TryGet");
            scope.Start();
            try
            {
                if (subResourceModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(subResourceModel1SName));
                }

                return await GetAsync(subResourceModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <param name="subResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual bool DoesExist(string subResourceModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubResourceModel1Container.DoesExist");
            scope.Start();
            try
            {
                if (subResourceModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(subResourceModel1SName));
                }

                return TryGet(subResourceModel1SName, cancellationToken: cancellationToken) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="subResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<bool> DoesExistAsync(string subResourceModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubResourceModel1Container.DoesExist");
            scope.Start();
            try
            {
                if (subResourceModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(subResourceModel1SName));
                }

                return await TryGetAsync(subResourceModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of SubResourceModel1 for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubResourceModel1Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SubResourceModel1Operations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of SubResourceModel1 for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubResourceModel1Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SubResourceModel1Operations.ResourceType);
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
        // public ArmBuilder<ResourceGroupResourceIdentifier, SubResourceModel1, SubResourceModel1Data> Construct() { }
    }
}
