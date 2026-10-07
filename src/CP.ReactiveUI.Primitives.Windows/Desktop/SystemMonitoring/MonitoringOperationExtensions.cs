// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Diagnostics;
using CP.ReactiveUI.Primitives.Windows.Operations;
using OperationVoid = global::ReactiveUI.Primitives.RxVoid;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
#endif

/// <summary>Creates deferred monitoring reads and explicit commands that run once per capture or subscription.</summary>
public static class MonitoringOperationExtensions
{
    /// <summary>Provides deferred operations for BrightnessDisplay.</summary>
    /// <param name="target">The monitor session, which must remain open through execution.</param>
    extension(BrightnessDisplay target)
    {
        /// <summary>Defers setting physical monitor brightness within its reported range.</summary>
        /// <param name="value">The brightness in native monitor units.</param>
        /// <returns>An operation returning the target after the command succeeds.</returns>
        public WindowsOperation<BrightnessDisplay> SetBrightnessOperation(uint value)
        {
            Throw.IfNull(target);
            return WindowsOperation.From(() => target.SetBrightness(value));
        }

        /// <summary>Defers capturing physical monitor brightness and capability.</summary>
        /// <returns>An operation preserving the brightness sample and native failure information.</returns>
        public WindowsOperation<BrightnessSample> CaptureOperation()
        {
            Throw.IfNull(target);
            return WindowsOperation.From(target.Capture);
        }
    }

    /// <summary>Provides deferred operations for BrightnessPanel.</summary>
    /// <param name="target">The panel target.</param>
    extension(BrightnessPanel target)
    {
        /// <summary>Defers requesting internal panel brightness.</summary>
        /// <param name="percentage">The brightness percentage from 0 through 100.</param>
        /// <returns>An operation returning the target after the command succeeds.</returns>
        public WindowsOperation<BrightnessPanel> SetBrightnessOperation(byte percentage)
        {
            Throw.IfNull(target);
            return WindowsOperation.From(() => target.SetBrightness(percentage));
        }
    }

    /// <summary>Provides deferred operations for PowerPlan.</summary>
    /// <param name="target">The power plan target.</param>
    extension(PowerPlan target)
    {
        /// <summary>Defers persisting a power plan AC setting value.</summary>
        /// <param name="subgroup">The setting subgroup identifier.</param>
        /// <param name="setting">The setting identifier.</param>
        /// <param name="value">The setting value index.</param>
        /// <returns>An operation returning the target after the command succeeds.</returns>
        public WindowsOperation<PowerPlan> AcValueOperation(Guid subgroup, Guid setting, uint value)
        {
            Throw.IfNull(target);
            return WindowsOperation.From(() => target.WithAcValue(subgroup, setting, value));
        }

        /// <summary>Defers persisting a power plan DC setting value.</summary>
        /// <param name="subgroup">The setting subgroup identifier.</param>
        /// <param name="setting">The setting identifier.</param>
        /// <param name="value">The setting value index.</param>
        /// <returns>An operation returning the target after the command succeeds.</returns>
        public WindowsOperation<PowerPlan> DcValueOperation(Guid subgroup, Guid setting, uint value)
        {
            Throw.IfNull(target);
            return WindowsOperation.From(() => target.WithDcValue(subgroup, setting, value));
        }

        /// <summary>Defers activating a power plan and applying its persisted settings.</summary>
        /// <returns>An operation returning the target after the command succeeds.</returns>
        public WindowsOperation<PowerPlan> ActivateOperation()
        {
            Throw.IfNull(target);
            return WindowsOperation.From(target.Activate);
        }

        /// <summary>Defers reading a power plan AC setting value.</summary>
        /// <param name="subgroup">The setting subgroup identifier.</param>
        /// <param name="setting">The setting identifier.</param>
        /// <returns>An operation returning the native value index.</returns>
        public WindowsOperation<uint> ReadAcValueOperation(Guid subgroup, Guid setting)
        {
            Throw.IfNull(target);
            return WindowsOperation.From(() => target.ReadAcValue(subgroup, setting));
        }

        /// <summary>Defers reading a power plan DC setting value.</summary>
        /// <param name="subgroup">The setting subgroup identifier.</param>
        /// <param name="setting">The setting identifier.</param>
        /// <returns>An operation returning the native value index.</returns>
        public WindowsOperation<uint> ReadDcValueOperation(Guid subgroup, Guid setting)
        {
            Throw.IfNull(target);
            return WindowsOperation.From(() => target.ReadDcValue(subgroup, setting));
        }
    }

    /// <summary>Provides deferred operations for ProcessTarget.</summary>
    /// <param name="target">The process target.</param>
    extension(ProcessTarget target)
    {
        /// <summary>Defers setting the selected process priority.</summary>
        /// <param name="priority">The requested priority class.</param>
        /// <returns>An operation returning the target after the command succeeds.</returns>
        public WindowsOperation<ProcessTarget> PriorityOperation(ProcessPriorityClass priority)
        {
            Throw.IfNull(target);
            return WindowsOperation.From(() => target.WithPriority(priority));
        }

        /// <summary>Defers setting the selected process affinity mask.</summary>
        /// <param name="affinity">The processor mask.</param>
        /// <returns>An operation returning the target after the command succeeds.</returns>
        public WindowsOperation<ProcessTarget> AffinityOperation(IntPtr affinity)
        {
            Throw.IfNull(target);
            return WindowsOperation.From(() => target.WithAffinity(affinity));
        }

        /// <summary>Defers requesting graceful closure of the selected process main window.</summary>
        /// <returns>An operation reporting whether a close message was sent.</returns>
        public WindowsOperation<bool> CloseMainWindowOperation()
        {
            Throw.IfNull(target);
            return WindowsOperation.From(target.CloseMainWindow);
        }

        /// <summary>Defers terminating the selected process without terminating descendants.</summary>
        /// <returns>An operation signaling completion after termination is requested.</returns>
        public WindowsOperation<OperationVoid> TerminateOperation()
        {
            Throw.IfNull(target);
            return WindowsOperation.From(target.Terminate);
        }
    }

    /// <summary>Provides deferred operations for ServiceTarget.</summary>
    /// <param name="target">The service target.</param>
    extension(ServiceTarget target)
    {
        /// <summary>Defers submitting a service startup request.</summary>
        /// <returns>An operation preserving the provider result; acceptance does not establish service state.</returns>
        public WindowsOperation<ServiceControlResult> StartOperation()
        {
            Throw.IfNull(target);
            return WindowsOperation.From(target.Start);
        }

        /// <summary>Defers submitting a service shutdown request.</summary>
        /// <returns>An operation preserving the provider result; acceptance does not establish service state.</returns>
        public WindowsOperation<ServiceControlResult> StopOperation()
        {
            Throw.IfNull(target);
            return WindowsOperation.From(target.Stop);
        }

        /// <summary>Defers submitting a service pause request.</summary>
        /// <returns>An operation preserving the provider result; acceptance does not establish service state.</returns>
        public WindowsOperation<ServiceControlResult> PauseOperation()
        {
            Throw.IfNull(target);
            return WindowsOperation.From(target.Pause);
        }

        /// <summary>Defers submitting a service resume request.</summary>
        /// <returns>An operation preserving the provider result; acceptance does not establish service state.</returns>
        public WindowsOperation<ServiceControlResult> ResumeOperation()
        {
            Throw.IfNull(target);
            return WindowsOperation.From(target.Resume);
        }

        /// <summary>Defers submitting a service startup configuration change.</summary>
        /// <param name="mode">The provider startup mode.</param>
        /// <returns>An operation preserving the provider result; acceptance does not establish service state.</returns>
        public WindowsOperation<ServiceControlResult> StartModeOperation(ServiceStartMode mode)
        {
            Throw.IfNull(target);
            return WindowsOperation.From(() => target.WithStartMode(mode));
        }
    }

    /// <summary>Provides deferred operations for SystemMonitorBuilder.</summary>
    /// <param name="builder">The immutable monitor configuration.</param>
    extension(SystemMonitorBuilder builder)
    {
        /// <summary>Defers capturing one snapshot using the selected monitoring configuration.</summary>
        /// <returns>An operation capturing one snapshot per execution.</returns>
        public WindowsOperation<SystemSnapshot> CaptureOperation()
        {
            Throw.IfNull(builder);
            return WindowsOperation.From(builder.Capture);
        }
    }
}
