// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace ModelsInCadl
{
    internal static partial class FixedStringEnumExtensions
    {
        public static string ToSerialString(this FixedStringEnum value) => value switch
        {
            FixedStringEnum.One => "1",
            FixedStringEnum.Two => "2",
            FixedStringEnum.Four => "4",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown FixedStringEnum value.")
        };

        public static FixedStringEnum ToFixedStringEnum(this string value)
        {
            if (string.Equals(value, "1", StringComparison.InvariantCultureIgnoreCase)) return FixedStringEnum.One;
            if (string.Equals(value, "2", StringComparison.InvariantCultureIgnoreCase)) return FixedStringEnum.Two;
            if (string.Equals(value, "4", StringComparison.InvariantCultureIgnoreCase)) return FixedStringEnum.Four;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown FixedStringEnum value.");
        }
    }
}
