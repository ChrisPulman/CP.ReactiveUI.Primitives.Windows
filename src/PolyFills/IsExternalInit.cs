// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NETFRAMEWORK
namespace System.Runtime.CompilerServices;

/// <summary>Enables init-only members on target frameworks that do not provide this compiler type.</summary>
internal static class IsExternalInit
{
    /// <summary>Prevents the compiler marker type from being empty.</summary>
    private const byte CompatibilityMarker = 0;
}
#endif
