<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken.ThrowWhenNoAccess](#api-b6c3200e4a8b)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken.CanAccess](#api-60b977c4958e)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken.IsLockTimeout](#api-023654cf7719)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken.IsOpenTimeout](#api-1f31e416bb48)

<a id="api-b6c3200e4a8b"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken.ThrowWhenNoAccess`

Throws a CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardAccessDeniedException when the clipboard cannot be accessed.

```csharp
void CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken.ThrowWhenNoAccess()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Clipboard/IClipboardAccessToken.cs:28`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken receiver, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@ThrowWhenNoAccess()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-60b977c4958e"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken.CanAccess`

Gets a value indicating whether the clipboard can be accessed.

```csharp
bool CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken.CanAccess { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Clipboard/IClipboardAccessToken.cs:19`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken receiver)
    {
        _ = receiver.@CanAccess;
    }
}
```

<a id="api-023654cf7719"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken.IsLockTimeout`

Gets a value indicating whether clipboard access was denied due to a lock timeout.

```csharp
bool CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken.IsLockTimeout { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Clipboard/IClipboardAccessToken.cs:22`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken receiver)
    {
        _ = receiver.@IsLockTimeout;
    }
}
```

<a id="api-1f31e416bb48"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken.IsOpenTimeout`

Gets a value indicating whether the clipboard could not be opened before the timeout.

```csharp
bool CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken.IsOpenTimeout { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Clipboard/IClipboardAccessToken.cs:25`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken receiver)
    {
        _ = receiver.@IsOpenTimeout;
    }
}
```
