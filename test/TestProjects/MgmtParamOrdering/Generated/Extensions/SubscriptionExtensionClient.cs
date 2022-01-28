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

namespace MgmtParamOrdering
{
    /// <summary> An internal class to add extension methods to. </summary>
    internal partial class SubscriptionExtensionClient : ArmResource
    {
        private ClientDiagnostics _availabilitySetClientDiagnostics;
        private AvailabilitySetsRestOperations _availabilitySetRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubscriptionExtensionClient"/> class for mocking. </summary>
        protected SubscriptionExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SubscriptionExtensionClient"/> class. </summary>
        /// <param name="armClient"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SubscriptionExtensionClient(ArmClient armClient, ResourceIdentifier id) : base(armClient, id)
        {
        }

        private ClientDiagnostics AvailabilitySetClientDiagnostics => _availabilitySetClientDiagnostics ??= new ClientDiagnostics("MgmtParamOrdering", AvailabilitySet.ResourceType.Namespace, DiagnosticOptions);
        private AvailabilitySetsRestOperations AvailabilitySetRestClient => _availabilitySetRestClient ??= new AvailabilitySetsRestOperations(AvailabilitySetClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, GetApiVersionOrNull(AvailabilitySet.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            ArmClient.TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/availabilitySets
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: AvailabilitySets_ListBySubscription
        /// <summary> Lists all availability sets in a subscription. </summary>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are &apos;instanceView&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AvailabilitySet" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AvailabilitySet> GetAvailabilitySetsAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<AvailabilitySet>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = AvailabilitySetClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetAvailabilitySets");
                scope.Start();
                try
                {
                    var response = await AvailabilitySetRestClient.ListBySubscriptionAsync(Id.SubscriptionId, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new AvailabilitySet(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<AvailabilitySet>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = AvailabilitySetClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetAvailabilitySets");
                scope.Start();
                try
                {
                    var response = await AvailabilitySetRestClient.ListBySubscriptionNextPageAsync(nextLink, Id.SubscriptionId, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new AvailabilitySet(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/availabilitySets
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: AvailabilitySets_ListBySubscription
        /// <summary> Lists all availability sets in a subscription. </summary>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are &apos;instanceView&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AvailabilitySet" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AvailabilitySet> GetAvailabilitySets(string expand = null, CancellationToken cancellationToken = default)
        {
            Page<AvailabilitySet> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = AvailabilitySetClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetAvailabilitySets");
                scope.Start();
                try
                {
                    var response = AvailabilitySetRestClient.ListBySubscription(Id.SubscriptionId, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new AvailabilitySet(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<AvailabilitySet> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = AvailabilitySetClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetAvailabilitySets");
                scope.Start();
                try
                {
                    var response = AvailabilitySetRestClient.ListBySubscriptionNextPage(nextLink, Id.SubscriptionId, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new AvailabilitySet(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
