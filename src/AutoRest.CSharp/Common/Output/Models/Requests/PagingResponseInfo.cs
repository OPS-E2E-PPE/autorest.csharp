// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;
using Azure;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class PagingResponseInfo
    {
        public PagingResponseInfo(string? nextLinkName, string? itemName, CSharpType type)
        {
            ResponseType = type;

            TypeProvider implementation = type.Implementation;
            if (!(implementation is SchemaObjectType objectType))
            {
                throw new InvalidOperationException($"The type '{type}' has to be an object schema to be used in paging");
            }

            itemName ??= "value";

            ObjectTypeProperty itemProperty = objectType.GetPropertyBySerializedName(itemName);

            ObjectTypeProperty? nextLinkProperty = null;
            if (!string.IsNullOrWhiteSpace(nextLinkName))
            {
                nextLinkProperty = objectType.GetPropertyBySerializedName(nextLinkName);
            }

            if (!TypeFactory.IsList(itemProperty.Declaration.Type))
            {
                throw new InvalidOperationException($"'{itemName}' property must be be an array schema instead of '{itemProperty.SchemaProperty?.Schema}'");
            }

            CSharpType itemType = TypeFactory.GetElementType(itemProperty.Declaration.Type);
            NextLinkProperty = nextLinkProperty;
            ItemProperty = itemProperty;
            ItemType = itemType;
        }

        public CSharpType ResponseType { get; }
        public ObjectTypeProperty? NextLinkProperty { get; }
        public ObjectTypeProperty ItemProperty { get; }
        public CSharpType PageType => new CSharpType(typeof(Page<>), ItemType);
        public CSharpType ItemType { get; }
    }
}
