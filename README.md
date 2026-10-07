# CP.ReactiveUI.Primitives.Windows

Composable Windows desktop primitives built on `ReactiveUI.Primitives`.

## Fluent operations and observable results

Use `WindowsOperation.From` to compose existing synchronous functions that return managed values, or actions with no return value. The operation builder defers its delegate until execution: `Capture()` executes immediately, while `Observe()` creates a cold `IObservable<T>` that runs once for each subscriber. `Select` transforms its result and `Do` adds a deferred action. Exceptions reach `OnError` when observed and are thrown normally when captured. The caller retains ownership of existing receivers and emitted resources. Existing immediate APIs keep their immediate behavior.

```csharp
using CP.ReactiveUI.Primitives.Windows.Operations;
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
using ReactiveUI.Primitives;

var readMemory = WindowsOperation.From(MemoryMonitoring.Capture)
    .Select(memory => memory.UsedPhysicalBytes)
    .Do(bytes => Console.WriteLine($"Used memory: {bytes:N0} bytes"));

using var subscription = readMemory.Observe().Subscribe(
    bytes => Console.WriteLine(bytes),
    error => Console.Error.WriteLine(error.Message));
```

For changing state, use the existing `Observe...` streams rather than repeatedly executing a command. `WindowsSystem.Monitor()` configures periodic telemetry; window caption/bounds, clipboard, display topology, input, device, registry and session sources provide event-driven observables. Explicit commands use deferred operations and execute once per subscription. Subscription is an execution request, so subscribing twice to a command executes it twice.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Dialogs;

// Subscribe from the application's STA UI thread; dispose when the view closes.
var chooseFile = new FileOpenDialogBuilder()
    .AddFilter("Text files", "*.txt")
    .AsOperation();

using var selection = chooseFile.Observe().Subscribe(result =>
{
    Console.WriteLine(result);
});
```

Task-based functions compose through `WindowsOperation.FromTask`, which emits the completed result rather than the task. Pass the subscription's cancellation token into the asynchronous function; adapt a `ValueTask<T>` with `AsTask()` inside the delegate. Synchronous operations and dialog/input/clipboard adapters run on the capturing or subscribing thread; async continuations can run on a different thread. These adapters do not choose a scheduler, move UI work to a background thread, or create an implicit message pump. Native hook subscriptions must be registered and disposed on their pumping owner thread.

The complete function reference indexed below lists each public callable signature and configuration/observable property, its description and a C# usage example. Examples that accept a receiver, native handle, callback, buffer or provider expect a valid value supplied by the application. They demonstrate the call without executing operations during documentation generation. Subscription examples return the subscription to the application, which retains it until the view or feature closes and then disposes it. Pointer/ref-like and lifetime-sensitive interop calls remain direct C# calls; materialize their results before publishing them as observable values. Private implementation methods and tests are outside the consumer API reference.

Regenerate the reference and compile-check every generated example after an API change:

```powershell
pwsh ./tools/Update-ApiReference.ps1
```

The generator inventories the public APIs in all four shipping packages across all seven shipping targets, including overloads, interface contracts, constructors, operators and properties. The [complete function reference](docs/api-reference-generated.md) and [inventory manifest](docs/api-reference-manifest.json) contain all entries and validation results. Reference pages are grouped by namespace to keep every example readable on GitHub; the navigation index is embedded below.

## Windows system monitoring and Task Manager applications

`Desktop.SystemMonitoring` provides CPU, memory, process, network, disk, GPU, hardware, thermal, battery, power-plan, brightness, and Windows service APIs. The lean and Reactive packages expose the same capabilities, including English performance counters and detached WMI queries/events for additional Windows providers. Applications consume ordinary C# values and `IObservable<T>` streams; no C++ project is required.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring;
using ReactiveUI.Primitives;

var monitor = WindowsSystem.Monitor()
    .WithCpu().WithMemory().WithProcesses()
    .WithNetwork().WithStorage().WithGraphics()
    .WithPower().WithHardware().WithServices()
    .Every(TimeSpan.FromSeconds(1));

using var subscription = monitor.Observe().Subscribe(snapshot =>
{
    if (snapshot.Memory.IsAvailable)
    {
        Console.WriteLine(snapshot.Memory.Value.UsedPhysicalBytes);
    }
});
```

Each subscriber owns its rate history and native resources. Sampling runs on the thread pool, uses a delay after each completed cycle, and never overlaps reads. Hardware inventory is cached for five minutes; thermal zones and services are cached for thirty seconds. Provider failures are reported independently through `MonitoringResult<T>`; per-counter warmup, denied access, missing providers, and unsupported sensors remain explicit.

The [monitoring guide](docs/windows-system-monitoring.md) describes the available functions, fluent controls, provider extension points, and hardware limits. The [WPF Task Manager example](src/CP.ReactiveUI.Primitives.Windows.Example.TaskManager/README.md) includes real per-core graphs, memory history, a sortable process table, hardware/GPU/network/disk views, and explicit power-plan selection:

```powershell
dotnet run --project src/CP.ReactiveUI.Primitives.Windows.Example.TaskManager/CP.ReactiveUI.Primitives.Windows.Example.TaskManager.csproj --framework net10.0-windows10.0.19041.0
```

The library collection exposes Windows operating-system state, callbacks, and commands through small focused packages. One-shot native calls remain ordinary methods; anything that changes over time, is raised by a message, or reports progress is exposed as an `IObservable<T>` using ReactiveUI.Primitives naming and lifetime conventions.

## Packages

Install the package based on your needs, CP.ReactiveUI.Primitives.Windows is the lean desktop package, CP.ReactiveUI.Primitives.Windows.Reactive is the System.Reactive-first variant. The other packages are optional and provide additional native interop, desktop, or integration features.

```powershell
dotnet add package CP.ReactiveUI.Primitives.Windows
dotnet add package CP.ReactiveUI.Primitives.Windows.Core
dotnet add package CP.ReactiveUI.Primitives.Windows.Integrations
dotnet add package CP.ReactiveUI.Primitives.Windows.Reactive
```

| Package | Use when | Main namespaces |
| --- | --- | --- |
| `CP.ReactiveUI.Primitives.Windows.Core` | You need native value types, safe handles, COM contracts, registry monitoring, GDI, Kernel32, Shell32, or User32 helpers. | `CP.ReactiveUI.Primitives.Windows.Native`, `CP.ReactiveUI.Primitives.Windows.Interop` |
| `CP.ReactiveUI.Primitives.Windows` | You need desktop features: clipboard, devices, DPI, dialogs, icons, input, messages, windows, display, power, lifecycle, or multimedia compiled against `ReactiveUI.Primitives`. | `CP.ReactiveUI.Primitives.Windows.Desktop` |
| `CP.ReactiveUI.Primitives.Windows.Integrations` | You need optional Citrix WFAPI helpers or the legacy WinForms `WebBrowser` integration. | `CP.ReactiveUI.Primitives.Windows.Integrations` |
| `CP.ReactiveUI.Primitives.Windows.Reactive` | Your app is System.Reactive-first and wants the same desktop capabilities compiled against `ReactiveUI.Primitives.Reactive`. | `CP.ReactiveUI.Primitives.Windows.Reactive.Desktop` |

The lean and `.Reactive` desktop packages compile the same source. The lean build uses `ReactiveUI.Primitives`; the `.Reactive` build defines `REACTIVE_SHIM`, uses `ReactiveUI.Primitives.Reactive`, and emits the desktop API beneath `CP.ReactiveUI.Primitives.Windows.Reactive.Desktop`. Core interop types remain in `CP.ReactiveUI.Primitives.Windows.Native` and `CP.ReactiveUI.Primitives.Windows.Interop`, so handles and value types keep one identity across both variants.

## Requirements

The packages target `net462`, `net472`, `net48`, `net481`, `net8.0-windows`, `net9.0-windows`, and `net10.0-windows`. The `net11.0-windows` preview target is enabled explicitly with `EnableDotNet11PreviewTargetFrameworks=true`. They are intended for Windows desktop processes and use Windows Forms/WPF-capable TFMs where required by the underlying operating-system feature.

The implementation logs through Apache `log4net`. Libraries never configure appenders on the consumer's behalf. Configure the repository once in the application startup path when diagnostic output is required:

```csharp
using log4net;
using log4net.Config;

BasicConfigurator.Configure();

ILog log = LogManager.GetLogger(typeof(Program));
log.Info("Windows primitives logging is configured.");
```

For production applications, prefer an XML `log4net` configuration with the appenders, levels, and retention policy appropriate to the host. Library trace-level details use the log4net debug level.

Typical consumer imports:

```csharp
using ReactiveUI.Primitives;
using CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard;
using CP.ReactiveUI.Primitives.Windows.Desktop.Devices;
using CP.ReactiveUI.Primitives.Windows.Desktop.Display;
using CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi;
using CP.ReactiveUI.Primitives.Windows.Desktop.Input;
using CP.ReactiveUI.Primitives.Windows.Desktop.Messaging;
using CP.ReactiveUI.Primitives.Windows.Desktop.Power;
using CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Dialogs;
using CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons;
using CP.ReactiveUI.Primitives.Windows.Desktop.Windows;
using CP.ReactiveUI.Primitives.Windows.Native;
using CP.ReactiveUI.Primitives.Windows.Native.Structs;
```

## Reactive Conventions

The package follows the ReactiveUI.Primitives naming model:

| Name shape | Meaning |
| --- | --- |
| `Observe...()` | Creates an observable stream for a changing OS value or event source. Dispose the returned subscription to detach the listener. |
| `...Events`, `...Changes`, or `...Requests` | Shared observable stream backed by a process-wide source, usually a hidden message window or native hook. |
| `Get...()` / properties | Snapshot reads with no subscription. |
| `Set...()` / command verbs | Immediate native command or state change. |
| `Try...()` | Native operation where failure is expected and reported as `false` instead of an exception. |

Reactive sources are ordinary `IObservable<T>` values. Most shared observables are published/ref-counted: the native registration is active while subscribers exist and is released when the last subscription is disposed.

## Lifecycle, Threading, And Errors

Dispose subscriptions and owned objects. Hooks, message windows, clipboard locks, timers, DPI handlers, COM wrappers, and safe handles release native resources through `IDisposable`.

```csharp
IDisposable subscription = ClipboardNative.ClipboardUpdateEvents.Subscribe(update =>
{
    Console.WriteLine(update.Id);
});

subscription.Dispose();
```

Clipboard and common dialogs should be used from an STA desktop thread. UI-bound observers should marshal back to the UI thread using the ReactiveUI.Primitives UI package or the dispatcher/control mechanism used by your application.

Observable setup failures are reported through `OnError`. Native one-shot methods either return `bool`, return nullable data where absence is normal, or throw a platform/native exception for unexpected failures.

## Package API

### Core Native Primitives

Namespace: `CP.ReactiveUI.Primitives.Windows.Native`

Core provides reusable interop building blocks:

| Area | Main APIs |
| --- | --- |
| Geometry and pixels | `NativePoint`, `NativePointFloat`, `NativeSize`, `NativeSizeFloat`, `NativeRect`, `NativeRectFloat`, `Bgr24`, `Bgra32`, `Indexed8`, conversion extensions. |
| Win32 status | `Win32.GetLastErrorCode()`, `Win32.GetHResult()`, `Win32.GetMessage(...)`, `WindowsVersion.IsWindows10OrLater`, `IsWindows11OrLater`, and other version checks. |
| Bitmap access | `BitmapAccessor<TPixel>`, `BitmapAccessorExtensions`, row-span processing for high-performance pixel reads/writes. |
| Handles | Safe handles for GDI, Shell, User32, monitors, cursors, icons, DCs, regions, bitmaps, and selected objects. |
| COM | `ComWrapper`, `DisposableCom`, `IUnknown`, `IDispatch`, `IOleWindow`, `IOleCommandTarget`, `ComProgIdAttribute`. |
| Registry | `RegistryMonitor.ObserveChanges()` and Advapi32 registry access enums. |
| GDI/GDI+ | `Gdi32Api`, `GdiPlusApi`, `GdiExtensions`, bitmap/header structs, raster and device capability enums. |
| Kernel32 | `Kernel32Api`, `PsApi`, native restart-manager helpers, package information, version/product/suite enums. |
| Shell32 | `Shell32Api`, app-bar structs/enums, shell file info, `SafeIconHandle`. |
| User32 | `User32Api`, `DisplayInfo`, window/message/scroll/cursor/monitor structs and enums. |

Core examples:

```csharp
using CP.ReactiveUI.Primitives.Windows.Native;
using CP.ReactiveUI.Primitives.Windows.Native.Structs;
using CP.ReactiveUI.Primitives.Windows.Native.UserInterface;
using CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums;

bool modernWindows = WindowsVersion.IsWindows10OrLater;
string lastErrorText = Win32.GetMessage(Win32.GetLastErrorCode());

NativeRect bounds = new(left: 0, top: 0, width: 1920, height: 1080);
NativePoint topLeft = bounds.TopLeft;

int screenWidth = User32Api.GetSystemMetrics(SystemMetric.SM_CXSCREEN);
IReadOnlyList<DisplayInfo> displays = User32Api.EnumDisplays();
```

```csharp
using System.Drawing;
using CP.ReactiveUI.Primitives.Windows.Native;
using CP.ReactiveUI.Primitives.Windows.Native.Structs.PixelFormats;

using Bitmap bitmap = new(200, 100);
using BitmapAccessor<Bgra32> accessor = new(bitmap);

accessor.ProcessRows(row =>
{
    for (int x = 0; x < accessor.Width; x++)
    {
        row[x] = new Bgra32(Blue: 0, Green: 0, Red: 255, Alpha: 255);
    }
});
```

```csharp
using CP.ReactiveUI.Primitives.Windows.Native.Security;
using CP.ReactiveUI.Primitives.Windows.Native.Security.Enums;

IDisposable changes = RegistryMonitor.ObserveChanges(
    Microsoft.Win32.RegistryHive.CurrentUser,
    @"Software\MyCompany\MyApp",
    RegistryNotifyFilter.ChangeLastSet)
    .Subscribe(_ =>
{
    Console.WriteLine("Registry value changed.");
});
```

### Desktop Windows

Namespace: `CP.ReactiveUI.Primitives.Windows.Desktop.Windows`

| API | Purpose |
| --- | --- |
| `InteropWindowFactory.CreateFor(...)` | Wrap a native `HWND` as an `InteropWindow`. |
| `InteropWindowQueryExtensions.GetForegroundWindow()`, `GetDesktopWindow()`, `GetTopLevelWindows(...)`, `GetTopWindows(...)`, `GetWindowsForProcess(...)` | Query common desktop windows. |
| `InteropWindowExtensions` | Fill/query cached window data, get caption/text/class/children/parent/process/placement/region/scroll info, move, restore, minimize, maximize, print, set style, bring to foreground. |
| `WindowsEnumerator.EnumerateWindowHandles(...)`, `EnumerateWindows(...)` | Enumerate windows as `IEnumerable<T>` or `IObservable<T>`. |
| `WinEventHook.ObserveWinEvents(...)`, `ObserveWindowTitleChanges()`, `ObserveWindowLifecycleEvents()` | Observe WinEvent callbacks. |
| `EnvironmentMonitor.EnvironmentChangeEvents` | Observe `WM_SETTINGCHANGE` environment and system parameter updates. |
| `WindowScroller` | Scroll a target window by message, mouse wheel, or keyboard page keys. |
| `WindowsExtensions` / `FormsExtensions` | Convert WPF/WinForms windows to `InteropWindow`; apply/retrieve placement. |

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Windows;

IInteropWindow foreground = InteropWindowQueryExtensions.GetForegroundWindow();
foreground.Fill();

Console.WriteLine(foreground.GetCaption());
Console.WriteLine(foreground.GetClassname());
Console.WriteLine(foreground.GetPlacement().ShowCmd);

await foreground.ToForegroundAsync();
foreground.MoveTo(new(100, 100));
foreground.Restore();
```

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Windows;

foreach (IInteropWindow window in InteropWindowQueryExtensions.GetTopLevelWindows())
{
    Console.WriteLine($"{window.Handle}: {window.GetCaption()}");
}

IDisposable enumeration = WindowsEnumerator.EnumerateWindows().Subscribe(window =>
{
    Console.WriteLine(window.GetCaption());
});
```

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Windows;

IDisposable titleChanges = WinEventHook.ObserveWindowTitleChanges().Subscribe(info =>
{
    Console.WriteLine($"{info.Window.GetCaption()} changed title");
});

IDisposable environment = EnvironmentMonitor.EnvironmentChangeEvents.Subscribe(change =>
{
    Console.WriteLine($"{change.Area}: {change.SystemParametersInfoAction}");
});
```

### Store App Visibility

Namespace: `CP.ReactiveUI.Primitives.Windows.Desktop.Apps`

`AppQueryExtensions` identifies Windows Store app host windows and launcher windows.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Apps;
using CP.ReactiveUI.Primitives.Windows.Desktop.Windows;

foreach (IInteropWindow appWindow in AppQueryExtensions.WindowsStoreApps)
{
    Console.WriteLine(appWindow.GetCaption());
}

bool launcherVisible = AppQueryExtensions.IsLauncherVisible;
IInteropWindow launcher = AppQueryExtensions.GetAppLauncher();
```

### Display And DPI

Namespaces:

- `CP.ReactiveUI.Primitives.Windows.Desktop.Display`
- `CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi`
- `CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Forms`
- `CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Wpf`

| API | Purpose |
| --- | --- |
| `DisplayTopology.ScreenBounds` | Virtual desktop bounds. |
| `DisplayTopology.GetSnapshot()` | Current monitor snapshot. |
| `DisplayTopology.GetBounds(NativePoint)` | Monitor bounds containing a point. |
| `DisplayTopology.ObserveChanges()` | Current display snapshot plus later topology changes. |
| `DpiApi` / `NativeDpiMethods` | DPI awareness and per-window/monitor DPI functions. |
| `DpiCalculator` | Pure scale/unscale helpers. |
| `DpiHandler` | Per-window DPI message handling and `ObserveDpiChanges()`. |
| `BitmapScaleHandler` | Cache bitmaps by DPI. |
| `FormsDpiExtensions` / `WindowDpiExtensions` | Attach DPI handling to WinForms and WPF windows. |

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Display;
using CP.ReactiveUI.Primitives.Windows.Native.Structs;

NativeRect virtualDesktop = DisplayTopology.ScreenBounds;
NativeRect activeMonitor = DisplayTopology.GetBounds(new NativePoint(10, 10));

IDisposable displayChanges = DisplayTopology.ObserveChanges().Subscribe(displays =>
{
    foreach (var display in displays)
    {
        Console.WriteLine($"{display.DeviceName}: {display.Bounds}");
    }
});
```

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi;
using CP.ReactiveUI.Primitives.Windows.Native.Structs;

using DpiHandler dpi = new();

IDisposable dpiChanges = dpi.ObserveDpiChanges().Subscribe(change =>
{
    Console.WriteLine($"DPI changed from {change.PreviousDpi} to {change.NewDpi}");
});

int scaled = dpi.ScaleWithCurrentDpi(24);
NativeSize scaledSize = dpi.ScaleWithCurrentDpi(new NativeSize(200, 100));
NativeSize originalSize = dpi.UnscaleWithCurrentDpi(scaledSize);
```

### Messaging And Session State

Namespace: `CP.ReactiveUI.Primitives.Windows.Desktop.Messaging`

| API | Purpose |
| --- | --- |
| `SharedMessageWindow.WindowMessageEvents` | Shared hidden-window message stream. |
| `SharedMessageWindow.ObserveWindowMessages(...)` | Observe messages with setup/teardown callbacks tied to the message-window handle. |
| `SharedMessageWindow.ObserveHandleChanges()` | Observe hidden-window handle creation/destruction. |
| `MessageLoop` | Run and control the message loop backing the shared window. |
| `WinProcListener`, `WinProcHandler`, `WinProcHandlerHook` | Attach to WPF/WinForms/native window procedures. |
| `WinProcWindowsExtensions`, `WinProcFormsExtensions` | Convenience attachment for WPF and WinForms. |
| `WindowsSessionListener` | Observe lock/unlock, logon/logoff, and other WTS session changes. |
| `WindowsMessage`, `WindowMessageInfo`, `WindowMessage`, `Msg` | Message data and helper structures. |

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Messaging;
using CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations;

IDisposable messages = SharedMessageWindow.WindowMessageEvents
    .Where(message => message.Msg == WindowsMessages.WM_SETTINGCHANGE)
    .Subscribe(message => Console.WriteLine(message.Msg));

IDisposable handleChanges = SharedMessageWindow.ObserveHandleChanges()
    .Subscribe(hwnd => Console.WriteLine($"Message window: {hwnd}"));
```

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Messaging;

using WindowsSessionListener listener = new();

IDisposable lockChanges = listener.ObserveSessionLockChanges().Subscribe(session =>
{
    Console.WriteLine($"{session.EventType} for session {session.SessionId}");
});

listener.Start();
listener.Pause();
listener.Resume();
listener.Stop();
```

### Clipboard

Namespace: `CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard`

| API | Purpose |
| --- | --- |
| `ClipboardNative.HasOwner`, `SequenceNumber`, `HasFormat(...)` | Snapshot clipboard state. |
| `ClipboardNative.Access(...)`, `AccessAsync(...)` | Open and lock the clipboard. Dispose the returned token. |
| `ClipboardNative.ClipboardUpdateEvents` | Observe clipboard sequence/content updates. |
| `ClipboardNative.ClipboardRenderFormatRequests` | Observe delayed-render requests. |
| `ClipboardFormatExtensions` | Register, map, enumerate, and display clipboard formats. |
| `ClipboardStringExtensions` | Read/write Unicode string data. |
| `ClipboardByteExtensions` | Read/write byte data. |
| `ClipboardStreamExtensions` | Read/write stream data. |
| `ClipboardFileExtensions` | Read/write file-drop lists. |
| `ClipboardCloudExtensions` | Set cloud/history/monitor-processing flags. |
| `ClipboardMiscExtensions` | Clear contents and set delayed-render content. |

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard;

using IClipboardAccessToken clipboard = ClipboardNative.Access();

clipboard.ClearContents();
clipboard.SetAsUnicodeString("Hello from CP.ReactiveUI.Primitives.Windows");

string text = clipboard.GetAsUnicodeString();
IEnumerable<string> formats = clipboard.AvailableFormats();
```

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard;

IDisposable updates = ClipboardNative.ClipboardUpdateEvents.Subscribe(update =>
{
    Console.WriteLine($"Clipboard #{update.Id} at {update.Timestamp}");
    Console.WriteLine(string.Join(", ", update.Formats));
});

IDisposable delayedRender = ClipboardNative.ClipboardRenderFormatRequests.Subscribe(request =>
{
    if (request.RenderAllFormats)
    {
        request.AccessToken.SetAsUnicodeString("Rendered on demand");
    }
});
```

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard;

using CancellationTokenSource cancellation = new(TimeSpan.FromSeconds(2));
using IClipboardAccessToken clipboard = await ClipboardNative.AccessAsync(cancellation.Token);

uint customFormat = ClipboardFormatExtensions.RegisterFormat("com.example.payload");
clipboard.SetAsBytes(new byte[] { 1, 2, 3 }, customFormat);
byte[] payload = clipboard.GetAsBytes(customFormat);
```

### Devices And Raw Input

Namespaces:

- `CP.ReactiveUI.Primitives.Windows.Desktop.Devices`
- `CP.ReactiveUI.Primitives.Windows.Desktop.Input`

| API | Purpose |
| --- | --- |
| `DeviceNotification.OnNotification` | Shared device notification stream. |
| `DeviceNotification.ObserveDeviceNotifications(...)` | Create a notification stream for all interfaces or one device class. |
| `ObserveDeviceArrivals(...)`, `ObserveDeviceRemovals(...)` | Filter device-interface arrivals/removals. |
| `ObserveVolumeChanges(...)`, `ObserveVolumeAdditions(...)`, `ObserveVolumeRemovals(...)` | Filter volume device changes. |
| `RawInputApi` | Register raw input and query raw-input devices/data. |
| `RawInputMonitor.ObserveRawInput(...)` | Observe `WM_INPUT` raw input events. |
| `RawInputDeviceMonitor.GetDevicesSnapshot()` | Current raw-input devices by handle. |
| `RawInputDeviceMonitor.ObserveDeviceChanges(...)` | Observe raw-input device arrival/removal. |
| `NativeInput` | Send native keyboard/mouse input. |

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Devices;

IDisposable arrivals = DeviceNotification.ObserveDeviceArrivals().Subscribe(change =>
{
    Console.WriteLine($"Arrived: {change.Device.DisplayName}");
});

IDisposable removals = DeviceNotification.ObserveDeviceRemovals().Subscribe(change =>
{
    Console.WriteLine($"Removed: {change.Device.DisplayName}");
});

IDisposable volumes = DeviceNotification.ObserveVolumeAdditions().Subscribe(volume =>
{
    Console.WriteLine(volume.Volume.Drives);
});
```

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Input;
using CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums;

IReadOnlyDictionary<IntPtr, RawInputDeviceInformation> devices =
    RawInputDeviceMonitor.GetDevicesSnapshot();

IDisposable rawInput = RawInputMonitor.ObserveRawInput(RawInputDevices.Keyboard, RawInputDevices.Mouse)
    .Subscribe(input => Console.WriteLine(input.RawInput.Header.Type));

IDisposable rawDevices = RawInputDeviceMonitor.ObserveDeviceChanges(RawInputDevices.Keyboard)
    .Subscribe(change => Console.WriteLine(change.Added));
```

### Keyboard And Mouse Hooks

Namespaces:

- `CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard`
- `CP.ReactiveUI.Primitives.Windows.Desktop.Input.Mouse`

| API | Purpose |
| --- | --- |
| `KeyboardHook.KeyboardHookEvents` | Global low-level keyboard hook stream. |
| `KeyboardHookExtensions` | Filter and compose keyboard hook events. |
| `KeyboardInputGenerator` | Send synthetic keyboard input. |
| `KeyHelper`, `VirtualKeyCodeExtensions` | Virtual-key classification and conversion helpers. |
| `KeyCombinationHandler`, `KeyOrCombinationHandler`, `KeySequenceHandler` | Detect key combinations and sequences. |
| `MouseHook.MouseHookEvents` | Global low-level mouse hook stream. |
| `MouseInputGenerator` | Send synthetic mouse input. |

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums;
using CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard;

IDisposable keyboard = KeyboardHook.KeyboardHookEvents.Subscribe(args =>
{
    if (args.IsKeyDown && args.Key == VirtualKeyCode.F12)
    {
        args.Handled = true;
        Console.WriteLine("F12 handled.");
    }
});

KeyboardInputGenerator.KeyPresses(VirtualKeyCode.Return);
```

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Input.Mouse;

IDisposable mouse = MouseHook.MouseHookEvents.Subscribe(args =>
{
    Console.WriteLine($"{args.WindowsMessage} at {args.Point.X}, {args.Point.Y}");
});

MouseInputGenerator.MoveMouse(new(200, 200));
```

### Shell Dialogs

Namespace: `CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Dialogs`

| API | Purpose |
| --- | --- |
| `FileDialog.PickFileToOpen(...)` | Convenience open-file dialog. |
| `FileDialog.PickFilesToOpen(...)` | Convenience multi-select open-file dialog. |
| `FileDialog.PickFileToSave(...)` | Convenience save-file dialog. |
| `FileDialog.PickFolder(...)` | Convenience folder-picker dialog. |
| `FileOpenDialogBuilder` | Fluent open-file dialog configuration. |
| `FileSaveDialogBuilder` | Fluent save-file dialog configuration. |
| `FolderPickerBuilder` | Fluent folder picker configuration. |
| `FileDialogResult` | Cancellation and selection result. |

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Dialogs;

string path = FileDialog.PickFileToOpen(
    ownerHandle: IntPtr.Zero,
    title: "Open image",
    initialDirectory: Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
    filters: new[] { ("Images", "*.png;*.jpg;*.bmp"), ("All files", "*.*") },
    defaultExtension: "png");

if (path is not null)
{
    Console.WriteLine(path);
}
```

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Dialogs;

FileDialogResult result = new FileOpenDialogBuilder()
    .WithTitle("Import")
    .WithInitialDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
    .AddFilter("JSON", "*.json")
    .AddFilter("All files", "*.*")
    .AddPlace(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), atTop: true)
    .AllowMultipleSelection()
    .ShowDialog();

if (!result.WasCancelled)
{
    foreach (string selectedPath in result.SelectedPaths)
    {
        Console.WriteLine(selectedPath);
    }
}
```

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Dialogs;

FileDialogResult save = new FileSaveDialogBuilder()
    .WithTitle("Save report")
    .WithSuggestedFileName("report.txt")
    .WithDefaultExtension("txt")
    .AddFilter("Text", "*.txt")
    .ShowDialog();

FileDialogResult folder = new FolderPickerBuilder()
    .WithTitle("Output folder")
    .ShowDialog();
```

### Icons, Cursors, And Shell Images

Namespace: `CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons`

| API | Purpose |
| --- | --- |
| `IconHelper.GetAppLogo<TBitmap>(...)` | Load a Store app logo as `Bitmap`, `Icon`, or WPF `BitmapSource` where supported. |
| `IconHelper.ExtractAssociatedIcon<TIcon>(...)` | Extract an icon from an executable or DLL. |
| `IconHelper.CountAssociatedIcons(...)` | Count associated icons in a file. |
| `IconHelper.IconHandleTo<TIcon>(...)` | Convert native/safe icon handles. |
| `IconHelper.GetFileExtensionIcon<TIcon>(...)` | Resolve shell icon for an extension. |
| `IconHelper.GetFolderIcon<TIcon>(...)` | Resolve system folder icons. |
| `IconHelper.GetSystemIconSize(...)` and metric methods | Query recommended icon sizes. |
| `IconHelper.LoadIconWithSystemMetrics(...)`, `LoadIconWithScaleDown(...)` | Load resources at DPI-aware sizes. |
| `IconLoader` and `IconStreamExtensions` | Load icons from files/streams. |
| `IconFileWriter.WriteIconFile(...)`, `IconHelper.WriteIcon(...)` | Create `.ico` files from images. |
| `CursorHelper.TryGetCurrentCursor(...)`, `DrawCursorOnGraphics(...)`, `DrawCursorOnBitmap(...)` | Capture and render current cursor layers. |

```csharp
using System.Drawing;
using CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons;
using CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums;

Icon notepadIcon = IconHelper.ExtractAssociatedIcon(
    @"C:\Windows\System32\notepad.exe",
    iconType: (Icon)null);

Bitmap txtIcon = IconHelper.GetFileExtensionIcon(
    "example.txt",
    iconType: (Bitmap)null,
    size: IconSize.Small,
    linkOverlay: false);

Size smallIconSize = IconHelper.GetSystemIconSize(IconMetricSize.SmallIcon);
```

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons;

if (CursorHelper.TryGetCurrentCursor(out CapturedCursor cursor)
    && cursor.ColorLayer is not null)
{
    cursor.ColorLayer.Save("cursor.png");
}
```

### Desktop Composition

Namespace: `CP.ReactiveUI.Primitives.Windows.Desktop.Composition`

`DwmApi` wraps Desktop Window Manager calls for thumbnails, iconic previews, window attributes, composition, blur, and corner preferences. `DwmBlurBehind` and `DwmThumbnailProperties` are managed structures for the native DWM values.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Composition;
using CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Enums;
using CP.ReactiveUI.Primitives.Windows.Desktop.Windows;

IntPtr hwnd = InteropWindowQueryExtensions.GetForegroundWindow().Handle.DangerousGetHandle();

bool applied = DwmApi.SetWindowCornerPreference(
    hwnd,
    DwmWindowCornerPreference.Round);
```

### Power, Timers, And Multimedia

Namespaces:

- `CP.ReactiveUI.Primitives.Windows.Desktop.Power`
- `CP.ReactiveUI.Primitives.Windows.Desktop.Media`

| API | Purpose |
| --- | --- |
| `PowerBroadcastListener.PowerBroadcastEvents` | Observe all `WM_POWERBROADCAST` events. |
| `SystemSuspendingEvents`, `SystemResumedFromSuspendEvents`, `SystemAutomaticResumeEvents`, `PowerStatusChanges` | Filter common power events. |
| `PowerManagementApi.Sleep(...)`, `Hibernate(...)`, `Shutdown(...)`, `Restart(...)`, `LogOff(...)`, `ExitWindowsEx(...)`, `SetSuspendState(...)` | Initiate system power/session commands. |
| `WaitableTimer` | Managed waitable timer with one-shot, absolute, periodic, cancellation, and observable signal support. |
| `SystemStateApi` | Execution-state and waitable-timer native helpers. |
| `WinMm.PlaySystemSound(...)`, `Play(...)`, `StopPlaying()` | Play system sounds, resources, files/memory, and stop playback. |

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Power;

IDisposable suspending = PowerBroadcastListener.Suspending.Subscribe(_ =>
{
    Console.WriteLine("System is suspending.");
});

IDisposable resumed = PowerBroadcastListener.SystemResumedFromSuspendEvents.Subscribe(_ =>
{
    Console.WriteLine("System resumed.");
});
```

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Power;

using WaitableTimer timer = new();
timer.SetOnce(TimeSpan.FromSeconds(10));

using CancellationTokenSource cts = new(TimeSpan.FromMinutes(1));
await timer.WaitAsync(cts.Token);

IDisposable signals = timer.ObserveSignals().Subscribe(_ =>
{
    Console.WriteLine("Timer signaled.");
});
```

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Media;
using CP.ReactiveUI.Primitives.Windows.Desktop.Media.Enums;
using CP.ReactiveUI.Primitives.Windows.Desktop.Power;

WinMm.PlaySystemSound(SystemSounds.Asterisk);
WinMm.StopPlaying();

// These are real OS commands. Use only for deliberate user actions.
// PowerManagementApi.Sleep();
// PowerManagementApi.Restart(force: false);
```

### Application Restart And End Session

Namespace: `CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle`

| API | Purpose |
| --- | --- |
| `ApplicationRestartManager.RegisterForRestart(...)` | Register the current process with Windows Application Restart. |
| `UnregisterForRestart()` | Remove restart registration. |
| `WasRestartRequested()` | Check common restart command-line markers. |
| `GetRestartCommandLineArgs()` | Return restart arguments excluding the executable path. |
| `ObserveEndSessionMessages(...)` | Observe `WM_QUERYENDSESSION` and `WM_ENDSESSION`. |

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle;
using CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums;

ApplicationRestartManager.RegisterForRestart(
    commandLineArgs: "--restart",
    flags: ApplicationRestartFlags.None);

bool restarted = ApplicationRestartManager.WasRestartRequested();
string[] restartArgs = ApplicationRestartManager.GetRestartCommandLineArgs();

IDisposable endSession = ApplicationRestartManager.ObserveEndSessionMessages(
    onQuerySession: reason =>
    {
        SaveDocuments();
        return true;
    },
    onEndSession: reason =>
    {
        FlushTelemetry();
        return true;
    })
    .Subscribe(message => Console.WriteLine(message.EndSessionReason));
```

### Software Inventory

Namespace: `CP.ReactiveUI.Primitives.Windows.Desktop.Software`

`InstallationInformation.InstalledSoftware()` reads uninstall registry entries and returns `SoftwareDetails`.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Software;

foreach (SoftwareDetails software in InstallationInformation.InstalledSoftware())
{
    Console.WriteLine($"{software.DisplayName} {software.DisplayVersion}");
}
```

### Shell Dialog, Window, And UI Framework Extensions

WinForms:

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Windows;

IInteropWindow interop = myForm.AsInteropWindow();
WindowPlacement placement = myForm.RetrievePlacement();
myForm.ApplyPlacement(placement);
```

WPF:

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Windows;

IInteropWindow interop = myWindow.AsInteropWindow();
WindowPlacement placement = myWindow.RetrievePlacement();
myWindow.ApplyPlacement(placement);
```

### Optional Integrations

Namespace: `CP.ReactiveUI.Primitives.Windows.Integrations.Citrix`

`WinFrame` wraps Citrix WFAPI session information:

| API | Purpose |
| --- | --- |
| `WinFrame.IsAvailabe` | Returns whether WFAPI can be queried in the current process. |
| `GetClientIpAddress()` | Citrix client IP address. |
| `GetClientName()` | Citrix client name. |
| `QuerySessionConnectState()` | Current Citrix connection state. |
| `QuerySessionInformation(InfoClasses)` | Raw string query by Citrix info class. |
| `WaitSystemEvent(EventMask)` | Block until a Citrix system event occurs. |

```csharp
using CP.ReactiveUI.Primitives.Windows.Integrations.Citrix;

if (WinFrame.IsAvailabe)
{
    Console.WriteLine(WinFrame.GetClientName());
    Console.WriteLine(WinFrame.GetClientIpAddress());
    Console.WriteLine(WinFrame.QuerySessionConnectState());
}
```

Additional Citrix integrations are split into composable, testable surfaces:

| Namespace | Surface |
| --- | --- |
| `.Citrix.Lifecycle` | Typed `OnConnect`, `OnDisconnect`, `OnLogin`, window, ICA-file parse, and session-state observables. `OnWindowDestroyed` is the preferred spelling; `OnWindowDistroyed` is retained as an alias. |
| `.Citrix.Ipc` | `DriverOpen`, `DriverClose`, `DriverWrite`, `VdRegisterFeature`, incoming-data, and driver-event streams over an injected virtual-driver adapter. |
| `.Citrix.Host` | Reactive CCM session information, disconnect, logoff, and disposable WTS session-notification registration. |
| `.Citrix.Telemetry` | Polling streams for sessions, machine resource utilization, connection failures, and application failures through an injected Citrix Monitor transport. |

The SDK-dependent surfaces accept interfaces or delegates so tests can use deterministic adapters. Host-management overloads without an adapter securely load the architecture-matched CCM SDK from the registered Citrix Workspace installation. Disposing a native CCM adapter, IPC session, WTS registration, or telemetry subscription also disposes its underlying lifetime.

```csharp
using CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host;
using CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc;
using CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle;
using CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry;

using IDisposable connected = lifecycleSource.OnConnect().Subscribe(HandleConnect);
using IDisposable channel = CitrixVirtualChannelIpc.DriverOpen(driver, openRequest).Subscribe(HandleChannel);
using IDisposable sessions = telemetry.Sessions.Subscribe(HandleSnapshot);
```

Namespace: `CP.ReactiveUI.Primitives.Windows.Integrations.Browser`

`InternetExplorerVersion` configures the legacy WinForms `WebBrowser` emulation mode. `ExtendedWebBrowser` hosts a `WebBrowser` control that suppresses script-error command handling through `IOleCommandTarget`.

```csharp
using CP.ReactiveUI.Primitives.Windows.Integrations.Browser;

int installedMajor = InternetExplorerVersion.Version;
int emulationVersion = InternetExplorerVersion.GetEmbVersion(ignoreDoctype: true);

InternetExplorerVersion.ChangeEmbeddedVersion(
    applicationName: "MyDesktopApp",
    browserVersion: emulationVersion);

var browser = new ExtendedWebBrowser
{
    Dock = DockStyle.Fill,
    ScriptErrorsSuppressed = true
};
```

## Reactive Package Variant

Use `CP.ReactiveUI.Primitives.Windows.Reactive` when your consuming project already uses System.Reactive-flavoured ReactiveUI.Primitives packages.

```powershell
dotnet add package CP.ReactiveUI.Primitives.Windows.Reactive
```

The package recompiles the `CP.ReactiveUI.Primitives.Windows` desktop source with `REACTIVE_SHIM`; it does not maintain a second implementation. Project-level aliases bind shared factory and scheduler/unit names to the System.Reactive-flavoured ReactiveUI.Primitives surface. Only the desktop namespace changes:

| Lean package | System.Reactive package |
|---|---|
| `CP.ReactiveUI.Primitives.Windows.Desktop.*` | `CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.*` |
| `ReactiveUI.Primitives` | `ReactiveUI.Primitives.Reactive` |
| `ReactiveUI.Primitives.RxVoid` | `System.Reactive.Unit` |
| `ReactiveUI.Primitives.Concurrency.ISequencer` | `System.Reactive.Concurrency.IScheduler` |

Core types are referenced, not recompiled, by both variants:

```csharp
using CP.ReactiveUI.Primitives.Windows.Native;
using CP.ReactiveUI.Primitives.Windows.Native.Structs;
using CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Power;
using System.Reactive.Linq;

// WaitableTimer is emitted by the .Reactive desktop assembly.
// NativeRect and the other Win32 value types retain their Core identity.
using var timer = new WaitableTimer();
using var subscription = timer
    .ObserveSignals()
    .Take(1)
    .Select(static elapsedAt => $"Timer elapsed at {elapsedAt:O}")
    .Subscribe(Console.WriteLine);

if (!timer.SetOnce(TimeSpan.FromSeconds(1)))
{
    throw new InvalidOperationException("The Windows waitable timer could not be armed.");
}
```

The shared source declares its package namespace with the following boundary:

```csharp
#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Power;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.Power;
#endif
```

Choose one desktop variant per consumer project. Reference `CP.ReactiveUI.Primitives.Windows` for lean pipelines, or `CP.ReactiveUI.Primitives.Windows.Reactive` when the consumer standardizes on System.Reactive operators and scheduler/unit conventions.

## Quality Gates For Contributors

The repository solution is `src\CP.ReactiveUI.Primitives.Windows.slnx`.

Use NUKE for the standard local build. It uses only SDK targets supported by a stable Visual Studio installation:

```powershell
.\build.cmd Compile --Configuration Release
```

The equivalent direct solution build is:

```powershell
dotnet build .\src\CP.ReactiveUI.Primitives.Windows.slnx -c Release `
  -p:TreatWarningsAsErrors=true -p:WarningsAsErrors=true
```

To validate and package the complete target-framework surface, install a .NET 11 preview SDK (and use a preview-capable Visual Studio configuration), then opt in explicitly:

```powershell
.\build.cmd Compile --Configuration Release `
  --EnableDotNet11PreviewTargetFrameworks true
```

The BuildOnly CI workflow installs both .NET 10 and the .NET 11 preview SDK, enables the preview target automatically, runs the NUKE compile target, and executes the lean and Reactive shared-source TUnit hosts sequentially through Microsoft Testing Platform with Cobertura coverage. It also runs the .NET 11 preview test host. A stable Visual Studio installation does not select `net11.0-windows`, preventing `NETSDK1045`; the preview target remains part of CI and release validation.

Run the strict direct build with warnings as errors when diagnosing MSBuild behavior:

```powershell
dotnet build .\src\CP.ReactiveUI.Primitives.Windows.slnx -c Release --no-restore `
  -p:TreatWarningsAsErrors=true -p:WarningsAsErrors=true `
  -p:CodeAnalysisTreatWarningsAsErrors=true
```

Run TUnit tests through Microsoft Testing Platform with the repository coverage configuration:

```powershell
dotnet .\src\CP.ReactiveUI.Primitives.Windows.Tests\bin\Release\net10.0-windows\CP.ReactiveUI.Primitives.Windows.Tests.dll `
  --minimum-expected-tests 1 --config-file .\testconfig.json --coverage `
  --coverage-output .\.codex-diagnostics\coverage-final.cobertura.xml `
  --coverage-output-format cobertura
```

`testconfig.json` contains the generated-code exclusions. Do not pass `--coverage-settings` together with `--config-file`; this Microsoft Testing Platform version accepts one configuration source per run.

All projects use central analyzer package versions, project-level usings/aliases, and no diagnostic suppressions. Tests are TUnit tests and should use TUnit assertions only.

<!-- BEGIN GENERATED API REFERENCE -->
# Public callable API reference

Every public method, overload, constructor, operator, conversion, delegate invocation, property and indexer has an exact signature, description and compiled C# example in the linked reference pages. Availability is recorded for each target framework. Examples accept valid existing typed inputs and are compiled without execution; retain native resources for their required lifetime. Observable sources subscribe directly; operation adapters observe their result before subscribing. Subscription examples return an IDisposable that the caller retains and disposes to control the subscription lifetime. Synchronous desktop methods support deferred fluent observation. Native buffer, pointer, span and by-reference methods retain direct calls.

Regenerate: `pwsh ./tools/Update-ApiReference.ps1`.

## CP.ReactiveUI.Primitives.Windows.Core

### CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations

- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WindowsMessages](docs/api/2cf081ec3bab.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WindowsMessagesExtensions](docs/api/499ea87d0c89.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WtsSessionChangeEvents](docs/api/0c2bc78d6c93.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Native

- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Native.WndProc](docs/api/539d4cf6a64e.md) — 5 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Structs

- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Structs.Msg](docs/api/e05f8454f37c.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Structs.WindowMessage](docs/api/0de1d2a3a88a.md) — 7 callable members.

### CP.ReactiveUI.Primitives.Windows.Interop.Com

- [CP.ReactiveUI.Primitives.Windows.Interop.Com.ComProgIdAttribute](docs/api/ebccf0099889.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Interop.Com.DisposableCom](docs/api/f050cd85f8f9.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Interop.Com.IDisposableCom<T>](docs/api/8896458d7eb4.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Interop.Com.IOleCommandTarget](docs/api/6916915ef95e.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Interop.Com.IOleWindow](docs/api/a07b4bb66a66.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Interop.Com.Ole32Api](docs/api/7f54299001e3.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Interop.Com.OleAut32Api](docs/api/02c1b378cab9.md) — 4 callable members.

### CP.ReactiveUI.Primitives.Windows.Native

- [CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel>](docs/api/bedd72fbe4c9.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel>.ProcessRowDelegate<TRowPixel>](docs/api/903a74804804.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessorExtensions](docs/api/1a15fcc51968.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Win32](docs/api/2b2db3f5a9f4.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.WindowsVersion](docs/api/536b4464d39b.md) — 16 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Enums

- [CP.ReactiveUI.Primitives.Windows.Native.Enums.AdjacentTo](docs/api/08c43bab4e54.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Enums.HResult](docs/api/4b3ffbd1eaa5.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Enums.Win32Error](docs/api/467d54215bf2.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Extensions

- [CP.ReactiveUI.Primitives.Windows.Native.Extensions.EnumExtensions](docs/api/042189dd27df.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Extensions.HResultExtensions](docs/api/c529088acf3f.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Extensions.NativePointExtensions](docs/api/fd60733b4cbd.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Extensions.NativePointFloatExtensions](docs/api/f73be8ab4325.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Extensions.NativeRectExtensions](docs/api/6699d3b8d801.md) — 31 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Extensions.NativeRectFloatExtensions](docs/api/2272271a220e.md) — 31 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Extensions.NativeSizeExtensions](docs/api/f691aeea2ecc.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Extensions.NativeSizeFloatExtensions](docs/api/b3e7ce397505.md) — 3 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Gdi

- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Gdi32Api](docs/api/689c43fb36d6.md) — 16 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.GdiExtensions](docs/api/10c13f2df83a.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.GdiPlusApi](docs/api/a07b075273ed.md) — 3 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Gdi.Enums

- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Enums.BitmapCompressionMethods](docs/api/71ab7197e8eb.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Enums.ColorSpace](docs/api/625bb485c4ff.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Enums.DeviceCaps](docs/api/3ceefd54bcb0.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Enums.DibColors](docs/api/8a3e3c6e91d6.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Enums.GdiPlusStatus](docs/api/e03d89f441fe.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Enums.GpUnit](docs/api/b3449925d4fa.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Enums.RasterOperations](docs/api/93300528c710.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles

- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeCompatibleDcHandle](docs/api/737a79251d91.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeDibSectionHandle](docs/api/62a0f98e32ba.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeGraphicsDcHandle](docs/api/a5beb50b9fba.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeHBitmapHandle](docs/api/d3ba5d6017c6.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeNonDisposableObjectHandle](docs/api/9c04cd06a0cb.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeRegionHandle](docs/api/21656a9dbe1c.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeSelectObjectHandle](docs/api/92f5fc502dd1.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeWindowDcHandle](docs/api/ad5e679102a2.md) — 8 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs

- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitfieldColorMask](docs/api/62ac2e258f0b.md) — 16 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader](docs/api/edcfea9bc9e9.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapInfoHeader](docs/api/c32033b1e41c.md) — 21 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapV4Header](docs/api/f657b72fef6e.md) — 30 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapV5Header](docs/api/7bff0e3230c7.md) — 34 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams](docs/api/caec2331bb2a.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.CieXyz](docs/api/466a12ce66a0.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.CieXyzTriple](docs/api/7b5994ac6489.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.GdiBitmap](docs/api/609fdee79873.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.RgbQuad](docs/api/d7470fd951c2.md) — 10 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Kernel

- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Kernel32Api](docs/api/46eb5f44d720.md) — 46 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Kernel32ApiExtensions](docs/api/7034b84ab6d9.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.PackageInfo](docs/api/547d4fd85ec7.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.PsApi](docs/api/9b66a5074834.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.RestartManager](docs/api/6a9a21d06376.md) — 20 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.RestartManagerApi](docs/api/af854a4900ab.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.RmStatusCallback](docs/api/2dcfa58617f2.md) — 5 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums

- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums.DefaultDllDirectories](docs/api/15e32245b754.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums.GlobalMemorySettings](docs/api/ae3e8dff6a31.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums.ProcessAccessRights](docs/api/33276baf3b43.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums.RmAppStatus](docs/api/f99aff0b136e.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums.RmAppType](docs/api/f38ee5e717da.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums.RmRebootReason](docs/api/0a62b6aa7c63.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums.RmShutdownType](docs/api/379d3342b611.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums.ThreadAccess](docs/api/65279dd1e806.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums.WindowsProducts](docs/api/2a90b8255bf3.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums.WindowsProductTypes](docs/api/c95c1a3fe671.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums.WindowsSuites](docs/api/9bb029ddd5c4.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Kernel.Structs

- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Structs.OsVersionInfoEx](docs/api/e71f8164030a.md) — 16 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Structs.RmProcessInfo](docs/api/3ff29615d076.md) — 14 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Structs.RmUniqueProcess](docs/api/c3dfd91f285e.md) — 9 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Security

- [CP.ReactiveUI.Primitives.Windows.Native.Security.Advapi32Api](docs/api/4ccf7d79d006.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Security.RegistryMonitor](docs/api/e4eefe9f45ea.md) — 4 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Security.Enums

- [CP.ReactiveUI.Primitives.Windows.Native.Security.Enums.RegistryKeySecurityAccessRights](docs/api/462b6104a66d.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Security.Enums.RegistryNotifyFilter](docs/api/98d4394204ab.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Security.Enums.RegistryOpenOptions](docs/api/bcc3250b6991.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Security.Enums.TokenInformationClasses](docs/api/6c95c1e7d8fe.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Shell

- [CP.ReactiveUI.Primitives.Windows.Native.Shell.Shell32Api](docs/api/3432d5fce17d.md) — 5 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Shell.Enums

- [CP.ReactiveUI.Primitives.Windows.Native.Shell.Enums.AppBarEdges](docs/api/c5753f215fc6.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Shell.Enums.AppBarMessages](docs/api/4805b2d422fc.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Shell.Enums.AppBarStates](docs/api/20e3d798d3e6.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Shell.Enums.ShellFileAttributeFlags](docs/api/f4f7363918a9.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Shell.Enums.ShellGetFileInfoFlags](docs/api/7f8e621fe6ff.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Shell.SafeHandles

- [CP.ReactiveUI.Primitives.Windows.Native.Shell.SafeHandles.SafeIconHandle](docs/api/648ca7a71caa.md) — 6 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Shell.Structs

- [CP.ReactiveUI.Primitives.Windows.Native.Shell.Structs.AppBarData](docs/api/58ed7912ebb9.md) — 14 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Shell.Structs.ShellFileInfo](docs/api/511278719998.md) — 11 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Structs

- [CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint](docs/api/013cc49f0dca.md) — 19 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePointFloat](docs/api/071d16bedec7.md) — 22 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeRect](docs/api/d1d5e0d6e6d2.md) — 40 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeRectFloat](docs/api/85ec8e5d8b47.md) — 45 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeSize](docs/api/d089f4919591.md) — 30 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeSizeFloat](docs/api/4becf0a65dc9.md) — 35 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Structs.PixelFormats

- [CP.ReactiveUI.Primitives.Windows.Native.Structs.PixelFormats.Bgr24](docs/api/ac04c9305663.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Structs.PixelFormats.Bgra32](docs/api/5dfd1a7316ae.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Structs.PixelFormats.Indexed8](docs/api/b1ef488190bf.md) — 9 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.TypeConverters

- [CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativePointFloatTypeConverter](docs/api/ca5e10e91bb6.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativePointTypeConverter](docs/api/304695a128a7.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectFloatTypeConverter](docs/api/a4f6f01e0074.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter](docs/api/f282eadcda03.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeSizeFloatTypeConverter](docs/api/de25fa645857.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeSizeTypeConverter](docs/api/e4f04d3e3c58.md) — 5 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.UserInterface

- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.DisplayInfo](docs/api/828f5b8d09ee.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.User32Api](docs/api/8ad32c22b8ed.md) — 143 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.User32Api.EnumWindowsProc](docs/api/a1b58f0f38a5.md) — 7 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums

- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.ClassLongIndex](docs/api/e69c6046e7a4.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.CursorInfoFlags](docs/api/de52ee71db44.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.DesktopAccessRight](docs/api/ec2f3671f402.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.ExtendedWindowStyleFlags](docs/api/282e67d38679.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.GetWindowCommands](docs/api/3d18ae7fe6eb.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.MonitorFrom](docs/api/c997b4fa106e.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.MonitorInfoFlags](docs/api/f820bc30b49b.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.ObjectIdentifiers](docs/api/4e3a68972402.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.ObjectStates](docs/api/becb1d62606b.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.PrintWindowFlags](docs/api/e2d4a52acaab.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.RegionResults](docs/api/1bf2a7a99be9.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.ScrollBarCommands](docs/api/096965c1c336.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.ScrollBarStateIndexes](docs/api/3e4e52c96ef5.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.ScrollBarTypes](docs/api/078e177a3c58.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.ScrollInfoMask](docs/api/b4778e73e53b.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.ScrollModes](docs/api/8705f8501a0e.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SendMessageTimeoutFlags](docs/api/d093a52f0e55.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.ShowWindowCommands](docs/api/b76603271c87.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SysCommands](docs/api/46e80610fcc3.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SystemColorIndex](docs/api/0b1b863bea6b.md) — 40 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SystemMetric](docs/api/f127cce27129.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SystemParametersInfoActions](docs/api/7167c8e12718.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SystemParametersInfoBehaviors](docs/api/7dd40b8b3f7d.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.TitleBarInfoIndexes](docs/api/84f66cc67f55.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.WindowDisplayAffinity](docs/api/d77ba7eb9323.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.WindowLongIndex](docs/api/76ae0f0403bd.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.WindowPlacementFlags](docs/api/20f366ef4be4.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.WindowPos](docs/api/248f34b94b8e.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.WindowsClassStyles](docs/api/5236c1c5430a.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.WindowStyleFlags](docs/api/e6f20592833a.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.UserInterface.SafeHandles

- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.SafeHandles.SafeCurrentInputDesktopHandle](docs/api/79c1f493f9fa.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.SafeHandles.SafeCursorReferenceHandle](docs/api/cf0b947fac81.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.SafeHandles.SafeMonitorHandle](docs/api/c76ce59645af.md) — 3 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs

- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.AnimationInfo](docs/api/c93fbc3c9c31.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.CursorInfo](docs/api/5e017dfc489e.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx](docs/api/ecbce1452f0a.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.ScrollBarInfo](docs/api/6c23c6129071.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.ScrollInfo](docs/api/6d129ba591a1.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.TitleBarInfoEx](docs/api/7f86f467c606.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.WindowInfo](docs/api/040435cbe426.md) — 16 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.WindowPlacement](docs/api/290aa8191096.md) — 13 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.UserInterface.TypeConverters

- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.TypeConverters.WindowPlacementTypeConverter](docs/api/0624db128a96.md) — 5 callable members.

### CP.ReactiveUI.Primitives.Windows.Operations

- [CP.ReactiveUI.Primitives.Windows.Operations.WindowsAsyncOperation<T>](docs/api/f63719be3b08.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation](docs/api/0831277ff95c.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<T>](docs/api/17eca6807c62.md) — 4 callable members.

## CP.ReactiveUI.Primitives.Windows.Integrations

### CP.ReactiveUI.Primitives.Windows.Integrations

- [CP.ReactiveUI.Primitives.Windows.Integrations.IntegrationOperationExtensions](docs/api/7856522c415c.md) — 15 callable members.

### CP.ReactiveUI.Primitives.Windows.Integrations.Browser

- [CP.ReactiveUI.Primitives.Windows.Integrations.Browser.ExtendedWebBrowser](docs/api/ff2055f379ac.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Browser.InternetExplorerVersion](docs/api/8569876cbc58.md) — 9 callable members.

### CP.ReactiveUI.Primitives.Windows.Integrations.Citrix

- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.WinFrame](docs/api/2da8c03a27a6.md) — 6 callable members.

### CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Enums

- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Enums.ConnectStates](docs/api/6fe0b14ae608.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Enums.EventMask](docs/api/a4f328091bf5.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Enums.InfoClasses](docs/api/d7f06c4bd388.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host

- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host.CcmHostOperationResult](docs/api/73461aeb0111.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host.CcmHostSessionInformation](docs/api/e1b4795ac78c.md) — 40 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host.CcmHostSessionInformationResult](docs/api/4e47662a1d1c.md) — 14 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host.CitrixHostSessionManagement](docs/api/c50f270c83f7.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host.DelegatingCitrixCcmHostSessionApi](docs/api/728716cf7839.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host.DelegatingWtsSessionNotificationApi](docs/api/d72671c15660.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host.ICitrixCcmHostSessionApi](docs/api/884cd90feb72.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host.IWtsSessionNotificationApi](docs/api/51d9263463c9.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host.NativeCitrixCcmHostSessionApi](docs/api/c87a1716b088.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host.WtsSessionNotificationRegistration](docs/api/a95e55a4c04b.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host.WtsSessionNotificationScope](docs/api/0aeb19e05d2d.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc

- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelCloseResult](docs/api/16fe2004e239.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelData](docs/api/8c9bfe560a7b.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelEvent](docs/api/fc8047e257c0.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelEventKind](docs/api/58779c86d458.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature](docs/api/7bd6dffbf419.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeatureRegistration](docs/api/04455733a282.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelHandle](docs/api/6d74ea4ac18a.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelIpc](docs/api/3c31f686c752.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenRequest](docs/api/90576e6df796.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult](docs/api/aadfde401cad.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelSession](docs/api/d0e44228c151.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelStatus](docs/api/52333b4d4a4f.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelWriteRequest](docs/api/4b1f78e5cf18.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelWriteResult](docs/api/26f299d13c2a.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.ICitrixVirtualDriverAdapter](docs/api/4cf29ca98c12.md) — 6 callable members.

### CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle

- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixConnectEvent](docs/api/7178637a4eab.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixDisconnectEvent](docs/api/f563a962baf9.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixICAFileInfo](docs/api/254db8968d5d.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixICAFileParseEvent](docs/api/3bece47b7d47.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixLifecycleEvent](docs/api/e945bb583adc.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixLifecycleExtensions](docs/api/8b3e937130d6.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixLifecycleObservables](docs/api/0d9f92c68cc9.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixLoginEvent](docs/api/8c851e983ac0.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixObservableLifecycleEventSource](docs/api/9d8b4e0fee19.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixSessionInfo](docs/api/0ac399a40687.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixSessionLifecycleEvent](docs/api/3f5107a8c9b9.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixSessionStateChangeEvent](docs/api/26e2a87fb799.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixWindowCreatedEvent](docs/api/f2ab9ef92876.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixWindowDestroyedEvent](docs/api/c081c7c31af5.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixWindowInfo](docs/api/b0fb240f1513.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixWinFrameLifecycleEventSource](docs/api/81a22bbf7d2c.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.ICitrixLifecycleEventSource](docs/api/587d9d476e0c.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs

- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.AppInfo](docs/api/d2b98b70e34b.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress](docs/api/4aba73c1c1ba.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientDisplay](docs/api/0d17a984984a.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientInfo](docs/api/159c19086c1e.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientLatency](docs/api/e28b9dd5467c.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.OsVersionInfo](docs/api/d7d62aa1b67e.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.SessionTime](docs/api/f5d4cc057fb2.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.UserInfo](docs/api/6cc36529f726.md) — 10 callable members.

### CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry

- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixApplicationFailureTelemetryEntity](docs/api/eef983f1022b.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMachineResourceUtilizationTelemetryEntity](docs/api/07b5c8b05a58.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetry](docs/api/55a2a9c43472.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetryOptions](docs/api/084e1d09a894.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetryRequest](docs/api/aab84466fbd3.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot](docs/api/9becf60b9ff9.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetryUriBuilder](docs/api/70e2f7b8041e.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.DelegateCitrixMonitorTelemetryTransport](docs/api/fe831b5825f4.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.ICitrixMonitorTelemetryTransport](docs/api/a226a8b235ac.md) — 1 callable members.

## CP.ReactiveUI.Primitives.Windows.Reactive

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Apps

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Apps.AppQueryExtensions](docs/api/e4930b2b1e7f.md) — 12 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardAccessDeniedException](docs/api/73462c39930d.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardByteExtensions](docs/api/000d1abb6cc0.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardCloudExtensions](docs/api/eaab28489254.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardFileExtensions](docs/api/aaafbcc5140b.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardFormatExtensions](docs/api/e310bd76ba0f.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardMiscExtensions](docs/api/32976518a9e0.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardNative](docs/api/8fa9e5939f2a.md) — 27 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardObservation](docs/api/08e7f5cb1150.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardRenderFormatRequest](docs/api/8eec2d69aa42.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardStreamExtensions](docs/api/d20da702192a.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardStringExtensions](docs/api/80958bc275ef.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation](docs/api/eac9cdc5a0b1.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.IClipboardAccessToken](docs/api/be31ea83ce42.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.StandardClipboardFormats](docs/api/fcf5dec3f920.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Composition

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Composition.DwmApi](docs/api/856edf7d040e.md) — 38 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Composition.Enums

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Composition.Enums.DwmBlurBehindFlags](docs/api/de17838084c0.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Composition.Enums.DwmSetIconicLivePreviewFlags](docs/api/aedaf8c43b2b.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Composition.Enums.DwmThumbnailPropertyFlags](docs/api/aa823da67670.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Composition.Enums.DwmWindowAttributes](docs/api/8597aff539bd.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Composition.Enums.DwmWindowCornerPreference](docs/api/f12c47781124.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Composition.Structs

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Composition.Structs.DwmBlurBehind](docs/api/e1a61dd8f6c6.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Composition.Structs.DwmThumbnailProperties](docs/api/7105877ca428.md) — 11 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.DeviceInterfaceChangeInfo](docs/api/e90de83f1df1.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.DeviceNotification](docs/api/228afd813663.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.DeviceNotificationEvent](docs/api/b52e16ea6891.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.VolumeInfo](docs/api/4595e2b45150.md) — 3 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.Enums

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.Enums.DeviceBroadcastDeviceType](docs/api/3c41a9978458.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.Enums.DeviceChangeEvent](docs/api/0f3da537eec6.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.Enums.DeviceInterfaceClass](docs/api/973a689077f9.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.Enums.DeviceNotifyFlags](docs/api/6b6d0413f259.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.Structs

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.Structs.DevBroadcastDeviceInterface](docs/api/f66d98013f8d.md) — 22 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.Structs.DevBroadcastHandle](docs/api/af020073c217.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.Structs.DevBroadcastHeader](docs/api/a38063928394.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.Structs.DevBroadcastPort](docs/api/1e2f1ffa1ff4.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.Structs.DevBroadcastVolume](docs/api/39cef5f7f404.md) — 9 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.DisplayTopology](docs/api/bc8b01c30bb9.md) — 4 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.BitmapScaleHandler](docs/api/fb9f1d71db52.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue>](docs/api/40534641540c.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.DpiApi](docs/api/70ff418d0b62.md) — 18 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.DpiCalculator](docs/api/d63207ee80c9.md) — 30 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.DpiChangeInfo](docs/api/ad091ecd0cbc.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.DpiHandler](docs/api/4b1705fdc824.md) — 31 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.NativeDpiMethods](docs/api/5d5a2933d188.md) — 40 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Enums

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Enums.DialogDpiChangeBehaviors](docs/api/4c9cdb3db133.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Enums.DialogScalingBehaviors](docs/api/e72ded9c4d60.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Enums.DpiAwareness](docs/api/9ab4102698b6.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Enums.DpiAwarenessContext](docs/api/89bb890aef2f.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Enums.DpiHostingBehavior](docs/api/b5c8280d8e84.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Enums.MonitorDpiType](docs/api/fd324cdbdfbf.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Forms

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Forms.DpiAwareFormBehavior](docs/api/5558d9e32432.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Forms.DpiUnawareFormBehavior](docs/api/169b82f45587.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Forms.FormsDpiExtensions](docs/api/a07fe374dbdd.md) — 4 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Wpf

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Wpf.WindowDpiExtensions](docs/api/fb2b23f995b6.md) — 2 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.InputOperationExtensions](docs/api/35b05363b6ac.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.InputOperations](docs/api/48c4e32ef542.md) — 21 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.NativeInput](docs/api/f3ef2b2697de.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.RawInputApi](docs/api/860b37aa8ebb.md) — 20 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.RawInputDeviceChangeEventArgs](docs/api/9063c8851607.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.RawInputDeviceInformation](docs/api/7516ed275831.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.RawInputDeviceMonitor](docs/api/5ac84c14ad30.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.RawInputEventArgs](docs/api/06334e316492.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.RawInputMonitor](docs/api/8a15035a49e6.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.ExtendedKeyFlags](docs/api/7e93eb421431.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.ExtendedMouseFlags](docs/api/0ef0195e156e.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.HidUsagePages](docs/api/0897d48fde3c.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.HidUsagesConsumer](docs/api/40db543ca357.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.HidUsagesGeneric](docs/api/0a8987323a7d.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.HookTypes](docs/api/4b4723b89f54.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.InputTypes](docs/api/f19c426f4377.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.KeyEventFlags](docs/api/fa6400d08078.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.MouseButtons](docs/api/95aa590c2000.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.MouseButtonStates](docs/api/dbbfadf80953.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.MouseEventFlags](docs/api/4f962dfe0b94.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.MouseStates](docs/api/120a17adbdc6.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.RawInputDataCommands](docs/api/91edf8ef0067.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.RawInputDeviceFlags](docs/api/34ecc0b9ac43.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.RawInputDeviceInfoCommands](docs/api/8d1975046d00.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.RawInputDevices](docs/api/8798ba436180.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.RawInputDeviceTypes](docs/api/d04a566826d9.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.RawKeyboardFlags](docs/api/c70c5d1c6d29.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.VirtualKeyCode](docs/api/d92eb45b66ac.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard.IKeyboardHookEventHandler](docs/api/56b304b61f95.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard.KeyboardHandlerExtensions](docs/api/ab0e6175f8ed.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard.KeyboardHook](docs/api/7207b6ffe22e.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard.KeyboardHookEventArgs](docs/api/8c34c449ba20.md) — 30 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard.KeyboardHookExtensions](docs/api/3264882ce1c3.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard.KeyboardInputGenerator](docs/api/2a79521b6478.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard.KeyCombinationHandler](docs/api/579816142837.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard.KeyHelper](docs/api/0311dd9e0f2b.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard.KeyOrCombinationHandler](docs/api/f7263cf9d240.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard.KeySequenceHandler](docs/api/600dc15505b2.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard.VirtualKeyCodeExtensions](docs/api/6dbcc84ce006.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Mouse

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Mouse.MouseHook](docs/api/0fd5aae2277d.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Mouse.MouseHookEventArgs](docs/api/e4b355c71d6b.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Mouse.MouseInputGenerator](docs/api/f9f36c89c67b.md) — 14 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.HardwareInput](docs/api/172ac1893651.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.Input](docs/api/afb3513499e4.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.InputUnion](docs/api/c349a75e2174.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.KeyboardInput](docs/api/6bcfb8a34abe.md) — 17 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.KeyboardLowLevelHookStruct](docs/api/6a7333e9fe24.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.LastInputInfo](docs/api/333243d3edf9.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.MouseInput](docs/api/475e6fa6a5b0.md) — 23 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.MouseLowLevelHookStruct](docs/api/2b988d18b13e.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawDevice](docs/api/7843b8787876.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawHID](docs/api/2194fcabc587.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawInput](docs/api/337cac7c3211.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawInputDevice](docs/api/59ad24c706da.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawInputDeviceInfo](docs/api/918ab1e87df9.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawInputDeviceInfoHID](docs/api/510555a13488.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawInputDeviceInfoKeyboard](docs/api/1223894827b3.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawInputDeviceInfoMouse](docs/api/907f8be9f24e.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawInputDeviceList](docs/api/6ba251ae1160.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawInputHeader](docs/api/3884ea7b2fb4.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawKeyboard](docs/api/7e61cdce7a68.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse](docs/api/feb3fff1e45a.md) — 12 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.ApplicationRestartManager](docs/api/a8fb4920b90f.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage](docs/api/b817bf0deee5.md) — 13 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.Enums

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.Enums.ApplicationRestartFlags](docs/api/59eee43728fe.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.Enums.EndSessionReasons](docs/api/98fe47ca0497.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Media

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Media.WinMm](docs/api/3624e0399f44.md) — 6 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Media.Enums

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Media.Enums.SoundSettings](docs/api/50460cae413a.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Media.Enums.SystemSounds](docs/api/fcea4bb140c1.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.MessageLoop](docs/api/9ac2b31b98b5.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.MessageLoop.MessageProc](docs/api/125a7b207f15.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.SessionChangeEventArgs](docs/api/52abcaf3c48a.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.SharedMessageWindow](docs/api/d945639a635a.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowMessageInfo](docs/api/06f7a95e3bda.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsMessage](docs/api/788d22585fac.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener](docs/api/b3a8a0d0caca.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WinProcFormsExtensions](docs/api/29a7eb327fec.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WinProcHandler](docs/api/9897d01f4c8e.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WinProcHandlerHook](docs/api/56e6fb80ccf8.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WinProcListener](docs/api/208071362219.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WinProcWindowsExtensions](docs/api/b202b1ce865f.md) — 2 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Power

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Power.PowerBroadcastListener](docs/api/ea4df67468df.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Power.PowerManagementApi](docs/api/c2de32f97108.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Power.SystemStateApi](docs/api/3d2092853b12.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Power.WaitableTimer](docs/api/d7ae510fb59d.md) — 21 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Power.Enums

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Power.Enums.ExitWindowsFlags](docs/api/44611dbe08d2.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Power.Enums.PowerBroadcastEvent](docs/api/a7d72860ca16.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Power.Enums.ThreadExecutionStateFlags](docs/api/742c79d6dd38.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialog](docs/api/d9a0851950a1.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions](docs/api/a6eb2f692ebb.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult](docs/api/1769dedde7fd.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileOpenDialogBuilder](docs/api/0ca72c94306c.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileSaveDialogBuilder](docs/api/bac92a04f64a.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FolderPickerBuilder](docs/api/6b22d1edf130.md) — 6 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.BitmapIconExtensions](docs/api/f75e7d3fbb1f.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.CapturedCursor](docs/api/b473c69dca04.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.CursorHelper](docs/api/0187fea7601f.md) — 14 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.IconExtensions](docs/api/bf04dcb116c7.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.IconFileWriter](docs/api/53f2d26e0db5.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.IconHelper](docs/api/746e182e6dc2.md) — 26 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.IconStreamExtensions](docs/api/e07308fe7035.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.NativeIconMethods](docs/api/df5b5a380b7f.md) — 16 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Enums

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Enums.CopyImageFlags](docs/api/b45a393da8b9.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Enums.DrawIconExFlags](docs/api/7ec51bacc7c7.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Enums.FolderIconType](docs/api/04b48b171567.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Enums.IconMetricSize](docs/api/32c8f74c8a0d.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Enums.IconSize](docs/api/62c43b928447.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Enums.ImageType](docs/api/c140e07bfe1a.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Enums.LoadImageFlags](docs/api/81eb0f6b6481.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Structs

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Structs.GrpIconDir](docs/api/5f478fc2e177.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Structs.GrpIconDirEntry](docs/api/234022707c5f.md) — 18 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Structs.IconDir](docs/api/51b6fc398ef2.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Structs.IconDirEntry](docs/api/47e1af12edd3.md) — 18 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Structs.IconInfo](docs/api/337a250de39e.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Structs.IconInfoEx](docs/api/463312b37630.md) — 16 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Software

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Software.InstallationInformation](docs/api/5412044e292a.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Software.SoftwareDetails](docs/api/10e50f70d4a2.md) — 29 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessDisplay](docs/api/b0df249e61fa.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessMonitoring](docs/api/ebb8afac5fab.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessPanel](docs/api/f866f6e92d1c.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessSample](docs/api/be104d821ad2.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessSnapshot](docs/api/6337dd0c713d.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessTransport](docs/api/638c3b83c049.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.CpuMonitoring](docs/api/5e716a482f48.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.CpuSample](docs/api/f119094cfafe.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.CpuUtilization](docs/api/8a2c65ccb0b1.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsAdapter](docs/api/92094b180928.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsEngineSample](docs/api/12f305072fa5.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsMonitoring](docs/api/aecdc5881dde.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot](docs/api/ff8f064b0cdc.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareBaseboard](docs/api/a7d0650875ac.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareBios](docs/api/718487488913.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareDisk](docs/api/50ccd3f206f7.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareMachine](docs/api/c4c0174b05f3.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareMemoryArray](docs/api/59db47253080.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareMemoryModule](docs/api/8c03e7f3067a.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareMonitoring](docs/api/8a32e5971b51.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareOperatingSystem](docs/api/113a044cf944.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwarePhysicalDisk](docs/api/906314d7b075.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwarePnpDevice](docs/api/f51e3c1270ae.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor](docs/api/42cd1defede4.md) — 16 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareSnapshot](docs/api/12aa9462e906.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.IThermalSensorProvider](docs/api/6ad9ebacdd0a.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.LogicalProcessorSample](docs/api/28649362479f.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.MemoryMonitoring](docs/api/dd1891fd2ed7.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.MemorySample](docs/api/686b60a0ce2d.md) — 17 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.MonitoringOperationExtensions](docs/api/8a1ca2a63f8f.md) — 19 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.MonitoringResult<T>](docs/api/09d6da1a588d.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.MonitoringSections](docs/api/148e7863fa8c.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.MonitoringStatus](docs/api/b4a9115cdf47.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot](docs/api/6f2b22dabcb2.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkInterfaceSnapshot](docs/api/7f19058c0595.md) — 27 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkMonitoring](docs/api/7018932c354a.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics](docs/api/76cdbacc7a70.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkSnapshot](docs/api/3e44349c1b64.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkTcpConnection](docs/api/20031da81541.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NvidiaSensorProvider](docs/api/4ae749e31872.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PerformanceCounterMonitoring](docs/api/75bfe737e72a.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PerformanceCounterQuery](docs/api/24dbaa8bc432.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PerformanceCounterSample](docs/api/14d9b79df1e6.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerBatteryFlags](docs/api/3652e2dcafa2.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerConnection](docs/api/b3b57c45673c.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerMonitoring](docs/api/82dbaaf9feec.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerPlan](docs/api/8626281dbe0b.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerPlans](docs/api/992325b866ff.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerSample](docs/api/941e238abff4.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerSettings](docs/api/41884d0cf64e.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessInfo](docs/api/670f117db9b6.md) — 26 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessMonitoring](docs/api/469dd46d3170.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessSnapshot](docs/api/ef7995ac35a0.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget](docs/api/ae6c3de7f6c0.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ServiceControlResult](docs/api/fe349a513dcf.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ServiceInfo](docs/api/e9f1fb5ec930.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ServiceMonitoring](docs/api/e2cf13c919f7.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ServiceSnapshot](docs/api/bb784f8198e0.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ServiceStartMode](docs/api/a5887080a11b.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ServiceTarget](docs/api/4ca383f8027f.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.StorageDiskSnapshot](docs/api/070ffe6f596b.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.StorageDriveSnapshot](docs/api/b1057afbaf84.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.StorageMonitoring](docs/api/efdfb7843eef.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.StorageSnapshot](docs/api/00b29de45223.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.SystemMonitorBuilder](docs/api/4a0530204a60.md) — 23 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.SystemSnapshot](docs/api/ee973004876c.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalMonitoring](docs/api/47b19004cb6f.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample](docs/api/c5fdbc4eb5f2.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSnapshot](docs/api/d73f26709a8b.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.WindowsManagement](docs/api/f8ad7bd3faef.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.WindowsSystem](docs/api/416f45ef28b3.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.WmiQueryResult](docs/api/fa2cd19589df.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.WmiQueryStatus](docs/api/d8d572bcbfff.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.WmiRow](docs/api/fcd77033adcf.md) — 2 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.BitmapExtensions](docs/api/695004bc172e.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.EnvironmentChangedEventArgs](docs/api/b321f2f05ac7.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.EnvironmentMonitor](docs/api/624540f3b3ca.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.FormsExtensions](docs/api/3c6b451e9019.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.IInteropWindow](docs/api/2ea25f9be999.md) — 25 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.InteropWindow](docs/api/2a772169f548.md) — 29 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.InteropWindowExtensions](docs/api/74b7e19be511.md) — 54 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.InteropWindowFactory](docs/api/2cb7e4721871.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.InteropWindowObservationExtensions](docs/api/2d2906768d3c.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.InteropWindowQueryExtensions](docs/api/6eeaa5194e41.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.SafeNativeWindowHandle](docs/api/d373c8c6949c.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.SafeWinEventHookHandle](docs/api/0ab93d942b08.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowScroller](docs/api/265ca526a033.md) — 22 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsEnumerator](docs/api/fdb3d181f0f4.md) — 16 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsExtensions](docs/api/04321bdfc7e2.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove](docs/api/fce9c9d9cdd0.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMoveBlockMode](docs/api/e5c2433927be.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WinEventHook](docs/api/104051b9cbdd.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WinEventInfo](docs/api/29bb4b069de6.md) — 11 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.Enums

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.Enums.InteropWindowRetrieveSettings](docs/api/e107d516fbc7.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.Enums.WinEventHookFlags](docs/api/0b6e6a24c512.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.Enums.WinEvents](docs/api/6f2895a417f3.md) — 1 callable members.

## CP.ReactiveUI.Primitives.Windows

### CP.ReactiveUI.Primitives.Windows.Desktop.Apps

- [CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions](docs/api/dac13e9af2cc.md) — 12 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard

- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardAccessDeniedException](docs/api/6900ad4e7acd.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardByteExtensions](docs/api/3989b339175d.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardCloudExtensions](docs/api/c55c90bee84a.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardFileExtensions](docs/api/280ded5c2a55.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardFormatExtensions](docs/api/b05740b2c6fd.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardMiscExtensions](docs/api/bd1835557a11.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardNative](docs/api/92ab593ec1a3.md) — 27 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardObservation](docs/api/e47146e53efe.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardRenderFormatRequest](docs/api/24f380393feb.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStreamExtensions](docs/api/5863c84aeb77.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions](docs/api/cbe4edf10c79.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardUpdateInformation](docs/api/e41c14736320.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken](docs/api/31a94bdab7dd.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.StandardClipboardFormats](docs/api/d87d5492e3ad.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Composition

- [CP.ReactiveUI.Primitives.Windows.Desktop.Composition.DwmApi](docs/api/d19bf56e4cdf.md) — 38 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Enums

- [CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Enums.DwmBlurBehindFlags](docs/api/9fc69ffdba4e.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Enums.DwmSetIconicLivePreviewFlags](docs/api/b12c21a2deb9.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Enums.DwmThumbnailPropertyFlags](docs/api/f6d6b1ccfd7d.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Enums.DwmWindowAttributes](docs/api/80ef324cbcac.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Enums.DwmWindowCornerPreference](docs/api/e6137e274aba.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs

- [CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind](docs/api/3cdf82bf79ca.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmThumbnailProperties](docs/api/108b0561b55b.md) — 11 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Devices

- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.DeviceInterfaceChangeInfo](docs/api/615b1cc02bc1.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.DeviceNotification](docs/api/0684ae916143.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.DeviceNotificationEvent](docs/api/a9140dfea4e4.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.VolumeInfo](docs/api/a81695674338.md) — 3 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Enums

- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Enums.DeviceBroadcastDeviceType](docs/api/b3d519389eaf.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Enums.DeviceChangeEvent](docs/api/86ebe0eadb21.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Enums.DeviceInterfaceClass](docs/api/ea9f4d0cd8c2.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Enums.DeviceNotifyFlags](docs/api/9e7b18daea1a.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs

- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface](docs/api/6fbf95ebbba8.md) — 22 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastHandle](docs/api/52fe3c70c3a0.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastHeader](docs/api/fd1e3c18287b.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastPort](docs/api/9e9148995421.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastVolume](docs/api/a66cfb2d1ba7.md) — 9 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Display

- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.DisplayTopology](docs/api/34ee41b785b2.md) — 4 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi

- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler](docs/api/e98397f687db.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue>](docs/api/bcdcb57a51b4.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.DpiApi](docs/api/b7e59d391117.md) — 18 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.DpiCalculator](docs/api/d2bbce2afcdc.md) — 30 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.DpiChangeInfo](docs/api/23f8279a92aa.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.DpiHandler](docs/api/a4810db616a4.md) — 31 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.NativeDpiMethods](docs/api/c2f2854905f7.md) — 40 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Enums

- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Enums.DialogDpiChangeBehaviors](docs/api/487fb48643a6.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Enums.DialogScalingBehaviors](docs/api/991089b2f409.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Enums.DpiAwareness](docs/api/ba4f46665a41.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Enums.DpiAwarenessContext](docs/api/2f44b7644b3a.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Enums.DpiHostingBehavior](docs/api/df4a2403dd33.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Enums.MonitorDpiType](docs/api/18b0266a655d.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Forms

- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Forms.DpiAwareFormBehavior](docs/api/8cda5b93fa5a.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Forms.DpiUnawareFormBehavior](docs/api/c429fc28b36f.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Forms.FormsDpiExtensions](docs/api/816d654b9902.md) — 4 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Wpf

- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Wpf.WindowDpiExtensions](docs/api/c6a407d507bc.md) — 2 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Input

- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperationExtensions](docs/api/9c1bc93f4010.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations](docs/api/a769aa9cb7ef.md) — 21 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.NativeInput](docs/api/1a6b9f812fcb.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.RawInputApi](docs/api/d435165faf94.md) — 20 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.RawInputDeviceChangeEventArgs](docs/api/c8c661a343ac.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.RawInputDeviceInformation](docs/api/3048e8faf071.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.RawInputDeviceMonitor](docs/api/84403513f568.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.RawInputEventArgs](docs/api/ed44fd1008b4.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.RawInputMonitor](docs/api/0ad80cf6193d.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums

- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.ExtendedKeyFlags](docs/api/538cafa70e90.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.ExtendedMouseFlags](docs/api/7a67129c5252.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.HidUsagePages](docs/api/0e9c19b60926.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.HidUsagesConsumer](docs/api/6f25d2c31a7e.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.HidUsagesGeneric](docs/api/e7b390f1607c.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.HookTypes](docs/api/ec5b5d7b1a07.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.InputTypes](docs/api/c3bf653443d7.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.KeyEventFlags](docs/api/4b14a1c10646.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons](docs/api/aaae8649a743.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtonStates](docs/api/61dc0c443949.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseEventFlags](docs/api/c69c299f51db.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseStates](docs/api/4b14d53d568a.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.RawInputDataCommands](docs/api/91e2b62b7d36.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.RawInputDeviceFlags](docs/api/87ce9fd0f9b5.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.RawInputDeviceInfoCommands](docs/api/f66f2b1e82d1.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.RawInputDevices](docs/api/add68c6d4696.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.RawInputDeviceTypes](docs/api/b43863226566.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.RawKeyboardFlags](docs/api/30c480e9b456.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode](docs/api/1810ba78d5d2.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard

- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.IKeyboardHookEventHandler](docs/api/cfb67567e8eb.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHandlerExtensions](docs/api/12c9af82ed8a.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHook](docs/api/1b111112e33d.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs](docs/api/0efe4adfeda9.md) — 30 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookExtensions](docs/api/4072fdea3a1a.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardInputGenerator](docs/api/570373e9d6a4.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyCombinationHandler](docs/api/ca178d42481e.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyHelper](docs/api/654af6dc4d60.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyOrCombinationHandler](docs/api/8e927ac0e440.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeySequenceHandler](docs/api/b50778b88629.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.VirtualKeyCodeExtensions](docs/api/c70fc86868aa.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Input.Mouse

- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Mouse.MouseHook](docs/api/9f1436d26742.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Mouse.MouseHookEventArgs](docs/api/c7f0cafa99f8.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Mouse.MouseInputGenerator](docs/api/4d743dc992ab.md) — 14 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs

- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.HardwareInput](docs/api/f71a16d2f03b.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.Input](docs/api/206b79b935ba.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.InputUnion](docs/api/c54ef6644a83.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput](docs/api/43c0aedabca9.md) — 17 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardLowLevelHookStruct](docs/api/9291f1ff4fef.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.LastInputInfo](docs/api/eb64fba03161.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput](docs/api/a61dacb8c6e0.md) — 23 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseLowLevelHookStruct](docs/api/c8d927bf6f19.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawDevice](docs/api/962d05637871.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawHID](docs/api/15c99f489457.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInput](docs/api/d2040535061d.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDevice](docs/api/22d159c9b813.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfo](docs/api/7faaf8cc4275.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoHID](docs/api/e777defc5756.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard](docs/api/ebbda0ae57e5.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoMouse](docs/api/2e97c6bfb50a.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList](docs/api/27bbbd1fab66.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputHeader](docs/api/297d14bb419d.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawKeyboard](docs/api/77f29679b1a9.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse](docs/api/bd7ee0c4dd5a.md) — 12 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle

- [CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager](docs/api/0cbab8d99ebf.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.EndSessionMessage](docs/api/5651fdab1d63.md) — 13 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums

- [CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.ApplicationRestartFlags](docs/api/d1609b9b5aef.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.EndSessionReasons](docs/api/091cab8b9a2a.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Media

- [CP.ReactiveUI.Primitives.Windows.Desktop.Media.WinMm](docs/api/b436329080b9.md) — 6 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Media.Enums

- [CP.ReactiveUI.Primitives.Windows.Desktop.Media.Enums.SoundSettings](docs/api/8ad1fe5519ba.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Media.Enums.SystemSounds](docs/api/a8dea39301f2.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Messaging

- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop](docs/api/fcb36746e826.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc](docs/api/dd5db9325eee.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.SessionChangeEventArgs](docs/api/af7d9d3b47ae.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.SharedMessageWindow](docs/api/51512b94fb1a.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WindowMessageInfo](docs/api/6ed54e685b85.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WindowsMessage](docs/api/ecd541e5914e.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WindowsSessionListener](docs/api/78d384b36ef2.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcFormsExtensions](docs/api/83e98fc7139a.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcHandler](docs/api/1debbd1583e7.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcHandlerHook](docs/api/eed464a6e4de.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcListener](docs/api/15a762a322b3.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcWindowsExtensions](docs/api/9fc2c4a91afb.md) — 2 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Power

- [CP.ReactiveUI.Primitives.Windows.Desktop.Power.PowerBroadcastListener](docs/api/bd1d55e2045e.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Power.PowerManagementApi](docs/api/7c65f00d0989.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Power.SystemStateApi](docs/api/17e82683d24a.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer](docs/api/e0cfdd7ec1aa.md) — 21 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Power.Enums

- [CP.ReactiveUI.Primitives.Windows.Desktop.Power.Enums.ExitWindowsFlags](docs/api/f8f598f8b22b.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Power.Enums.PowerBroadcastEvent](docs/api/5d0dc7c112aa.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Power.Enums.ThreadExecutionStateFlags](docs/api/72b817cde3fa.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Dialogs

- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Dialogs.FileDialog](docs/api/f050e584353e.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Dialogs.FileDialogOperationExtensions](docs/api/2352d6f92955.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Dialogs.FileDialogResult](docs/api/6ef7c64f3fbd.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Dialogs.FileOpenDialogBuilder](docs/api/af6e8e0fec6b.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Dialogs.FileSaveDialogBuilder](docs/api/345175dcc950.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Dialogs.FolderPickerBuilder](docs/api/c0d0069e1d9d.md) — 6 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons

- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.BitmapIconExtensions](docs/api/28efb5befbdb.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.CapturedCursor](docs/api/9f45c2e15358.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.CursorHelper](docs/api/8887ce04c5fd.md) — 14 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconExtensions](docs/api/6ce189e5a59b.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconFileWriter](docs/api/91836a046b02.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper](docs/api/fd73ddd1c6ae.md) — 26 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconStreamExtensions](docs/api/1b02c181b844.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.NativeIconMethods](docs/api/c75d146bb0be.md) — 16 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums

- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.CopyImageFlags](docs/api/2a6fbdf51df9.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.DrawIconExFlags](docs/api/e98c4ef4e249.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.FolderIconType](docs/api/1ca56c0e7a9b.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize](docs/api/1e98429e903f.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconSize](docs/api/2fcc1ab82ba1.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.ImageType](docs/api/6b81269f1f7e.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.LoadImageFlags](docs/api/62d277bb8386.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Structs

- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Structs.GrpIconDir](docs/api/ad4267fa5043.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Structs.GrpIconDirEntry](docs/api/496555cc0a99.md) — 18 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Structs.IconDir](docs/api/51da61d45e42.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Structs.IconDirEntry](docs/api/c8157e313cbd.md) — 18 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Structs.IconInfo](docs/api/0e0026d6c95d.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Structs.IconInfoEx](docs/api/8aaec6105676.md) — 16 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Software

- [CP.ReactiveUI.Primitives.Windows.Desktop.Software.InstallationInformation](docs/api/bb9577972ecc.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails](docs/api/facfb0f1f98b.md) — 29 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring

- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay](docs/api/33eaa4fe75ae.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessMonitoring](docs/api/0b24d3ae4924.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessPanel](docs/api/9cda2188931a.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessSample](docs/api/870518ea5d2d.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessSnapshot](docs/api/0d31345b16d2.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessTransport](docs/api/a87eb827f76e.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.CpuMonitoring](docs/api/f0452510d823.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.CpuSample](docs/api/ddb88f099754.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.CpuUtilization](docs/api/06f8abf6079b.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.GraphicsAdapter](docs/api/2bb419565cf7.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.GraphicsEngineSample](docs/api/1c6bcd7a5275.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.GraphicsMonitoring](docs/api/e62b5e2cfd51.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.GraphicsSnapshot](docs/api/c8e3fac10246.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareBaseboard](docs/api/78b88670efab.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareBios](docs/api/310aea3cc4f5.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareDisk](docs/api/41513a1bac81.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareMachine](docs/api/00bd952c0b9c.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareMemoryArray](docs/api/943d40ee83a3.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareMemoryModule](docs/api/499e8d958dbb.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareMonitoring](docs/api/2dcb615d8e86.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareOperatingSystem](docs/api/32487dccf3f2.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwarePhysicalDisk](docs/api/fc1ca8c15ce4.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwarePnpDevice](docs/api/041806aed722.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareProcessor](docs/api/7eec3c003d5c.md) — 16 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot](docs/api/aab40a1ff0f2.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.IThermalSensorProvider](docs/api/f2d854378cd5.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.LogicalProcessorSample](docs/api/d7889d1865f7.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MemoryMonitoring](docs/api/e8522a311ee5.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MemorySample](docs/api/a465f0a9eb04.md) — 17 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions](docs/api/dfee4f5bd422.md) — 19 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringResult<T>](docs/api/5a7d1aa32461.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringSections](docs/api/5e263ff56fed.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringStatus](docs/api/cd15af85a04e.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkConnectionsSnapshot](docs/api/1d459ae4116d.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot](docs/api/2d8dfbc2efd7.md) — 27 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkMonitoring](docs/api/207c8ed4b2df.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkProtocolStatistics](docs/api/35659947a38a.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkSnapshot](docs/api/2d5f4cd1d68d.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkTcpConnection](docs/api/884b5f4fb16c.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NvidiaSensorProvider](docs/api/1a28f5b0bd6f.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PerformanceCounterMonitoring](docs/api/75e282d37b75.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PerformanceCounterQuery](docs/api/4352382459a3.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PerformanceCounterSample](docs/api/18ff167cee0f.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerBatteryFlags](docs/api/469c7b617684.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerConnection](docs/api/74bc703be61f.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerMonitoring](docs/api/78809c107068.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan](docs/api/27a3b8116c02.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlans](docs/api/1e39b7893ba8.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerSample](docs/api/1e609403c5ff.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerSettings](docs/api/a17fa8273e5b.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessInfo](docs/api/40bf72f9a5ca.md) — 26 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessMonitoring](docs/api/40b12f0ea559.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessSnapshot](docs/api/8ac0ec4cbdaa.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget](docs/api/3a73701fef83.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceControlResult](docs/api/abc688eb4e68.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceInfo](docs/api/620d08370219.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceMonitoring](docs/api/add01a13d70e.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceSnapshot](docs/api/7f253375eedf.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceStartMode](docs/api/9a07194413c6.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget](docs/api/3faa56d05e72.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.StorageDiskSnapshot](docs/api/9442da77856c.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.StorageDriveSnapshot](docs/api/d4d988669aa4.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.StorageMonitoring](docs/api/7ffbae2abd90.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.StorageSnapshot](docs/api/d4a0f5f56949.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.SystemMonitorBuilder](docs/api/b397292f92a4.md) — 23 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.SystemSnapshot](docs/api/3ce4fe1b5552.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ThermalMonitoring](docs/api/8a5d20b3cc2f.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ThermalSensorSample](docs/api/ed04a7f7f50c.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ThermalSnapshot](docs/api/3e3df4efa1cc.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WindowsManagement](docs/api/5ea07c0192ce.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WindowsSystem](docs/api/b995515601c3.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiQueryResult](docs/api/fd7c53a6cc9a.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiQueryStatus](docs/api/6f65bd489142.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiRow](docs/api/57f1748508d9.md) — 2 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Windows

- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.BitmapExtensions](docs/api/47d062ac404d.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs](docs/api/b4efbfcd9fc0.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentMonitor](docs/api/d56bec0b0b37.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.FormsExtensions](docs/api/e2a81596fd7b.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow](docs/api/b154fd9efc97.md) — 25 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.InteropWindow](docs/api/7a076401f9aa.md) — 29 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.InteropWindowExtensions](docs/api/f9fd17d527c2.md) — 54 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.InteropWindowFactory](docs/api/0c6f767a69bf.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.InteropWindowObservationExtensions](docs/api/5fba84ae21f4.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.InteropWindowQueryExtensions](docs/api/4638b93c7b60.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.SafeNativeWindowHandle](docs/api/1f822191f93e.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.SafeWinEventHookHandle](docs/api/082c70f7c77d.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowScroller](docs/api/5279081a13ea.md) — 22 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsEnumerator](docs/api/9d317935b8aa.md) — 16 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions](docs/api/0dffca382eb4.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsMove](docs/api/1fc51f6c18b4.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsMoveBlockMode](docs/api/9c1dca44a146.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WinEventHook](docs/api/6252b0d5d6c1.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WinEventInfo](docs/api/1293277fd9dc.md) — 11 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Windows.Enums

- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.Enums.InteropWindowRetrieveSettings](docs/api/7fa708fa8f48.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.Enums.WinEventHookFlags](docs/api/ba24f3a0018c.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.Enums.WinEvents](docs/api/98905557e9ab.md) — 1 callable members.
<!-- END GENERATED API REFERENCE -->
