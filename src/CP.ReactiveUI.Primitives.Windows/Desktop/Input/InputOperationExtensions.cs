// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using CP.ReactiveUI.Primitives.Windows.Operations;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.Input;
#endif

/// <summary>Provides deferred operations over input records and registrations.</summary>
public static class InputOperationExtensions
{
    /// <summary>Provides commands over native input records.</summary>
    /// <param name="inputs">The records to send.</param>
    extension(DesktopInput[] inputs)
    {
        /// <summary>Creates a deferred command from a snapshot of native input records.</summary>
        /// <returns>The command reporting the number of input records sent.</returns>
        public WindowsOperation<uint> SendOperation()
        {
            Throw.IfNull(inputs, nameof(inputs));
            var snapshot = (DesktopInput[])inputs.Clone();
            return WindowsOperation.From(() => NativeInput.SendInput(snapshot));
        }
    }

    /// <summary>Provides commands over raw input registrations.</summary>
    /// <param name="devices">The device registrations.</param>
    extension(RawInputDevice[] devices)
    {
        /// <summary>Creates a deferred raw input registration command from a snapshot of the registrations.</summary>
        /// <returns>The operation returning the registered device snapshot.</returns>
        public WindowsOperation<RawInputDevice[]> RegisterOperation()
        {
            Throw.IfNull(devices, nameof(devices));
            var snapshot = (RawInputDevice[])devices.Clone();
            return WindowsOperation.From(() =>
            {
                RawInputApi.RegisterRawInput(snapshot);
                return (RawInputDevice[])snapshot.Clone();
            });
        }
    }
}
