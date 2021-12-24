// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtExpandResourceTypes.Models
{
    public partial class ARecord : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Ipv4Address))
            {
                writer.WritePropertyName("ipv4Address");
                writer.WriteStringValue(Ipv4Address);
            }
            writer.WriteEndObject();
        }

        internal static ARecord DeserializeARecord(JsonElement element)
        {
            Optional<string> ipv4Address = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ipv4Address"))
                {
                    ipv4Address = property.Value.GetString();
                    continue;
                }
            }
            return new ARecord(ipv4Address.Value);
        }
    }
}
