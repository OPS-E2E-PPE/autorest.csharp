// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    internal partial class ResourceGroupResourceExtensionClient : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="ResourceGroupResourceExtensionClient"/> class for mocking. </summary>
        protected ResourceGroupResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResourceGroupResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ResourceGroupResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of AvailabilitySetResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of AvailabilitySetResources and their operations over a AvailabilitySetResource. </returns>
        public virtual AvailabilitySetCollection GetAvailabilitySets()
        {
            return GetCachedClient(Client => new AvailabilitySetCollection(Client, Id));
        }

        /// <summary> Gets a collection of ProximityPlacementGroupResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of ProximityPlacementGroupResources and their operations over a ProximityPlacementGroupResource. </returns>
        public virtual ProximityPlacementGroupCollection GetProximityPlacementGroups()
        {
            return GetCachedClient(Client => new ProximityPlacementGroupCollection(Client, Id));
        }

        /// <summary> Gets a collection of DedicatedHostGroupResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of DedicatedHostGroupResources and their operations over a DedicatedHostGroupResource. </returns>
        public virtual DedicatedHostGroupCollection GetDedicatedHostGroups()
        {
            return GetCachedClient(Client => new DedicatedHostGroupCollection(Client, Id));
        }

        /// <summary> Gets a collection of SshPublicKeyResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of SshPublicKeyResources and their operations over a SshPublicKeyResource. </returns>
        public virtual SshPublicKeyCollection GetSshPublicKeys()
        {
            return GetCachedClient(Client => new SshPublicKeyCollection(Client, Id));
        }

        /// <summary> Gets a collection of VirtualMachineResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of VirtualMachineResources and their operations over a VirtualMachineResource. </returns>
        public virtual VirtualMachineCollection GetVirtualMachines()
        {
            return GetCachedClient(Client => new VirtualMachineCollection(Client, Id));
        }

        /// <summary> Gets a collection of ImageResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of ImageResources and their operations over a ImageResource. </returns>
        public virtual ImageCollection GetImages()
        {
            return GetCachedClient(Client => new ImageCollection(Client, Id));
        }

        /// <summary> Gets a collection of VirtualMachineScaleSetResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of VirtualMachineScaleSetResources and their operations over a VirtualMachineScaleSetResource. </returns>
        public virtual VirtualMachineScaleSetCollection GetVirtualMachineScaleSets()
        {
            return GetCachedClient(Client => new VirtualMachineScaleSetCollection(Client, Id));
        }
    }
}
