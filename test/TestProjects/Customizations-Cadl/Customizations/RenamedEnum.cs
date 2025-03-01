// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace CustomizationsInCadl
{
    /// <summary> Renamed enum (original name: EnumToRename). </summary>
    [CodeGenModel("EnumToRename")]
    public enum RenamedEnum
    {
        /// <summary> 1. </summary>
        One,
        /// <summary> 2. </summary>
        Two,
        /// <summary> 3. </summary>
        Three
    }
}
