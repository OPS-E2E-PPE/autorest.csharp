﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;
using Resource = AutoRest.CSharp.Mgmt.Output.Resource;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceWriter : MgmtClientBaseWriter
    {
        private Resource This { get; }

        public ResourceWriter(CodeWriter writer, Resource resource) : base(writer, resource)
        {
            This = resource;
            _customMethods.Add(nameof(WriteAddTagBody), WriteAddTagBody);
            _customMethods.Add(nameof(WriteSetTagsBody), WriteSetTagsBody);
            _customMethods.Add(nameof(WriteRemoveTagBody), WriteRemoveTagBody);
        }

        protected override void WriteStaticMethods()
        {
            WriteCreateResourceIdentifierMethods();
            _writer.Line();
        }

        private void WriteCreateResourceIdentifierMethods()
        {
            var requestPath = This.RequestPath;
            var method = This.CreateResourceIdentifierMethodSignature();
            _writer.WriteXmlDocumentationSummary($"{method.Description}");
            using (_writer.WriteMethodDeclaration(method))
            {
                // Storage has inconsistent definitions:
                // - https://github.com/Azure/azure-rest-api-specs/blob/719b74f77b92eb1ec3814be6c4488bcf6b651733/specification/storage/resource-manager/Microsoft.Storage/stable/2021-04-01/blob.json#L58
                // - https://github.com/Azure/azure-rest-api-specs/blob/719b74f77b92eb1ec3814be6c4488bcf6b651733/specification/storage/resource-manager/Microsoft.Storage/stable/2021-04-01/blob.json#L146
                // so here we have to use `Seqment.BuildSerializedSegments` instead of `RequestPath.SerializedPath` which could be from `RestClientMethod.Operation.GetHttpPath`
                var resourceId = new CodeWriterDeclaration("resourceId");
                _writer.Append($"var {resourceId:D} = ");
                _writer.AppendRaw("$\"");
                var first = true;
                foreach (var segment in requestPath)
                {
                    if (first)
                    {
                        first = false;
                        // If first segment is "{var}", then we should not add leading "/". Instead, we should let callers to specify, e.g. "{scope}/providers/Microsoft.Resources/..." v.s. "/subscriptions/{subscriptionId}/..."
                        if (!requestPath.Any() || requestPath.First().IsConstant)
                            _writer.AppendRaw("/");
                    }
                    else
                        _writer.AppendRaw("/");
                    if (segment.IsConstant)
                        _writer.AppendRaw(segment.ConstantValue);
                    else
                        _writer.Append($"{{{segment.ReferenceName:I}}}");
                }
                _writer.LineRaw("\";");
                _writer.Line($"return new {method.ReturnType?.Name}({resourceId:I});");
            }
        }

        protected override void WriteProperties()
        {
            _writer.WriteXmlDocumentationSummary($"Gets the resource type for the operations");

            _writer.Line($"public static readonly {typeof(ResourceType)} ResourceType = \"{This.ResourceType}\";");
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets whether or not the current instance has data.");
            _writer.Line($"public virtual bool HasData {{ get; }}");
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets the data representing this Feature.");
            _writer.WriteXmlDocumentationException(typeof(InvalidOperationException), $"Throws if there is no data loaded in the current instance.");
            using (_writer.Scope($"public virtual {This.ResourceData.Type} Data"))
            {
                using (_writer.Scope($"get"))
                {
                    _writer.Line($"if (!HasData)");
                    _writer.Line($"throw new {typeof(InvalidOperationException)}(\"The current instance does not have data, you must call Get first.\");");
                    _writer.Line($"return _data;");
                }
            }

            _writer.Line();
            WriteStaticValidate($"ResourceType");
        }

        private void WriteAddTagBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool isAsync)
        {
            using (WriteDiagnosticScope(_writer, diagnostic, GetDiagnosticName(This.GetOperation.OperationMappings.Values.First())))
            {
                using (_writer.Scope(GetTagResourceCheckString(isAsync)))
                {
                    WriteGetOriginalFromTagResource(isAsync, "[key] = value");
                    WriteTaggableCommonMethod(isAsync);
                }
                using (_writer.Scope($"else"))
                {
                    WriteTaggableCommonMethodFromPutOrPatch(isAsync, "[key] = value");
                }
            }
            _writer.Line();
        }

        private void WriteSetTagsBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool isAsync)
        {
            using (WriteDiagnosticScope(_writer, diagnostic, GetDiagnosticName(This.GetOperation.OperationMappings.Values.First())))
            {
                using (_writer.Scope(GetTagResourceCheckString(isAsync)))
                {
                    if (isAsync)
                    {
                        _writer.Append($"await ");
                    }
                    _writer.Line($"GetTagResource().{CreateMethodName("Delete", isAsync)}({typeof(WaitUntil)}.Completed, cancellationToken: cancellationToken){GetConfigureAwait(isAsync)};");
                    WriteGetOriginalFromTagResource(isAsync, ".ReplaceWith(tags)");
                    WriteTaggableCommonMethod(isAsync);
                }
                using (_writer.Scope($"else"))
                {
                    WriteTaggableCommonMethodFromPutOrPatch(isAsync, ".ReplaceWith(tags)", true);
                }
            }
            _writer.Line();
        }

        private void WriteRemoveTagBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool isAsync)
        {
            using (WriteDiagnosticScope(_writer, diagnostic, GetDiagnosticName(This.GetOperation.OperationMappings.Values.First())))
            {
                using (_writer.Scope(GetTagResourceCheckString(isAsync)))
                {
                    WriteGetOriginalFromTagResource(isAsync, ".Remove(key)");
                    WriteTaggableCommonMethod(isAsync);
                }
                using (_writer.Scope($"else"))
                {
                    WriteTaggableCommonMethodFromPutOrPatch(isAsync, ".Remove(key)");
                }
            }
            _writer.Line();
        }

        private static FormattableString GetTagResourceCheckString(bool isAsync)
        {
            var awaitStr = isAsync ? "await " : String.Empty;
            var configureStr = isAsync ? ".ConfigureAwait(false)" : String.Empty;
            return $"if({awaitStr} {CreateMethodName("CanUseTagResource", isAsync)}(cancellationToken: cancellationToken){configureStr})";
        }

        private void WriteGetOriginalFromTagResource(bool isAsync, string setCode)
        {
            _writer.Append($"var originalTags = ");
            if (isAsync)
            {
                _writer.Append($"await ");
            }
            _writer.Line($"GetTagResource().{CreateMethodName("Get", isAsync)}(cancellationToken){GetConfigureAwait(isAsync)};");
            _writer.Line($"originalTags.Value.Data.TagValues{setCode};");
        }

        private void WriteTaggableCommonMethodFromPutOrPatch(bool isAsync, string setCode, bool isSetTags = false)
        {
            if (This.UpdateOperation is null && This.CreateOperation is null)
                throw new InvalidOperationException($"Unexpected null update method for resource {This.ResourceName} while its marked as taggable");
            MgmtClientOperation operation = (This.UpdateOperation ?? This.CreateOperation)!;
            var updateMethodName = This.UpdateOperation is null ? This.IsSingleton ? "CreateOrUpdate" : "Update" : This.UpdateOperation.Name;

            var configureStr = isAsync ? ".ConfigureAwait(false)" : String.Empty;
            var awaitStr = isAsync ? "await " : String.Empty;
            _writer.Line($"var current = ({awaitStr}{CreateMethodName("Get", isAsync)}(cancellationToken: cancellationToken){configureStr}).Value.Data;");

            var lroParamStr = operation.IsLongRunningOperation ? "WaitUntil.Completed, " : String.Empty;

            var parameters = operation.IsLongRunningOperation ? operation.MethodSignature.Parameters.Skip(1) : operation.MethodSignature.Parameters;
            var bodyParamType = parameters.First().Type;
            string bodyParamName = "current";
            //if we are using PATCH always minimize what we pass in the body to what we actually want to change
            if (!bodyParamType.Equals(This.ResourceData.Type) || operation.OperationMappings.Values.First().Operation.GetHttpMethod() == HttpMethod.Patch)
            {
                bodyParamName = "patch";
                if (bodyParamType.Implementation is ObjectType objectType)
                {
                    Configuration.MgmtConfiguration.PatchInitializerCustomization.TryGetValue(bodyParamType.Name, out var customizations);
                    customizations ??= new Dictionary<string, string>();
                    _writer.Append($"var patch = new {bodyParamType}(");
                    foreach (var parameter in objectType.InitializationConstructor.Signature.Parameters)
                    {
                        var varName = parameter.Name.FirstCharToUpperCase();
                        if (customizations.TryGetValue(varName, out var customization))
                        {
                            _writer.Append($"{customization}");
                        }
                        else
                        {
                            _writer.Append($"current.{varName}, ");
                        }
                    }
                    _writer.RemoveTrailingComma();
                    _writer.Line($");");
                }
                else
                {
                    _writer.Line($"var patch = new {bodyParamType}();");
                }
                if (!isSetTags)
                {
                    using (_writer.Scope($"foreach(var tag in current.Tags)"))
                    {
                        _writer.Line($"patch.Tags.Add(tag);");
                    }
                }
                Configuration.MgmtConfiguration.UpdateRequiredCopy.TryGetValue(This.ResourceName, out var properties);
                if (properties is not null)
                {
                    foreach (var property in properties.Split(','))
                    {
                        _writer.Line($"patch.{property} = current.{property};");
                    }
                }
            }

            _writer.Line($"{bodyParamName}.Tags{setCode};");
            _writer.Line($"var result = {awaitStr}{CreateMethodName(updateMethodName, isAsync)}({lroParamStr}{bodyParamName}, cancellationToken: cancellationToken){configureStr};");
            if (operation.IsLongRunningOperation)
            {
                if (operation.ReturnType.Arguments.Length == 0)
                {
                    _writer.Line($"return {awaitStr}{CreateMethodName("Get", isAsync)}(cancellationToken: cancellationToken){configureStr};");
                }
                else
                {
                    _writer.Line($"return Response.FromValue(result.Value, result.GetRawResponse());");
                }
            }
            else
            {
                _writer.Line($"return result;");
            }
        }

        private void WriteTaggableCommonMethod(bool isAsync)
        {
            _writer.Line($"{GetAwait(isAsync)} GetTagResource().{CreateMethodName("CreateOrUpdate", isAsync)}({typeof(WaitUntil)}.Completed, originalTags.Value.Data, cancellationToken: cancellationToken){GetConfigureAwait(isAsync)};");

            MgmtClientOperation clientOperation = This.GetOperation!;
            // we need to write multiple branches for a normal method
            if (clientOperation.OperationMappings.Count == 1)
            {
                // if we only have one branch, we would not need those if-else statements
                var branch = clientOperation.OperationMappings.Keys.First();
                WriteTaggableCommonMethodBranch(clientOperation.OperationMappings[branch], clientOperation.ParameterMappings[branch], isAsync);
            }
            else
            {
                // branches go here
                throw new NotImplementedException("multi-branch normal method not supported yet");
            }
        }

        private void WriteTaggableCommonMethodBranch(MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMappings, bool isAsync)
        {
            var originalResponse = new CodeWriterDeclaration("originalResponse");
            _writer
                .Append($"var {originalResponse:D} = {GetAwait(isAsync)} ")
                .Append($"{GetRestClientName(operation)}.{CreateMethodName(operation.Method.Name, isAsync)}(");

            WriteArguments(_writer, parameterMappings, true);
            _writer.Line($"cancellationToken){GetConfigureAwait(isAsync)};");

            if (This.ResourceData.ShouldSetResourceIdentifier)
            {
                _writer.Line($"{originalResponse}.Value.Id = {CreateResourceIdentifierExpression(This, operation.RequestPath, parameterMappings, $"{originalResponse}.Value")};");
            }

            _writer.Line($"return {typeof(Response)}.FromValue(new {operation.ReturnType.UnWrapResponse()}({ArmClientReference}, {originalResponse}.Value), {originalResponse}.GetRawResponse());");
        }
    }
}
