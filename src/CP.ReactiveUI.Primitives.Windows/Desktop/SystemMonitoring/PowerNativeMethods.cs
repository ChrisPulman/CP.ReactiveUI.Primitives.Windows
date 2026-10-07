// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif
/// <summary>Documented power profile native entry points.</summary>
#if NETFRAMEWORK
internal static class PowerNativeMethods
#else
internal static partial class PowerNativeMethods
#endif
{
    /// <summary>Checks a power profile API return code.</summary>
    /// <param name="result">The Windows error code.</param>
    internal static void Check(uint result)
    {
        if (result != 0)
        {
            throw new NativeWin32Exception(unchecked((int)result));
        }
    }

    /// <summary>Native Windows API declarations.</summary>
#if NETFRAMEWORK
    internal static class NativeMethods
#else
    internal static partial class NativeMethods
#endif
    {
        /// <summary>Calls the documented GetSystemPowerStatus entry point.</summary>
        /// <param name="status">The native status parameter.</param>
        /// <returns>The native result.</returns>
#if NETFRAMEWORK
        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern int GetSystemPowerStatus(out PowerStatus status);
#else
        [LibraryImport("kernel32.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial int GetSystemPowerStatus(out PowerStatus status);
#endif

        /// <summary>Calls the documented LocalFree entry point.</summary>
        /// <param name="pointer">The native pointer parameter.</param>
        /// <returns>The native result.</returns>
#if NETFRAMEWORK
        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern IntPtr LocalFree(IntPtr pointer);
#else
        [LibraryImport("kernel32.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial IntPtr LocalFree(IntPtr pointer);
#endif

        /// <summary>Calls the documented PowerEnumerate entry point.</summary>
        /// <param name="root">The native root parameter.</param>
        /// <param name="scheme">The native scheme parameter.</param>
        /// <param name="subgroup">The native subgroup parameter.</param>
        /// <param name="accessFlags">The native accessFlags parameter.</param>
        /// <param name="index">The native index parameter.</param>
        /// <param name="buffer">The native buffer parameter.</param>
        /// <param name="bufferSize">The native bufferSize parameter.</param>
        /// <returns>The native result.</returns>
#if NETFRAMEWORK
        [DllImport("powrprof.dll", ExactSpelling = true, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern uint PowerEnumerate(IntPtr root, IntPtr scheme, IntPtr subgroup, uint accessFlags, uint index, [Out] byte[] buffer, ref uint bufferSize);
#else
        [LibraryImport("powrprof.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial uint PowerEnumerate(IntPtr root,
            IntPtr scheme,
            IntPtr subgroup,
            uint accessFlags,
            uint index,
            [Out,
            MarshalAs(UnmanagedType.LPArray,
            SizeParamIndex = 6)] byte[] buffer,
            ref uint bufferSize);
#endif

        /// <summary>Calls the documented PowerGetActiveScheme entry point.</summary>
        /// <param name="root">The native root parameter.</param>
        /// <param name="scheme">The native scheme parameter.</param>
        /// <returns>The native result.</returns>
#if NETFRAMEWORK
        [DllImport("powrprof.dll", ExactSpelling = true, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern uint PowerGetActiveScheme(IntPtr root, out IntPtr scheme);
#else
        [LibraryImport("powrprof.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial uint PowerGetActiveScheme(IntPtr root, out IntPtr scheme);
#endif

        /// <summary>Calls the documented PowerSetActiveScheme entry point.</summary>
        /// <param name="root">The native root parameter.</param>
        /// <param name="scheme">The native scheme parameter.</param>
        /// <returns>The native result.</returns>
#if NETFRAMEWORK
        [DllImport("powrprof.dll", ExactSpelling = true, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern uint PowerSetActiveScheme(IntPtr root, ref Guid scheme);
#else
        [LibraryImport("powrprof.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial uint PowerSetActiveScheme(IntPtr root, ref Guid scheme);
#endif

        /// <summary>Calls the documented PowerReadFriendlyName entry point.</summary>
        /// <param name="root">The native root parameter.</param>
        /// <param name="scheme">The native scheme parameter.</param>
        /// <param name="subgroup">The native subgroup parameter.</param>
        /// <param name="setting">The native setting parameter.</param>
        /// <param name="buffer">The native buffer parameter.</param>
        /// <param name="bufferSize">The native bufferSize parameter.</param>
        /// <returns>The native result.</returns>
#if NETFRAMEWORK
        [DllImport("powrprof.dll", ExactSpelling = true, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern uint PowerReadFriendlyName(IntPtr root, ref Guid scheme, IntPtr subgroup, IntPtr setting, [Out] byte[]? buffer, ref uint bufferSize);
#else
        [LibraryImport("powrprof.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial uint PowerReadFriendlyName(IntPtr root,
            ref Guid scheme,
            IntPtr subgroup,
            IntPtr setting,
            [Out,
            MarshalAs(UnmanagedType.LPArray,
            SizeParamIndex = 5)] byte[]? buffer,
            ref uint bufferSize);
#endif

        /// <summary>Calls the documented PowerReadACValueIndex entry point.</summary>
        /// <param name="root">The native root parameter.</param>
        /// <param name="scheme">The native scheme parameter.</param>
        /// <param name="subgroup">The native subgroup parameter.</param>
        /// <param name="setting">The native setting parameter.</param>
        /// <param name="value">The native value parameter.</param>
        /// <returns>The native result.</returns>
#if NETFRAMEWORK
        [DllImport("powrprof.dll", ExactSpelling = true, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern uint PowerReadACValueIndex(IntPtr root, ref Guid scheme, ref Guid subgroup, ref Guid setting, out uint value);
#else
        [LibraryImport("powrprof.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial uint PowerReadACValueIndex(IntPtr root, ref Guid scheme, ref Guid subgroup, ref Guid setting, out uint value);
#endif

        /// <summary>Calls the documented PowerReadDCValueIndex entry point.</summary>
        /// <param name="root">The native root parameter.</param>
        /// <param name="scheme">The native scheme parameter.</param>
        /// <param name="subgroup">The native subgroup parameter.</param>
        /// <param name="setting">The native setting parameter.</param>
        /// <param name="value">The native value parameter.</param>
        /// <returns>The native result.</returns>
#if NETFRAMEWORK
        [DllImport("powrprof.dll", ExactSpelling = true, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern uint PowerReadDCValueIndex(IntPtr root, ref Guid scheme, ref Guid subgroup, ref Guid setting, out uint value);
#else
        [LibraryImport("powrprof.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial uint PowerReadDCValueIndex(IntPtr root, ref Guid scheme, ref Guid subgroup, ref Guid setting, out uint value);
#endif

        /// <summary>Calls the documented PowerWriteACValueIndex entry point.</summary>
        /// <param name="root">The native root parameter.</param>
        /// <param name="scheme">The native scheme parameter.</param>
        /// <param name="subgroup">The native subgroup parameter.</param>
        /// <param name="setting">The native setting parameter.</param>
        /// <param name="value">The native value parameter.</param>
        /// <returns>The native result.</returns>
#if NETFRAMEWORK
        [DllImport("powrprof.dll", ExactSpelling = true, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern uint PowerWriteACValueIndex(IntPtr root, ref Guid scheme, ref Guid subgroup, ref Guid setting, uint value);
#else
        [LibraryImport("powrprof.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial uint PowerWriteACValueIndex(IntPtr root, ref Guid scheme, ref Guid subgroup, ref Guid setting, uint value);
#endif

        /// <summary>Calls the documented PowerWriteDCValueIndex entry point.</summary>
        /// <param name="root">The native root parameter.</param>
        /// <param name="scheme">The native scheme parameter.</param>
        /// <param name="subgroup">The native subgroup parameter.</param>
        /// <param name="setting">The native setting parameter.</param>
        /// <param name="value">The native value parameter.</param>
        /// <returns>The native result.</returns>
#if NETFRAMEWORK
        [DllImport("powrprof.dll", ExactSpelling = true, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern uint PowerWriteDCValueIndex(IntPtr root, ref Guid scheme, ref Guid subgroup, ref Guid setting, uint value);
#else
        [LibraryImport("powrprof.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial uint PowerWriteDCValueIndex(IntPtr root, ref Guid scheme, ref Guid subgroup, ref Guid setting, uint value);
#endif
    }
}
