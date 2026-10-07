// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace CP.ReactiveUI.Primitives.Windows.Native.Kernel;

/// <summary>Defines a version-query operation.</summary>
/// <param name="versionInfo">The native version information buffer.</param>
/// <returns><see langword="true"/> when the query succeeds.</returns>
internal unsafe delegate bool GetVersionExOperation(void* versionInfo);
