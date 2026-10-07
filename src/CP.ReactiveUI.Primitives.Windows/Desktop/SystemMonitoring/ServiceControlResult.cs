// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>The result of submitting a service operation; acceptance does not establish the final service state.</summary>
public sealed class ServiceControlResult
{
    /// <summary>Initializes a new instance of the <see cref="ServiceControlResult"/> class.</summary>
    /// <param name="target">The operation target.</param>
    /// <param name="method">The provider method.</param>
    /// <param name="nativeCode">The unmodified provider return code, or null when invocation failed.</param>
    /// <param name="error">The invocation failure description.</param>
    internal ServiceControlResult(ServiceTarget target, string method, uint? nativeCode, string? error)
    {
        Target = target;
        Method = method;
        NativeCode = nativeCode;
        Error = error;
    }

    /// <summary>Gets the target for a subsequent explicit operation.</summary>
    public ServiceTarget Target { get; }

    /// <summary>Gets the invoked Win32_Service method name.</summary>
    public string Method { get; }

    /// <summary>Gets the unmodified provider return code. Zero means the request was accepted.</summary>
    public uint? NativeCode { get; }

    /// <summary>Gets whether the provider accepted the request. Observe state to determine completion.</summary>
    public bool IsAccepted => NativeCode == 0;

    /// <summary>Gets an invocation failure description, or null when the provider returned a code.</summary>
    public string? Error { get; }
}
