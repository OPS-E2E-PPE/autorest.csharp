﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.MgmtTest.Models
{
    internal class OperationExample
    {
        internal protected ExampleModel _example;
        public string OperationId { get; }
        public string Name => _example.Name;

        public MgmtTypeProvider Carrier { get; }

        /// <summary>
        /// The Owner of this Operation means which test class this test operation will go into
        /// if the provider is a resource, the owner is the resource (this includes the ResourceCollection). Otherwise, for instance the extensions, use the Operation.Resource as its owner. Use the Carrier as a fallback
        /// </summary>
        public MgmtTypeProvider Owner => Carrier is Resource ? Carrier : (Operation.Resource ?? Carrier);
        public MgmtClientOperation Operation { get; }

        private MgmtRestOperation? _restOperation;
        public MgmtRestOperation RestOperation => _restOperation ??= GetRestOperationFromOperationId();
        public RequestPath RequestPath => RestOperation.RequestPath;

        /// <summary>
        /// All the parameters defined in this test case
        /// We do not need to distiguish between ClientParameters and MethodParameters because we usually change that in code model transformation
        /// </summary>
        public IEnumerable<ExampleParameter> AllParameters => _example.AllParameters;
        private IEnumerable<ExampleParameter>? _pathParameters;
        public IEnumerable<ExampleParameter> PathParameters => _pathParameters ??= AllParameters.Where(p => p.Parameter.In == HttpParameterIn.Path);

        protected OperationExample(string operationId, MgmtTypeProvider carrier, MgmtClientOperation operation, ExampleModel example)
        {
            OperationId = operationId;
            _example = example;
            Carrier = carrier;
            Operation = operation;
        }

        private MgmtRestOperation GetRestOperationFromOperationId()
        {
            foreach (var operation in Operation)
            {
                if (operation.OperationId == OperationId)
                    return operation;
            }

            throw new InvalidOperationException($"Cannot find operationId {OperationId} in example {_example.Name}");
        }

        /// <summary>
        /// Returns the values to construct a resource identifier for the input request path
        /// This method does not validate the parenting relationship between the request path passing in and the request path inside this test case
        /// The passing in request path should always be a parent of the request path in this test case
        /// </summary>
        /// <param name="requestPath"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public IEnumerable<ExampleParameterValue> ComposeResourceIdentifierParameterValues(RequestPath requestPath)
        {
            // we first take the same amount of segments from my own request path, in case there is a case that the parameter names between different paths are different
            var piecesFromMyOwn = RequestPath.Take(requestPath.Count);
            // there should be a contract that we will never have two parameters with the same name in one path
            foreach (var referenceSegment in piecesFromMyOwn.Where(segment => segment.IsReference))
            {
                // find a path parameter in our path parameters for one with same name
                var serializedName = GetParameterSerializedName(referenceSegment.ReferenceName);
                var parameter = FindPathExampleParameterBySerializedName(serializedName);
                var exampleValue = parameter.ExampleValue;
                exampleValue = ReplacePathParameterValue(serializedName, referenceSegment.Reference.Type, exampleValue);

                yield return new ExampleParameterValue(referenceSegment.Reference, exampleValue);
            }
        }

        protected virtual ExampleValue ReplacePathParameterValue(string serializedName, CSharpType type, ExampleValue value)
            => value;

        private Dictionary<string, string> EnsureParameterSerializedNames()
        {
            if (_parameterNameToSerializedNameMapping != null)
                return _parameterNameToSerializedNameMapping;

            _parameterNameToSerializedNameMapping = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var operation = _example.Operation;
            var serviceRequest = operation.GetServiceRequest()!;

            var allRequestParameters = operation.Parameters.Concat(serviceRequest.Parameters);

            foreach (var requestParameter in allRequestParameters)
            {
                var serializedName = GetRequestParameterName(requestParameter);
                _parameterNameToSerializedNameMapping.Add(requestParameter.Language.Default.Name, serializedName);
            }

            return _parameterNameToSerializedNameMapping;
        }

        private Dictionary<string, string>? _parameterNameToSerializedNameMapping;

        protected string GetParameterSerializedName(string name) => EnsureParameterSerializedNames()[name];

        private static string GetRequestParameterName(RequestParameter requestParameter)
        {
            var language = requestParameter.Language.Default;
            return language.SerializedName ?? language.Name;
        }

        private ExampleParameter FindPathExampleParameterBySerializedName(string serializedName)
        {
            var parameter = FindExampleParameterBySerializedName(PathParameters, serializedName);

            // we throw exceptions here because path parameter cannot be optional, therefore if we do not find a parameter in the example, there must be an issue in the example
            if (parameter == null)
                throw new InvalidOperationException($"Cannot find a parameter in test case {_example.Name} with the name of {serializedName}");

            return parameter;
        }

        protected ExampleParameter? FindExampleParameterBySerializedName(IEnumerable<ExampleParameter> parameters, string name)
            => parameters.FirstOrDefault(p => GetRequestParameterName(p.Parameter) == name);
    }
}
