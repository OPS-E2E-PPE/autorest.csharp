﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Input;
using Azure.Core;

#pragma warning disable SA1649
namespace AutoRest.CSharp.Common.Input
{
    internal record InputNamespace(string Name, string Description, IReadOnlyList<string> ApiVersions, IReadOnlyList<InputEnumType> Enums, IReadOnlyList<InputModelType> Models, IReadOnlyList<InputClient> Clients, InputAuth Auth)
    {
        public InputNamespace() : this(Name: string.Empty, Description: string.Empty, ApiVersions: Array.Empty<string>(), Enums: Array.Empty<InputEnumType>(), Models: Array.Empty<InputModelType>(), Clients: Array.Empty<InputClient>(), Auth: new InputAuth()) {}
    }

    internal record InputAuth(InputApiKeyAuth? ApiKey, InputOAuth2Auth? OAuth2)
    {
        public InputAuth() : this(null, null) {}
    }

    internal record InputApiKeyAuth(string Name)
    {
        public InputApiKeyAuth() : this(string.Empty) { }
    }

    internal record InputOAuth2Auth(IReadOnlyCollection<string> Scopes)
    {
        public InputOAuth2Auth() : this(Array.Empty<string>()) {}
    }

    internal record InputClient(string Name, string Description, IReadOnlyList<InputOperation> Operations)
    {
        private readonly string? _key;

        public string Key
        {
            get => _key ?? Name;
            init => _key = value;
        }

        public InputClient() : this(string.Empty, string.Empty, Array.Empty<InputOperation>()) { }
    }

    internal record InputOperation(
        string Name,
        string? Summary,
        string Description,
        string? Accessibility,
        IReadOnlyList<InputParameter> Parameters,
        IReadOnlyList<OperationResponse> Responses,
        RequestMethod HttpMethod,
        BodyMediaType RequestBodyMediaType,
        string Uri,
        string Path,
        string? ExternalDocsUrl,
        IReadOnlyList<string>? RequestMediaTypes,
        bool BufferResponse,
        OperationLongRunning? LongRunning,
        OperationPaging? Paging,
        bool GenerateConvenienceMethod)
    {
        public InputOperation() : this(
            Name: string.Empty,
            Summary: null,
            Description: string.Empty,
            Accessibility: null,
            Parameters: Array.Empty<InputParameter>(),
            Responses: Array.Empty<OperationResponse>(),
            HttpMethod: RequestMethod.Get,
            RequestBodyMediaType: BodyMediaType.None,
            Uri: string.Empty,
            Path: string.Empty,
            ExternalDocsUrl: null,
            RequestMediaTypes: Array.Empty<string>(),
            BufferResponse: false,
            LongRunning: null,
            Paging: null,
            GenerateConvenienceMethod: false)
        { }
    }

    internal record InputParameter(
        string Name,
        string NameInRequest,
        string? Description,
        InputType Type,
        RequestLocation Location,
        InputConstant? DefaultValue,
        VirtualParameter? VirtualParameter,
        InputParameter? GroupedBy,
        InputOperationParameterKind Kind,
        bool IsRequired,
        bool IsApiVersion,
        bool IsResourceParameter,
        bool IsContentType,
        bool IsEndpoint,
        bool SkipUrlEncoding,
        bool Explode,
        string? ArraySerializationDelimiter,
        string? HeaderCollectionPrefix)
    {
        public InputParameter() : this(
            Name: string.Empty,
            NameInRequest: string.Empty,
            Description: null,
            Type: new InputPrimitiveType(InputTypeKind.Object),
            Location: RequestLocation.None,
            DefaultValue: null,
            VirtualParameter: null,
            GroupedBy: null,
            Kind: InputOperationParameterKind.Method,
            IsRequired: false,
            IsApiVersion: false,
            IsResourceParameter: false,
            IsContentType: false,
            IsEndpoint: false,
            SkipUrlEncoding: false,
            Explode: false,
            ArraySerializationDelimiter: null,
            HeaderCollectionPrefix: null)
        { }
    }

    internal record OperationResponse(IReadOnlyList<int> StatusCodes, InputType? BodyType, BodyMediaType BodyMediaType, IReadOnlyList<HttpResponseHeader> Headers)
    {
        public OperationResponse() : this(StatusCodes: Array.Empty<int>(), BodyType: null, BodyMediaType: BodyMediaType.None, Headers: Array.Empty<HttpResponseHeader>()) { }
    }

    internal record OperationLongRunning(OperationFinalStateVia FinalStateVia, OperationResponse FinalResponse);

    internal record OperationPaging(string? NextLinkName, string? ItemName)
    {
        public InputOperation? NextLinkOperation => NextLinkOperationRef?.Invoke() ?? null;
        public Func<InputOperation>? NextLinkOperationRef { get; init; }
    }

    internal abstract record InputType(string Name, bool IsNullable = false) { }

    internal record InputPrimitiveType(InputTypeKind Kind, bool IsNullable = false) : InputType(Kind.ToString(), IsNullable)
    {
        public static InputPrimitiveType AzureLocation { get; }      = new(InputTypeKind.AzureLocation);
        public static InputPrimitiveType BinaryData { get; }         = new(InputTypeKind.BinaryData);
        public static InputPrimitiveType Boolean { get; }            = new(InputTypeKind.Boolean);
        public static InputPrimitiveType Bytes { get; }              = new(InputTypeKind.Bytes);
        public static InputPrimitiveType BytesBase64Url { get; }     = new(InputTypeKind.BytesBase64Url);
        public static InputPrimitiveType ContentType { get; }        = new(InputTypeKind.ContentType);
        public static InputPrimitiveType Date { get; }               = new(InputTypeKind.Date);
        public static InputPrimitiveType DateTime { get; }           = new(InputTypeKind.DateTime);
        public static InputPrimitiveType DateTimeISO8601 { get; }    = new(InputTypeKind.DateTimeISO8601);
        public static InputPrimitiveType DateTimeRFC1123 { get; }    = new(InputTypeKind.DateTimeRFC1123);
        public static InputPrimitiveType DateTimeUnix { get; }       = new(InputTypeKind.DateTimeUnix);
        public static InputPrimitiveType DurationISO8601 { get; }    = new(InputTypeKind.DurationISO8601);
        public static InputPrimitiveType DurationConstant { get; }   = new(InputTypeKind.DurationConstant);
        public static InputPrimitiveType ETag { get; }               = new(InputTypeKind.ETag);
        public static InputPrimitiveType Float32 { get; }            = new(InputTypeKind.Float32);
        public static InputPrimitiveType Float64 { get; }            = new(InputTypeKind.Float64);
        public static InputPrimitiveType Float128 { get; }           = new(InputTypeKind.Float128);
        public static InputPrimitiveType Guid { get; }               = new(InputTypeKind.Guid);
        public static InputPrimitiveType Int32 { get; }              = new(InputTypeKind.Int32);
        public static InputPrimitiveType Int64 { get; }              = new(InputTypeKind.Int64);
        public static InputPrimitiveType Object { get; }             = new(InputTypeKind.Object);
        public static InputPrimitiveType RequestMethod { get; }      = new(InputTypeKind.RequestMethod);
        public static InputPrimitiveType ResourceIdentifier { get; } = new(InputTypeKind.ResourceIdentifier);
        public static InputPrimitiveType ResourceType { get; }       = new(InputTypeKind.ResourceType);
        public static InputPrimitiveType Stream { get; }             = new(InputTypeKind.Stream);
        public static InputPrimitiveType String { get; }             = new(InputTypeKind.String);
        public static InputPrimitiveType Time { get; }               = new(InputTypeKind.Time);
        public static InputPrimitiveType Uri { get; }                = new(InputTypeKind.Uri);

        public bool IsNumber => Kind is InputTypeKind.Int32 or InputTypeKind.Int64 or InputTypeKind.Float32 or InputTypeKind.Float64 or InputTypeKind.Float128;
    }

    internal record InputListType(string Name, InputType ElementType, bool IsNullable = false) : InputType(Name, IsNullable) { }

    internal record InputDictionaryType(string Name, InputType KeyType, InputType ValueType, bool IsNullable = false) : InputType(Name, IsNullable) { }

    internal record InputModelProperty(string Name, string? SerializedName, string Description, InputType Type, bool IsRequired, bool IsReadOnly, bool IsDiscriminator) { }

    internal record InputConstant(object Value, InputType Type);

    internal record InputEnumTypeValue(string Name, string Value, string? Description);

    internal enum InputOperationParameterKind
    {
        Method = 0,
        Client = 1,
        Constant = 2,
        Flattened = 3,
        Grouped = 4,
    }

    internal enum BodyMediaType
    {
        None,
        Binary,
        Form,
        Json,
        Multipart,
        Text,
        Xml
    }

    internal enum InputTypeKind
    {
        AzureLocation,
        Boolean,
        BinaryData,
        Bytes,
        BytesBase64Url,
        ContentType,
        Date,
        DateTime,
        DateTimeISO8601,
        DateTimeRFC1123,
        DateTimeUnix,
        DurationISO8601,
        DurationConstant,
        ETag,
        Float32,
        Float64,
        Float128,
        Guid,
        Int32,
        Int64,
        Object,
        RequestMethod,
        ResourceIdentifier,
        ResourceType,
        Stream,
        String,
        Time,
        Uri,
    }
}
