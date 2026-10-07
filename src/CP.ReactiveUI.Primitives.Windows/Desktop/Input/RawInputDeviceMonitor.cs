// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.ObjectModel;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.Input;
#endif
/// <summary>
/// Reactive access to RawInput device information and changes.
/// This class provides an observable stream of device change events, and a cache of currently known devices.
/// </summary>
public static class RawInputDeviceMonitor
{
    /// <summary>Synchronizes access to raw-input monitor state.</summary>
    private static readonly Lock SyncRoot = new();

    /// <summary>The raw-input device cache keyed by native device handle.</summary>
    private static readonly Dictionary<IntPtr, RawInputDeviceInformation> DeviceCache = new();

    /// <summary>The shared raw-input device change observable.</summary>
    private static IObservable<RawInputDeviceChangeEventArgs> _rawInputDeviceObservable;

    /// <summary>Gets a snapshot of the raw-input devices currently in the system.</summary>
    /// <returns>A point-in-time raw-input device snapshot keyed by device handle.</returns>
    public static IReadOnlyDictionary<IntPtr, RawInputDeviceInformation> GetDevicesSnapshot()
    {
        lock (SyncRoot)
        {
            RefreshDeviceCache();
            return new ReadOnlyDictionary<IntPtr, RawInputDeviceInformation>(new Dictionary<IntPtr, RawInputDeviceInformation>(DeviceCache));
        }
    }

    /// <summary>
    /// Observes Raw Input device arrival and removal notifications.
    /// Multiple subscribers will share the same underlying hook, and the hook
    /// is automatically disposed when the subscriber count reaches zero.
    /// </summary>
    /// <param name="devices">The raw input device types to register.</param>
    /// <returns>A shared stream of raw input device change events.</returns>
    public static IObservable<RawInputDeviceChangeEventArgs> ObserveDeviceChanges(params RawInputDevices[] devices)
    {
        if (_rawInputDeviceObservable is not null)
        {
            return _rawInputDeviceObservable;
        }

        _rawInputDeviceObservable = ReactiveSignal.CreateSafe<RawInputDeviceChangeEventArgs>(observer =>
        {
            var source = RawInputMonitor.Infrastructure.MessageSource;
            lock (SyncRoot)
            {
                RefreshDeviceCache();
            }

            return RawInputMonitor.CreateObservation(
                source,
                WindowsMessages.WM_INPUT_DEVICE_CHANGE,
                handle => RawInputApi.RegisterRawInput((nint)handle, RawInputDeviceFlags.DeviceNotify, devices),
                ReadDeviceChange,
                static () => _rawInputDeviceObservable = null).Subscribe(observer);
        }).Publish().RefCount();
        return _rawInputDeviceObservable;
    }

    /// <summary>Resets cached raw-input device monitor state for deterministic tests.</summary>
    internal static void ResetForTesting()
    {
        lock (SyncRoot)
        {
            _rawInputDeviceObservable = null;
            DeviceCache.Clear();
        }
    }

    /// <summary>Reads a device change and updates the device cache.</summary>
    /// <param name="message">The native device notification.</param>
    /// <returns>The materialized device change.</returns>
    private static RawInputDeviceChangeEventArgs ReadDeviceChange(WindowMessage message)
    {
        var added = checked((int)message.WParam) == 1;
        IntPtr handle = new(message.LParam);
        lock (SyncRoot)
        {
            RawInputDeviceInformation value;
            if (added)
            {
                value = RawInputApi.GetDeviceInformation(handle);
                DeviceCache[handle] = value;
            }
            else if (!DeviceCache.TryGetValue(handle, out value))
            {
                value = new RawInputDeviceInformation { Handle = handle };
            }

            if (!added)
            {
                _ = DeviceCache.Remove(handle);
            }

            return new RawInputDeviceChangeEventArgs { Added = added, DeviceInformation = value };
        }
    }

    /// <summary>Refreshes the device cache from the operating system.</summary>
    private static void RefreshDeviceCache()
    {
        DeviceCache.Clear();
        foreach (var deviceInformation in RawInputApi.GetAllDevices())
        {
            DeviceCache[deviceInformation.Handle] = deviceInformation;
        }
    }
}
