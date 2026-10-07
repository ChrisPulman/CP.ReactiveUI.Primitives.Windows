<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeGraphicsDcHandle

Package: `CP.ReactiveUI.Primitives.Windows.Core`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeGraphicsDcHandle.#ctor](#api-a457d964d4ed)
- [M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeGraphicsDcHandle.FromGraphics(System.Drawing.Graphics)](#api-e95165704374)
- [M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeGraphicsDcHandle.FromGraphics(System.Drawing.Graphics,System.Boolean)](#api-823bf9630ad1)
- [M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeGraphicsDcHandle.SelectObject(System.Runtime.InteropServices.SafeHandle)](#api-4f3d05e6f74e)

<a id="api-a457d964d4ed"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeGraphicsDcHandle.#ctor`

Initializes a new instance of the CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeGraphicsDcHandle class.

```csharp
public CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeGraphicsDcHandle.SafeGraphicsDcHandle()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Gdi/SafeHandles/SafeGraphicsDcHandle.cs:22`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeGraphicsDcHandle();
    }
}
```

<a id="api-e95165704374"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeGraphicsDcHandle.FromGraphics(System.Drawing.Graphics)`

Creates a safe device-context handle that does not dispose the graphics instance.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeGraphicsDcHandle CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeGraphicsDcHandle.FromGraphics(System.Drawing.Graphics graphics)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Gdi/SafeHandles/SafeGraphicsDcHandle.cs:61`.

- `graphics` (`System.Drawing.Graphics`): The graphics instance from which to obtain the device context.

```csharp
internal static class ApiExample
{
    internal static void Call(global::System.Drawing.Graphics @graphics)
    {
        _ = global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeGraphicsDcHandle.@FromGraphics(@graphics);
    }
}
```

<a id="api-823bf9630ad1"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeGraphicsDcHandle.FromGraphics(System.Drawing.Graphics,System.Boolean)`

Creates a safe device-context handle for a graphics instance.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeGraphicsDcHandle CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeGraphicsDcHandle.FromGraphics(System.Drawing.Graphics graphics, bool disposeGraphics)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Gdi/SafeHandles/SafeGraphicsDcHandle.cs:68`.

- `graphics` (`System.Drawing.Graphics`): The graphics instance from which to obtain the device context.
- `disposeGraphics` (`bool`): Indicates whether to dispose when this handle is released.

```csharp
internal static class ApiExample
{
    internal static void Call(global::System.Drawing.Graphics @graphics, global::System.Boolean @disposeGraphics)
    {
        _ = global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeGraphicsDcHandle.@FromGraphics(@graphics, @disposeGraphics);
    }
}
```

<a id="api-4f3d05e6f74e"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeGraphicsDcHandle.SelectObject(System.Runtime.InteropServices.SafeHandle)`

Selects an object into this device context.

```csharp
public CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeSelectObjectHandle CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeGraphicsDcHandle.SelectObject(System.Runtime.InteropServices.SafeHandle newHandle)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Core/Native/Gdi/SafeHandles/SafeGraphicsDcHandle.cs:77`.

- `newHandle` (`System.Runtime.InteropServices.SafeHandle`): The object to select.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeGraphicsDcHandle receiver, global::System.Runtime.InteropServices.SafeHandle @newHandle)
    {
        _ = receiver.@SelectObject(@newHandle);
    }
}
```
