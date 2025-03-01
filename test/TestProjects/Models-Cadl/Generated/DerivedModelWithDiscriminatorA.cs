// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace ModelsInCadl
{
    /// <summary> Deriver model with discriminator property. </summary>
    public partial class DerivedModelWithDiscriminatorA
    {
        /// <summary> Initializes a new instance of DerivedModelWithDiscriminatorA. </summary>
        /// <param name="requiredString"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredString"/> is null. </exception>
        public DerivedModelWithDiscriminatorA(string requiredString)
        {
            Argument.AssertNotNull(requiredString, nameof(requiredString));

            RequiredString = requiredString;
        }

        public string RequiredString { get; set; }
    }
}
