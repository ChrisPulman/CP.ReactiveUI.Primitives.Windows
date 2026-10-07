<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs.#ctor](#api-883738168b6c)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs.Create(CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SystemParametersInfoActions)](#api-32297da35895)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs.Create(CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SystemParametersInfoActions,System.String)](#api-f70f64c7c3d2)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs.Create](#api-357f3d8673ae)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs.Area](#api-3bb2421b33d4)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs.SystemParametersInfoAction](#api-ce3d7d7b42a9)

<a id="api-883738168b6c"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs.#ctor`

Creates the default EnvironmentChangedEventArgs value.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs.EnvironmentChangedEventArgs()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Windows/EnvironmentChangedEventArgs.cs:11`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs();
    }
}
```

<a id="api-32297da35895"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs.Create(CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SystemParametersInfoActions)`

Factory for the EnvironmentChangedEventArgs.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs.Create(CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SystemParametersInfoActions systemParametersInfoAction)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Windows/EnvironmentChangedEventArgs.cs:49`.

- `systemParametersInfoAction` (`CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SystemParametersInfoActions`): SystemParametersInfo action that triggered the change.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SystemParametersInfoActions @systemParametersInfoAction, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs.@Create(@systemParametersInfoAction)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-f70f64c7c3d2"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs.Create(CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SystemParametersInfoActions,System.String)`

Factory for the EnvironmentChangedEventArgs.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs.Create(CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SystemParametersInfoActions systemParametersInfoAction, string area)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Windows/EnvironmentChangedEventArgs.cs:55`.

- `systemParametersInfoAction` (`CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SystemParametersInfoActions`): SystemParametersInfo action that triggered the change.
- `area` (`string`): Area containing the changed system parameter.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SystemParametersInfoActions @systemParametersInfoAction, global::System.String @area, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs.@Create(@systemParametersInfoAction, @area)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-357f3d8673ae"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs.Create`

Factory for the EnvironmentChangedEventArgs.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs.Create()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Windows/EnvironmentChangedEventArgs.cs:44`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs.@Create()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-3bb2421b33d4"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs.Area`

Gets the area containing the system parameter that changed. When the system sends this message as a result of a SystemParametersInfo call, longParameter is a pointer to a string that indicates the area containing the system parameter that was changed. This parameter does not usually indicate which specific system parameter changed. (Note that some applications send this message with longParameter set to NULL.) In general, when you receive this message, you should check and reload any system parameter settings that are used by your application. This string can be the name of a registry key or the name of a section in the Win.ini file. When the string is a registry name, it typically indicates only the leaf node in the registry, not the full path. When the system sends this message as a result of a change in policy settings, this parameter points to the string "Policy". When the system sends this message as a result of a change in locale settings, this parameter points to the string "intl". To effect a change in the environment variables for the system or the user, broadcast this message with longParameter set to the string "Environment".

```csharp
public string CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs.Area { get; private set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Windows/EnvironmentChangedEventArgs.cs:29`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs receiver)
    {
        _ = receiver.@Area;
    }
}
```

<a id="api-ce3d7d7b42a9"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs.SystemParametersInfoAction`

Gets the SystemParametersInfo action that triggered the change. When the system sends this message as a result of a SystemParametersInfo call, the wordParameter parameter is the value of the action parameter passed to the SystemParametersInfo function. For a list of values, see SystemParametersInfo. When the system sends this message as a result of a change in policy settings, this parameter indicates the type of policy that was applied. This value is 1 if computer policy was applied or zero if user policy was applied. When the system sends this message as a result of a change in locale settings, this parameter is zero. When an application sends this message, this parameter must be NULL.

```csharp
public CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SystemParametersInfoActions CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs.SystemParametersInfoAction { get; private set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Windows/EnvironmentChangedEventArgs.cs:40`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs receiver)
    {
        _ = receiver.@SystemParametersInfoAction;
    }
}
```
