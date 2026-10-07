// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
using System.Management;
using System.Security;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>An explicit local service control target. Creating a target performs no operation.</summary>
public sealed class ServiceTarget
{
    /// <summary>The provider operation timeout in seconds.</summary>
    private const int OperationTimeoutSeconds = 10;

    /// <summary>The provider invocation used by this target.</summary>
    private readonly Func<string, string, string?, uint?> _invoke;

    /// <summary>Initializes a new instance of the <see cref="ServiceTarget"/> class.</summary>
    /// <param name="name">The service name.</param>
    /// <param name="invoke">The provider invocation.</param>
    internal ServiceTarget(string name, Func<string, string, string?, uint?> invoke)
    {
        Throw.IfNullOrWhiteSpace(name);
        Throw.IfNull(invoke);
        foreach (var character in name)
        {
            if (char.IsControl(character))
            {
                throw new ArgumentException("The service name contains a control character.", nameof(name));
            }
        }

        Name = name;
        _invoke = invoke;
    }

    /// <summary>Gets the service's provider key name.</summary>
    public string Name { get; }

    /// <summary>Creates a target using the service key name, rather than its display name.</summary>
    /// <param name="name">The local service name.</param>
    /// <returns>The target, without modifying the service.</returns>
    public static ServiceTarget ForName(string name) => new(name, InvokeProvider);

    /// <summary>Explicitly requests service startup. Observe state to determine completion.</summary>
    /// <returns>The unmodified provider result.</returns>
    public ServiceControlResult Start() => Execute("StartService", null);

    /// <summary>Explicitly requests service shutdown. Observe state to determine completion.</summary>
    /// <returns>The unmodified provider result.</returns>
    public ServiceControlResult Stop() => Execute("StopService", null);

    /// <summary>Explicitly requests that the service pause.</summary>
    /// <returns>The unmodified provider result.</returns>
    public ServiceControlResult Pause() => Execute("PauseService", null);

    /// <summary>Explicitly requests that a paused service resume.</summary>
    /// <returns>The unmodified provider result.</returns>
    public ServiceControlResult Resume() => Execute("ResumeService", null);

    /// <summary>Immediately submits a startup configuration change. Boot and System apply only to drivers.</summary>
    /// <param name="mode">The documented provider startup mode.</param>
    /// <returns>The result; its Target property permits another explicit operation.</returns>
    public ServiceControlResult WithStartMode(ServiceStartMode mode)
    {
        var value = mode switch
        {
            ServiceStartMode.Boot => "Boot",
            ServiceStartMode.System => "System",
            ServiceStartMode.Automatic => "Automatic",
            ServiceStartMode.Manual => "Manual",
            ServiceStartMode.Disabled => "Disabled",
            _ => throw new ArgumentOutOfRangeException(nameof(mode)),
        };
        return Execute("ChangeStartMode", value);
    }

    /// <summary>Creates a quoted CIM object key, without constructing a WQL query.</summary>
    /// <param name="name">The service key name.</param>
    /// <returns>The escaped relative object path.</returns>
    internal static string ObjectPath(string name)
    {
        var escapedName = name.Replace("\\", "\\\\").Replace("\"", "\\\"");
        return $"Win32_Service.Name=\"{escapedName}\"";
    }

    /// <summary>Invokes a documented method on the exact local service instance.</summary>
    /// <param name="name">The service key name.</param>
    /// <param name="method">The fixed provider method.</param>
    /// <param name="startMode">The startup mode for ChangeStartMode, or null.</param>
    /// <returns>The native return code, when provided.</returns>
    private static uint? InvokeProvider(string name, string method, string? startMode)
    {
        var scope = new ManagementScope(@"\\.\root\cimv2");
        using var service = new ManagementObject(scope, new ManagementPath(ObjectPath(name)), null);
        using var input = startMode is null ? null : service.GetMethodParameters(method);
        if (input is not null)
        {
            input["StartMode"] = startMode;
        }

        using var output = service.InvokeMethod(method, input, new InvokeMethodOptions { Timeout = TimeSpan.FromSeconds(OperationTimeoutSeconds) });
        return output?["ReturnValue"] is uint code ? code : null;
    }

    /// <summary>Submits one operation while preserving provider errors and native return values.</summary>
    /// <param name="method">The fixed provider method.</param>
    /// <param name="startMode">The optional startup mode.</param>
    /// <returns>The invocation result.</returns>
    private ServiceControlResult Execute(string method, string? startMode)
    {
        try
        {
            var code = _invoke(Name, method, startMode);
            return new(this, method, code, code.HasValue ? null : "The provider returned no native status code.");
        }
        catch (Exception exception) when (exception is ManagementException or UnauthorizedAccessException or SecurityException or COMException or PlatformNotSupportedException)
        {
            return new(this, method, null, exception.Message);
        }
    }
}
