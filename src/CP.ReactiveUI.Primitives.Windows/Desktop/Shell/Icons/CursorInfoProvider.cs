// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons;
#endif

/// <summary>Retrieves native cursor information.</summary>
/// <param name="cursorInfo">The cursor information to populate.</param>
/// <returns><see langword="true" /> when the cursor information was retrieved.</returns>
internal delegate bool CursorInfoProvider(ref CursorInfo cursorInfo);
