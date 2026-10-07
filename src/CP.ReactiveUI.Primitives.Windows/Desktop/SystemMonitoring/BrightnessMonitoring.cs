// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.
using System.Management;

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Read-only internal panel and DDC/CI brightness monitoring.</summary>
public static class BrightnessMonitoring
{
    /// <summary>The bounded WMI query timeout.</summary>
    private const int QueryTimeoutSeconds = 5;

    /// <summary>The maximum brightness percentage.</summary>
    private const byte MaximumPercentage = 100;

    /// <summary>Captures display brightness and provider failures.</summary>
    /// <returns>The brightness inventory.</returns>
    public static BrightnessSnapshot Capture()
    {
        var samples = new List<BrightnessSample>();
        var errors = new List<string>();
        try
        {
            using var searcher = new ManagementObjectSearcher("root/wmi", "SELECT InstanceName, CurrentBrightness, Active FROM WmiMonitorBrightness");
            searcher.Options.Timeout = TimeSpan.FromSeconds(QueryTimeoutSeconds);
            using var objects = searcher.Get();
            foreach (var item in objects)
            {
                var panel = (ManagementObject)item;
                using (panel)
                {
                    if (panel["Active"] is true)
                    {
                        samples.Add(new BrightnessSample
                        {
                            Id = (string)panel["InstanceName"],
                            Description = "Internal panel",
                            Transport = BrightnessTransport.Wmi,
                            IsSupported = true,
                            Current = (byte)panel["CurrentBrightness"],
                            Minimum = 0,
                            Maximum = MaximumPercentage
                        });
                    }
                }
            }
        }
        catch (ManagementException exception)
        {
            errors.Add(exception.Message);
        }
        catch (UnauthorizedAccessException exception)
        {
            errors.Add(exception.Message);
        }
        catch (COMException exception)
        {
            errors.Add(exception.Message);
        }

        BrightnessNativeMethods.Enumerate(samples, errors);
        return new BrightnessSnapshot
        {
            Timestamp = TimeProvider.System.GetUtcNow(),
            Displays = samples.ToArray(),
            Errors = errors.ToArray()
        };
    }

    /// <summary>Gets the current display inventory. Capture also exposes inventory errors.</summary>
    /// <returns>The discovered displays.</returns>
    public static BrightnessSample[] GetDisplays() => Capture().Displays;

    /// <summary>Observes brightness with an independent sampler per subscription.</summary>
    /// <param name="interval">The positive polling interval.</param>
    /// <returns>The brightness stream.</returns>
    public static IObservable<BrightnessSnapshot> Observe(TimeSpan interval) => SystemPolling.Observe(static () => new BrightnessSampler(), interval);

    /// <summary>Provides BrightnessSampler operations.</summary>
    private sealed class BrightnessSampler : ISystemSampler<BrightnessSnapshot>
    {
        /// <summary>Provides Capture operations.</summary>
        /// <returns>The operation result.</returns>
        public BrightnessSnapshot Capture() => BrightnessMonitoring.Capture();

        /// <summary>Provides Dispose operations.</summary>
        public void Dispose()
        {
        }
    }
}
