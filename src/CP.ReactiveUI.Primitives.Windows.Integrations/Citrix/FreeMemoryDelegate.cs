// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace CP.ReactiveUI.Primitives.Windows.Integrations.Citrix;

/// <summary>Represents the native WFFreeMemory export.</summary>
/// <param name="memory">The memory pointer to free.</param>
internal delegate void FreeMemoryDelegate(IntPtr memory);
