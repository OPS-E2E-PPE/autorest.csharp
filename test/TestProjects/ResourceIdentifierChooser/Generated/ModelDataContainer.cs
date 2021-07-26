// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using ResourceIdentifierChooser.Models;

namespace ResourceIdentifierChooser
{
    /// <summary> A class representing collection of ModelData and their operations over a ResourceGroup. </summary>
    public partial class ModelDataContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, ModelData, ModelDataData>
    {
        /// <summary> Initializes a new instance of the <see cref="ModelDataContainer"/> class for mocking. </summary>
        protected ModelDataContainer()
        {
        }

        /// <summary> Initializes a new instance of ModelDataContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ModelDataContainer(OperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private ModelDatasRestOperations _restClient => new ModelDatasRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <param name="modelDatasName"> The String to use. </param>
        /// <param name="parameters"> The ModelData to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelDatasName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual Response<ModelData> CreateOrUpdate(string modelDatasName, ModelDataData parameters, CancellationToken cancellationToken = default)
        {
            if (modelDatasName == null)
            {
                throw new ArgumentNullException(nameof(modelDatasName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ModelDataContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(modelDatasName, parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="modelDatasName"> The String to use. </param>
        /// <param name="parameters"> The ModelData to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelDatasName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<ModelData>> CreateOrUpdateAsync(string modelDatasName, ModelDataData parameters, CancellationToken cancellationToken = default)
        {
            if (modelDatasName == null)
            {
                throw new ArgumentNullException(nameof(modelDatasName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ModelDataContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(modelDatasName, parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="modelDatasName"> The String to use. </param>
        /// <param name="parameters"> The ModelData to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelDatasName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ModelDatasPutOperation StartCreateOrUpdate(string modelDatasName, ModelDataData parameters, CancellationToken cancellationToken = default)
        {
            if (modelDatasName == null)
            {
                throw new ArgumentNullException(nameof(modelDatasName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ModelDataContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.Put(Id.ResourceGroupName, modelDatasName, parameters, cancellationToken);
                return new ModelDatasPutOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="modelDatasName"> The String to use. </param>
        /// <param name="parameters"> The ModelData to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelDatasName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ModelDatasPutOperation> StartCreateOrUpdateAsync(string modelDatasName, ModelDataData parameters, CancellationToken cancellationToken = default)
        {
            if (modelDatasName == null)
            {
                throw new ArgumentNullException(nameof(modelDatasName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ModelDataContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.PutAsync(Id.ResourceGroupName, modelDatasName, parameters, cancellationToken).ConfigureAwait(false);
                return new ModelDatasPutOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="modelDatasName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<ModelData> Get(string modelDatasName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ModelDataContainer.Get");
            scope.Start();
            try
            {
                if (modelDatasName == null)
                {
                    throw new ArgumentNullException(nameof(modelDatasName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, modelDatasName, cancellationToken: cancellationToken);
                return Response.FromValue(new ModelData(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="modelDatasName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<ModelData>> GetAsync(string modelDatasName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ModelDataContainer.Get");
            scope.Start();
            try
            {
                if (modelDatasName == null)
                {
                    throw new ArgumentNullException(nameof(modelDatasName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, modelDatasName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ModelData(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="modelDatasName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual ModelData TryGet(string modelDatasName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ModelDataContainer.TryGet");
            scope.Start();
            try
            {
                if (modelDatasName == null)
                {
                    throw new ArgumentNullException(nameof(modelDatasName));
                }

                return Get(modelDatasName, cancellationToken: cancellationToken).Value;
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
        /// <param name="modelDatasName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<ModelData> TryGetAsync(string modelDatasName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ModelDataContainer.TryGet");
            scope.Start();
            try
            {
                if (modelDatasName == null)
                {
                    throw new ArgumentNullException(nameof(modelDatasName));
                }

                return await GetAsync(modelDatasName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <param name="modelDatasName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual bool DoesExist(string modelDatasName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ModelDataContainer.DoesExist");
            scope.Start();
            try
            {
                if (modelDatasName == null)
                {
                    throw new ArgumentNullException(nameof(modelDatasName));
                }

                return TryGet(modelDatasName, cancellationToken: cancellationToken) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="modelDatasName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<bool> DoesExistAsync(string modelDatasName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ModelDataContainer.DoesExist");
            scope.Start();
            try
            {
                if (modelDatasName == null)
                {
                    throw new ArgumentNullException(nameof(modelDatasName));
                }

                return await TryGetAsync(modelDatasName, cancellationToken: cancellationToken).ConfigureAwait(false) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ModelData" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ModelDataContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ModelDataOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ModelData" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ModelDataContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ModelDataOperations.ResourceType);
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
        // public ArmBuilder<ResourceGroupResourceIdentifier, ModelData, ModelDataData> Construct() { }
    }
}
