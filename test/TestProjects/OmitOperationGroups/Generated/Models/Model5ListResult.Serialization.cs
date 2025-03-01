// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace OmitOperationGroups.Models
{
    internal partial class Model5ListResult
    {
        internal static Model5ListResult DeserializeModel5ListResult(JsonElement element)
        {
            Optional<IReadOnlyList<Model5>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<Model5> array = new List<Model5>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(Model5.DeserializeModel5(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new Model5ListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
