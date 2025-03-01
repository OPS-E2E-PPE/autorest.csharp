// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Net;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;
using MgmtMockAndSample;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample.Tests.Mock
{
    /// <summary> Test for MhsmPrivateEndpointConnectionCollection. </summary>
    public partial class MhsmPrivateEndpointConnectionCollectionMockTests : MockTestBase
    {
        public MhsmPrivateEndpointConnectionCollectionMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            // Example: ManagedHsmPutPrivateEndpointConnection

            ResourceIdentifier managedHsmResourceId = ManagedHsmResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-mhsm");
            ManagedHsmResource managedHsm = GetArmClient().GetManagedHsmResource(managedHsmResourceId);
            var collection = managedHsm.GetMhsmPrivateEndpointConnections();
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, "sample-pec", new MhsmPrivateEndpointConnectionData(new AzureLocation("placeholder"))
            {
                PrivateLinkServiceConnectionState = new MhsmPrivateLinkServiceConnectionState()
                {
                    Status = MgmtMockAndSamplePrivateEndpointServiceConnectionStatus.Approved,
                    Description = "My name is Joe and I'm approving this.",
                },
            });
        }

        [RecordedTest]
        public async Task Exists()
        {
            // Example: ManagedHsmGetPrivateEndpointConnection

            ResourceIdentifier managedHsmResourceId = ManagedHsmResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-mhsm");
            ManagedHsmResource managedHsm = GetArmClient().GetManagedHsmResource(managedHsmResourceId);
            var collection = managedHsm.GetMhsmPrivateEndpointConnections();
            await collection.ExistsAsync("sample-pec");
        }

        [RecordedTest]
        public async Task Get()
        {
            // Example: ManagedHsmGetPrivateEndpointConnection

            ResourceIdentifier managedHsmResourceId = ManagedHsmResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-mhsm");
            ManagedHsmResource managedHsm = GetArmClient().GetManagedHsmResource(managedHsmResourceId);
            var collection = managedHsm.GetMhsmPrivateEndpointConnections();
            await collection.GetAsync("sample-pec");
        }

        [RecordedTest]
        public async Task GetAll()
        {
            // Example: List managed HSM Pools in a subscription

            ResourceIdentifier managedHsmResourceId = ManagedHsmResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-mhsm");
            ManagedHsmResource managedHsm = GetArmClient().GetManagedHsmResource(managedHsmResourceId);
            var collection = managedHsm.GetMhsmPrivateEndpointConnections();
            await foreach (var _ in collection.GetAllAsync())
            {
            }
        }
    }
}
