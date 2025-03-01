﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.MgmtTest.Extensions;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.MgmtTest.Output;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace AutoRest.CSharp.MgmtTest.Generation
{
    internal abstract class MgmtTestWriterBase<TProvider> where TProvider : MgmtTestProvider
    {
        protected CodeWriter _writer;

        protected TProvider This { get; }

        protected MgmtTestWriterBase(TProvider provider) : this(new CodeWriter(), provider)
        {
        }

        protected MgmtTestWriterBase(CodeWriter writer, TProvider provider)
        {
            _writer = writer;
            This = provider;
        }

        public abstract void Write();

        protected virtual void WriteClassDeclaration()
        {
            _writer.WriteXmlDocumentationSummary(This.Description);
            _writer.Append($"{This.Accessibility} partial class {This.Type.Name}");
            if (This.BaseType != null)
            {
                _writer.Append($" : {This.BaseType:D}");
            }
            _writer.Line();
        }

        protected virtual void WriteCreateResourceIdentifier(OperationExample example, CodeWriterDeclaration declaration, RequestPath requestPath, CSharpType resourceType)
        {
            _writer.Append($"{typeof(ResourceIdentifier)} {declaration:D} = {resourceType}.CreateResourceIdentifier(");
            foreach (var value in example.ComposeResourceIdentifierParameterValues(requestPath))
            {
                _writer.AppendExampleParameterValue(value).AppendRaw(",");
            }
            _writer.RemoveTrailingComma();
            _writer.Line($");");
        }

        protected virtual void WriteCreateScopeResourceIdentifier(OperationExample example, CodeWriterDeclaration declaration, RequestPath requestPath)
        {
            _writer.Append($"{typeof(ResourceIdentifier)} {declaration:D} = new {typeof(ResourceIdentifier)}(");
            // we do not know exactly which resource the scope is, therefore we need to use the string.Format method to include those parameter values and construct a valid resource id of the scope
            _writer.Append($"{typeof(string)}.Format(\"");
            int refIndex = 0;
            foreach (var segment in requestPath)
            {
                _writer.AppendRaw("/");
                if (segment.IsConstant)
                    _writer.AppendRaw(segment.ConstantValue);
                else
                    _writer.Append($"{{{refIndex++}}}");
            }
            _writer.AppendRaw("\", ");
            foreach (var value in example.ComposeResourceIdentifierParameterValues(requestPath))
            {
                _writer.AppendExampleParameterValue(value).AppendRaw(",");
            }
            _writer.RemoveTrailingComma();
            _writer.LineRaw("));");
        }

        protected CodeWriterDeclaration WriteGetResource(MgmtTypeProvider carrierResource, OperationExample example, FormattableString client)
            => carrierResource switch
            {
                ResourceCollection => throw new InvalidOperationException($"ResourceCollection is not supported here"),
                Resource parentResource => WriteGetFromResource(parentResource, example, client),
                MgmtExtensions parentExtension => WriteGetExtension(parentExtension, example, client),
                _ => throw new InvalidOperationException($"Unknown parent {carrierResource.GetType()}"),
            };

        protected CodeWriterDeclaration WriteGetFromResource(Resource carrierResource, OperationExample example, FormattableString client)
        {
            var idVar = new CodeWriterDeclaration($"{carrierResource.Type.Name}Id".ToVariableName());
            WriteCreateResourceIdentifier(example, idVar, carrierResource.RequestPath, carrierResource.Type);
            var resourceVar = new CodeWriterDeclaration(carrierResource.ResourceName.ToVariableName());
            _writer.Line($"{carrierResource.Type} {resourceVar:D} = {client}.Get{carrierResource.Type.Name}({idVar});");

            return resourceVar;
        }

        protected CodeWriterDeclaration WriteGetExtension(MgmtExtensions parentExtension, OperationExample example, FormattableString client) => parentExtension.ArmCoreType switch
        {
            _ when parentExtension.ArmCoreType == typeof(TenantResource) => WriteGetTenantResource(parentExtension, example, client),
            _ when parentExtension.ArmCoreType == typeof(ArmResource) => throw new InvalidOperationException("The method that extends ArmResource might not exist, we should always use the client.GetXXXs(scope) to get the collection, this does not have to be invoked on a resource"),
            _ => WriteGetOtherExtension(parentExtension, example, client)
        };

        private CodeWriterDeclaration WriteGetTenantResource(MgmtExtensions parentExtension, OperationExample example, FormattableString client)
        {
            var resourceVar = new CodeWriterDeclaration(parentExtension.ResourceName.ToVariableName());
            _writer.Line($"var {resourceVar:D} = {client}.GetTenants().GetAllAsync().GetAsyncEnumerator().Current;");
            return resourceVar;
        }

        private CodeWriterDeclaration WriteGetOtherExtension(MgmtExtensions parentExtension, OperationExample example, FormattableString client)
        {
            var resourceVar = new CodeWriterDeclaration(parentExtension.ResourceName.ToVariableName());
            var idVar = new CodeWriterDeclaration($"{parentExtension.ArmCoreType.Name}Id".ToVariableName());
            WriteCreateResourceIdentifier(example, idVar, parentExtension.ContextualPath, parentExtension.ArmCoreType);

            _writer.Line($"{parentExtension.ArmCoreType} {resourceVar:D} = {client}.Get{parentExtension.ArmCoreType.Name}({idVar});");
            return resourceVar;
        }

        public override string ToString()
        {
            return _writer.ToString();
        }

        protected string CreateMethodName(string methodName, bool async = true)
        {
            return async ? $"{methodName}Async" : methodName;
        }
    }
}
