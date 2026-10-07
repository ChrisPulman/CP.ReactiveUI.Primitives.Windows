// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.ComponentModel;
using System.Diagnostics;
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Process telemetry delta, identity and error isolation tests.</summary>
public class ProcessSamplerTests
{
    /// <summary>The SampleSeconds test value.</summary>
    private const int SampleSeconds = 2;

    /// <summary>The ProcessorCount test value.</summary>
    private const int ProcessorCount = 4;

    /// <summary>The AccessDenied test value.</summary>
    private const int AccessDenied = 5;

    /// <summary>The ExpectedCpuPercent test value.</summary>
    private const int ExpectedCpuPercent = 25;

    /// <summary>The AvailableMemory test value.</summary>
    private const int AvailableMemory = 42;

    /// <summary>The InitialReadBytes test value.</summary>
    private const int InitialReadBytes = 100;

    /// <summary>The InitialWriteBytes test value.</summary>
    private const int InitialWriteBytes = 200;

    /// <summary>The ExpectedWriteRate test value.</summary>
    private const int ExpectedWriteRate = 300;

    /// <summary>The CurrentReadBytes test value.</summary>
    private const int CurrentReadBytes = 500;

    /// <summary>The CurrentWriteBytes test value.</summary>
    private const int CurrentWriteBytes = 800;

    /// <summary>The SampleYear test value.</summary>
    private const int SampleYear = 2026;

    /// <summary>Checks machine-normalized CPU and I/O deltas.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task ApplyRates_SameLifetime_NormalizesCpuAndIo()
    {
        var start = new DateTimeOffset(SampleYear, 1, 1, 0, 0, 0, TimeSpan.Zero);
        var previous = new ProcessInfo
        {
            ProcessId = 1,
            StartTimeUtc = start,
            TotalProcessorTime = TimeSpan.FromSeconds(SampleSeconds),
            ReadBytes = InitialReadBytes,
            WriteBytes = InitialWriteBytes,
        };

        var current = new ProcessInfo
        {
            ProcessId = 1,
            StartTimeUtc = start,
            TotalProcessorTime = TimeSpan.FromSeconds(ProcessorCount),
            ReadBytes = CurrentReadBytes,
            WriteBytes = CurrentWriteBytes,
        };

        ProcessSampler.ApplyRates(current, previous, SampleSeconds, ProcessorCount);
        await Assert.That(current.CpuUsagePercent).IsEqualTo(ExpectedCpuPercent);
        await Assert.That(current.ReadBytesPerSecond).IsEqualTo(InitialWriteBytes);
        await Assert.That(current.WriteBytesPerSecond).IsEqualTo(ExpectedWriteRate);
    }

    /// <summary>Checks that recycled identifiers never inherit old counters.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task ApplyRates_RecycledIdentifier_HasNoRates()
    {
        var previous = new ProcessInfo
        {
            ProcessId = 1,
            StartTimeUtc = new DateTimeOffset(SampleYear, 1, 1, 0, 0, 0, TimeSpan.Zero),
            TotalProcessorTime = TimeSpan.Zero,
            ReadBytes = 1,
        };

        var current = new ProcessInfo
        {
            ProcessId = 1,
            StartTimeUtc = previous.StartTimeUtc.GetValueOrDefault().AddSeconds(1),
            TotalProcessorTime = TimeSpan.FromSeconds(1),
            ReadBytes = InitialReadBytes,
        };

        ProcessSampler.ApplyRates(current, previous, 1, 1);
        await Assert.That(current.CpuUsagePercent).IsNull();
        await Assert.That(current.ReadBytesPerSecond).IsNull();
    }

    /// <summary>Checks that counter resets and invalid timing remain unavailable.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task ApplyRates_ResetCounters_DoesNotUnderflow()
    {
        var previous = new ProcessInfo
        {
            ProcessId = 1,
            StartTimeUtc = new DateTimeOffset(SampleYear, 1, 1, 0, 0, 0, TimeSpan.Zero),
            ReadBytes = InitialReadBytes,
        };

        var current = new ProcessInfo
        {
            ProcessId = 1,
            StartTimeUtc = previous.StartTimeUtc,
            ReadBytes = 1,
        };

        ProcessSampler.ApplyRates(current, previous, 1, 1);
        await Assert.That(current.ReadBytesPerSecond).IsNull();
        ProcessSampler.ApplyRates(current, previous, 0, 1);
        await Assert.That(current.CpuUsagePercent).IsNull();
    }

    /// <summary>Checks field errors are isolated and recorded.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task ReadField_AccessDenied_ReturnsUnavailableAndError()
    {
        var errors = new List<string>();
        var value = ProcessSampler.ReadField<long?>(static () => throw new Win32Exception(AccessDenied), "Memory", errors);
        await Assert.That(value).IsNull();
        await Assert.That(errors.Count).IsEqualTo(1);
        var available = ProcessSampler.ReadField<long?>(static () => AvailableMemory, "Memory", errors);
        await Assert.That(available).IsEqualTo(AvailableMemory);
    }

    /// <summary>Checks a process that exits during capture leaves a field-specific error.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task ReadField_ProcessExited_ReturnsUnavailableAndError()
    {
        var errors = new List<string>();
        var value = ProcessSampler.ReadField<int?>(static () => throw new InvalidOperationException("Process exited."), "Threads", errors);
        await Assert.That(value).IsNull();
        await Assert.That(errors.Count).IsEqualTo(1);
    }

    /// <summary>Checks unavailable creation times do not connect unrelated process counters.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task ApplyRates_UnknownCreationTime_HasNoRates()
    {
        var previous = new ProcessInfo { ProcessId = 1, ReadBytes = 1 };
        var current = new ProcessInfo { ProcessId = 1, ReadBytes = InitialReadBytes };
        ProcessSampler.ApplyRates(current, previous, 1, 1);
        await Assert.That(current.ReadBytesPerSecond).IsNull();
    }

    /// <summary>Checks a read-only capture includes the current process without mutation.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task Capture_CurrentProcess_ReturnsIdentityAndMemory()
    {
        using var current = Process.GetCurrentProcess();
        var snapshot = ProcessMonitoring.Capture(current.Id);
        await Assert.That(snapshot.Processes.Count).IsEqualTo(1);
        var sample = snapshot.Processes[0];
        await Assert.That(sample.ProcessId).IsEqualTo(current.Id);
        await Assert.That(sample.StartTimeUtc.HasValue).IsTrue();
        await Assert.That(sample.WorkingSetBytes > 0).IsTrue();
        await Assert.That(sample.CpuUsagePercent).IsNull();
        await Assert.That(sample.ReadBytes).IsNotNull();
        await Assert.That(sample.WriteBytes).IsNotNull();
        await Assert.That(sample.PageFaultCount).IsNotNull();
        await Assert.That(sample.Architecture).IsNotNull();
        await Assert.That(sample.UserName).IsNotNull();
    }
}
