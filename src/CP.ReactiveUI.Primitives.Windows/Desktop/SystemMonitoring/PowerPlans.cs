// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.
#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Enumerates and selects Windows power schemes.</summary>
public static class PowerPlans
{
    /// <summary>The enumerate power schemes access selector.</summary>
    private const uint SchemeAccess = 16;

    /// <summary>The enumeration completion code.</summary>
    private const uint NoMoreItems = 259;

    /// <summary>Enumerates installed power schemes.</summary>
    /// <returns>The installed schemes.</returns>
    public static PowerPlan[] GetPlans()
    {
        var plans = new List<PowerPlan>();
        for (uint index = 0;; index++)
        {
            uint size = SchemeAccess;
            var buffer = new byte[size];
            var result = PowerNativeMethods.NativeMethods.PowerEnumerate(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, SchemeAccess, index, buffer, ref size);
            if (result == NoMoreItems)
            {
                return plans.ToArray();
            }

            PowerNativeMethods.Check(result);
            plans.Add(PowerPlan.ForId(new(buffer)));
        }
    }

    /// <summary>Reads the active scheme.</summary>
    /// <returns>The active scheme.</returns>
    public static PowerPlan GetActive()
    {
        PowerNativeMethods.Check(PowerNativeMethods.NativeMethods.PowerGetActiveScheme(IntPtr.Zero, out var pointer));
        try
        {
            return PowerPlan.ForId(Marshal.PtrToStructure<Guid>(pointer));
        }
        finally
        {
            _ = PowerNativeMethods.NativeMethods.LocalFree(pointer);
        }
    }

    /// <summary>Activates a scheme.</summary>
    /// <param name="id">The installed scheme identifier.</param>
    public static void SetActive(Guid id) => PowerPlan.ForId(id).Activate();
}
