// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Models;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ResourceTypeBuilder
    {
        private static ConcurrentDictionary<RequestPath, ResourceTypeSegment> _requestPathToResourceTypeCache = new ConcurrentDictionary<RequestPath, ResourceTypeSegment>();

        static ResourceTypeBuilder()
        {
            _requestPathToResourceTypeCache.TryAdd(RequestPath.Subscription, ResourceTypeSegment.Subscription);
            _requestPathToResourceTypeCache.TryAdd(RequestPath.ResourceGroup, ResourceTypeSegment.ResourceGroup);
            _requestPathToResourceTypeCache.TryAdd(RequestPath.Tenant, ResourceTypeSegment.Tenant);
            _requestPathToResourceTypeCache.TryAdd(RequestPath.ManagementGroup, ResourceTypeSegment.ManagementGroup);
        }

        public static ResourceTypeSegment GetResourceType(this RequestPath requestPath)
        {
            if (_requestPathToResourceTypeCache.TryGetValue(requestPath, out var resourceType))
                return resourceType;

            resourceType = CalculateResourceType(requestPath);
            _requestPathToResourceTypeCache.TryAdd(requestPath, resourceType);
            return resourceType;
        }

        private static ResourceTypeSegment CalculateResourceType(RequestPath requestPath)
        {
            if (Configuration.MgmtConfiguration.RequestPathToResourceType.TryGetValue(requestPath.SerializedPath, out var resourceType))
                return new ResourceTypeSegment(resourceType);

            // we cannot directly return the new ResourceType here, the requestPath here can be a parameterized scope, which does not have a resource type
            // even if we have the configuration to assign explicit types to a parameterized scope, we do not have enough information to get which request path the current scope variable belongs
            // therefore we can only return a place holder here to let the caller decide the actual resource type
            if (requestPath.IsParameterizedScope())
                return ResourceTypeSegment.Scope;
            return ResourceTypeSegment.ParseRequestPath(requestPath);
        }

        public static ResourceTypeSegment GetResourceType(this IEnumerable<RequestPath> requestPaths)
        {
            var resourceTypes = requestPaths.Select(path => path.GetResourceType()).Distinct();

            if (resourceTypes.Count() > 1)
                throw new InvalidOperationException($"Request path(s) {string.Join(", ", requestPaths)} contain multiple resource types in it ({string.Join(", ", resourceTypes)}), please double check and override it in `request-path-to-resource-type` section.");

            var resourceType = resourceTypes.First();

            if (resourceType == ResourceTypeSegment.Scope)
                throw new InvalidOperationException($"Request path(s) {string.Join(", ", requestPaths)} is a 'ById' resource, we cannot derive a resource type from its request path, please double check and override it in `request-path-to-resource-type` section.");

            return resourceType;
        }
    }
}
