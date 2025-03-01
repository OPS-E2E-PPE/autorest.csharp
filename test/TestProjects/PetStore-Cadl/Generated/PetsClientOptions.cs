// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace CadlPetStore
{
    /// <summary> Client options for PetsClient. </summary>
    public partial class PetsClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2021_03_25;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2021-03-25". </summary>
            V2021_03_25 = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of PetsClientOptions. </summary>
        public PetsClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2021_03_25 => "2021-03-25",
                _ => throw new NotSupportedException()
            };
        }
    }
}
