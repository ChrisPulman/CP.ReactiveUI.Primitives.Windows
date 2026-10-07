// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using CP.ReactiveUI.Primitives.Windows.Integrations;
using CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host;

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Verifies deferred integration calls through managed adapters.</summary>
public sealed class IntegrationOperationTests
{
    /// <summary>The query session identifier.</summary>
    private const int QuerySessionId = 42;

    /// <summary>The number of independent subscribers.</summary>
    private const int SubscriberCount = 2;

    /// <summary>The disconnect session identifier.</summary>
    private const int DisconnectSessionId = 12;

    /// <summary>The logoff session identifier.</summary>
    private const int LogoffSessionId = 34;

    /// <summary>The distinct disconnect result code.</summary>
    private const int DisconnectResultCode = 17;

    /// <summary>The distinct logoff result code.</summary>
    private const int LogoffResultCode = 23;

    /// <summary>Verifies each subscriber queries its selected session without owning the adapter.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task SessionQuery_DefersAndRepeatsWithoutDisposingReceiverAsync()
    {
        using var api = new SessionApi();
        var operation = api.GetSessionInfoOperation(QuerySessionId).Select(static result => result.SessionId);
        var observable = operation.Observe();
        await Assert.That(api.Queries).IsEqualTo(0);
        var first = new RecordingObserver<int>();
        var second = new RecordingObserver<int>();
        observable.Subscribe(first).Dispose();
        observable.Subscribe(second).Dispose();
        await Assert.That(api.Queries).IsEqualTo(SubscriberCount);
        await Assert.That(first.Value).IsEqualTo(QuerySessionId);
        await Assert.That(second.Value).IsEqualTo(QuerySessionId);
        await Assert.That(first.Completions).IsEqualTo(1);
        await Assert.That(api.Disposed).IsFalse();
    }

    /// <summary>Verifies disconnect and logoff preserve native status values and session identifiers.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task SessionCommands_ExecuteOnlyOnCaptureAndPreserveResultsAsync()
    {
        var calls = new List<int>();
        var api = new DelegatingCitrixCcmHostSessionApi(
            static id => new(id, 0, default, false),
            id =>
            {
                calls.Add(id);
                return new(id, DisconnectResultCode);
            },
            id =>
            {
                calls.Add(-id);
                return new(id, LogoffResultCode);
            });
        var disconnect = api.DisconnectSessionOperation(DisconnectSessionId);
        var logoff = api.LogoffSessionOperation(LogoffSessionId);
        await Assert.That(calls.Count).IsEqualTo(0);
        await Assert.That(disconnect.Capture()).IsEqualTo(new(DisconnectSessionId, DisconnectResultCode));
        await Assert.That(logoff.Capture()).IsEqualTo(new(LogoffSessionId, LogoffResultCode));
        await Assert.That(calls[0]).IsEqualTo(DisconnectSessionId);
        await Assert.That(calls[1]).IsEqualTo(-LogoffSessionId);
    }

    /// <summary>Verifies missing native dependencies reach OnError only after subscription.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task MissingNativeDependency_NotifiesOnErrorAfterSubscriptionAsync()
    {
        var calls = 0;
        var failure = new DllNotFoundException("managed test dependency");
        var api = new DelegatingCitrixCcmHostSessionApi(
            static id => new(id, 0, default, false),
            _ =>
            {
                calls++;
                throw failure;
            },
            static id => new(id, 0));
        var observable = api.DisconnectSessionOperation(QuerySessionId).Observe();
        await Assert.That(calls).IsEqualTo(0);
        var observer = new RecordingObserver<CcmHostOperationResult>();
        using var subscription = observable.Subscribe(observer);
        await Assert.That(calls).IsEqualTo(1);
        await Assert.That(observer.Error).IsSameReferenceAs(failure);
        await Assert.That(observer.Values).IsEqualTo(0);
        await Assert.That(observer.Completions).IsEqualTo(0);
    }

    /// <summary>Records calls and disposal of a caller-owned adapter.</summary>
    private sealed class SessionApi : ICitrixCcmHostSessionApi, IDisposable
    {
        /// <summary>Gets the query count.</summary>
        public int Queries { get; private set; }

        /// <summary>Gets a value indicating whether the adapter was disposed.</summary>
        public bool Disposed { get; private set; }

        /// <inheritdoc />
        public CcmHostSessionInformationResult GetSessionInfo(int sessionId)
        {
            Queries++;
            return new(sessionId, 0, default, false);
        }

        /// <inheritdoc />
        public CcmHostOperationResult DisconnectSession(int sessionId) => new(sessionId, 0);

        /// <inheritdoc />
        public CcmHostOperationResult LogoffSession(int sessionId) => DisconnectSession(sessionId);

        /// <inheritdoc />
        public void Dispose() => Disposed = true;
    }

    /// <summary>Records synchronous observable notifications.</summary>
    /// <typeparam name="T">The observed value type.</typeparam>
    private sealed class RecordingObserver<T> : IObserver<T>
    {
        /// <summary>Gets the most recently observed value.</summary>
        public T Value { get; private set; }

        /// <summary>Gets the value count.</summary>
        public int Values { get; private set; }

        /// <summary>Gets the observed failure.</summary>
        public Exception Error { get; private set; }

        /// <summary>Gets the completion count.</summary>
        public int Completions { get; private set; }

        /// <inheritdoc />
        public void OnNext(T value)
        {
            Value = value;
            Values++;
        }

        /// <inheritdoc />
        public void OnError(Exception error) => Error = error;

        /// <inheritdoc />
        public void OnCompleted() => Completions++;
    }
}
