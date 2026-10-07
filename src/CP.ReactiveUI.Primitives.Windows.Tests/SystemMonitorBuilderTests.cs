// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_TEST_SHIM
using CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Verifies fluent selection, provider isolation, and subscription lifetimes.</summary>
public sealed class SystemMonitorBuilderTests
{
    /// <summary>The expected second sample.</summary>
    private const int SecondSample = 2;

    /// <summary>The expected first subscription history.</summary>
    private static readonly int[] FirstHistory = [1, SecondSample];

    /// <summary>The expected second subscription history.</summary>
    private static readonly int[] SecondHistory = [1];

    /// <summary>Verifies fluent configurations do not modify earlier configurations.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task ConfigurationIsImmutableAndEmptyCaptureDoesNotOpenProvidersAsync()
    {
        var empty = WindowsSystem.Monitor();
        var selected = empty.WithCpu().WithMemory();
        var snapshot = empty.Capture();

        await Assert.That(empty.Sections).IsEqualTo(MonitoringSections.None);
        await Assert.That(selected.Sections).IsEqualTo(MonitoringSections.Cpu | MonitoringSections.Memory);
        await Assert.That(snapshot.Sequence).IsEqualTo(1L);
        await Assert.That(snapshot.Cpu.Status).IsEqualTo(MonitoringStatus.NotRequested);
        await Assert.That(snapshot.Memory.Value).IsNull();
        await Assert.That(() => empty.Every(TimeSpan.Zero)).Throws<ArgumentOutOfRangeException>();
        await Assert.That(() => empty.RefreshHardwareEvery(TimeSpan.FromMilliseconds(-1))).Throws<ArgumentOutOfRangeException>();
    }

    /// <summary>Verifies slow providers retain a measured result and stop when disposed.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task ProviderCacheUsesIndependentStateAndDisposesOnceAsync()
    {
        var sampler = new CountingSampler();
        using var slot = new ProviderSlot<int>(true, () => sampler, TimeSpan.FromSeconds(1));
        var now = TimeProvider.System.GetUtcNow();
        var first = slot.Capture(now);
        var cached = slot.Capture(now);
        var next = slot.Capture(now.AddSeconds(1));

        await Assert.That(first.Value).IsEqualTo(1);
        await Assert.That(cached).IsSameReferenceAs(first);
        await Assert.That(next.Value).IsEqualTo(SecondSample);
        slot.Dispose();
        slot.Dispose();
        await Assert.That(sampler.DisposeCount).IsEqualTo(1);
        await Assert.That(() => slot.Capture(now)).Throws<ObjectDisposedException>();
    }

    /// <summary>Verifies permission and unsupported-provider outcomes do not look like zero measurements.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task ProviderFailuresRemainClassifiedAsync()
    {
        var denied = MonitoringResult<int>.Capture(static () => throw new UnauthorizedAccessException());
        var unsupported = MonitoringResult<int>.Capture(static () => throw new NotSupportedException());
        var failure = MonitoringResult<int>.Capture(static () => throw new InvalidOperationException());

        await Assert.That(denied.Status).IsEqualTo(MonitoringStatus.AccessDenied);
        await Assert.That(denied.IsAvailable).IsFalse();
        await Assert.That(unsupported.Status).IsEqualTo(MonitoringStatus.Unavailable);
        await Assert.That(failure.Status).IsEqualTo(MonitoringStatus.Failed);
    }

    /// <summary>Verifies each subscription owns rate history and cannot emit after disposal.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task PollingSubscriptionsOwnIndependentStateAsync()
    {
        var firstObserver = new CoreInteropCoverageTests.RecordingObserver<int>();
        var secondObserver = new CoreInteropCoverageTests.RecordingObserver<int>();
        using var first = new PollingSubscription<int>(static () => new CountingSampler(), firstObserver, TimeSpan.FromSeconds(1));
        using var second = new PollingSubscription<int>(static () => new CountingSampler(), secondObserver, TimeSpan.FromSeconds(1));
        first.Tick();
        first.Tick();
        second.Tick();
        first.Dispose();
        first.Tick();

        await Assert.That(firstObserver.Values).IsEquivalentTo(FirstHistory);
        await Assert.That(secondObserver.Values).IsEquivalentTo(SecondHistory);
    }

    /// <summary>Verifies a failed provider terminates only its own subscription and releases its state.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task PollingFailureReleasesSamplerAndReportsErrorAsync()
    {
        var observer = new CoreInteropCoverageTests.RecordingObserver<int>();
        var sampler = new CountingSampler { FailCapture = true };
        using var subscription = new PollingSubscription<int>(() => sampler, observer, TimeSpan.FromSeconds(1));
        subscription.Tick();
        subscription.Tick();

        await Assert.That(observer.Error).IsTypeOf<InvalidOperationException>();
        await Assert.That(observer.Values).IsEmpty();
        await Assert.That(sampler.DisposeCount).IsEqualTo(1);
    }

    /// <summary>Verifies vendor providers are created per subscription and disposed exactly once.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task VendorProviderFactoryHasIndependentOwnedLifetimesAsync()
    {
        var firstProvider = new DisposableSensorProvider();
        var secondProvider = new DisposableSensorProvider();
        using var first = new ThermalProviderSampler(() => firstProvider);
        using var second = new ThermalProviderSampler(() => secondProvider);
        first.Dispose();
        first.Dispose();

        await Assert.That(firstProvider.DisposeCount).IsEqualTo(1);
        await Assert.That(secondProvider.DisposeCount).IsEqualTo(0);
        await Assert.That(first.Capture).Throws<ObjectDisposedException>();
        second.Dispose();
        await Assert.That(secondProvider.DisposeCount).IsEqualTo(1);
    }

    /// <summary>Verifies native watcher cancellation cannot run before native startup completes.</summary>
    /// <returns>A task representing the asynchronous test.</returns>
    [Test]
    public async Task WmiCancellationWaitsForStartupCompletionAsync()
    {
        var startup = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var releases = 0;
        var release = WmiEventSubscription.ReleaseAfterStart(startup.Task, () => releases++);

        await Assert.That(releases).IsEqualTo(0);
        startup.SetResult(true);
        await release;
        await Assert.That(releases).IsEqualTo(1);
    }

    /// <summary>Provides a resource-owning vendor sensor for lifetime verification.</summary>
    private sealed class DisposableSensorProvider : IThermalSensorProvider, IDisposable
    {
        /// <summary>Gets the number of disposal calls.</summary>
        internal int DisposeCount { get; private set; }

        /// <inheritdoc />
        public IReadOnlyList<ThermalSensorSample> Capture() => [];

        /// <inheritdoc />
        public void Dispose() => DisposeCount++;
    }

    /// <summary>Provides deterministic per-subscription counters.</summary>
    private sealed class CountingSampler : ISystemSampler<int>
    {
        /// <summary>The last returned value.</summary>
        private int _value;

        /// <summary>Gets or sets whether capture fails.</summary>
        internal bool FailCapture { get; init; }

        /// <summary>Gets the number of disposal calls.</summary>
        internal int DisposeCount { get; private set; }

        /// <inheritdoc />
        public int Capture()
        {
            if (FailCapture)
            {
                throw new InvalidOperationException();
            }

            _value++;
            return _value;
        }

        /// <inheritdoc />
        public void Dispose() => DisposeCount++;
    }
}
