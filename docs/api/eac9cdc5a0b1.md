<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation

Package: `CP.ReactiveUI.Primitives.Windows.Reactive`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.Create(System.IntPtr)](#api-23f34578f2e0)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.Create(System.IntPtr)](#api-de22d668041d)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.Create](#api-18e4b3594a8e)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.FormatIds](#api-0ce0ca714091)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.Formats](#api-13b69fc1f34a)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.HasOwner](#api-5e35901405b5)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.Id](#api-e30e82f9bc85)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.Timestamp](#api-4e8bfa24aa81)

<a id="api-23f34578f2e0"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.Create(System.IntPtr)`

Creates clipboard update information.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.Create(System.IntPtr windowHandle)
```

Availability: net462, net472, net48, net481. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Clipboard/ClipboardUpdateInformation.cs:60`.

- `windowHandle` (`System.IntPtr`): The window handle for the clipboard lock.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IntPtr @windowHandle, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.@Create(@windowHandle)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-de22d668041d"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.Create(System.IntPtr)`

Creates clipboard update information.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.Create(nint windowHandle)
```

Availability: net10.0-windows, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Clipboard/ClipboardUpdateInformation.cs:60`.

- `windowHandle` (`nint`): The window handle for the clipboard lock.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(nint @windowHandle, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.@Create(@windowHandle)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-18e4b3594a8e"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.Create`

Creates clipboard update information.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.Create()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Clipboard/ClipboardUpdateInformation.cs:55`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.@Create()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-0ce0ca714091"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.FormatIds`

Gets the formats in this clipboard content as identifiers.

```csharp
public System.Collections.Generic.IEnumerable<uint> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.FormatIds { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Clipboard/ClipboardUpdateInformation.cs:51`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation receiver)
    {
        _ = receiver.@FormatIds;
    }
}
```

<a id="api-13b69fc1f34a"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.Formats`

Gets the formats in this clipboard content as strings.

```csharp
public System.Collections.Generic.IEnumerable<string> CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.Formats { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Clipboard/ClipboardUpdateInformation.cs:35`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation receiver)
    {
        _ = receiver.@Formats;
    }
}
```

<a id="api-5e35901405b5"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.HasOwner`

Gets whether a window owns the clipboard content.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.HasOwner { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Clipboard/ClipboardUpdateInformation.cs:32`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation receiver)
    {
        _ = receiver.@HasOwner;
    }
}
```

<a id="api-e30e82f9bc85"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.Id`

Gets the clipboard sequence number, which starts at 0 when the Windows session starts.

```csharp
public uint CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.Id { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Clipboard/ClipboardUpdateInformation.cs:26`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation receiver)
    {
        _ = receiver.@Id;
    }
}
```

<a id="api-4e8bfa24aa81"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.Timestamp`

Gets the timestamp of the clipboard update event.

```csharp
public System.DateTimeOffset CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation.Timestamp { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Clipboard/ClipboardUpdateInformation.cs:29`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation receiver)
    {
        _ = receiver.@Timestamp;
    }
}
```
