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
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using MgmtMockAndSample;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample.Tests.Mock
{
    /// <summary> Test for DiskEncryptionSetCollection. </summary>
    public partial class DiskEncryptionSetCollectionMockTests : MockTestBase
    {
        public DiskEncryptionSetCollectionMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task CreateOrUpdate_CreateADiskEncryptionSetWithKeyVaultFromADifferentSubscription()
        {
            // Example: Create a disk encryption set with key vault from a different subscription.

            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "myResourceGroup");
            ResourceGroupResource resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
            var collection = resourceGroupResource.GetDiskEncryptionSets();
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, "myDiskEncryptionSet", new DiskEncryptionSetData()
            {
                Identity = new ManagedServiceIdentity("SystemAssigned"),
                EncryptionType = DiskEncryptionSetType.EncryptionAtRestWithCustomerKey,
                ActiveKey = new KeyForDiskEncryptionSet(new Uri("https://myvaultdifferentsub.vault-int.azure-int.net/keys/{key}")),
                MinimumTlsVersion = MinimumTlsVersion.Tls1_1,
            });
        }

        [RecordedTest]
        public async Task CreateOrUpdate_CreateADiskEncryptionSetWithKeyVaultFromADifferentTenant()
        {
            // Example: Create a disk encryption set with key vault from a different tenant.

            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "myResourceGroup");
            ResourceGroupResource resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
            var collection = resourceGroupResource.GetDiskEncryptionSets();
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, "myDiskEncryptionSet", new DiskEncryptionSetData()
            {
                Identity = new ManagedServiceIdentity("UserAssigned")
                {
                    UserAssignedIdentities =
{
[new ResourceIdentifier("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}")] = new UserAssignedIdentity(),
},
                },
                EncryptionType = DiskEncryptionSetType.EncryptionAtRestWithCustomerKey,
                ActiveKey = new KeyForDiskEncryptionSet(new Uri("https://myvaultdifferenttenant.vault-int.azure-int.net/keys/{key}")),
                FederatedClientId = "00000000-0000-0000-0000-000000000000",
            });
        }

        [RecordedTest]
        public async Task CreateOrUpdate_CreateADiskEncryptionSet()
        {
            // Example: Create a disk encryption set.

            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "myResourceGroup");
            ResourceGroupResource resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
            var collection = resourceGroupResource.GetDiskEncryptionSets();
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, "myDiskEncryptionSet", new DiskEncryptionSetData()
            {
                Identity = new ManagedServiceIdentity("SystemAssigned"),
                EncryptionType = DiskEncryptionSetType.EncryptionAtRestWithCustomerKey,
                ActiveKey = new KeyForDiskEncryptionSet(new Uri("https://myvmvault.vault-int.azure-int.net/keys/{key}"))
                {
                    SourceVaultId = new ResourceIdentifier("/subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.KeyVault/vaults/myVMVault"),
                },
            });
        }

        [RecordedTest]
        public async Task Exists_GetInformationAboutADiskEncryptionSetWhenAutoKeyRotationFailed()
        {
            // Example: Get information about a disk encryption set when auto-key rotation failed.

            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "myResourceGroup");
            ResourceGroupResource resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
            var collection = resourceGroupResource.GetDiskEncryptionSets();
            await collection.ExistsAsync("myDiskEncryptionSet");
        }

        [RecordedTest]
        public async Task Exists_GetInformationAboutADiskEncryptionSet()
        {
            // Example: Get information about a disk encryption set.

            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "myResourceGroup");
            ResourceGroupResource resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
            var collection = resourceGroupResource.GetDiskEncryptionSets();
            await collection.ExistsAsync("myDiskEncryptionSet");
        }

        [RecordedTest]
        public async Task Get_GetInformationAboutADiskEncryptionSetWhenAutoKeyRotationFailed()
        {
            // Example: Get information about a disk encryption set when auto-key rotation failed.

            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "myResourceGroup");
            ResourceGroupResource resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
            var collection = resourceGroupResource.GetDiskEncryptionSets();
            await collection.GetAsync("myDiskEncryptionSet");
        }

        [RecordedTest]
        public async Task Get_GetInformationAboutADiskEncryptionSet()
        {
            // Example: Get information about a disk encryption set.

            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "myResourceGroup");
            ResourceGroupResource resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
            var collection = resourceGroupResource.GetDiskEncryptionSets();
            await collection.GetAsync("myDiskEncryptionSet");
        }

        [RecordedTest]
        public async Task GetAll()
        {
            // Example: List all disk encryption sets in a resource group.

            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "myResourceGroup");
            ResourceGroupResource resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
            var collection = resourceGroupResource.GetDiskEncryptionSets();
            await foreach (var _ in collection.GetAllAsync())
            {
            }
        }
    }
}
