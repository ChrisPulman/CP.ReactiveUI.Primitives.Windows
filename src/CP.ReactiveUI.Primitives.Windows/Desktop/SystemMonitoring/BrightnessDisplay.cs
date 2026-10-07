// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.
#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>A DDC/CI physical monitor session owning its native handle.</summary>
public sealed class BrightnessDisplay : IDisposable
{
    /// <summary>The native WCHAR description buffer size.</summary>
    private const int NativeDescriptionBytes = 256;

    /// <summary>The DDC/CI brightness capability flag.</summary>
    private const uint BrightnessCapability = 2;

    /// <summary>Synchronizes disposal and native requests.</summary>
    private readonly Lock _gate = new();

    /// <summary>Provides _handle operations.</summary>
    private readonly BrightnessMonitorHandle _handle;

    /// <summary>Initializes a new instance of the <see cref="BrightnessDisplay"/> class.</summary>
    /// <param name="handle">The handle value.</param>
    /// <param name="description">The description value.</param>
    internal BrightnessDisplay(IntPtr handle, string description)
    {
        _handle = new(handle);
        Description = description;
    }

    /// <summary>Gets the physical monitor description.</summary>
    public string Description { get; }

    /// <summary>Opens physical monitors for a logical monitor. Dispose every returned session.</summary>
    /// <param name="monitor">The logical monitor handle.</param>
    /// <returns>The owned sessions.</returns>
    public static BrightnessDisplay[] OpenForMonitor(IntPtr monitor)
    {
        if (monitor == IntPtr.Zero)
            throw new ArgumentException("A logical monitor handle is required.", nameof(monitor));
        BrightnessNativeMethods.Check(BrightnessNativeMethods.NativeMethods.GetNumberOfPhysicalMonitorsFromHMONITOR(monitor, out var count));
        if (count == 0)
        {
            return [];
        }

        var stride = IntPtr.Size + NativeDescriptionBytes;
        var buffer = Marshal.AllocHGlobal(checked((int)count * stride));
        var sessions = new BrightnessDisplay[checked((int)count)];
        var created = 0;
        try
        {
            BrightnessNativeMethods.Check(BrightnessNativeMethods.NativeMethods.GetPhysicalMonitorsFromHMONITOR(monitor, count, buffer));
            try
            {
                for (; created < sessions.Length; created++)
                {
                    var entry = IntPtr.Add(buffer, created * stride);
                    sessions[created] = new(Marshal.ReadIntPtr(entry), Marshal.PtrToStringUni(IntPtr.Add(entry, IntPtr.Size)) ?? string.Empty);
                }

                return sessions;
            }
            catch
            {
                for (var index = 0; index < created; index++)
                    sessions[index].Dispose();
                for (var index = created; index < sessions.Length; index++)
                    _ = BrightnessNativeMethods.NativeMethods.DestroyPhysicalMonitor(Marshal.ReadIntPtr(IntPtr.Add(buffer, index * stride)));
                throw;
            }
        }
        finally
        {
            Marshal.FreeHGlobal(buffer);
        }
    }

    /// <summary>Captures capability and brightness, retaining native failure information.</summary>
    /// <returns>The physical monitor brightness sample.</returns>
    public BrightnessSample Capture()
    {
        lock (_gate)
        {
            EnsureOpen();
            if (BrightnessNativeMethods.NativeMethods.GetMonitorCapabilities(_handle, out var capabilities, out _) == 0)
            {
                return new BrightnessSample
                {
                    Description = Description,
                    Transport = BrightnessTransport.DdcCi,
                    Error = new NativeWin32Exception(Marshal.GetLastWin32Error()).Message,
                };
            }

            var supported = (capabilities & BrightnessCapability) != 0;
            if (!supported)
            {
                return new BrightnessSample
                {
                    Description = Description,
                    Transport = BrightnessTransport.DdcCi,
                    Error = "The monitor does not report DDC/CI brightness capability."
                };
            }

            return BrightnessNativeMethods.NativeMethods.GetMonitorBrightness(_handle, out var minimum, out var current, out var maximum) == 0
                ? new BrightnessSample
            {
                Description = Description,
                Transport = BrightnessTransport.DdcCi,
                IsSupported = true,
                Error = new NativeWin32Exception(Marshal.GetLastWin32Error()).Message
            }
                : new BrightnessSample
            {
                Description = Description,
                Transport = BrightnessTransport.DdcCi,
                IsSupported = true,
                Minimum = minimum,
                Current = current,
                Maximum = maximum
            };
        }
    }

    /// <summary>Immediately sets native brightness within the monitor's reported range.</summary>
    /// <param name="value">The brightness in native monitor units.</param>
    /// <returns>This session.</returns>
    public BrightnessDisplay SetBrightness(uint value)
    {
        lock (_gate)
        {
            EnsureOpen();
            BrightnessNativeMethods.Check(BrightnessNativeMethods.NativeMethods.GetMonitorBrightness(_handle, out var minimum, out _, out var maximum));
            if (value < minimum || value > maximum)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "The value is outside this monitor's brightness range.");
            }

            BrightnessNativeMethods.Check(BrightnessNativeMethods.NativeMethods.SetMonitorBrightness(_handle, value));
            return this;
        }
    }

    /// <summary>Closes the owned physical monitor handle.</summary>
    public void Dispose()
    {
        lock (_gate)
        {
            _handle.Dispose();
        }
    }

    /// <summary>Provides EnsureOpen operations.</summary>
    private void EnsureOpen() => Throw.IfDisposed(_handle.IsClosed, this);
}
