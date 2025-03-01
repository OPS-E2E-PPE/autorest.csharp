// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> Represents the confidence scores between 0 and 1 across all sentiment classes: positive, neutral, negative. </summary>
    public partial class SentimentConfidenceScorePerLabel
    {
        /// <summary> Initializes a new instance of SentimentConfidenceScorePerLabel. </summary>
        /// <param name="positive"></param>
        /// <param name="neutral"></param>
        /// <param name="negative"></param>
        internal SentimentConfidenceScorePerLabel(double positive, double neutral, double negative)
        {
            Positive = positive;
            Neutral = neutral;
            Negative = negative;
        }

        /// <summary> Gets the positive. </summary>
        public double Positive { get; }
        /// <summary> Gets the neutral. </summary>
        public double Neutral { get; }
        /// <summary> Gets the negative. </summary>
        public double Negative { get; }
    }
}
