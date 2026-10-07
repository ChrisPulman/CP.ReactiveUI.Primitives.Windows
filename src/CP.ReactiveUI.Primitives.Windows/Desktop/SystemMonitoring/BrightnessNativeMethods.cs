// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.
#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Provides BrightnessNativeMethods operations.</summary>
#if NETFRAMEWORK
internal static class BrightnessNativeMethods
#else
internal static partial class BrightnessNativeMethods
#endif
{
    /// <summary>Provides MonitorCallback operations.</summary>
    /// <param name="monitor">The monitor value.</param>
    /// <param name="deviceContext">The deviceContext value.</param>
    /// <param name="rectangle">The rectangle value.</param>
    /// <param name="data">The data value.</param>
    /// <returns>Whether enumeration should continue.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    private delegate int MonitorCallback(IntPtr monitor, IntPtr deviceContext, IntPtr rectangle, IntPtr data);

    /// <summary>Provides Check operations.</summary>
    /// <param name="result">The result value.</param>
    internal static void Check(int result)
    {
        if (result == 0)
        {
            throw new NativeWin32Exception(Marshal.GetLastWin32Error());
        }
    }

    /// <summary>Provides Enumerate operations.</summary>
    /// <param name="samples">The samples value.</param>
    /// <param name="errors">The errors value.</param>
    internal static void Enumerate(List<BrightnessSample> samples, List<string> errors)
    {
        MonitorCallback callback = (monitor, _, _, _) =>
        {
            try
            {
                var displays = BrightnessDisplay.OpenForMonitor(monitor);
                try
                {
                    for (var index = 0; index < displays.Length; index++)
                    {
                        var sample = displays[index].Capture();
                        sample.Id = FormattableString.Invariant($"{monitor.ToInt64()}:{index}");
                        samples.Add(sample);
                    }
                }
                finally
                {
                    foreach (var display in displays)
                    {
                        display.Dispose();
                    }
                }
            }
            catch (NativeWin32Exception exception)
            {
                errors.Add(exception.Message);
            }

            return 1;
        };
        if (NativeMethods.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, Marshal.GetFunctionPointerForDelegate(callback), IntPtr.Zero) == 0)
        {
            errors.Add(new NativeWin32Exception(Marshal.GetLastWin32Error()).Message);
        }

        GC.KeepAlive(callback);
    }

    /// <summary>Native Windows API declarations.</summary>
#if NETFRAMEWORK
    internal static class NativeMethods
#else
    internal static partial class NativeMethods
#endif
    {
        /// <summary>Calls the documented EnumDisplayMonitors entry point.</summary>
        /// <param name="deviceContext">The native deviceContext parameter.</param>
        /// <param name="clip">The native clip parameter.</param>
        /// <param name="callback">The native callback parameter.</param>
        /// <param name="data">The native data parameter.</param>
        /// <returns>The native result.</returns>
#if NETFRAMEWORK
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern int EnumDisplayMonitors(IntPtr deviceContext, IntPtr clip, IntPtr callback, IntPtr data);
#else
        [LibraryImport("user32.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial int EnumDisplayMonitors(IntPtr deviceContext, IntPtr clip, IntPtr callback, IntPtr data);
#endif

        /// <summary>Calls the documented GetNumberOfPhysicalMonitorsFromHMONITOR entry point.</summary>
        /// <param name="monitor">The native monitor parameter.</param>
        /// <param name="count">The native count parameter.</param>
        /// <returns>The native result.</returns>
#if NETFRAMEWORK
        [DllImport("dxva2.dll", ExactSpelling = true, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern int GetNumberOfPhysicalMonitorsFromHMONITOR(IntPtr monitor, out uint count);
#else
        [LibraryImport("dxva2.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial int GetNumberOfPhysicalMonitorsFromHMONITOR(IntPtr monitor, out uint count);
#endif

        /// <summary>Calls the documented GetPhysicalMonitorsFromHMONITOR entry point.</summary>
        /// <param name="monitor">The native monitor parameter.</param>
        /// <param name="count">The native count parameter.</param>
        /// <param name="monitors">The native monitors parameter.</param>
        /// <returns>The native result.</returns>
#if NETFRAMEWORK
        [DllImport("dxva2.dll", ExactSpelling = true, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern int GetPhysicalMonitorsFromHMONITOR(IntPtr monitor, uint count, IntPtr monitors);
#else
        [LibraryImport("dxva2.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial int GetPhysicalMonitorsFromHMONITOR(IntPtr monitor, uint count, IntPtr monitors);
#endif

        /// <summary>Calls the documented DestroyPhysicalMonitor entry point.</summary>
        /// <param name="monitor">The native monitor parameter.</param>
        /// <returns>The native result.</returns>
#if NETFRAMEWORK
        [DllImport("dxva2.dll", ExactSpelling = true, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern int DestroyPhysicalMonitor(IntPtr monitor);
#else
        [LibraryImport("dxva2.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial int DestroyPhysicalMonitor(IntPtr monitor);
#endif

        /// <summary>Calls the documented GetMonitorCapabilities entry point.</summary>
        /// <param name="monitor">The native monitor parameter.</param>
        /// <param name="capabilities">The native capabilities parameter.</param>
        /// <param name="colorTemperatures">The native colorTemperatures parameter.</param>
        /// <returns>The native result.</returns>
#if NETFRAMEWORK
        [DllImport("dxva2.dll", ExactSpelling = true, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern int GetMonitorCapabilities(BrightnessMonitorHandle monitor, out uint capabilities, out uint colorTemperatures);
#else
        [LibraryImport("dxva2.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial int GetMonitorCapabilities(BrightnessMonitorHandle monitor, out uint capabilities, out uint colorTemperatures);
#endif

        /// <summary>Calls the documented GetMonitorBrightness entry point.</summary>
        /// <param name="monitor">The native monitor parameter.</param>
        /// <param name="minimum">The native minimum parameter.</param>
        /// <param name="current">The native current parameter.</param>
        /// <param name="maximum">The native maximum parameter.</param>
        /// <returns>The native result.</returns>
#if NETFRAMEWORK
        [DllImport("dxva2.dll", ExactSpelling = true, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern int GetMonitorBrightness(BrightnessMonitorHandle monitor, out uint minimum, out uint current, out uint maximum);
#else
        [LibraryImport("dxva2.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial int GetMonitorBrightness(BrightnessMonitorHandle monitor, out uint minimum, out uint current, out uint maximum);
#endif

        /// <summary>Calls the documented SetMonitorBrightness entry point.</summary>
        /// <param name="monitor">The native monitor parameter.</param>
        /// <param name="value">The native value parameter.</param>
        /// <returns>The native result.</returns>
#if NETFRAMEWORK
        [DllImport("dxva2.dll", ExactSpelling = true, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern int SetMonitorBrightness(BrightnessMonitorHandle monitor, uint value);
#else
        [LibraryImport("dxva2.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial int SetMonitorBrightness(BrightnessMonitorHandle monitor, uint value);
#endif
    }
}
