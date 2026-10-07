// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Software;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.Software;
#endif
/// <summary>Composes installed-software registry access for production and deterministic tests.</summary>
internal interface IInstalledSoftwareRegistry
{
    /// <summary>Opens a LocalMachine subkey.</summary>
    /// <param name="subkeyName">The subkey path.</param>
    /// <returns>The opened subkey, or null when it is unavailable.</returns>
    IInstalledSoftwareRegistryKey OpenLocalMachineSubKey(string subkeyName);
}
