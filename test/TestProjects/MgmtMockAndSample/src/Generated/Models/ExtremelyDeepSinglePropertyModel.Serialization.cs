// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    internal partial class ExtremelyDeepSinglePropertyModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Extreme))
            {
                writer.WritePropertyName("extreme");
                writer.WriteObjectValue(Extreme);
            }
            writer.WriteEndObject();
        }

        internal static ExtremelyDeepSinglePropertyModel DeserializeExtremelyDeepSinglePropertyModel(JsonElement element)
        {
            Optional<SuperDeepSinglePropertyModel> extreme = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("extreme"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    extreme = SuperDeepSinglePropertyModel.DeserializeSuperDeepSinglePropertyModel(property.Value);
                    continue;
                }
            }
            return new ExtremelyDeepSinglePropertyModel(extreme.Value);
        }
    }
}
