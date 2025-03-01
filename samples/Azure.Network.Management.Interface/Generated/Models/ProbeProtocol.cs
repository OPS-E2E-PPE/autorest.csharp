// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> The protocol of the end point. If &apos;Tcp&apos; is specified, a received ACK is required for the probe to be successful. If &apos;Http&apos; or &apos;Https&apos; is specified, a 200 OK response from the specifies URI is required for the probe to be successful. </summary>
    public readonly partial struct ProbeProtocol : IEquatable<ProbeProtocol>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ProbeProtocol"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ProbeProtocol(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string HttpValue = "Http";
        private const string TcpValue = "Tcp";
        private const string HttpsValue = "Https";

        /// <summary> Http. </summary>
        public static ProbeProtocol Http { get; } = new ProbeProtocol(HttpValue);
        /// <summary> Tcp. </summary>
        public static ProbeProtocol Tcp { get; } = new ProbeProtocol(TcpValue);
        /// <summary> Https. </summary>
        public static ProbeProtocol Https { get; } = new ProbeProtocol(HttpsValue);
        /// <summary> Determines if two <see cref="ProbeProtocol"/> values are the same. </summary>
        public static bool operator ==(ProbeProtocol left, ProbeProtocol right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ProbeProtocol"/> values are not the same. </summary>
        public static bool operator !=(ProbeProtocol left, ProbeProtocol right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ProbeProtocol"/>. </summary>
        public static implicit operator ProbeProtocol(string value) => new ProbeProtocol(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ProbeProtocol other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ProbeProtocol other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
