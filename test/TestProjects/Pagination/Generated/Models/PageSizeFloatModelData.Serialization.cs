// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager;

namespace Pagination
{
    public partial class PageSizeFloatModelData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        internal static PageSizeFloatModelData DeserializePageSizeFloatModelData(JsonElement element)
        {
            Optional<string> name = default;
            Optional<string> type = default;
            ResourceGroupResourceIdentifier id = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
            }
            return new PageSizeFloatModelData(id, name.Value, type.Value);
        }
    }
}
