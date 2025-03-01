// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using SupersetFlattenInheritance;

namespace SupersetFlattenInheritance.Models
{
    /// <summary> The response from the List Storage Accounts operation. </summary>
    internal partial class TrackedResourceModel1ListResult
    {
        /// <summary> Initializes a new instance of TrackedResourceModel1ListResult. </summary>
        internal TrackedResourceModel1ListResult()
        {
            Value = new ChangeTrackingList<TrackedResourceModel1Data>();
        }

        /// <summary> Initializes a new instance of TrackedResourceModel1ListResult. </summary>
        /// <param name="value"> Gets the list of storage accounts and their properties. </param>
        /// <param name="nextLink"> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </param>
        internal TrackedResourceModel1ListResult(IReadOnlyList<TrackedResourceModel1Data> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Gets the list of storage accounts and their properties. </summary>
        public IReadOnlyList<TrackedResourceModel1Data> Value { get; }
        /// <summary> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </summary>
        public string NextLink { get; }
    }
}
