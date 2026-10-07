// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Drive capacity and physical disk performance captured together.</summary>
public sealed class StorageSnapshot
{
    /// <summary>Gets the UTC capture time.</summary>
    public DateTimeOffset Timestamp { get; internal init; }

    /// <summary>Gets the logical drives reported by Windows.</summary>
    public IReadOnlyList<StorageDriveSnapshot> Drives { get; internal init; } = Array.Empty<StorageDriveSnapshot>();

    /// <summary>Gets the physical disk performance counter instances.</summary>
    public IReadOnlyList<StorageDiskSnapshot> PhysicalDisks { get; internal init; } = Array.Empty<StorageDiskSnapshot>();
}
