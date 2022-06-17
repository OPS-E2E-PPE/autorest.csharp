// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Net;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;
using MgmtKeyvault;

namespace MgmtKeyvault.Tests.Mock
{
    /// <summary> Test for MgmtKeyvaultPrivateEndpointConnectionCollection. </summary>
    public partial class MgmtKeyvaultPrivateEndpointConnectionCollectionMockTests : MockTestBase
    {
        public MgmtKeyvaultPrivateEndpointConnectionCollectionMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            // Example: KeyVaultPutPrivateEndpointConnection

            var vaultResourceId = MgmtKeyvault.VaultResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-vault");
            var vaultResource = GetArmClient().GetVaultResource(vaultResourceId);
            var collection = vaultResource.GetMgmtKeyvaultPrivateEndpointConnections();
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, "sample-pec", default);
        }

        [RecordedTest]
        public async Task Exists()
        {
            // Example: KeyVaultGetPrivateEndpointConnection

            var vaultResourceId = MgmtKeyvault.VaultResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-vault");
            var vaultResource = GetArmClient().GetVaultResource(vaultResourceId);
            var collection = vaultResource.GetMgmtKeyvaultPrivateEndpointConnections();
            await collection.ExistsAsync("sample-pec");
        }

        [RecordedTest]
        public async Task Get()
        {
            // Example: KeyVaultGetPrivateEndpointConnection

            var vaultResourceId = MgmtKeyvault.VaultResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-vault");
            var vaultResource = GetArmClient().GetVaultResource(vaultResourceId);
            var collection = vaultResource.GetMgmtKeyvaultPrivateEndpointConnections();
            await collection.GetAsync("sample-pec");
        }

        [RecordedTest]
        public async Task GetAll()
        {
            // Example: KeyVaultListPrivateEndpointConnection

            var vaultResourceId = MgmtKeyvault.VaultResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-vault");
            var vaultResource = GetArmClient().GetVaultResource(vaultResourceId);
            var collection = vaultResource.GetMgmtKeyvaultPrivateEndpointConnections();
            await foreach (var _ in collection.GetAllAsync())
            {
            }
        }
    }
}
