// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Acquires only query access and keeps a process identifier pinned to its kernel object.</summary>
internal static class ProcessQueryHandle
{
    /// <summary>Opens a process without requesting mutation or virtual-memory-write access.</summary>
    /// <param name="processId">The process identifier.</param>
    /// <returns>An owned process handle.</returns>
    internal static SafeProcessHandle Open(int processId)
    {
        var handle = Kernel32Api.OpenProcess(ProcessAccessRights.QueryLimitedInformation, false, processId);
        if (handle == IntPtr.Zero)
        {
            throw new NativeWin32Exception(Marshal.GetLastWin32Error());
        }

        return new(handle, ownsHandle: true);
    }
}
