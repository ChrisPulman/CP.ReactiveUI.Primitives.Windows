// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;

namespace CP.ReactiveUI.Primitives.Windows.Tests;

/// <summary>Verifies explicit power scheme validation without modifying Windows.</summary>
public sealed class PowerPlanTests
{
    /// <summary>An empty identifier cannot identify an installed plan.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task ForId_EmptyIdentifier_Throws() =>
        await Assert.That(static () => PowerPlan.ForId(Guid.Empty)).Throws<ArgumentException>();

    /// <summary>Creating a plan target retains identity without native calls.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task ForId_PreservesIdentifier()
    {
        var id = Guid.NewGuid();
        await Assert.That(PowerPlan.ForId(id).Id).IsEqualTo(id);
    }

    /// <summary>Mocked native success codes are accepted.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task Check_Success_DoesNotThrow() =>
        await Assert.That(static () => PowerNativeMethods.Check(0)).ThrowsNothing();

    /// <summary>Mocked native access denied codes become native exceptions.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task Check_AccessDenied_Throws()
    {
        const uint accessDenied = 5;
        await Assert.That(static () => PowerNativeMethods.Check(accessDenied)).Throws<NativeWin32Exception>();
    }

    /// <summary>Fluent writes preserve AC and DC selection and activation order.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task FluentControls_ForwardExplicitRequests()
    {
        const uint pluggedInValue = 25;
        const uint batteryValue = 50;
        var id = Guid.NewGuid();
        var subgroup = Guid.NewGuid();
        var setting = Guid.NewGuid();
        var calls = new List<string>();
        var observedPlans = new List<Guid>();
        var observedSubgroups = new List<Guid>();
        var observedSettings = new List<Guid>();
        var observedValues = new List<uint>();
        var target = new PowerPlan(id, new PowerPlanOperations
        {
            Write = (plan, group, key, dc, value) =>
            {
                calls.Add(dc ? "dc" : "ac");
                observedPlans.Add(plan);
                observedSubgroups.Add(group);
                observedSettings.Add(key);
                observedValues.Add(value);
                return 0;
            },
            Activate = plan =>
            {
                calls.Add("activate");
                observedPlans.Add(plan);
                return 0;
            },
        });
        var result = target.WithAcValue(subgroup, setting, pluggedInValue).WithDcValue(subgroup, setting, batteryValue).Activate();
        await Assert.That(ReferenceEquals(result, target)).IsTrue();
        await Assert.That(string.Join(",", calls)).IsEqualTo("ac,dc,activate");
        await Assert.That(observedPlans.TrueForAll(plan => plan == id)).IsTrue();
        await Assert.That(observedSubgroups.TrueForAll(group => group == subgroup)).IsTrue();
        await Assert.That(observedSettings.TrueForAll(key => key == setting)).IsTrue();
        await Assert.That(observedValues[0]).IsEqualTo(pluggedInValue);
        await Assert.That(observedValues[1]).IsEqualTo(batteryValue);
    }

    /// <summary>Native write failure stops the fluent operation and retains its error code.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task WithAcValue_NativeFailure_Throws()
    {
        const uint accessDenied = 5;
        var target = new PowerPlan(Guid.NewGuid(), new PowerPlanOperations { Write = static (_, _, _, _, _) => accessDenied });
        await Assert.That(() => target.WithAcValue(Guid.Empty, Guid.Empty, 0)).Throws<NativeWin32Exception>();
    }

    /// <summary>AC and DC reads preserve the requested source and native values.</summary>
    /// <returns>The asynchronous test.</returns>
    [Test]
    public async Task ReadValues_ForwardAcDcSelection()
    {
        const uint pluggedInValue = 25;
        const uint batteryValue = 50;
        var target = new PowerPlan(Guid.NewGuid(), new PowerPlanOperations
        {
            Read = static (_, _, _, dc) => new(0, dc ? batteryValue : pluggedInValue),
        });
        await Assert.That(target.ReadAcValue(Guid.Empty, Guid.Empty)).IsEqualTo(pluggedInValue);
        await Assert.That(target.ReadDcValue(Guid.Empty, Guid.Empty)).IsEqualTo(batteryValue);
    }
}
