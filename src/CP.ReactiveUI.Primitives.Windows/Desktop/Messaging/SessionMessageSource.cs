// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.Messaging;
#endif
/// <summary>Creates the session-message source.</summary>
/// <param name="onSetup">The setup callback.</param>
/// <param name="onTeardown">The teardown callback.</param>
/// <returns>The session-message stream.</returns>
internal delegate IObservable<WindowMessage> SessionMessageSource(Action<long> onSetup, Action<long> onTeardown);
