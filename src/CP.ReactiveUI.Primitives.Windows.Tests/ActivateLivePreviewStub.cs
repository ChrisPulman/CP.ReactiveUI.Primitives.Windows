// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Represents the DwmpActivateLivePreview native signature.</summary>
/// <param name="active">The requested active state.</param>
/// <param name="windowHandle">The target window handle.</param>
/// <param name="onTopHandle">The topmost window handle.</param>
/// <param name="unknown">The undocumented option.</param>
/// <returns>A native result.</returns>
[UnmanagedFunctionPointer(CallingConvention.StdCall)]
internal delegate HResult ActivateLivePreviewStub(uint active, IntPtr windowHandle, IntPtr onTopHandle, uint unknown);
