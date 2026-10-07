// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>A native power setting read result.</summary>
/// <param name="ErrorCode">The Windows error code.</param>
/// <param name="Value">The setting value index.</param>
internal readonly record struct PowerSettingRead(uint ErrorCode, uint Value);
