// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Management.Storage.Models
{
    public partial class UpdateHistoryProperty
    {
        internal static UpdateHistoryProperty DeserializeUpdateHistoryProperty(JsonElement element)
        {
            Optional<ImmutabilityPolicyUpdateType> update = default;
            Optional<int> immutabilityPeriodSinceCreationInDays = default;
            Optional<DateTimeOffset> timestamp = default;
            Optional<string> objectIdentifier = default;
            Optional<Guid> tenantId = default;
            Optional<string> upn = default;
            Optional<bool> allowProtectedAppendWrites = default;
            Optional<bool> allowProtectedAppendWritesAll = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("update"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    update = new ImmutabilityPolicyUpdateType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("immutabilityPeriodSinceCreationInDays"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    immutabilityPeriodSinceCreationInDays = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("timestamp"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    timestamp = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("objectIdentifier"))
                {
                    objectIdentifier = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("tenantId"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    tenantId = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("upn"))
                {
                    upn = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("allowProtectedAppendWrites"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    allowProtectedAppendWrites = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("allowProtectedAppendWritesAll"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    allowProtectedAppendWritesAll = property.Value.GetBoolean();
                    continue;
                }
            }
            return new UpdateHistoryProperty(Optional.ToNullable(update), Optional.ToNullable(immutabilityPeriodSinceCreationInDays), Optional.ToNullable(timestamp), objectIdentifier.Value, Optional.ToNullable(tenantId), upn.Value, Optional.ToNullable(allowProtectedAppendWrites), Optional.ToNullable(allowProtectedAppendWritesAll));
        }
    }
}
