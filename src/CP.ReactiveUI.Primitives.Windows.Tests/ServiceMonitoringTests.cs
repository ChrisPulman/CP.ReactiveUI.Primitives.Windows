// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable
#if REACTIVE_TEST_SHIM
using CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Verifies service projection and explicit controls without modifying Windows services.</summary>
public sealed class ServiceMonitoringTests
{
    /// <summary>The fixture service key.</summary>
    private const string ServiceName = "fixture";

    /// <summary>The provider failure fixture.</summary>
    private const string DeniedMessage = "denied";

    /// <summary>Verifies provider failures and missing fields are retained.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task Snapshot_PartialQuery_PreservesUnavailableFields()
    {
        var row = new WmiRow(new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase)
        {
            ["Name"] = ServiceName,
            ["ProcessId"] = 1U,
            ["AcceptStop"] = false,
        });
        var query = new WmiQueryResult(WmiQueryStatus.AccessDenied, [row], DeniedMessage);
        var snapshot = new ServiceSnapshot(query);
        await Assert.That(snapshot.Query).IsSameReferenceAs(query);
        await Assert.That(snapshot.Services.Count).IsEqualTo(1);
        await Assert.That(snapshot.Services[0].Name).IsEqualTo(ServiceName);
        await Assert.That(snapshot.Services[0].ProcessId).IsEqualTo(1U);
        await Assert.That(snapshot.Services[0].AcceptStop).IsFalse();
        await Assert.That(snapshot.Services[0].DelayedAutoStart).IsNull();
        await Assert.That(snapshot.Services[0].ExitCode).IsNull();
        await Assert.That(snapshot.Services[0].State).IsNull();
    }

    /// <summary>Verifies embedded CIM syntax cannot alter the instance key.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task ObjectPath_QuotesAndBackslashes_EscapesKey()
    {
        await Assert.That(ServiceTarget.ObjectPath("a\\b\"c")).IsEqualTo("Win32_Service.Name=\"a\\\\b\\\"c\"");
    }

    /// <summary>Verifies typed fields preserve provider configuration and pending states.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task ServiceInfo_CompleteRow_PreservesConfiguration()
    {
        const uint processId = 123U;
        const uint exitCode = 1066U;
        var service = new ServiceInfo(new WmiRow(new Dictionary<string, object?>
        {
            ["Name"] = ServiceName,
            ["DisplayName"] = "Fixture Service",
            ["State"] = "Start Pending",
            ["StartMode"] = "Auto",
            ["ProcessId"] = processId,
            ["AcceptStop"] = true,
            ["AcceptPause"] = false,
            ["DelayedAutoStart"] = true,
            ["StartName"] = @"NT AUTHORITY\LocalService",
            ["PathName"] = "fixture.exe -service",
            ["ExitCode"] = exitCode,
            ["ServiceSpecificExitCode"] = 1U,
        }));
        await Assert.That(service.DisplayName).IsEqualTo("Fixture Service");
        await Assert.That(service.State).IsEqualTo("Start Pending");
        await Assert.That(service.StartMode).IsEqualTo("Auto");
        await Assert.That(service.ProcessId).IsEqualTo(processId);
        await Assert.That(service.AcceptStop).IsTrue();
        await Assert.That(service.AcceptPause).IsFalse();
        await Assert.That(service.DelayedAutoStart).IsTrue();
        await Assert.That(service.ServiceAccount).IsEqualTo(@"NT AUTHORITY\LocalService");
        await Assert.That(service.BinaryPath).IsEqualTo("fixture.exe -service");
        await Assert.That(service.ExitCode).IsEqualTo(exitCode);
        await Assert.That(service.ServiceSpecificExitCode).IsEqualTo(1U);
    }

    /// <summary>Verifies each control calls its documented provider method.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task Controls_InjectedProvider_UsesExactMethods()
    {
        var methods = new List<string>();
        var target = new ServiceTarget(ServiceName, (name, method, mode) =>
        {
            methods.Add(method);
            return 0U;
        });
        await Assert.That(target.Start().IsAccepted).IsTrue();
        await Assert.That(target.Stop().IsAccepted).IsTrue();
        await Assert.That(target.Pause().IsAccepted).IsTrue();
        await Assert.That(target.Resume().IsAccepted).IsTrue();
        await Assert.That(string.Join(",", methods)).IsEqualTo("StartService,StopService,PauseService,ResumeService");
    }

    /// <summary>Verifies startup modes use provider spellings and retain failure codes.</summary>
    /// <param name="mode">The startup mode.</param>
    /// <param name="expected">The provider spelling.</param>
    /// <returns>The assertion task.</returns>
    [Test]
    [Arguments(ServiceStartMode.Automatic, "Automatic")]
    [Arguments(ServiceStartMode.Manual, "Manual")]
    [Arguments(ServiceStartMode.Disabled, "Disabled")]
    [Arguments(ServiceStartMode.Boot, "Boot")]
    [Arguments(ServiceStartMode.System, "System")]
    public async Task WithStartMode_InjectedProvider_PreservesCode(ServiceStartMode mode, string expected)
    {
        const uint denied = 2U;
        string? received = null;
        var target = new ServiceTarget(ServiceName, (name, method, value) =>
        {
            received = value;
            return denied;
        });
        var result = target.WithStartMode(mode);
        await Assert.That(received).IsEqualTo(expected);
        await Assert.That(result.Method).IsEqualTo("ChangeStartMode");
        await Assert.That(result.NativeCode).IsEqualTo(denied);
        await Assert.That(result.IsAccepted).IsFalse();
        await Assert.That(result.Target).IsSameReferenceAs(target);
    }

    /// <summary>Verifies access failures are distinguishable from native service rejection.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task Control_AccessDenied_PreservesInvocationFailure()
    {
        var target = new ServiceTarget(ServiceName, static (name, method, value) => throw new UnauthorizedAccessException(DeniedMessage));
        var result = target.Start();
        await Assert.That(result.NativeCode).IsNull();
        await Assert.That(result.Error).IsEqualTo(DeniedMessage);
        await Assert.That(result.IsAccepted).IsFalse();
    }

    /// <summary>Verifies a missing provider return code is not interpreted as acceptance.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task Control_MissingReturnCode_RemainsUnavailable()
    {
        var target = new ServiceTarget(ServiceName, static (name, method, value) => null);
        var result = target.Start();
        await Assert.That(result.NativeCode).IsNull();
        await Assert.That(result.Error).IsNotNull();
        await Assert.That(result.IsAccepted).IsFalse();
    }

    /// <summary>Verifies invalid modes are rejected before invoking a provider.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task WithStartMode_InvalidMode_RejectsInput()
    {
        var target = new ServiceTarget(ServiceName, static (name, method, value) => throw new InvalidOperationException());
        await Assert.That(() => target.WithStartMode((ServiceStartMode)(-1))).Throws<ArgumentOutOfRangeException>();
    }

    /// <summary>Verifies invalid object key names are rejected without provider access.</summary>
    /// <param name="name">The invalid service name.</param>
    /// <returns>The assertion task.</returns>
    [Test]
    [Arguments("")]
    [Arguments(" ")]
    [Arguments("a\0b")]
    public async Task ForName_InvalidName_RejectsInput(string name)
    {
        await Assert.That(() => ServiceTarget.ForName(name)).Throws<ArgumentException>();
    }
}
