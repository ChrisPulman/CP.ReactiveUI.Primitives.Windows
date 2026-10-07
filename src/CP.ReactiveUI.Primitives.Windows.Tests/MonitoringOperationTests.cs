// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_TEST_SHIM
using CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Verifies deferred monitoring commands with injected providers and no machine setting changes.</summary>
public sealed class MonitoringOperationTests
{
    /// <summary>The injected service and panel identity.</summary>
    private const string FixtureName = "fixture";

    /// <summary>The provider code for a denied service request.</summary>
    private const uint ServiceDeniedCode = 2U;

    /// <summary>The number of independent subscriptions and AC/DC operations.</summary>
    private const int PairCount = 2;

    /// <summary>The injected AC setting value.</summary>
    private const uint AcSettingValue = 25U;

    /// <summary>The injected DC setting value.</summary>
    private const uint DcSettingValue = 75U;

    /// <summary>The native Win32 access denial code.</summary>
    private const int NativeAccessDeniedCode = 5;

    /// <summary>A valid panel brightness percentage.</summary>
    private const byte PanelBrightness = 50;

    /// <summary>A representative physical monitor brightness value.</summary>
    private const uint DisplayBrightness = 50U;

    /// <summary>Verifies service command construction and observation perform no provider calls.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task ServiceCommands_Construction_DefersProviderCalls()
    {
        var calls = new List<string>();
        var target = new ServiceTarget(FixtureName, (_, method, mode) =>
        {
            calls.Add($"{method}:{mode}");
            return ServiceDeniedCode;
        });
        var start = target.StartOperation();
        var stop = target.StopOperation();
        var pause = target.PauseOperation();
        var resume = target.ResumeOperation();
        var mode = target.StartModeOperation(ServiceStartMode.Disabled);
        var observable = start.Observe();

        await Assert.That(calls.Count).IsEqualTo(0);
        await Assert.That(observable).IsNotNull();
        var result = start.Capture();
        await Assert.That(result.NativeCode).IsEqualTo(ServiceDeniedCode);
        await Assert.That(result.IsAccepted).IsFalse();
        await Assert.That(result.Target).IsSameReferenceAs(target);
        _ = stop.Capture();
        _ = pause.Capture();
        _ = resume.Capture();
        _ = mode.Capture();
        await Assert.That(string.Join(",", calls)).IsEqualTo("StartService:,StopService:,PauseService:,ResumeService:,ChangeStartMode:Disabled");
    }

    /// <summary>Verifies service observation invokes once per subscriber and completes without polling.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task ServiceCommand_Observe_InvokesOncePerSubscriber()
    {
        var calls = 0;
        var target = new ServiceTarget(FixtureName, (_, _, _) =>
        {
            calls++;
            return 0U;
        });
        var observable = target.StartOperation().Observe();
        var first = new RecordingObserver<ServiceControlResult>();
        var second = new RecordingObserver<ServiceControlResult>();
        using var firstSubscription = observable.Subscribe(first);
        using var secondSubscription = observable.Subscribe(second);

        await Assert.That(calls).IsEqualTo(PairCount);
        await Assert.That(first.Values.Count).IsEqualTo(1);
        await Assert.That(first.Values[0].IsAccepted).IsTrue();
        await Assert.That(first.Completions).IsEqualTo(1);
        await Assert.That(second.Values.Count).IsEqualTo(1);
        await Assert.That(second.Completions).IsEqualTo(1);
        await Assert.That(first.Error).IsNull();
        await Assert.That(second.Error).IsNull();
    }

    /// <summary>Verifies provider invocation failure remains a service result with its original details.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task ServiceCommand_AccessDenied_PreservesProviderFailure()
    {
        var target = new ServiceTarget(FixtureName, static (_, _, _) => throw new UnauthorizedAccessException("denied"));
        var observer = new RecordingObserver<ServiceControlResult>();
        using var subscription = target.StopOperation().Observe().Subscribe(observer);

        await Assert.That(observer.Values.Count).IsEqualTo(1);
        await Assert.That(observer.Values[0].NativeCode).IsNull();
        await Assert.That(observer.Values[0].Error).IsEqualTo("denied");
        await Assert.That(observer.Values[0].IsAccepted).IsFalse();
        await Assert.That(observer.Error).IsNull();
        await Assert.That(observer.Completions).IsEqualTo(1);
    }

    /// <summary>Verifies power setting identities and values reach the injected provider only at execution.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task PowerCommands_Capture_PreservesArgumentsAndTarget()
    {
        var id = Guid.NewGuid();
        var subgroup = Guid.NewGuid();
        var setting = Guid.NewGuid();
        var writes = new List<(Guid Plan, Guid Subgroup, Guid Setting, bool Dc, uint Value)>();
        var activations = new List<Guid>();
        var target = new PowerPlan(id, new PowerPlanOperations
        {
            Write = (plan, group, key, dc, value) =>
            {
                writes.Add((plan, group, key, dc, value));
                return 0U;
            },
            Activate = plan =>
            {
                activations.Add(plan);
                return 0U;
            },
        });
        var ac = target.AcValueOperation(subgroup, setting, AcSettingValue);
        var dc = target.DcValueOperation(subgroup, setting, DcSettingValue);
        var activate = target.ActivateOperation();

        await Assert.That(writes.Count).IsEqualTo(0);
        await Assert.That(activations.Count).IsEqualTo(0);
        await Assert.That(ac.Capture()).IsSameReferenceAs(target);
        await Assert.That(dc.Capture()).IsSameReferenceAs(target);
        await Assert.That(activate.Capture()).IsSameReferenceAs(target);
        await Assert.That(writes.Count).IsEqualTo(PairCount);
        await Assert.That(writes[0]).IsEqualTo((id, subgroup, setting, false, AcSettingValue));
        await Assert.That(writes[1]).IsEqualTo((id, subgroup, setting, true, DcSettingValue));
        await Assert.That(activations[0]).IsEqualTo(id);
    }

    /// <summary>Verifies native power failures propagate through capture and observable error notification.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task PowerCommand_NativeFailure_PropagatesError()
    {
        var target = new PowerPlan(Guid.NewGuid(), new PowerPlanOperations { Activate = static _ => NativeAccessDeniedCode });
        var operation = target.ActivateOperation();
        await Assert.That(() => operation.Capture()).Throws<NativeWin32Exception>();
        var observer = new RecordingObserver<PowerPlan>();
        using var subscription = operation.Observe().Subscribe(observer);

        var error = await Assert.That(observer.Error).IsTypeOf<NativeWin32Exception>();
        await Assert.That(error?.NativeErrorCode).IsEqualTo(NativeAccessDeniedCode);
        await Assert.That(observer.Values.Count).IsEqualTo(0);
        await Assert.That(observer.Completions).IsEqualTo(0);
    }

    /// <summary>Verifies setting reads are deferred and keep their native AC/DC values.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task PowerReads_Capture_PreservesSourceAndValues()
    {
        var calls = 0;
        var target = new PowerPlan(Guid.NewGuid(), new PowerPlanOperations
        {
            Read = (_, _, _, dc) =>
            {
                calls++;
                return new PowerSettingRead(0U, dc ? DcSettingValue : AcSettingValue);
            },
        });
        var ac = target.ReadAcValueOperation(Guid.NewGuid(), Guid.NewGuid());
        var dc = target.ReadDcValueOperation(Guid.NewGuid(), Guid.NewGuid());

        await Assert.That(calls).IsEqualTo(0);
        await Assert.That(ac.Capture()).IsEqualTo(AcSettingValue);
        await Assert.That(dc.Capture()).IsEqualTo(DcSettingValue);
        await Assert.That(calls).IsEqualTo(PairCount);
    }

    /// <summary>Verifies brightness validation runs at execution before any WMI access.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task PanelBrightness_InvalidPercentage_FailsAtExecution()
    {
        var operation = BrightnessPanel.ForDisplay(FixtureName).SetBrightnessOperation(byte.MaxValue);
        await Assert.That(() => operation.Capture()).Throws<ArgumentOutOfRangeException>();
        var observer = new RecordingObserver<BrightnessPanel>();
        using var subscription = operation.Observe().Subscribe(observer);

        await Assert.That(observer.Error).IsTypeOf<ArgumentOutOfRangeException>();
        await Assert.That(observer.Values.Count).IsEqualTo(0);
        await Assert.That(observer.Completions).IsEqualTo(0);
    }

    /// <summary>Verifies null targets are rejected during operation construction.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task Operation_NullTarget_RejectsConstruction()
    {
        await Assert.That(static () => MonitoringOperationExtensions.StartOperation(null!)).Throws<ArgumentNullException>();
        await Assert.That(static () => MonitoringOperationExtensions.ActivateOperation(null!)).Throws<ArgumentNullException>();
        await Assert.That(static () => MonitoringOperationExtensions.TerminateOperation(null!)).Throws<ArgumentNullException>();
        await Assert.That(static () => MonitoringOperationExtensions.SetBrightnessOperation((BrightnessPanel)null!, PanelBrightness)).Throws<ArgumentNullException>();
        await Assert.That(static () => MonitoringOperationExtensions.SetBrightnessOperation((BrightnessDisplay)null!, DisplayBrightness)).Throws<ArgumentNullException>();
        await Assert.That(static () => MonitoringOperationExtensions.CaptureOperation((SystemMonitorBuilder)null!)).Throws<ArgumentNullException>();
    }

    /// <summary>Records finite operation notifications.</summary>
    /// <typeparam name="T">The result type.</typeparam>
    private sealed class RecordingObserver<T> : IObserver<T>
    {
        /// <summary>Gets the received values.</summary>
        public List<T> Values { get; } = [];

        /// <summary>Gets the received failure.</summary>
        public Exception? Error { get; private set; }

        /// <summary>Gets the number of completion notifications.</summary>
        public int Completions { get; private set; }

        /// <inheritdoc />
        public void OnNext(T value) => Values.Add(value);

        /// <inheritdoc />
        public void OnError(Exception error) => Error = error;

        /// <inheritdoc />
        public void OnCompleted() => Completions++;
    }
}
