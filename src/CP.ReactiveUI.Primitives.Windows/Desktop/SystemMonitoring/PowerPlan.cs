// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.
#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>An explicit power scheme target. Writes persist immediately; Activate applies an active scheme's changed settings.</summary>
public sealed class PowerPlan
{
    /// <summary>The buffer resizing status code.</summary>
    private const uint MoreData = 234;

    /// <summary>The instance-bound native operations.</summary>
    private readonly PowerPlanOperations _operations;

    /// <summary>Initializes a new instance of the <see cref = "PowerPlan"/> class.</summary>
    /// <param name="id">The scheme identifier.</param>
    /// <param name="operations">The instance-bound native operations.</param>
    internal PowerPlan(Guid id, PowerPlanOperations operations)
    {
        Id = id;
        _operations = operations;
    }

    /// <summary>Gets the scheme identifier.</summary>
    public Guid Id { get; }

    /// <summary>Gets the current friendly name.</summary>
    public string FriendlyName
    {
        get
        {
            var id = Id;
            uint size = 0;
            var result = PowerNativeMethods.NativeMethods.PowerReadFriendlyName(IntPtr.Zero, ref id, IntPtr.Zero, IntPtr.Zero, null, ref size);
            if (result != MoreData)
            {
                PowerNativeMethods.Check(result);
            }

            var bytes = new byte[size];
            PowerNativeMethods.Check(PowerNativeMethods.NativeMethods.PowerReadFriendlyName(IntPtr.Zero, ref id, IntPtr.Zero, IntPtr.Zero, bytes, ref size));
            return Encoding.Unicode.GetString(bytes, 0, checked((int)size)).TrimEnd('\0');
        }
    }

    /// <summary>Creates a target for an installed scheme identifier.</summary>
    /// <param name="id">The scheme identifier.</param>
    /// <returns>The target.</returns>
    public static PowerPlan ForId(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("A power scheme identifier is required.", nameof(id));
        }

        return new(id, new());
    }

    /// <summary>Reads an AC setting's native value index.</summary>
    /// <param name="subgroup">The setting subgroup identifier.</param>
    /// <param name="setting">The setting identifier.</param>
    /// <returns>The value index in the setting's documented units.</returns>
    public uint ReadAcValue(Guid subgroup, Guid setting)
    {
        var result = _operations.Read(Id, subgroup, setting, false);
        PowerNativeMethods.Check(result.ErrorCode);
        return result.Value;
    }

    /// <summary>Reads a DC setting's native value index.</summary>
    /// <param name="subgroup">The setting subgroup identifier.</param>
    /// <param name="setting">The setting identifier.</param>
    /// <returns>The value index in the setting's documented units.</returns>
    public uint ReadDcValue(Guid subgroup, Guid setting)
    {
        var result = _operations.Read(Id, subgroup, setting, true);
        PowerNativeMethods.Check(result.ErrorCode);
        return result.Value;
    }

    /// <summary>Immediately persists an AC setting value; native validation errors propagate.</summary>
    /// <param name="subgroup">The subgroup identifier.</param>
    /// <param name="setting">The setting identifier.</param>
    /// <param name="value">The setting value index.</param>
    /// <returns>This target.</returns>
    public PowerPlan WithAcValue(Guid subgroup, Guid setting, uint value)
    {
        PowerNativeMethods.Check(_operations.Write(Id, subgroup, setting, false, value));
        return this;
    }

    /// <summary>Immediately persists a DC setting value; native validation errors propagate.</summary>
    /// <param name="subgroup">The subgroup identifier.</param>
    /// <param name="setting">The setting identifier.</param>
    /// <param name="value">The setting value index.</param>
    /// <returns>This target.</returns>
    public PowerPlan WithDcValue(Guid subgroup, Guid setting, uint value)
    {
        PowerNativeMethods.Check(_operations.Write(Id, subgroup, setting, true, value));
        return this;
    }

    /// <summary>Activates this scheme and applies its persisted settings.</summary>
    /// <returns>This target.</returns>
    public PowerPlan Activate()
    {
        PowerNativeMethods.Check(_operations.Activate(Id));
        return this;
    }
}
