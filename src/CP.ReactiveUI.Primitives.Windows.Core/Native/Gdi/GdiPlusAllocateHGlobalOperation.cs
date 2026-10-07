// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace CP.ReactiveUI.Primitives.Windows.Native.Gdi;

/// <summary>Represents unmanaged memory allocation.</summary>
/// <param name="size">The allocation size.</param>
/// <returns>The allocated memory.</returns>
internal delegate nint GdiPlusAllocateHGlobalOperation(int size);
