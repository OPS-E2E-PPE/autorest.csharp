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
using MgmtExtensionResource.Models;

namespace MgmtExtensionResource
{
    /// <summary> A class representing collection of PolicyDefinition and their operations over its parent. </summary>
    public partial class SubscriptionPolicyDefinitionCollection : ArmCollection, IEnumerable<SubscriptionPolicyDefinition>, IAsyncEnumerable<SubscriptionPolicyDefinition>
    {
        private readonly ClientDiagnostics _subscriptionPolicyDefinitionPolicyDefinitionsClientDiagnostics;
        private readonly PolicyDefinitionsRestOperations _subscriptionPolicyDefinitionPolicyDefinitionsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubscriptionPolicyDefinitionCollection"/> class for mocking. </summary>
        protected SubscriptionPolicyDefinitionCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SubscriptionPolicyDefinitionCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal SubscriptionPolicyDefinitionCollection(ArmResource parent) : base(parent)
        {
            _subscriptionPolicyDefinitionPolicyDefinitionsClientDiagnostics = new ClientDiagnostics("MgmtExtensionResource", SubscriptionPolicyDefinition.ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(SubscriptionPolicyDefinition.ResourceType, out string subscriptionPolicyDefinitionPolicyDefinitionsApiVersion);
            _subscriptionPolicyDefinitionPolicyDefinitionsRestClient = new PolicyDefinitionsRestOperations(_subscriptionPolicyDefinitionPolicyDefinitionsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, subscriptionPolicyDefinitionPolicyDefinitionsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Subscription.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Subscription.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: PolicyDefinitions_CreateOrUpdate
        /// <summary> This operation creates or updates a policy definition in the given subscription with the given name. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="policyDefinitionName"> The name of the policy definition to create. </param>
        /// <param name="parameters"> The policy definition properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyDefinitionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyDefinitionName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual SubscriptionPolicyDefinitionCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string policyDefinitionName, PolicyDefinitionData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyDefinitionName, nameof(policyDefinitionName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _subscriptionPolicyDefinitionPolicyDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicyDefinitionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _subscriptionPolicyDefinitionPolicyDefinitionsRestClient.CreateOrUpdate(Id.SubscriptionId, policyDefinitionName, parameters, cancellationToken);
                var operation = new SubscriptionPolicyDefinitionCreateOrUpdateOperation(ArmClient, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: PolicyDefinitions_CreateOrUpdate
        /// <summary> This operation creates or updates a policy definition in the given subscription with the given name. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="policyDefinitionName"> The name of the policy definition to create. </param>
        /// <param name="parameters"> The policy definition properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyDefinitionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyDefinitionName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<SubscriptionPolicyDefinitionCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string policyDefinitionName, PolicyDefinitionData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyDefinitionName, nameof(policyDefinitionName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _subscriptionPolicyDefinitionPolicyDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicyDefinitionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _subscriptionPolicyDefinitionPolicyDefinitionsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, policyDefinitionName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SubscriptionPolicyDefinitionCreateOrUpdateOperation(ArmClient, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: PolicyDefinitions_Get
        /// <summary> This operation retrieves the policy definition in the given subscription with the given name. </summary>
        /// <param name="policyDefinitionName"> The name of the policy definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyDefinitionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyDefinitionName"/> is null. </exception>
        public virtual Response<SubscriptionPolicyDefinition> Get(string policyDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyDefinitionName, nameof(policyDefinitionName));

            using var scope = _subscriptionPolicyDefinitionPolicyDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicyDefinitionCollection.Get");
            scope.Start();
            try
            {
                var response = _subscriptionPolicyDefinitionPolicyDefinitionsRestClient.Get(Id.SubscriptionId, policyDefinitionName, cancellationToken);
                if (response.Value == null)
                    throw _subscriptionPolicyDefinitionPolicyDefinitionsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SubscriptionPolicyDefinition(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: PolicyDefinitions_Get
        /// <summary> This operation retrieves the policy definition in the given subscription with the given name. </summary>
        /// <param name="policyDefinitionName"> The name of the policy definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyDefinitionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyDefinitionName"/> is null. </exception>
        public async virtual Task<Response<SubscriptionPolicyDefinition>> GetAsync(string policyDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyDefinitionName, nameof(policyDefinitionName));

            using var scope = _subscriptionPolicyDefinitionPolicyDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicyDefinitionCollection.Get");
            scope.Start();
            try
            {
                var response = await _subscriptionPolicyDefinitionPolicyDefinitionsRestClient.GetAsync(Id.SubscriptionId, policyDefinitionName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _subscriptionPolicyDefinitionPolicyDefinitionsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SubscriptionPolicyDefinition(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="policyDefinitionName"> The name of the policy definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyDefinitionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyDefinitionName"/> is null. </exception>
        public virtual Response<SubscriptionPolicyDefinition> GetIfExists(string policyDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyDefinitionName, nameof(policyDefinitionName));

            using var scope = _subscriptionPolicyDefinitionPolicyDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicyDefinitionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _subscriptionPolicyDefinitionPolicyDefinitionsRestClient.Get(Id.SubscriptionId, policyDefinitionName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SubscriptionPolicyDefinition>(null, response.GetRawResponse());
                return Response.FromValue(new SubscriptionPolicyDefinition(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="policyDefinitionName"> The name of the policy definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyDefinitionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyDefinitionName"/> is null. </exception>
        public async virtual Task<Response<SubscriptionPolicyDefinition>> GetIfExistsAsync(string policyDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyDefinitionName, nameof(policyDefinitionName));

            using var scope = _subscriptionPolicyDefinitionPolicyDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicyDefinitionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _subscriptionPolicyDefinitionPolicyDefinitionsRestClient.GetAsync(Id.SubscriptionId, policyDefinitionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SubscriptionPolicyDefinition>(null, response.GetRawResponse());
                return Response.FromValue(new SubscriptionPolicyDefinition(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="policyDefinitionName"> The name of the policy definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyDefinitionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyDefinitionName"/> is null. </exception>
        public virtual Response<bool> Exists(string policyDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyDefinitionName, nameof(policyDefinitionName));

            using var scope = _subscriptionPolicyDefinitionPolicyDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicyDefinitionCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(policyDefinitionName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="policyDefinitionName"> The name of the policy definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyDefinitionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyDefinitionName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string policyDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyDefinitionName, nameof(policyDefinitionName));

            using var scope = _subscriptionPolicyDefinitionPolicyDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicyDefinitionCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(policyDefinitionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: PolicyDefinitions_List
        /// <summary> This operation retrieves a list of all the policy definitions in a given subscription that match the optional given $filter. Valid values for $filter are: &apos;atExactScope()&apos;, &apos;policyType -eq {value}&apos; or &apos;category eq &apos;{value}&apos;&apos;. If $filter is not provided, the unfiltered list includes all policy definitions associated with the subscription, including those that apply directly or from management groups that contain the given subscription. If $filter=atExactScope() is provided, the returned list only includes all policy definitions that at the given subscription. If $filter=&apos;policyType -eq {value}&apos; is provided, the returned list only includes all policy definitions whose type match the {value}. Possible policyType values are NotSpecified, BuiltIn, Custom, and Static. If $filter=&apos;category -eq {value}&apos; is provided, the returned list only includes all policy definitions whose category match the {value}. </summary>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: &apos;atExactScope()&apos;, &apos;policyType -eq {value}&apos; or &apos;category eq &apos;{value}&apos;&apos;. If $filter is not provided, no filtering is performed. If $filter=atExactScope() is provided, the returned list only includes all policy definitions that at the given scope. If $filter=&apos;policyType -eq {value}&apos; is provided, the returned list only includes all policy definitions whose type match the {value}. Possible policyType values are NotSpecified, BuiltIn, Custom, and Static. If $filter=&apos;category -eq {value}&apos; is provided, the returned list only includes all policy definitions whose category match the {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubscriptionPolicyDefinition" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SubscriptionPolicyDefinition> GetAll(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Page<SubscriptionPolicyDefinition> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _subscriptionPolicyDefinitionPolicyDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicyDefinitionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _subscriptionPolicyDefinitionPolicyDefinitionsRestClient.List(Id.SubscriptionId, filter, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionPolicyDefinition(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SubscriptionPolicyDefinition> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _subscriptionPolicyDefinitionPolicyDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicyDefinitionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _subscriptionPolicyDefinitionPolicyDefinitionsRestClient.ListNextPage(nextLink, Id.SubscriptionId, filter, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionPolicyDefinition(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: PolicyDefinitions_List
        /// <summary> This operation retrieves a list of all the policy definitions in a given subscription that match the optional given $filter. Valid values for $filter are: &apos;atExactScope()&apos;, &apos;policyType -eq {value}&apos; or &apos;category eq &apos;{value}&apos;&apos;. If $filter is not provided, the unfiltered list includes all policy definitions associated with the subscription, including those that apply directly or from management groups that contain the given subscription. If $filter=atExactScope() is provided, the returned list only includes all policy definitions that at the given subscription. If $filter=&apos;policyType -eq {value}&apos; is provided, the returned list only includes all policy definitions whose type match the {value}. Possible policyType values are NotSpecified, BuiltIn, Custom, and Static. If $filter=&apos;category -eq {value}&apos; is provided, the returned list only includes all policy definitions whose category match the {value}. </summary>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: &apos;atExactScope()&apos;, &apos;policyType -eq {value}&apos; or &apos;category eq &apos;{value}&apos;&apos;. If $filter is not provided, no filtering is performed. If $filter=atExactScope() is provided, the returned list only includes all policy definitions that at the given scope. If $filter=&apos;policyType -eq {value}&apos; is provided, the returned list only includes all policy definitions whose type match the {value}. Possible policyType values are NotSpecified, BuiltIn, Custom, and Static. If $filter=&apos;category -eq {value}&apos; is provided, the returned list only includes all policy definitions whose category match the {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubscriptionPolicyDefinition" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SubscriptionPolicyDefinition> GetAllAsync(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SubscriptionPolicyDefinition>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _subscriptionPolicyDefinitionPolicyDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicyDefinitionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _subscriptionPolicyDefinitionPolicyDefinitionsRestClient.ListAsync(Id.SubscriptionId, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionPolicyDefinition(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SubscriptionPolicyDefinition>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _subscriptionPolicyDefinitionPolicyDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicyDefinitionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _subscriptionPolicyDefinitionPolicyDefinitionsRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionPolicyDefinition(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        IEnumerator<SubscriptionPolicyDefinition> IEnumerable<SubscriptionPolicyDefinition>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SubscriptionPolicyDefinition> IAsyncEnumerable<SubscriptionPolicyDefinition>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
