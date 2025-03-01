// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtResourceName.Models
{
    /// <summary> Resource Type. </summary>
    public partial class ResourceType
    {
        /// <summary> Initializes a new instance of ResourceType. </summary>
        internal ResourceType()
        {
            Operations = new ChangeTrackingList<ResourceOperation>();
        }

        /// <summary> Initializes a new instance of ResourceType. </summary>
        /// <param name="name"> The resource type name. </param>
        /// <param name="displayName"> The resource type display name. </param>
        /// <param name="operations"> The resource type operations. </param>
        internal ResourceType(string name, string displayName, IReadOnlyList<ResourceOperation> operations)
        {
            Name = name;
            DisplayName = displayName;
            Operations = operations;
        }

        /// <summary> The resource type name. </summary>
        public string Name { get; }
        /// <summary> The resource type display name. </summary>
        public string DisplayName { get; }
        /// <summary> The resource type operations. </summary>
        public IReadOnlyList<ResourceOperation> Operations { get; }
    }
}
