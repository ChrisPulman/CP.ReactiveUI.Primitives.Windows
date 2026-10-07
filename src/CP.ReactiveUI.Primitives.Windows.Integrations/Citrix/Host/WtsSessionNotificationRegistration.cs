// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host;

/// <summary>Represents the result of WTS session notification registration.</summary>
/// <param name="WindowHandleValue">The registered window handle value.</param>
/// <param name="Scope">The notification scope requested for the window.</param>
/// <param name="Succeeded">A value indicating whether the registration succeeded.</param>
/// <param name="LastError">The last Win32 error captured after a failed registration.</param>
public readonly record struct WtsSessionNotificationRegistration(
    long WindowHandleValue,
    WtsSessionNotificationScope Scope,
    bool Succeeded,
    int LastError);
