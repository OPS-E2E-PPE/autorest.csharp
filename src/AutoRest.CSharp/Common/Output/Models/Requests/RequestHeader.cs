﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class RequestHeader
    {
        private static HashSet<string> ContentHeaders = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "Allow",
            "Content-Disposition",
            "Content-Encoding",
            "Content-Language",
            "Content-Length",
            "Content-Location",
            "Content-MD5",
            "Content-Range",
            "Content-Type",
            "Expires",
            "Last-Modified",
        };

        private static HashSet<string> ConditionRequstHeader = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "If-Match",
            "If-None-Match",
            "If-Modified-Since",
            "If-Unmodified-Since",
        };

        private static HashSet<string> MatchConditionRequstHeader = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "If-Match",
            "If-None-Match"
        };
        public string Name { get; }
        public ReferenceOrConstant Value { get; }
        public RequestParameterSerializationStyle SerializationStyle { get; }
        public SerializationFormat Format { get; }
        public bool IsContentHeader { get; }
        public bool IsRequestCondition { get; }
        public bool IsMatchCondition { get; }

        public RequestHeader(string name, ReferenceOrConstant value, RequestParameterSerializationStyle serializationStyle, SerializationFormat format = SerializationFormat.Default)
        {
            Name = name;
            Value = value;
            SerializationStyle = serializationStyle;
            Format = format;
            IsContentHeader = ContentHeaders.Contains(name);
            IsRequestCondition = ConditionRequstHeader.Contains(name);
            IsMatchCondition = MatchConditionRequstHeader.Contains(name);
        }
    }
}
