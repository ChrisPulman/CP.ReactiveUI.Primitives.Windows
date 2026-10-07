// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NETFRAMEWORK
namespace System.Diagnostics.CodeAnalysis;

/// <summary>Indicates that a constructor initializes every required member.</summary>
[AttributeUsage(AttributeTargets.Constructor)]
internal sealed class SetsRequiredMembersAttribute : Attribute;
#endif
