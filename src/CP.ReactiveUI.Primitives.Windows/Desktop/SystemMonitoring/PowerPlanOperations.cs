// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Instance-bound native operations for power setting controls.</summary>
internal sealed class PowerPlanOperations
{
    /// <summary>Gets the native setting read operation.</summary>
    internal Func<Guid, Guid, Guid, bool, PowerSettingRead> Read { get; init; } = ReadNative;

    /// <summary>Gets the native setting write operation.</summary>
    internal Func<Guid, Guid, Guid, bool, uint, uint> Write { get; init; } = WriteNative;

    /// <summary>Gets the native scheme activation operation.</summary>
    internal Func<Guid, uint> Activate { get; init; } = ActivateNative;

    /// <summary>Reads the AC or DC setting through the native provider.</summary>
    /// <param name="plan">The scheme identifier.</param>
    /// <param name="subgroup">The subgroup identifier.</param>
    /// <param name="setting">The setting identifier.</param>
    /// <param name="dc">Whether to read the DC value.</param>
    /// <returns>The native error and value.</returns>
    private static PowerSettingRead ReadNative(Guid plan, Guid subgroup, Guid setting, bool dc)
    {
        uint value;
        var error = dc
            ? PowerNativeMethods.NativeMethods.PowerReadDCValueIndex(IntPtr.Zero, ref plan, ref subgroup, ref setting, out value)
            : PowerNativeMethods.NativeMethods.PowerReadACValueIndex(IntPtr.Zero, ref plan, ref subgroup, ref setting, out value);
        return new(error, value);
    }

    /// <summary>Persists the AC or DC setting through the native provider.</summary>
    /// <param name="plan">The scheme identifier.</param>
    /// <param name="subgroup">The subgroup identifier.</param>
    /// <param name="setting">The setting identifier.</param>
    /// <param name="dc">Whether to write the DC value.</param>
    /// <param name="value">The value index.</param>
    /// <returns>The native error code.</returns>
    private static uint WriteNative(Guid plan, Guid subgroup, Guid setting, bool dc, uint value) => dc
        ? PowerNativeMethods.NativeMethods.PowerWriteDCValueIndex(IntPtr.Zero, ref plan, ref subgroup, ref setting, value)
        : PowerNativeMethods.NativeMethods.PowerWriteACValueIndex(IntPtr.Zero, ref plan, ref subgroup, ref setting, value);

    /// <summary>Activates the specified scheme through the native provider.</summary>
    /// <param name="plan">The scheme identifier.</param>
    /// <returns>The native error code.</returns>
    private static uint ActivateNative(Guid plan) => PowerNativeMethods.NativeMethods.PowerSetActiveScheme(IntPtr.Zero, ref plan);
}
