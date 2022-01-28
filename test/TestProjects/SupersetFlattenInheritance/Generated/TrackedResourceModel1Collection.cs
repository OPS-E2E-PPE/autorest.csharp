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
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using SupersetFlattenInheritance.Models;

namespace SupersetFlattenInheritance
{
    /// <summary> A class representing collection of TrackedResourceModel1 and their operations over its parent. </summary>
    public partial class TrackedResourceModel1Collection : ArmCollection, IEnumerable<TrackedResourceModel1>, IAsyncEnumerable<TrackedResourceModel1>
    {
        private readonly ClientDiagnostics _trackedResourceModel1ClientDiagnostics;
        private readonly TrackedResourceModel1SRestOperations _trackedResourceModel1RestClient;

        /// <summary> Initializes a new instance of the <see cref="TrackedResourceModel1Collection"/> class for mocking. </summary>
        protected TrackedResourceModel1Collection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TrackedResourceModel1Collection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal TrackedResourceModel1Collection(ArmResource parent) : base(parent)
        {
            _trackedResourceModel1ClientDiagnostics = new ClientDiagnostics("SupersetFlattenInheritance", TrackedResourceModel1.ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(TrackedResourceModel1.ResourceType, out string trackedResourceModel1ApiVersion);
            _trackedResourceModel1RestClient = new TrackedResourceModel1SRestOperations(_trackedResourceModel1ClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, trackedResourceModel1ApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel1s/{trackedResourceModel1sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: TrackedResourceModel1s_Put
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="trackedResourceModel1SName"> The String to use. </param>
        /// <param name="parameters"> The TrackedResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="trackedResourceModel1SName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="trackedResourceModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual TrackedResourceModel1CreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string trackedResourceModel1SName, TrackedResourceModel1Data parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(trackedResourceModel1SName, nameof(trackedResourceModel1SName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _trackedResourceModel1ClientDiagnostics.CreateScope("TrackedResourceModel1Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _trackedResourceModel1RestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, trackedResourceModel1SName, parameters, cancellationToken);
                var operation = new TrackedResourceModel1CreateOrUpdateOperation(ArmClient, response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel1s/{trackedResourceModel1sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: TrackedResourceModel1s_Put
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="trackedResourceModel1SName"> The String to use. </param>
        /// <param name="parameters"> The TrackedResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="trackedResourceModel1SName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="trackedResourceModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<TrackedResourceModel1CreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string trackedResourceModel1SName, TrackedResourceModel1Data parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(trackedResourceModel1SName, nameof(trackedResourceModel1SName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _trackedResourceModel1ClientDiagnostics.CreateScope("TrackedResourceModel1Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _trackedResourceModel1RestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, trackedResourceModel1SName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new TrackedResourceModel1CreateOrUpdateOperation(ArmClient, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel1s/{trackedResourceModel1sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: TrackedResourceModel1s_Get
        /// <param name="trackedResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="trackedResourceModel1SName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="trackedResourceModel1SName"/> is null. </exception>
        public virtual Response<TrackedResourceModel1> Get(string trackedResourceModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(trackedResourceModel1SName, nameof(trackedResourceModel1SName));

            using var scope = _trackedResourceModel1ClientDiagnostics.CreateScope("TrackedResourceModel1Collection.Get");
            scope.Start();
            try
            {
                var response = _trackedResourceModel1RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, trackedResourceModel1SName, cancellationToken);
                if (response.Value == null)
                    throw _trackedResourceModel1ClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TrackedResourceModel1(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel1s/{trackedResourceModel1sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: TrackedResourceModel1s_Get
        /// <param name="trackedResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="trackedResourceModel1SName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="trackedResourceModel1SName"/> is null. </exception>
        public async virtual Task<Response<TrackedResourceModel1>> GetAsync(string trackedResourceModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(trackedResourceModel1SName, nameof(trackedResourceModel1SName));

            using var scope = _trackedResourceModel1ClientDiagnostics.CreateScope("TrackedResourceModel1Collection.Get");
            scope.Start();
            try
            {
                var response = await _trackedResourceModel1RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, trackedResourceModel1SName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _trackedResourceModel1ClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new TrackedResourceModel1(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="trackedResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="trackedResourceModel1SName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="trackedResourceModel1SName"/> is null. </exception>
        public virtual Response<TrackedResourceModel1> GetIfExists(string trackedResourceModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(trackedResourceModel1SName, nameof(trackedResourceModel1SName));

            using var scope = _trackedResourceModel1ClientDiagnostics.CreateScope("TrackedResourceModel1Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = _trackedResourceModel1RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, trackedResourceModel1SName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<TrackedResourceModel1>(null, response.GetRawResponse());
                return Response.FromValue(new TrackedResourceModel1(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="trackedResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="trackedResourceModel1SName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="trackedResourceModel1SName"/> is null. </exception>
        public async virtual Task<Response<TrackedResourceModel1>> GetIfExistsAsync(string trackedResourceModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(trackedResourceModel1SName, nameof(trackedResourceModel1SName));

            using var scope = _trackedResourceModel1ClientDiagnostics.CreateScope("TrackedResourceModel1Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _trackedResourceModel1RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, trackedResourceModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<TrackedResourceModel1>(null, response.GetRawResponse());
                return Response.FromValue(new TrackedResourceModel1(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="trackedResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="trackedResourceModel1SName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="trackedResourceModel1SName"/> is null. </exception>
        public virtual Response<bool> Exists(string trackedResourceModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(trackedResourceModel1SName, nameof(trackedResourceModel1SName));

            using var scope = _trackedResourceModel1ClientDiagnostics.CreateScope("TrackedResourceModel1Collection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(trackedResourceModel1SName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="trackedResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="trackedResourceModel1SName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="trackedResourceModel1SName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string trackedResourceModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(trackedResourceModel1SName, nameof(trackedResourceModel1SName));

            using var scope = _trackedResourceModel1ClientDiagnostics.CreateScope("TrackedResourceModel1Collection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(trackedResourceModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel1s
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: TrackedResourceModel1s_List
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TrackedResourceModel1" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TrackedResourceModel1> GetAll(CancellationToken cancellationToken = default)
        {
            Page<TrackedResourceModel1> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _trackedResourceModel1ClientDiagnostics.CreateScope("TrackedResourceModel1Collection.GetAll");
                scope.Start();
                try
                {
                    var response = _trackedResourceModel1RestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TrackedResourceModel1(ArmClient, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel1s
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: TrackedResourceModel1s_List
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TrackedResourceModel1" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TrackedResourceModel1> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<TrackedResourceModel1>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _trackedResourceModel1ClientDiagnostics.CreateScope("TrackedResourceModel1Collection.GetAll");
                scope.Start();
                try
                {
                    var response = await _trackedResourceModel1RestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TrackedResourceModel1(ArmClient, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        IEnumerator<TrackedResourceModel1> IEnumerable<TrackedResourceModel1>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TrackedResourceModel1> IAsyncEnumerable<TrackedResourceModel1>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
