// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs;

namespace CP.ReactiveUI.Primitives.Windows.Native.Gdi;

/// <summary>Represents unmanaged blur-parameter writing.</summary>
/// <param name="parameters">The parameters to write.</param>
/// <param name="memory">The target memory.</param>
internal delegate void GdiPlusStructureToPtrOperation(BlurParams parameters, nint memory);
