// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using RawInputSubscriptionSlot = global::ReactiveUI.Primitives.Disposables.AssignmentSlot;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.Input;
#endif
/// <summary>Reactive access to RawInput.</summary>
public static class RawInputMonitor
{
    /// <summary>The cached shared raw-input observable.</summary>
    private static IObservable<RawInputEventArgs> _rawInputObservable;

    /// <summary>
    /// Gets the shared observable for Raw Input.
    /// Multiple subscribers will share the same underlying hook, and the hook
    /// is automatically disposed when the subscriber count reaches zero.
    /// </summary>
    /// <param name="devices">The raw input device types to register.</param>
    /// <returns>A shared stream of raw input events.</returns>
    public static IObservable<RawInputEventArgs> ObserveRawInput(params RawInputDevices[] devices)
    {
        if (_rawInputObservable is not null)
        {
            return _rawInputObservable;
        }

        _rawInputObservable = ReactiveSignal.CreateSafe<RawInputEventArgs>(observer =>
        {
            var source = Infrastructure.MessageSource;
            return CreateObservation(
                source,
                WindowsMessages.WM_INPUT,
                handle => RawInputApi.RegisterRawInput((nint)handle, RawInputDeviceFlags.InputSink | RawInputDeviceFlags.DeviceNotify, devices),
                ReadInput,
                static () => _rawInputObservable = null).Subscribe(observer);
        }).Publish().RefCount();
        return _rawInputObservable;
    }

    /// <summary>Resets the cached raw-input observable for deterministic tests.</summary>
    internal static void ResetForTesting() => _rawInputObservable = null;

    /// <summary>Composes message observation with registration and input reads.</summary>
    /// <typeparam name="T">The observed input event type.</typeparam>
    /// <param name="source">The message and handle source.</param>
    /// <param name="messageKind">The input message to process.</param>
    /// <param name="register">Registers the first available handle.</param>
    /// <param name="read">Reads one input message.</param>
    /// <param name="onStopped">Releases the cached stream on termination.</param>
    /// <returns>The owned input observation.</returns>
    internal static IObservable<T> CreateObservation<T>(
        IRawInputMessageSource source,
        WindowsMessages messageKind,
        Action<long> register,
        Func<WindowMessage, T> read,
        Action onStopped) => ReactiveSignal.CreateSafe<T>(observer =>
        {
            var subscription = new InputSubscription<T>(observer, messageKind, register, read, onStopped);
            try
            {
                subscription.Attach(source);
                return subscription;
            }
            catch (Exception error)
            {
                if (!subscription.CanReportSetupFailure)
                {
                    subscription.Dispose();
                    throw;
                }

                subscription.OnError(error);
                return subscription;
            }
        });

    /// <summary>Reads a raw-input message while its native payload is valid.</summary>
    /// <param name="message">The native input message.</param>
    /// <returns>The input record, or null when the native read fails.</returns>
    private static RawInputEventArgs ReadInput(WindowMessage message)
    {
        var dataSize = Marshal.SizeOf<RawInput>();
        return RawInputApi.GetRawInputData((nint)message.LParam, RawInputDataCommands.Input, out var data, ref dataSize, Marshal.SizeOf<RawInputHeader>()) != -1
            ? new RawInputEventArgs { IsForeground = checked((int)message.WParam) == 0, RawInput = data }
            : null;
    }

    /// <summary>Raw-input monitor infrastructure shared by the raw-input monitor types.</summary>
    internal static class Infrastructure
    {
        /// <summary>The default shared message source.</summary>
        private static readonly IRawInputMessageSource DefaultMessageSource = new SharedRawInputMessageSource();

        /// <summary>The active message source.</summary>
        private static IRawInputMessageSource _messageSource = DefaultMessageSource;

        /// <summary>Gets the active raw-input message source.</summary>
        internal static IRawInputMessageSource MessageSource => _messageSource;

        /// <summary>Overrides the raw-input message source for deterministic tests.</summary>
        /// <param name="messageSource">The replacement source.</param>
        /// <returns>A scope that restores the previous source.</returns>
        internal static IDisposable OverrideMessageSourceForTesting(IRawInputMessageSource messageSource)
        {
            Throw.IfNull(messageSource);
            var messageSource2 = _messageSource;
            _messageSource = messageSource;
            ResetMonitorCaches();
            return Scope.Create(messageSource2, static source =>
            {
                _messageSource = source;
                ResetMonitorCaches();
            });
        }

        /// <summary>Resets raw-input monitor caches.</summary>
        private static void ResetMonitorCaches()
        {
            ResetForTesting();
            RawInputDeviceMonitor.ResetForTesting();
        }
    }

    /// <summary>Serializes native callbacks with disposal and owns both source subscriptions.</summary>
    /// <typeparam name="T">The input event type.</typeparam>
    /// <param name="observer">The downstream input observer.</param>
    /// <param name="messageKind">The input message to process.</param>
    /// <param name="register">The native registration operation.</param>
    /// <param name="read">The native input read.</param>
    /// <param name="onStopped">The stream cache cleanup.</param>
    private sealed class InputSubscription<T>(
        IObserver<T> observer,
        WindowsMessages messageKind,
        Action<long> register,
        Func<WindowMessage, T> read,
        Action onStopped) : IObserver<WindowMessage>, IDisposable
    {
        /// <summary>Serializes callback execution and termination.</summary>
#if NET9_0_OR_GREATER
        private readonly System.Threading.Lock _gate = new();
#else
        private readonly object _gate = new();
#endif

        /// <summary>Owns the message subscription, including late assignment.</summary>
        private readonly RawInputSubscriptionSlot _messages = new();

        /// <summary>Owns the handle subscription, including late assignment.</summary>
        private readonly RawInputSubscriptionSlot _handles = new();

        /// <summary>Tracks terminal state under the callback gate.</summary>
        private bool _stopped;

        /// <summary>Tracks a downstream callback exception that must retain its propagation.</summary>
        private bool _observerFailed;

        /// <summary>Gets whether an attachment exception can become an observable error.</summary>
        internal bool CanReportSetupFailure
        {
            get
            {
                lock (_gate)
                {
                    return !_stopped && !_observerFailed;
                }
            }
        }

        /// <inheritdoc />
        public void OnNext(WindowMessage value)
        {
            lock (_gate)
            {
                if (_stopped || value.Msg != messageKind)
                {
                    return;
                }

                value.Handled = true;
                T input;
                try
                {
                    input = read(value);
                }
                catch (Exception error)
                {
                    OnError(error);
                    return;
                }

                if (!_stopped && input is not null)
                {
                    try
                    {
                        observer.OnNext(input);
                    }
                    catch
                    {
                        _observerFailed = true;
                        throw;
                    }
                }
            }
        }

        /// <inheritdoc />
        public void OnError(Exception error)
        {
            lock (_gate)
            {
                if (_stopped)
                {
                    return;
                }

                Dispose();
                observer.OnError(error);
            }
        }

        /// <inheritdoc />
        public void OnCompleted()
        {
            lock (_gate)
            {
                if (_stopped)
                {
                    return;
                }

                Dispose();
                observer.OnCompleted();
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            lock (_gate)
            {
                if (_stopped)
                {
                    return;
                }

                _stopped = true;
            }

            onStopped();
            _handles.Dispose();
            _messages.Dispose();
        }

        /// <summary>Attaches sources and transfers their ownership.</summary>
        /// <param name="source">The raw-input source.</param>
        internal void Attach(IRawInputMessageSource source)
        {
            _messages.Create(source.Messages.Subscribe(this));
            lock (_gate)
            {
                if (_stopped)
                {
                    return;
                }
            }

            _handles.Create(source.ObserveHandleChanges().Where(static handle => handle != 0).Take(1)
                .Subscribe(Register, OnError));
        }

        /// <summary>Registers a handle only while observation remains active.</summary>
        /// <param name="handle">The available message-window handle.</param>
        private void Register(long handle)
        {
            lock (_gate)
            {
                if (_stopped)
                {
                    return;
                }

                try
                {
                    register(handle);
                }
                catch (Exception error)
                {
                    OnError(error);
                }
            }
        }
    }

    /// <summary>Production raw-input message source backed by the shared message window.</summary>
    private sealed class SharedRawInputMessageSource : IRawInputMessageSource
    {
        /// <inheritdoc />
        public IObservable<WindowMessage> Messages => SharedMessageWindow.WindowMessageEvents;

        /// <inheritdoc />
        public IObservable<long> ObserveHandleChanges() => SharedMessageWindow.ObserveHandleChanges();
    }
}
