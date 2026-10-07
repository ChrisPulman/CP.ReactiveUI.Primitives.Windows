// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace CP.ReactiveUI.Primitives.Windows.Native.UserInterface;

/// <summary>Represents a physical-cursor-position operation.</summary>
/// <param name="cursorLocation">The cursor location.</param>
/// <returns>True when a physical location was returned.</returns>
internal delegate bool GetPhysicalCursorPosOperation(out NativePoint cursorLocation);
