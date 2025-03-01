// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.ResourceManager.Resources.Models;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Describes an Operating System disk.
    /// Serialized Name: ImageOSDisk
    /// </summary>
    public partial class ImageOSDisk : ImageDisk
    {
        /// <summary> Initializes a new instance of ImageOSDisk. </summary>
        /// <param name="osType">
        /// This property allows you to specify the type of the OS that is included in the disk if creating a VM from a custom image. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **Windows** &lt;br&gt;&lt;br&gt; **Linux**
        /// Serialized Name: ImageOSDisk.osType
        /// </param>
        /// <param name="osState">
        /// The OS State.
        /// Serialized Name: ImageOSDisk.osState
        /// </param>
        public ImageOSDisk(OperatingSystemType osType, OperatingSystemStateType osState)
        {
            OSType = osType;
            OSState = osState;
        }

        /// <summary> Initializes a new instance of ImageOSDisk. </summary>
        /// <param name="snapshot">
        /// The snapshot.
        /// Serialized Name: ImageDisk.snapshot
        /// </param>
        /// <param name="managedDisk">
        /// The managedDisk.
        /// Serialized Name: ImageDisk.managedDisk
        /// </param>
        /// <param name="blobUri">
        /// The Virtual Hard Disk.
        /// Serialized Name: ImageDisk.blobUri
        /// </param>
        /// <param name="caching">
        /// Specifies the caching requirements. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **ReadOnly** &lt;br&gt;&lt;br&gt; **ReadWrite** &lt;br&gt;&lt;br&gt; Default: **None for Standard storage. ReadOnly for Premium storage**
        /// Serialized Name: ImageDisk.caching
        /// </param>
        /// <param name="diskSizeGB">
        /// Specifies the size of empty data disks in gigabytes. This element can be used to overwrite the name of the disk in a virtual machine image. &lt;br&gt;&lt;br&gt; This value cannot be larger than 1023 GB
        /// Serialized Name: ImageDisk.diskSizeGB
        /// </param>
        /// <param name="storageAccountType">
        /// Specifies the storage account type for the managed disk. NOTE: UltraSSD_LRS can only be used with data disks, it cannot be used with OS Disk.
        /// Serialized Name: ImageDisk.storageAccountType
        /// </param>
        /// <param name="diskEncryptionSet">
        /// Specifies the customer managed disk encryption set resource id for the managed image disk.
        /// Serialized Name: ImageDisk.diskEncryptionSet
        /// </param>
        /// <param name="osType">
        /// This property allows you to specify the type of the OS that is included in the disk if creating a VM from a custom image. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **Windows** &lt;br&gt;&lt;br&gt; **Linux**
        /// Serialized Name: ImageOSDisk.osType
        /// </param>
        /// <param name="osState">
        /// The OS State.
        /// Serialized Name: ImageOSDisk.osState
        /// </param>
        internal ImageOSDisk(WritableSubResource snapshot, WritableSubResource managedDisk, Uri blobUri, CachingType? caching, int? diskSizeGB, StorageAccountType? storageAccountType, WritableSubResource diskEncryptionSet, OperatingSystemType osType, OperatingSystemStateType osState) : base(snapshot, managedDisk, blobUri, caching, diskSizeGB, storageAccountType, diskEncryptionSet)
        {
            OSType = osType;
            OSState = osState;
        }

        /// <summary>
        /// This property allows you to specify the type of the OS that is included in the disk if creating a VM from a custom image. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **Windows** &lt;br&gt;&lt;br&gt; **Linux**
        /// Serialized Name: ImageOSDisk.osType
        /// </summary>
        public OperatingSystemType OSType { get; set; }
        /// <summary>
        /// The OS State.
        /// Serialized Name: ImageOSDisk.osState
        /// </summary>
        public OperatingSystemStateType OSState { get; set; }
    }
}
