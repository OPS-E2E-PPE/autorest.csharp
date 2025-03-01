// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Management.Storage.Models
{
    public partial class LegalHoldProperties
    {
        internal static LegalHoldProperties DeserializeLegalHoldProperties(JsonElement element)
        {
            Optional<bool> hasLegalHold = default;
            Optional<IReadOnlyList<TagProperty>> tags = default;
            Optional<ProtectedAppendWritesHistory> protectedAppendWritesHistory = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("hasLegalHold"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    hasLegalHold = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("tags"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<TagProperty> array = new List<TagProperty>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TagProperty.DeserializeTagProperty(item));
                    }
                    tags = array;
                    continue;
                }
                if (property.NameEquals("protectedAppendWritesHistory"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    protectedAppendWritesHistory = ProtectedAppendWritesHistory.DeserializeProtectedAppendWritesHistory(property.Value);
                    continue;
                }
            }
            return new LegalHoldProperties(Optional.ToNullable(hasLegalHold), Optional.ToList(tags), protectedAppendWritesHistory.Value);
        }
    }
}
