// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons;
#endif

/// <summary>Creates a mask bitmap for an alpha-less cursor.</summary>
/// <param name="cursorHandle">The native cursor handle.</param>
/// <param name="width">The requested mask width.</param>
/// <param name="height">The requested mask height.</param>
/// <returns>The created mask bitmap.</returns>
internal delegate Bitmap CursorMaskLayerProvider(IntPtr cursorHandle, int width, int height);
