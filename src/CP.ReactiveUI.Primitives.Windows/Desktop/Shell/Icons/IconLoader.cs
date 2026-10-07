// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons;
#endif
/// <summary>Loads an icon and returns the raw native handle.</summary>
/// <param name="iconHandle">The loaded icon handle.</param>
/// <returns>The native call result.</returns>
internal delegate int IconLoader(out IntPtr iconHandle);
