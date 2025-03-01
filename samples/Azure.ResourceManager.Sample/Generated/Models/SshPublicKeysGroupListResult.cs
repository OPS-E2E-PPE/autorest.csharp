// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.ResourceManager.Sample;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The list SSH public keys operation response.
    /// Serialized Name: SshPublicKeysGroupListResult
    /// </summary>
    internal partial class SshPublicKeysGroupListResult
    {
        /// <summary> Initializes a new instance of SshPublicKeysGroupListResult. </summary>
        /// <param name="value">
        /// The list of SSH public keys
        /// Serialized Name: SshPublicKeysGroupListResult.value
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal SshPublicKeysGroupListResult(IEnumerable<SshPublicKeyData> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of SshPublicKeysGroupListResult. </summary>
        /// <param name="value">
        /// The list of SSH public keys
        /// Serialized Name: SshPublicKeysGroupListResult.value
        /// </param>
        /// <param name="nextLink">
        /// The URI to fetch the next page of SSH public keys. Call ListNext() with this URI to fetch the next page of SSH public keys.
        /// Serialized Name: SshPublicKeysGroupListResult.nextLink
        /// </param>
        internal SshPublicKeysGroupListResult(IReadOnlyList<SshPublicKeyData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary>
        /// The list of SSH public keys
        /// Serialized Name: SshPublicKeysGroupListResult.value
        /// </summary>
        public IReadOnlyList<SshPublicKeyData> Value { get; }
        /// <summary>
        /// The URI to fetch the next page of SSH public keys. Call ListNext() with this URI to fetch the next page of SSH public keys.
        /// Serialized Name: SshPublicKeysGroupListResult.nextLink
        /// </summary>
        public string NextLink { get; }
    }
}
