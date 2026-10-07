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

/// <summary>An explicitly selected WMI internal panel brightness control.</summary>
public sealed class BrightnessPanel
{
    /// <summary>The maximum brightness percentage.</summary>
    internal const byte MaximumPercentage = 100;

    /// <summary>The bounded WMI query timeout.</summary>
    private const int QueryTimeoutSeconds = 5;

    /// <summary>Provides _instanceName operations.</summary>
    private readonly string _instanceName;

    /// <summary>Initializes a new instance of the <see cref = "BrightnessPanel"/> class.</summary>
    /// <param name="instanceName">The instanceName value.</param>
    private BrightnessPanel(string instanceName) => _instanceName = instanceName;

    /// <summary>Selects the exact WMI instance identifier returned by brightness monitoring.</summary>
    /// <param name="instanceName">The WMI display instance identifier.</param>
    /// <returns>The panel target.</returns>
    public static BrightnessPanel ForDisplay(string instanceName)
    {
        Throw.IfNullOrWhiteSpace(instanceName);
        return new(instanceName);
    }

    /// <summary>Immediately requests the panel brightness percentage.</summary>
    /// <param name="percentage">A percentage from 0 through 100.</param>
    /// <returns>This panel.</returns>
    public BrightnessPanel SetBrightness(byte percentage)
    {
        ValidatePercentage(percentage);
        using var searcher = new ManagementObjectSearcher("root/wmi", "SELECT * FROM WmiMonitorBrightnessMethods");
        searcher.Options.Timeout = TimeSpan.FromSeconds(QueryTimeoutSeconds);
        using var objects = searcher.Get();
        foreach (var item in objects)
        {
            var panel = (ManagementObject)item;
            using (panel)
            {
                if (string.Equals(panel["InstanceName"] as string, _instanceName, StringComparison.OrdinalIgnoreCase))
                {
                    using var input = panel.GetMethodParameters("WmiSetBrightness");
                    input[nameof(Timeout)] = 0UL;
                    input["Brightness"] = percentage;
                    using var output = panel.InvokeMethod("WmiSetBrightness", input, null);
                    var result = (uint)output["ReturnValue"];
                    PowerNativeMethods.Check(result);
                    return this;
                }
            }
        }

        throw new InvalidOperationException("The selected panel does not expose WMI brightness control.");
    }

    /// <summary>Provides ValidatePercentage operations.</summary>
    /// <param name="percentage">The percentage value.</param>
    internal static void ValidatePercentage(byte percentage)
    {
#if NETFRAMEWORK
        if (percentage > MaximumPercentage)
        {
            throw new ArgumentOutOfRangeException(nameof(percentage));
        }
#else
        ArgumentOutOfRangeException.ThrowIfGreaterThan(percentage, MaximumPercentage);
#endif
    }
}
