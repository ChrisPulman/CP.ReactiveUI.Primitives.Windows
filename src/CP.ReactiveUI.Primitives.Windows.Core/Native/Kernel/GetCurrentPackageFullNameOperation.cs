// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace CP.ReactiveUI.Primitives.Windows.Native.Kernel;

/// <summary>Gets the package full name for the current process.</summary>
/// <param name="packageFullNameLength">Package name buffer length.</param>
/// <param name="packageFullName">Package name buffer.</param>
/// <returns>Win32 result code.</returns>
internal unsafe delegate int GetCurrentPackageFullNameOperation(
    ref int packageFullNameLength,
    char* packageFullName);
