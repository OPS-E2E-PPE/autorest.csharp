// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace NoTypeReplacement.Models
{
    /// <summary> The MiddleResourceModel. </summary>
    internal partial class MiddleResourceModel
    {
        /// <summary> Initializes a new instance of MiddleResourceModel. </summary>
        public MiddleResourceModel()
        {
        }

        /// <summary> Initializes a new instance of MiddleResourceModel. </summary>
        /// <param name="foo"></param>
        internal MiddleResourceModel(NoSubResourceModel2 foo)
        {
            Foo = foo;
        }

        /// <summary> Gets or sets the foo. </summary>
        internal NoSubResourceModel2 Foo { get; set; }
        /// <summary> Gets the foo id. </summary>
        public string FooId
        {
            get => Foo is null ? default : Foo.Id;
        }
    }
}
