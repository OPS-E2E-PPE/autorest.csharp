// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;

namespace ExactMatchFlattenInheritance.Models
{
    /// <summary> TrackedResource type. </summary>
    internal partial class TrackedResourceModel : Resource<TenantResourceIdentifier>
    {
        /// <summary> Initializes a new instance of TrackedResourceModel. </summary>
        internal TrackedResourceModel()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        public string Location { get; }
        /// <summary> Dictionary of &lt;string&gt;. </summary>
        public IReadOnlyDictionary<string, string> Tags { get; }
    }
}
