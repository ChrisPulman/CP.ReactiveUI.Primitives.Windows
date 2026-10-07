<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.ApplyPlacement(System.Windows.Window,CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.WindowPlacement)](#api-b70dd05a1ebb)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.AsInteropWindow(System.Windows.Window)](#api-d294259f0aef)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.BlockMove(System.Windows.Window)](#api-9f2fef736594)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.BlockMove(System.Windows.Window,System.Func{System.Boolean})](#api-e7c4b6aacf44)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.BlockMoveAndResize(System.Windows.Window)](#api-51642864a97d)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.BlockMoveAndResize(System.Windows.Window,System.Func{System.Boolean})](#api-c60b49cd37a1)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.RetrievePlacement(System.Windows.Window)](#api-858b3f9d17b5)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.Handle(System.Windows.Window)](#api-f28c247328c8)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.Handle(System.Windows.Window)](#api-c7394889801f)

<a id="api-b70dd05a1ebb"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.ApplyPlacement(System.Windows.Window,CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.WindowPlacement)`

Place the window.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Windows.InteropWindow CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.ApplyPlacement(System.Windows.Window window, CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.WindowPlacement windowPlacement)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Extensions/WindowsExtensions.cs:56`.

- `window` (`System.Windows.Window`): The window to adapt.
- `windowPlacement` (`CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.WindowPlacement`): WindowPlacement.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Windows;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.Windows.Window @window, global::CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.WindowPlacement @windowPlacement, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Windows.InteropWindow> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => @window.@ApplyPlacement(@windowPlacement)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-d294259f0aef"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.AsInteropWindow(System.Windows.Window)`

Factory method to create a InteropWindow for the supplied Window.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Windows.InteropWindow CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.AsInteropWindow(System.Windows.Window window)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Extensions/WindowsExtensions.cs:51`.

- `window` (`System.Windows.Window`): The window to adapt.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Windows;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.Windows.Window @window, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Windows.InteropWindow> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => @window.@AsInteropWindow()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-9f2fef736594"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.BlockMove(System.Windows.Window)`

Blocks interactive movement of the window.

```csharp
public static System.IObservable<ReactiveUI.Primitives.RxVoid> CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.BlockMove(System.Windows.Window window)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Extensions/WindowsExtensions.cs:25`.

- `window` (`System.Windows.Window`): The window to adapt.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Windows;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.Windows.Window @window, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return ((global::System.IObservable<global::ReactiveUI.Primitives.RxVoid>)(@window.@BlockMove())).Subscribe(operationObserver);
    }
}
```

<a id="api-e7c4b6aacf44"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.BlockMove(System.Windows.Window,System.Func{System.Boolean})`

Blocks interactive movement of the window while a dynamic condition evaluates to false.

```csharp
public static System.IObservable<ReactiveUI.Primitives.RxVoid> CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.BlockMove(System.Windows.Window window, System.Func<bool> allowMoveCondition)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Extensions/WindowsExtensions.cs:33`.

- `window` (`System.Windows.Window`): The window to adapt.
- `allowMoveCondition` (`System.Func<bool>`): A condition evaluated for every move request. Returning true allows movement; returning false blocks it.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Windows;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.Windows.Window @window, global::System.Func<global::System.Boolean> @allowMoveCondition, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return ((global::System.IObservable<global::ReactiveUI.Primitives.RxVoid>)(@window.@BlockMove(@allowMoveCondition))).Subscribe(operationObserver);
    }
}
```

<a id="api-51642864a97d"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.BlockMoveAndResize(System.Windows.Window)`

Blocks interactive movement and resizing of the window.

```csharp
public static System.IObservable<ReactiveUI.Primitives.RxVoid> CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.BlockMoveAndResize(System.Windows.Window window)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Extensions/WindowsExtensions.cs:38`.

- `window` (`System.Windows.Window`): The window to adapt.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Windows;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.Windows.Window @window, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return ((global::System.IObservable<global::ReactiveUI.Primitives.RxVoid>)(@window.@BlockMoveAndResize())).Subscribe(operationObserver);
    }
}
```

<a id="api-c60b49cd37a1"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.BlockMoveAndResize(System.Windows.Window,System.Func{System.Boolean})`

Blocks interactive movement and resizing while a dynamic condition evaluates to false.

```csharp
public static System.IObservable<ReactiveUI.Primitives.RxVoid> CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.BlockMoveAndResize(System.Windows.Window window, System.Func<bool> allowMoveCondition)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Extensions/WindowsExtensions.cs:46`.

- `window` (`System.Windows.Window`): The window to adapt.
- `allowMoveCondition` (`System.Func<bool>`): A condition evaluated for every move or resize request. Returning true allows the operation; returning false blocks it.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Windows;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.Windows.Window @window, global::System.Func<global::System.Boolean> @allowMoveCondition, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return ((global::System.IObservable<global::ReactiveUI.Primitives.RxVoid>)(@window.@BlockMoveAndResize(@allowMoveCondition))).Subscribe(operationObserver);
    }
}
```

<a id="api-858b3f9d17b5"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.RetrievePlacement(System.Windows.Window)`

Returns the WindowPlacement.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.WindowPlacement CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.RetrievePlacement(System.Windows.Window window)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Extensions/WindowsExtensions.cs:65`.

- `window` (`System.Windows.Window`): The window to adapt.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Windows;
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.Windows.Window @window, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.WindowPlacement> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => @window.@RetrievePlacement()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-f28c247328c8"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.Handle(System.Windows.Window)`

Gets the native handle of a Window.

```csharp
extension(global::System.Windows.Window @window) { public global::System.IntPtr @Handle { get; } }
```

Availability: net462, net472, net48, net481. Source: `src/CP.ReactiveUI.Primitives.Windows/Extensions/WindowsExtensions.cs:21`.

- `window` (`System.Windows.Window`): The window to adapt.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Windows;
internal static class ApiExample
{
    internal static void Call(global::System.Windows.Window @window)
    {
        _ = @window.@Handle;
    }
}
```

<a id="api-c7394889801f"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions.Handle(System.Windows.Window)`

Gets the native handle of a Window.

```csharp
extension(global::System.Windows.Window @window) { public nint @Handle { get; } }
```

Availability: net10.0-windows, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Extensions/WindowsExtensions.cs:21`.

- `window` (`System.Windows.Window`): The window to adapt.

```csharp
using CP.ReactiveUI.Primitives.Windows.Desktop.Windows;
internal static class ApiExample
{
    internal static void Call(global::System.Windows.Window @window)
    {
        _ = @window.@Handle;
    }
}
```
