// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Management.Storage.Models
{
    internal partial class KeyPolicy : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("keyExpirationPeriodInDays");
            writer.WriteNumberValue(KeyExpirationPeriodInDays);
            writer.WriteEndObject();
        }

        internal static KeyPolicy DeserializeKeyPolicy(JsonElement element)
        {
            int keyExpirationPeriodInDays = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("keyExpirationPeriodInDays"))
                {
                    keyExpirationPeriodInDays = property.Value.GetInt32();
                    continue;
                }
            }
            return new KeyPolicy(keyExpirationPeriodInDays);
        }
    }
}
