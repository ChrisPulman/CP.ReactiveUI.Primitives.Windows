// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Documented Windows SDK power setting identifiers. Availability depends on hardware and Windows policy.</summary>
public static class PowerSettings
{
    /// <summary>Gets the processor settings subgroup.</summary>
    public static Guid ProcessorSubgroup { get; } = new("54533251-82be-4824-96c1-47b60b740d00");

    /// <summary>Gets the display settings subgroup.</summary>
    public static Guid DisplaySubgroup { get; } = new("7516b95f-f776-4464-8c53-06167f40cc99");

    /// <summary>Gets the sleep settings subgroup.</summary>
    public static Guid SleepSubgroup { get; } = new("238c9fa8-0aad-41ed-83f4-97be242c8f20");

    /// <summary>Gets the minimum processor performance percentage setting.</summary>
    public static Guid ProcessorMinimumState { get; } = new("893dee8e-2bef-41e0-89c6-b55d0929964c");

    /// <summary>Gets the maximum processor performance percentage setting.</summary>
    public static Guid ProcessorMaximumState { get; } = new("bc5038f7-23e0-4960-96da-33abaf5935ec");

    /// <summary>Gets the processor throttle policy value index setting.</summary>
    public static Guid ProcessorThrottlePolicy { get; } = new("57027304-4af6-4104-9260-e3d95248fc36");

    /// <summary>Gets the processor energy performance preference percentage setting.</summary>
    public static Guid ProcessorEnergyPreference { get; } = new("36687f9e-e3a5-4dbf-b1dc-15eb381c6863");

    /// <summary>Gets the processor boost mode value index setting.</summary>
    public static Guid ProcessorBoostMode { get; } = new("be337238-0d82-4146-a960-4f3749d470c7");

    /// <summary>Gets the display idle timeout setting in seconds. Zero means never.</summary>
    public static Guid DisplayIdleTimeout { get; } = new("3c0bc021-c8a8-4e07-a973-6b14cbcb2b7e");

    /// <summary>Gets the system sleep idle timeout setting in seconds. Zero means never.</summary>
    public static Guid SleepIdleTimeout { get; } = new("29f6c1db-86da-48c5-9fdb-f2b67b1f44da");
}
