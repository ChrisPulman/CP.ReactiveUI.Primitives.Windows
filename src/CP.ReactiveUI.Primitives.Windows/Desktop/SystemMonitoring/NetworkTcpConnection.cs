// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Net.NetworkInformation;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>A TCP connection endpoint pair and current state.</summary>
public sealed class NetworkTcpConnection
{
    /// <summary>Gets the local IP address and port.</summary>
    public string LocalEndpoint { get; internal init; } = string.Empty;

    /// <summary>Gets the remote IP address and port.</summary>
    public string RemoteEndpoint { get; internal init; } = string.Empty;

    /// <summary>Gets the TCP connection state.</summary>
    public TcpState State { get; internal init; }
}
