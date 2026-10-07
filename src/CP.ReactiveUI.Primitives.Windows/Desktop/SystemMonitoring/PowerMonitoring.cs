// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.
#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Read-only battery, external power, and active scheme sampling.</summary>
public static class PowerMonitoring
{
    /// <summary>The maximum valid battery charge percentage.</summary>
    private const byte MaximumPercentage = 100;

    /// <summary>Captures current power status.</summary>
    /// <returns>The current status.</returns>
    public static PowerSample Capture()
    {
        if (PowerNativeMethods.NativeMethods.GetSystemPowerStatus(out var status) == 0)
        {
            throw new NativeWin32Exception(Marshal.GetLastWin32Error());
        }

        return Convert(status, PowerPlans.GetActive().Id);
    }

    /// <summary>Observes power status with an independent sampler per subscriber.</summary>
    /// <param name="interval">The positive sampling interval.</param>
    /// <returns>The sampled status stream.</returns>
    public static IObservable<PowerSample> Observe(TimeSpan interval) => SystemPolling.Observe(static () => new PowerSampler(), interval);

    /// <summary>Provides Convert operations.</summary>
    /// <param name="status">The status value.</param>
    /// <param name="activePlanId">The activePlanId value.</param>
    /// <returns>The operation result.</returns>
    internal static PowerSample Convert(PowerStatus status, Guid activePlanId) => new()
    {
        Timestamp = TimeProvider.System.GetUtcNow(),
        Connection = (PowerConnection)status.AcLineStatus,
        BatteryFlags = status.BatteryFlag == byte.MaxValue ? null : status.BatteryFlag,
        BatteryChargePercent = status.BatteryLifePercent <= MaximumPercentage ? status.BatteryLifePercent : null,
        BatteryLifeRemaining = status.BatteryLifeTime == uint.MaxValue ? null : TimeSpan.FromSeconds(status.BatteryLifeTime),
        BatteryFullLifetime = status.BatteryFullLifeTime == uint.MaxValue ? null : TimeSpan.FromSeconds(status.BatteryFullLifeTime),
        IsEnergySaverEnabled = status.SystemStatusFlag != 0,
        ActivePlanId = activePlanId,
    };

    /// <summary>Provides PowerSampler operations.</summary>
    private sealed class PowerSampler : ISystemSampler<PowerSample>
    {
        /// <summary>Provides Capture operations.</summary>
        /// <returns>The operation result.</returns>
        public PowerSample Capture() => PowerMonitoring.Capture();

        /// <summary>Provides Dispose operations.</summary>
        public void Dispose()
        {
        }
    }
}
