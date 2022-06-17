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
    /// <summary> Test for MhsmPrivateEndpointConnectionResource. </summary>
    public partial class MhsmPrivateEndpointConnectionResourceMockTests : MockTestBase
    {
        public MhsmPrivateEndpointConnectionResourceMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task Delete()
        {
            // Example: ManagedHsmDeletePrivateEndpointConnection

            var mhsmPrivateEndpointConnectionResourceId = MgmtKeyvault.MhsmPrivateEndpointConnectionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-mhsm", "sample-pec");
            var mhsmPrivateEndpointConnectionResource = GetArmClient().GetMhsmPrivateEndpointConnectionResource(mhsmPrivateEndpointConnectionResourceId);
            await mhsmPrivateEndpointConnectionResource.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task Get()
        {
            // Example: ManagedHsmGetPrivateEndpointConnection

            var mhsmPrivateEndpointConnectionResourceId = MgmtKeyvault.MhsmPrivateEndpointConnectionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-mhsm", "sample-pec");
            var mhsmPrivateEndpointConnectionResource = GetArmClient().GetMhsmPrivateEndpointConnectionResource(mhsmPrivateEndpointConnectionResourceId);
            await mhsmPrivateEndpointConnectionResource.GetAsync();
        }

        [RecordedTest]
        public async Task Update()
        {
            // Example: ManagedHsmPutPrivateEndpointConnection

            var mhsmPrivateEndpointConnectionResourceId = MgmtKeyvault.MhsmPrivateEndpointConnectionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-mhsm", "sample-pec");
            var mhsmPrivateEndpointConnectionResource = GetArmClient().GetMhsmPrivateEndpointConnectionResource(mhsmPrivateEndpointConnectionResourceId);
            await mhsmPrivateEndpointConnectionResource.UpdateAsync(WaitUntil.Completed, default);
        }
    }
}
