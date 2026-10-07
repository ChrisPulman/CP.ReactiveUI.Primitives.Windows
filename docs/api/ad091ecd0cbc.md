<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.DpiChangeInfo

Package: `CP.ReactiveUI.Primitives.Windows.Reactive`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.DpiChangeInfo.#ctor(System.Int32,System.Int32)](#api-4f365944547a)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.DpiChangeInfo.NewDpi](#api-127e67872343)
- [P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.DpiChangeInfo.PreviousDpi](#api-e3e107b8775c)

<a id="api-4f365944547a"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.DpiChangeInfo.#ctor(System.Int32,System.Int32)`

Initializes a new instance of the CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.DpiChangeInfo class.

```csharp
public CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.DpiChangeInfo.DpiChangeInfo(int previousDpi, int newDpi)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Display/Dpi/DpiChangeInfo.cs:16`.

- `previousDpi` (`int`): The DPI before the change.
- `newDpi` (`int`): The DPI after the change.

```csharp
internal static class ApiExample
{
    internal static void Call(global::System.Int32 @previousDpi, global::System.Int32 @newDpi)
    {
        new global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.DpiChangeInfo(@previousDpi, @newDpi);
    }
}
```

<a id="api-127e67872343"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.DpiChangeInfo.NewDpi`

Gets the new DPI.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.DpiChangeInfo.NewDpi { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Display/Dpi/DpiChangeInfo.cs:26`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.DpiChangeInfo receiver)
    {
        _ = receiver.@NewDpi;
    }
}
```

<a id="api-e3e107b8775c"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.DpiChangeInfo.PreviousDpi`

Gets the DPI from before the change.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.DpiChangeInfo.PreviousDpi { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Display/Dpi/DpiChangeInfo.cs:23`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.DpiChangeInfo receiver)
    {
        _ = receiver.@PreviousDpi;
    }
}
```
