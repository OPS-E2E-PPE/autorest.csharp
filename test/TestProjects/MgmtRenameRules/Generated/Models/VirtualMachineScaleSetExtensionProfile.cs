// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtRenameRules;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Describes a virtual machine scale set extension profile.
    /// Serialized Name: VirtualMachineScaleSetExtensionProfile
    /// </summary>
    public partial class VirtualMachineScaleSetExtensionProfile
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetExtensionProfile. </summary>
        public VirtualMachineScaleSetExtensionProfile()
        {
            Extensions = new ChangeTrackingList<VirtualMachineScaleSetExtensionData>();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetExtensionProfile. </summary>
        /// <param name="extensions">
        /// The virtual machine scale set child extension resources.
        /// Serialized Name: VirtualMachineScaleSetExtensionProfile.extensions
        /// </param>
        /// <param name="extensionsTimeBudget">
        /// Specifies the time alloted for all extensions to start. The time duration should be between 15 minutes and 120 minutes (inclusive) and should be specified in ISO 8601 format. The default value is 90 minutes (PT1H30M). &lt;br&gt;&lt;br&gt; Minimum api-version: 2020-06-01
        /// Serialized Name: VirtualMachineScaleSetExtensionProfile.extensionsTimeBudget
        /// </param>
        internal VirtualMachineScaleSetExtensionProfile(IList<VirtualMachineScaleSetExtensionData> extensions, string extensionsTimeBudget)
        {
            Extensions = extensions;
            ExtensionsTimeBudget = extensionsTimeBudget;
        }

        /// <summary>
        /// The virtual machine scale set child extension resources.
        /// Serialized Name: VirtualMachineScaleSetExtensionProfile.extensions
        /// </summary>
        public IList<VirtualMachineScaleSetExtensionData> Extensions { get; }
        /// <summary>
        /// Specifies the time alloted for all extensions to start. The time duration should be between 15 minutes and 120 minutes (inclusive) and should be specified in ISO 8601 format. The default value is 90 minutes (PT1H30M). &lt;br&gt;&lt;br&gt; Minimum api-version: 2020-06-01
        /// Serialized Name: VirtualMachineScaleSetExtensionProfile.extensionsTimeBudget
        /// </summary>
        public string ExtensionsTimeBudget { get; set; }
    }
}
