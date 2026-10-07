// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using CP.ReactiveUI.Primitives.Windows.Native.Security.Enums;

namespace CP.ReactiveUI.Primitives.Windows.Native.Security;

/// <summary>Opens a registry key.</summary>
/// <param name="key">Parent registry key handle.</param>
/// <param name="subKey">Subkey name.</param>
/// <param name="options">Open options.</param>
/// <param name="desiredAccess">Requested access rights.</param>
/// <param name="openedKey">Opened registry key handle.</param>
/// <returns>Win32 result code.</returns>
internal delegate int RegOpenKeyOperation(
    nint key,
    string subKey,
    RegistryOpenOptions options,
    RegistryKeySecurityAccessRights desiredAccess,
    out SafeRegistryHandle openedKey);
