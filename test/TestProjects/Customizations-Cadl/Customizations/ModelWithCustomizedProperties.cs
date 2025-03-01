// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace CustomizationsInCadl
{
    public partial class ModelWithCustomizedProperties
    {
        /// <summary>
        /// Public property made internal
        /// </summary>
        internal int PropertyToMakeInternal { get; set; }

        /// <summary>
        /// Renamed property (original name: PropertyToRename)
        /// </summary>
        [CodeGenMember("PropertyToRename")]
        public int RenamedProperty { get; set; }

        /// <summary>
        /// Property with type changed to float (original type: int)
        /// </summary>
        public float PropertyToMakeFloat { get; set; }

        /// <summary>
        /// Property with type changed to int (original type: float)
        /// </summary>
        public int PropertyToMakeInt { get; set; }

        /// <summary>
        /// "Property with type changed to duration (original type: string)"
        /// </summary>
        public TimeSpan PropertyToMakeDuration { get; set; }

        /// <summary>
        /// Property with type changed to string (original type: duration)
        /// </summary>
        public string PropertyToMakeString { get; set; }

        /// <summary>
        /// "Property with type changed to JsonElement (original type: string)"
        /// </summary>
        public JsonElement PropertyToMakeJsonElement { get; set; }

        /// <summary>
        /// Field that replaces property (original name: PropertyToField)
        /// </summary>
        [CodeGenMember("PropertyToField")]
        private readonly string _propertyToField;
    }
}
