// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Optional connection tables captured separately from interface polling.</summary>
public sealed class NetworkConnectionsSnapshot
{
    /// <summary>Gets the UTC capture time.</summary>
    public DateTimeOffset Timestamp { get; internal init; }

    /// <summary>Gets the TCP connections with local and remote endpoints.</summary>
    public IReadOnlyList<NetworkTcpConnection> TcpConnections { get; internal init; } = Array.Empty<NetworkTcpConnection>();

    /// <summary>Gets the TCP listening endpoints.</summary>
    public IReadOnlyList<string> TcpListeners { get; internal init; } = Array.Empty<string>();

    /// <summary>Gets the UDP listening endpoints.</summary>
    public IReadOnlyList<string> UdpListeners { get; internal init; } = Array.Empty<string>();

    /// <summary>Gets the IPv4 TCP and UDP cumulative statistics.</summary>
    public NetworkProtocolStatistics Ipv4 { get; internal init; } = new();

    /// <summary>Gets the IPv6 TCP and UDP cumulative statistics.</summary>
    public NetworkProtocolStatistics Ipv6 { get; internal init; } = new();
}
