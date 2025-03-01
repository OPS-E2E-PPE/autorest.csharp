// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using MgmtMultipleParentResource;

namespace MgmtMultipleParentResource.Models
{
    /// <summary> The List run command operation response. </summary>
    internal partial class SubParentsListResult
    {
        /// <summary> Initializes a new instance of SubParentsListResult. </summary>
        /// <param name="value"> The list of run commands. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal SubParentsListResult(IEnumerable<SubParentData> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of SubParentsListResult. </summary>
        /// <param name="value"> The list of run commands. </param>
        /// <param name="nextLink"> The uri to fetch the next page of run commands. </param>
        internal SubParentsListResult(IReadOnlyList<SubParentData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of run commands. </summary>
        public IReadOnlyList<SubParentData> Value { get; }
        /// <summary> The uri to fetch the next page of run commands. </summary>
        public string NextLink { get; }
    }
}
