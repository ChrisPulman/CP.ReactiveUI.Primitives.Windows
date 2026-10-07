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

/// <summary>Tests native read-only WMI availability and detached query results.</summary>
public class WindowsManagementTests
{
    /// <summary>The native local inventory namespace.</summary>
    private const string CimNamespace = @"root\cimv2";

    /// <summary>Verifies a native OS query remains readable after provider objects have been disposed.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task NativeOperatingSystemQueryReturnsDetachedBuild()
    {
        var result = WindowsManagement.Query(CimNamespace, "SELECT BuildNumber FROM Win32_OperatingSystem");
        await Assert.That(result.Status).IsEqualTo(WmiQueryStatus.Available);
        await Assert.That(result.Rows.Count).IsEqualTo(1);
        await Assert.That(result.Rows[0].TryGet<string>("BuildNumber", out var build)).IsTrue();
        await Assert.That(string.IsNullOrWhiteSpace(build)).IsFalse();
    }

    /// <summary>Verifies a missing provider class returns explicit unavailability.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task NativeMissingClassReturnsUnavailable()
    {
        var result = WindowsManagement.Query(CimNamespace, "SELECT * FROM CP_NonexistentMonitoringClass");
        await Assert.That(result.Status).IsEqualTo(WmiQueryStatus.Unavailable);
        await Assert.That(result.Rows.Count).IsEqualTo(0);
    }

    /// <summary>Verifies invalid query durations fail before native provider activation.</summary>
    /// <returns>The assertion task.</returns>
    [Test]
    public async Task QueryRejectsUnboundedTimeout()
    {
        await Assert.That(static () => WindowsManagement.Query(CimNamespace, "SELECT * FROM Win32_OperatingSystem", TimeSpan.Zero))
            .Throws<ArgumentOutOfRangeException>();
    }
}
