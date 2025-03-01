// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace ModelsInCadl
{
    /// <summary> Model used only as output. </summary>
    public partial class OutputModel
    {
        /// <summary> Initializes a new instance of OutputModel. </summary>
        /// <param name="requiredString"></param>
        /// <param name="requiredInt"></param>
        /// <param name="requiredModel"></param>
        /// <param name="requiredCollection"></param>
        /// <param name="requiredModelRecord"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredString"/>, <paramref name="requiredModel"/>, <paramref name="requiredCollection"/> or <paramref name="requiredModelRecord"/> is null. </exception>
        public OutputModel(string requiredString, int requiredInt, DerivedModel requiredModel, IEnumerable<CollectionItem> requiredCollection, IDictionary<string, RecordItem> requiredModelRecord)
        {
            Argument.AssertNotNull(requiredString, nameof(requiredString));
            Argument.AssertNotNull(requiredModel, nameof(requiredModel));
            Argument.AssertNotNull(requiredCollection, nameof(requiredCollection));
            Argument.AssertNotNull(requiredModelRecord, nameof(requiredModelRecord));

            RequiredString = requiredString;
            RequiredInt = requiredInt;
            RequiredModel = requiredModel;
            RequiredCollection = requiredCollection.ToList();
            RequiredModelRecord = requiredModelRecord;
        }
        /// <summary> Initializes a new instance of OutputModel. </summary>
        /// <param name="requiredString"></param>
        /// <param name="requiredInt"></param>
        /// <param name="requiredModel"></param>
        /// <param name="requiredCollection"></param>
        /// <param name="requiredModelRecord"></param>
        internal OutputModel(string requiredString, int requiredInt, DerivedModel requiredModel, IList<CollectionItem> requiredCollection, IDictionary<string, RecordItem> requiredModelRecord)
        {
            RequiredString = requiredString;
            RequiredInt = requiredInt;
            RequiredModel = requiredModel;
            RequiredCollection = requiredCollection;
            RequiredModelRecord = requiredModelRecord;
        }

        public string RequiredString { get; set; }

        public int RequiredInt { get; set; }

        public DerivedModel RequiredModel { get; set; }

        public IList<CollectionItem> RequiredCollection { get; }

        public IDictionary<string, RecordItem> RequiredModelRecord { get; }
    }
}
