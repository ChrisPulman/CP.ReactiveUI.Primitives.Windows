// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
using System.Globalization;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>A GPU counter instance with raw identity preserved independently of WMI adapter order.</summary>
public sealed class GraphicsEngineSample
{
    /// <summary>The number of adapter LUID components.</summary>
    private const int LuidComponentCount = 2;

    /// <summary>Initializes a new instance of the <see cref="GraphicsEngineSample"/> class.</summary>
    /// <param name="sample">The sample value.</param>
    internal GraphicsEngineSample(PerformanceCounterSample sample)
    {
        Counter = sample;
        var tokens = sample.InstanceName.Split('_');
        for (var index = 0; index + LuidComponentCount < tokens.Length; index++)
        {
            if (string.Equals(tokens[index], "luid", StringComparison.OrdinalIgnoreCase))
            {
                AdapterLuid = $"{tokens[index + 1]}_{tokens[index + LuidComponentCount]}";
                break;
            }
        }

        for (var index = 0; index + 1 < tokens.Length; index++)
        {
            if (string.Equals(tokens[index], "pid", StringComparison.OrdinalIgnoreCase) &&
                uint.TryParse(tokens[index + 1], NumberStyles.None, CultureInfo.InvariantCulture, out var pid))
            {
                ProcessId = pid;
                break;
            }
        }
    }

    /// <summary>Gets the raw counter instance, value and availability status.</summary>
    public PerformanceCounterSample Counter { get; }

    /// <summary>Gets the two hexadecimal LUID components, or null when the instance contains none.</summary>
    public string? AdapterLuid { get; }

    /// <summary>Gets the process identifier when encoded by the provider.</summary>
    public uint? ProcessId { get; }
}
