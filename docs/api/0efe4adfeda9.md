<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.#ctor](#api-61f7977f556c)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.GetEventTime(System.TimeProvider)](#api-b3440ddf4271)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.KeyDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode)](#api-c44b7181ec6c)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.KeyUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode)](#api-e1f3bc24f6c4)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.ToString](#api-cd458a1e071e)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.EventTime](#api-cd12d5d26b1a)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.Flags](#api-2891f91e9531)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.Handled](#api-df497554a29a)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsAlt](#api-13e842b85baf)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsCapsLockActive](#api-d49380113156)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsControl](#api-27fb7ec9e177)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsInjectedByLowerIntegrityLevelProcess](#api-f3d67d067460)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsInjectedByProcess](#api-c6842bd6a25c)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsKeyDown](#api-2e1ef0794efd)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsLeftAlt](#api-65623de1dd55)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsLeftControl](#api-44be144cbbe3)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsLeftShift](#api-cc4aa5b9886a)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsLeftWindows](#api-fc538102264c)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsModifier](#api-617dfd491caf)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsNumLockActive](#api-dc9956a93c21)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsRightAlt](#api-e4d9c7c40e3d)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsRightControl](#api-a08d2814cd65)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsRightShift](#api-5058cc310c96)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsRightWindows](#api-7f37b4508867)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsScrollLockActive](#api-19484a6cc72a)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsShift](#api-c2211153f570)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsSystemKey](#api-aa4330e1e4b9)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsWindows](#api-f4801276e620)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.Key](#api-e3e4900e85b7)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.TimeStamp](#api-af8a273d8be2)

<a id="api-61f7977f556c"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.#ctor`

Creates the default KeyboardHookEventArgs value.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.KeyboardHookEventArgs()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:11`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs();
    }
}
```

<a id="api-b3440ddf4271"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.GetEventTime(System.TimeProvider)`

Gets the event time using the supplied time provider.

```csharp
public System.DateTimeOffset CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.GetEventTime(System.TimeProvider timeProvider)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:101`.

- `timeProvider` (`System.TimeProvider`): The time provider.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver, global::System.TimeProvider @timeProvider, global::System.IObserver<global::System.DateTimeOffset> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@GetEventTime(@timeProvider)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-c44b7181ec6c"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.KeyDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode)`

Generate KeyboardHookEventArgs for a key down.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.KeyDown(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode virtualKeyCode)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:91`.

- `virtualKeyCode` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode`): VirtualKeyCode.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode @virtualKeyCode, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.@KeyDown(@virtualKeyCode)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-e1f3bc24f6c4"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.KeyUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode)`

Generate KeyboardHookEventArgs for a key up.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.KeyUp(CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode virtualKeyCode)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:96`.

- `virtualKeyCode` (`CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode`): VirtualKeyCode.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode @virtualKeyCode, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.@KeyUp(@virtualKeyCode)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-cd458a1e071e"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.ToString`

Returns a string that represents the current object.

```csharp
public override string CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.ToString()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:109`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver, global::System.IObserver<global::System.String> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@ToString()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-cd12d5d26b1a"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.EventTime`

Gets the DateTimeOffset for this event.

```csharp
public System.DateTimeOffset CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.EventTime { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:77`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@EventTime;
    }
}
```

<a id="api-2891f91e9531"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.Flags`

Gets details about the keyboard event.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.ExtendedKeyFlags CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.Flags { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:80`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@Flags;
    }
}
```

<a id="api-df497554a29a"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.Handled`

Gets or sets set this to true if the event is handled, other event-handlers in the chain will not be called.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.Handled { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:14`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver, global::System.Boolean configurableValue)
    {
        receiver.@Handled = configurableValue;
        _ = receiver.@Handled;
    }
}
```

<a id="api-13e842b85baf"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsAlt`

Gets true if Alt key is pressed.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsAlt { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:20`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@IsAlt;
    }
}
```

<a id="api-d49380113156"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsCapsLockActive`

Gets a value indicating whether caps lock is active.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsCapsLockActive { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:23`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@IsCapsLockActive;
    }
}
```

<a id="api-27fb7ec9e177"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsControl`

Gets true if control is pressed.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsControl { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:26`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@IsControl;
    }
}
```

<a id="api-f3d67d067460"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsInjectedByLowerIntegrityLevelProcess`

Gets a value indicating whether a lower-integrity process injected this event.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsInjectedByLowerIntegrityLevelProcess { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:86`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@IsInjectedByLowerIntegrityLevelProcess;
    }
}
```

<a id="api-c6842bd6a25c"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsInjectedByProcess`

Gets a value indicating whether another process injected this event.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsInjectedByProcess { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:83`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@IsInjectedByProcess;
    }
}
```

<a id="api-2e1ef0794efd"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsKeyDown`

Gets a value indicating whether this is a key-down event.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsKeyDown { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:29`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@IsKeyDown;
    }
}
```

<a id="api-65623de1dd55"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsLeftAlt`

Gets a value indicating whether the left alt key is pressed.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsLeftAlt { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:32`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@IsLeftAlt;
    }
}
```

<a id="api-44be144cbbe3"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsLeftControl`

Gets a value indicating whether the left control key is pressed.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsLeftControl { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:35`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@IsLeftControl;
    }
}
```

<a id="api-cc4aa5b9886a"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsLeftShift`

Gets a value indicating whether the left shift key is pressed.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsLeftShift { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:38`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@IsLeftShift;
    }
}
```

<a id="api-fc538102264c"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsLeftWindows`

Gets a value indicating whether the left Windows key is pressed.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsLeftWindows { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:41`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@IsLeftWindows;
    }
}
```

<a id="api-617dfd491caf"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsModifier`

Gets a value indicating whether this event is for a modifier key.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsModifier { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:17`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@IsModifier;
    }
}
```

<a id="api-dc9956a93c21"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsNumLockActive`

Gets a value indicating whether num lock is active.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsNumLockActive { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:44`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@IsNumLockActive;
    }
}
```

<a id="api-e4d9c7c40e3d"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsRightAlt`

Gets a value indicating whether the right alt key is pressed.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsRightAlt { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:47`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@IsRightAlt;
    }
}
```

<a id="api-a08d2814cd65"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsRightControl`

Gets a value indicating whether the right control key is pressed.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsRightControl { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:50`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@IsRightControl;
    }
}
```

<a id="api-5058cc310c96"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsRightShift`

Gets a value indicating whether the right shift key is pressed.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsRightShift { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:53`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@IsRightShift;
    }
}
```

<a id="api-7f37b4508867"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsRightWindows`

Gets a value indicating whether the right Windows key is pressed.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsRightWindows { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:56`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@IsRightWindows;
    }
}
```

<a id="api-19484a6cc72a"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsScrollLockActive`

Gets a value indicating whether scroll lock is active.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsScrollLockActive { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:59`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@IsScrollLockActive;
    }
}
```

<a id="api-c2211153f570"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsShift`

Gets true if shift is pressed.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsShift { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:62`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@IsShift;
    }
}
```

<a id="api-aa4330e1e4b9"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsSystemKey`

Gets a value indicating whether this is a system key.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsSystemKey { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:65`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@IsSystemKey;
    }
}
```

<a id="api-f4801276e620"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsWindows`

Gets true if shift is pressed.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.IsWindows { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:68`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@IsWindows;
    }
}
```

<a id="api-e3e4900e85b7"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.Key`

Gets the key code itself.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.Key { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:71`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@Key;
    }
}
```

<a id="api-af8a273d8be2"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.TimeStamp`

Gets the timestamp of the event.

```csharp
public uint CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs.TimeStamp { get; internal set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Input/Keyboard/KeyboardHookEventArgs.cs:74`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs receiver)
    {
        _ = receiver.@TimeStamp;
    }
}
```
