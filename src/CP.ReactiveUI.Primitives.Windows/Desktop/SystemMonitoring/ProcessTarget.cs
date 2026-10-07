// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Diagnostics;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>An explicit process control target bound to its creation time.</summary>
public sealed class ProcessTarget
{
    /// <summary>The process identifier.</summary>
    private readonly int _processId;

    /// <summary>The process creation time used to reject recycled identifiers.</summary>
    private readonly DateTime _startTime;

    /// <summary>Initializes a new instance of the <see cref="ProcessTarget"/> class.</summary>
    /// <param name="process">The process whose identity is captured.</param>
    private ProcessTarget(Process process)
    {
        _processId = process.Id;
        _startTime = process.StartTime.ToUniversalTime();
    }

    /// <summary>Binds a target to the currently running process with the specified identifier.</summary>
    /// <param name="processId">The process identifier.</param>
    /// <returns>The control target.</returns>
    public static ProcessTarget ForId(int processId)
    {
        using var process = Process.GetProcessById(processId);
        return new(process);
    }

    /// <summary>Immediately sets the process priority; access and exit errors propagate.</summary>
    /// <param name="priority">The requested priority class.</param>
    /// <returns>This target.</returns>
    public ProcessTarget WithPriority(ProcessPriorityClass priority)
    {
        using var process = Open();
        process.Process.PriorityClass = priority;
        return this;
    }

    /// <summary>Immediately sets the process affinity mask within its processor group.</summary>
    /// <param name="affinity">The nonzero processor mask supported by the process.</param>
    /// <returns>This target.</returns>
    public ProcessTarget WithAffinity(IntPtr affinity)
    {
        if (affinity == IntPtr.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(affinity));
        }

        using var process = Open();
        process.Process.ProcessorAffinity = affinity;
        return this;
    }

    /// <summary>Requests graceful closure of the process main window.</summary>
    /// <returns>Whether a close message was sent.</returns>
    public bool CloseMainWindow()
    {
        using var process = Open();
        return process.Process.CloseMainWindow();
    }

    /// <summary>Immediately terminates the selected process without terminating descendants.</summary>
    public void Terminate()
    {
        using var process = Open();
        process.Process.Kill();
    }

    /// <summary>Opens and validates the original process identity.</summary>
    /// <returns>The validated process, owned by the caller.</returns>
    private ProcessLease Open()
    {
        var process = Process.GetProcessById(_processId);
        SafeProcessHandle pin = null;
        try
        {
            // Retaining a handle prevents PID reuse between the identity check and the command.
            pin = ProcessQueryHandle.Open(_processId);
            if (process.StartTime.ToUniversalTime() != _startTime)
            {
                throw new InvalidOperationException("The process identifier has been reused.");
            }

            return new(process, pin);
        }
        catch
        {
            pin?.Dispose();
            process.Dispose();
            throw;
        }
    }

    /// <summary>Owns the process view and its identity pin for one explicit command.</summary>
    /// <param name="process">The process view.</param>
    /// <param name="pin">The query handle that prevents identifier reuse.</param>
    private sealed class ProcessLease(Process process, SafeProcessHandle pin) : IDisposable
    {
        /// <summary>Gets the validated process view.</summary>
        internal Process Process => process;

        /// <inheritdoc />
        public void Dispose()
        {
            process.Dispose();
            pin.Dispose();
        }
    }
}
