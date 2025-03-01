// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace ExactMatchInheritance.Models
{
    /// <summary> The ExactMatchModel4. </summary>
    public partial class ExactMatchModel4 : ExactMatchModel9
    {
        /// <summary> Initializes a new instance of ExactMatchModel4. </summary>
        public ExactMatchModel4()
        {
        }

        /// <summary> Initializes a new instance of ExactMatchModel4. </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="exactMatchModel9Type"></param>
        /// <param name="new"></param>
        internal ExactMatchModel4(int? id, string name, string exactMatchModel9Type, string @new) : base(id, name, exactMatchModel9Type)
        {
            New = @new;
        }

        /// <summary> Gets or sets the new. </summary>
        public string New { get; set; }
    }
}
