// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Capacity and availability of one logical drive.</summary>
public sealed class StorageDriveSnapshot
{
    /// <summary>Gets the drive root path.</summary>
    public string Name { get; internal init; } = string.Empty;

    /// <summary>Gets the drive category.</summary>
    public DriveType DriveType { get; internal init; }

    /// <summary>Gets the whether drive capacity and format can be read.</summary>
    public bool IsReady { get; internal init; }

    /// <summary>Gets the volume label when available.</summary>
    public string VolumeLabel { get; internal init; } = string.Empty;

    /// <summary>Gets the file system format when available.</summary>
    public string DriveFormat { get; internal init; } = string.Empty;

    /// <summary>Gets the total capacity in bytes, or null when unavailable.</summary>
    public long? TotalBytes { get; internal init; }

    /// <summary>Gets the free bytes available to the current user.</summary>
    public long? AvailableFreeBytes { get; internal init; }

    /// <summary>Gets the total free bytes including reserved space.</summary>
    public long? TotalFreeBytes { get; internal init; }

    /// <summary>Gets the availability error, or an empty string on success.</summary>
    public string Error { get; internal init; } = string.Empty;
}
