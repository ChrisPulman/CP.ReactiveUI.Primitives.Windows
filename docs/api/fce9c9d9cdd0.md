<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove

Package: `CP.ReactiveUI.Primitives.Windows.Reactive`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove.#ctor(System.Func{System.Boolean})](#api-b18cdf04b6af)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove.#ctor(System.Func{System.Boolean},CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMoveBlockMode)](#api-9d408c7242cd)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove.Subscribe(System.IObserver{System.Reactive.Unit})](#api-6511371067b1)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove.Subscribe(System.IObserver{System.Reactive.Unit},System.Windows.Forms.Form)](#api-837c6dd56b0e)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove.Subscribe(System.IObserver{System.Reactive.Unit},System.Windows.Interop.HwndSource)](#api-4041fd124ff7)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove.Subscribe(System.IObserver{System.Reactive.Unit},System.Windows.Media.Visual)](#api-5be04f6292d9)
- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove.Subscribe(System.IObserver{System.Reactive.Unit},System.Windows.Window)](#api-18f467c98dd2)

<a id="api-b18cdf04b6af"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove.#ctor(System.Func{System.Boolean})`

Initializes a new instance of the CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove class that protects movement and resizing.

```csharp
public CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove.WindowsMove(System.Func<bool> allowMoveCondition)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Windows/WindowsMove.cs:44`.

- `allowMoveCondition` (`System.Func<bool>`): A condition evaluated for every protected request. Returning true allows the operation; returning false blocks it.

```csharp
internal static class ApiExample
{
    internal static void Call(global::System.Func<global::System.Boolean> @allowMoveCondition)
    {
        new global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove(@allowMoveCondition);
    }
}
```

<a id="api-9d408c7242cd"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove.#ctor(System.Func{System.Boolean},CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMoveBlockMode)`

Initializes a new instance of the CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove class for the selected operations.

```csharp
public CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove.WindowsMove(System.Func<bool> allowMoveCondition, CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMoveBlockMode blockMode)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Windows/WindowsMove.cs:56`.

- `allowMoveCondition` (`System.Func<bool>`): A condition evaluated for every protected request. Returning true allows the operation; returning false blocks it.
- `blockMode` (`CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMoveBlockMode`): The interactive operations protected by the guard.

```csharp
internal static class ApiExample
{
    internal static void Call(global::System.Func<global::System.Boolean> @allowMoveCondition, global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMoveBlockMode @blockMode)
    {
        new global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove(@allowMoveCondition, @blockMode);
    }
}
```

<a id="api-6511371067b1"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove.Subscribe(System.IObserver{System.Reactive.Unit})`

Installs the movement guard on the current process main WPF window.

```csharp
public System.IDisposable CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove.Subscribe(System.IObserver<System.Reactive.Unit> observer)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Windows/WindowsMove.cs:71`.

- `observer` (`System.IObserver<System.Reactive.Unit>`): The observer that receives a setup error when the main WPF window cannot be resolved.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove receiver, global::System.IObserver<global::System.Reactive.Unit> @observer, global::System.IObserver<global::System.IDisposable> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Subscribe(@observer)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-837c6dd56b0e"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove.Subscribe(System.IObserver{System.Reactive.Unit},System.Windows.Forms.Form)`

Installs the movement guard on a Windows Forms form and follows native handle recreation.

```csharp
public System.IDisposable CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove.Subscribe(System.IObserver<System.Reactive.Unit> observer, System.Windows.Forms.Form form)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Windows/WindowsMove.cs:111`.

- `observer` (`System.IObserver<System.Reactive.Unit>`): The observer associated with the hook lifetime.
- `form` (`System.Windows.Forms.Form`): The Windows Forms form on which to install the hook.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove receiver, global::System.IObserver<global::System.Reactive.Unit> @observer, global::System.Windows.Forms.Form @form, global::System.IObserver<global::System.IDisposable> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Subscribe(@observer, @form)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-4041fd124ff7"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove.Subscribe(System.IObserver{System.Reactive.Unit},System.Windows.Interop.HwndSource)`

Installs the movement guard on an HWND source.

```csharp
public System.IDisposable CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove.Subscribe(System.IObserver<System.Reactive.Unit> observer, System.Windows.Interop.HwndSource hwndSource)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Windows/WindowsMove.cs:89`.

- `observer` (`System.IObserver<System.Reactive.Unit>`): The observer associated with the hook lifetime.
- `hwndSource` (`System.Windows.Interop.HwndSource`): The HWND source on which to install the hook.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove receiver, global::System.IObserver<global::System.Reactive.Unit> @observer, global::System.Windows.Interop.HwndSource @hwndSource, global::System.IObserver<global::System.IDisposable> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Subscribe(@observer, @hwndSource)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-5be04f6292d9"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove.Subscribe(System.IObserver{System.Reactive.Unit},System.Windows.Media.Visual)`

Installs the movement guard on the HWND source that presents a visual.

```csharp
public System.IDisposable CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove.Subscribe(System.IObserver<System.Reactive.Unit> observer, System.Windows.Media.Visual visual)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Windows/WindowsMove.cs:136`.

- `observer` (`System.IObserver<System.Reactive.Unit>`): The observer that receives a setup error when the visual has no WPF window source.
- `visual` (`System.Windows.Media.Visual`): The visual whose HWND source receives the hook.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove receiver, global::System.IObserver<global::System.Reactive.Unit> @observer, global::System.Windows.Media.Visual @visual, global::System.IObserver<global::System.IDisposable> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Subscribe(@observer, @visual)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-18f467c98dd2"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove.Subscribe(System.IObserver{System.Reactive.Unit},System.Windows.Window)`

Installs the movement guard on a WPF window when its HWND source becomes available.

```csharp
public System.IDisposable CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove.Subscribe(System.IObserver<System.Reactive.Unit> observer, System.Windows.Window window)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Windows/WindowsMove.cs:100`.

- `observer` (`System.IObserver<System.Reactive.Unit>`): The observer that receives a setup error when the window source cannot be resolved.
- `window` (`System.Windows.Window`): The WPF window on which to install the hook.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove receiver, global::System.IObserver<global::System.Reactive.Unit> @observer, global::System.Windows.Window @window, global::System.IObserver<global::System.IDisposable> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Subscribe(@observer, @window)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```
