// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons;
#endif

/// <summary>Renders a cursor or icon handle into a bitmap.</summary>
/// <param name="cursorHandle">The cursor or icon handle.</param>
/// <param name="width">The requested bitmap width.</param>
/// <param name="height">The requested bitmap height.</param>
/// <param name="flags">The draw flags.</param>
/// <returns>The rendered bitmap.</returns>
internal delegate Bitmap CursorBitmapRenderer(IntPtr cursorHandle, int width, int height, DrawIconExFlags flags);
