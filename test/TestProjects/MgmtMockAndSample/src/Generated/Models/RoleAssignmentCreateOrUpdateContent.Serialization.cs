// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    public partial class RoleAssignmentCreateOrUpdateContent : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (Optional.IsDefined(RoleDefinitionId))
            {
                writer.WritePropertyName("roleDefinitionId");
                writer.WriteStringValue(RoleDefinitionId);
            }
            if (Optional.IsDefined(PrincipalId))
            {
                writer.WritePropertyName("principalId");
                writer.WriteStringValue(PrincipalId);
            }
            if (Optional.IsDefined(CanDelegate))
            {
                writer.WritePropertyName("canDelegate");
                writer.WriteBooleanValue(CanDelegate.Value);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
    }
}
