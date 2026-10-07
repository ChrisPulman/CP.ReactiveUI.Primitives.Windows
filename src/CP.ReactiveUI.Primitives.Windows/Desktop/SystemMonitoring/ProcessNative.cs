// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Documented native process telemetry entry points.</summary>
internal static
#if !NETFRAMEWORK
partial
#endif
class ProcessNative
{
    /// <summary>Gets or sets the native IoCounters layout.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal record struct IoCounters
    {
        /// <summary>Gets or sets the native ReadOperations field.</summary>
        internal ulong ReadOperations { get; set; }

        /// <summary>Gets or sets the native WriteOperations field.</summary>
        internal ulong WriteOperations { get; set; }

        /// <summary>Gets or sets the native OtherOperations field.</summary>
        internal ulong OtherOperations { get; set; }

        /// <summary>Gets or sets the native ReadBytes field.</summary>
        internal ulong ReadBytes { get; set; }

        /// <summary>Gets or sets the native WriteBytes field.</summary>
        internal ulong WriteBytes { get; set; }

        /// <summary>Gets or sets the native OtherBytes field.</summary>
        internal ulong OtherBytes { get; set; }
    }

    /// <summary>Gets or sets the native MemoryCounters layout.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal record struct MemoryCounters
    {
        /// <summary>Gets or sets the native Size field.</summary>
        internal uint Size { get; set; }

        /// <summary>Gets or sets the native PageFaultCount field.</summary>
        internal uint PageFaultCount { get; set; }

        /// <summary>Gets or sets the native PeakWorkingSet field.</summary>
        internal UIntPtr PeakWorkingSet { get; set; }

        /// <summary>Gets or sets the native WorkingSet field.</summary>
        internal UIntPtr WorkingSet { get; set; }

        /// <summary>Gets or sets the native PeakPagedPool field.</summary>
        internal UIntPtr PeakPagedPool { get; set; }

        /// <summary>Gets or sets the native PagedPool field.</summary>
        internal UIntPtr PagedPool { get; set; }

        /// <summary>Gets or sets the native PeakNonPagedPool field.</summary>
        internal UIntPtr PeakNonPagedPool { get; set; }

        /// <summary>Gets or sets the native NonPagedPool field.</summary>
        internal UIntPtr NonPagedPool { get; set; }

        /// <summary>Gets or sets the native PagefileUsage field.</summary>
        internal UIntPtr PagefileUsage { get; set; }

        /// <summary>Gets or sets the native PeakPagefileUsage field.</summary>
        internal UIntPtr PeakPagefileUsage { get; set; }
    }

    /// <summary>Contains native process entry points.</summary>
    internal static
#if !NETFRAMEWORK
    partial
#endif
    class NativeMethods
    {
        /// <summary>Calls the documented GetProcessIoCounters entry point.</summary>
        /// <param name="process">The native process value.</param>
        /// <param name="counters">The native counters value.</param>
        /// <returns>The native result.</returns>
#if NETFRAMEWORK
        [DllImport("kernel32.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern int GetProcessIoCounters(SafeProcessHandle process, out IoCounters counters);
#else
        [LibraryImport("kernel32.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial int GetProcessIoCounters(SafeProcessHandle process, out IoCounters counters);
#endif

        /// <summary>Calls the documented GetProcessMemoryInfo entry point.</summary>
        /// <param name="process">The native process value.</param>
        /// <param name="counters">The native counters value.</param>
        /// <param name="size">The native size value.</param>
        /// <returns>The native result.</returns>
#if NETFRAMEWORK
        [DllImport("psapi.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern int GetProcessMemoryInfo(SafeProcessHandle process, out MemoryCounters counters, uint size);
#else
        [LibraryImport("psapi.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial int GetProcessMemoryInfo(SafeProcessHandle process, out MemoryCounters counters, uint size);
#endif

        /// <summary>Calls the documented IsWow64Process2 entry point.</summary>
        /// <param name="process">The native process value.</param>
        /// <param name="processMachine">The native processMachine value.</param>
        /// <param name="nativeMachine">The native nativeMachine value.</param>
        /// <returns>The native result.</returns>
#if NETFRAMEWORK
        [DllImport("kernel32.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern int IsWow64Process2(SafeProcessHandle process, out ushort processMachine, out ushort nativeMachine);
#else
        [LibraryImport("kernel32.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial int IsWow64Process2(SafeProcessHandle process, out ushort processMachine, out ushort nativeMachine);
#endif

        /// <summary>Calls the documented GetActiveProcessorCount entry point.</summary>
        /// <param name="groupNumber">The native groupNumber value.</param>
        /// <returns>The native result.</returns>
#if NETFRAMEWORK
        [DllImport("kernel32.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern uint GetActiveProcessorCount(ushort groupNumber);
#else
        [LibraryImport("kernel32.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial uint GetActiveProcessorCount(ushort groupNumber);
#endif

        /// <summary>Opens the query-only process access token.</summary>
        /// <param name="process">The process handle.</param>
        /// <param name="access">The token access mask.</param>
        /// <param name="token">The owned token handle.</param>
        /// <returns>The native success result.</returns>
#if NETFRAMEWORK
        [DllImport("advapi32.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern int OpenProcessToken(SafeProcessHandle process, uint access, out IntPtr token);
#else
        [LibraryImport("advapi32.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial int OpenProcessToken(SafeProcessHandle process, uint access, out IntPtr token);
#endif

        /// <summary>Releases an owned token handle.</summary>
        /// <param name="handle">The token handle.</param>
        /// <returns>The native success result.</returns>
#if NETFRAMEWORK
        [DllImport("kernel32.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern int CloseHandle(IntPtr handle);
#else
        [LibraryImport("kernel32.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial int CloseHandle(IntPtr handle);
#endif
    }
}
