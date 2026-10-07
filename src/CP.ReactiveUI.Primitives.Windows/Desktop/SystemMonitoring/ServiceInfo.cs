// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>A detached Windows service observation. Null fields are unavailable from the provider.</summary>
public sealed class ServiceInfo
{
    /// <summary>Initializes a new instance of the <see cref="ServiceInfo"/> class.</summary>
    /// <param name="row">The detached service row.</param>
    internal ServiceInfo(WmiRow row)
    {
        Name = row.String(nameof(Name));
        DisplayName = row.String(nameof(DisplayName));
        State = row.String(nameof(State));
        StartMode = row.String(nameof(StartMode));
        ProcessId = row.UInt32(nameof(ProcessId));
        AcceptStop = row.Boolean(nameof(AcceptStop));
        AcceptPause = row.Boolean(nameof(AcceptPause));
        DelayedAutoStart = row.Boolean(nameof(DelayedAutoStart));
        ServiceAccount = row.String("StartName");
        BinaryPath = row.String("PathName");
        ExitCode = row.UInt32(nameof(ExitCode));
        ServiceSpecificExitCode = row.UInt32(nameof(ServiceSpecificExitCode));
    }

    /// <summary>Gets the service name, or null when unavailable.</summary>
    public string? Name { get; }

    /// <summary>Gets the display name, or null when unavailable.</summary>
    public string? DisplayName { get; }

    /// <summary>Gets the provider state, including pending states, or null when unavailable.</summary>
    public string? State { get; }

    /// <summary>Gets the configured provider startup mode, or null when unavailable.</summary>
    public string? StartMode { get; }

    /// <summary>Gets the current process identifier, or null when unavailable.</summary>
    public uint? ProcessId { get; }

    /// <summary>Gets the whether stop controls are accepted, or null when unavailable.</summary>
    public bool? AcceptStop { get; }

    /// <summary>Gets the whether pause controls are accepted, or null when unavailable.</summary>
    public bool? AcceptPause { get; }

    /// <summary>Gets the whether automatic startup is delayed, or null when unavailable.</summary>
    public bool? DelayedAutoStart { get; }

    /// <summary>Gets the account used to run the service, or null when unavailable.</summary>
    public string? ServiceAccount { get; }

    /// <summary>Gets the configured executable path and arguments, or null when unavailable.</summary>
    public string? BinaryPath { get; }

    /// <summary>Gets the last Win32 exit code, or null when unavailable.</summary>
    public uint? ExitCode { get; }

    /// <summary>Gets the last service specific exit code, or null when unavailable.</summary>
    public uint? ServiceSpecificExitCode { get; }
}
