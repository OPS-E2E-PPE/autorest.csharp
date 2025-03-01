// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using NoTypeReplacement;

namespace NoTypeReplacement.Models
{
    /// <summary> The response from the List Storage Accounts operation. </summary>
    internal partial class NoTypeReplacementModel2ListResult
    {
        /// <summary> Initializes a new instance of NoTypeReplacementModel2ListResult. </summary>
        internal NoTypeReplacementModel2ListResult()
        {
            Value = new ChangeTrackingList<NoTypeReplacementModel2Data>();
        }

        /// <summary> Initializes a new instance of NoTypeReplacementModel2ListResult. </summary>
        /// <param name="value"> Gets the list of storage accounts and their properties. </param>
        /// <param name="nextLink"> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </param>
        internal NoTypeReplacementModel2ListResult(IReadOnlyList<NoTypeReplacementModel2Data> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Gets the list of storage accounts and their properties. </summary>
        public IReadOnlyList<NoTypeReplacementModel2Data> Value { get; }
        /// <summary> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </summary>
        public string NextLink { get; }
    }
}
