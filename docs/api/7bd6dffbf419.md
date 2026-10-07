<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature

Package: `CP.ReactiveUI.Primitives.Windows.Integrations`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature.#ctor(System.String,System.Version)](#api-7ab82092a51b)
- [M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature.#ctor(System.String,System.Version,System.Byte[])](#api-86a0f9524e7c)
- [M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature.CopyMetadata](#api-caf5fd1ffdb2)
- [P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature.MetadataLength](#api-b05f73a9289a)
- [P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature.Name](#api-57b3953fb0c7)
- [P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature.Version](#api-553bedb7be8f)

<a id="api-7ab82092a51b"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature.#ctor(System.String,System.Version)`

Initializes a new instance of the CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature class.

```csharp
public CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature.CitrixVirtualChannelFeature(string name, System.Version version)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Ipc/CitrixVirtualChannelFeature.cs:16`.

- `name` (`string`): The feature name.
- `version` (`System.Version`): The feature version.

```csharp
internal static class ApiExample
{
    internal static void Call(global::System.String @name, global::System.Version @version)
    {
        new global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature(@name, @version);
    }
}
```

<a id="api-86a0f9524e7c"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature.#ctor(System.String,System.Version,System.Byte[])`

Initializes a new instance of the CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature class.

```csharp
public CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature.CitrixVirtualChannelFeature(string name, System.Version version, byte[] metadata)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Ipc/CitrixVirtualChannelFeature.cs:25`.

- `name` (`string`): The feature name.
- `version` (`System.Version`): The feature version.
- `metadata` (`byte[]`): Optional feature metadata.

```csharp
internal static class ApiExample
{
    internal static void Call(global::System.String @name, global::System.Version @version, global::System.Byte[] @metadata)
    {
        new global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature(@name, @version, @metadata);
    }
}
```

<a id="api-caf5fd1ffdb2"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature.CopyMetadata`

Copies the immutable metadata snapshot.

```csharp
public byte[] CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature.CopyMetadata()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Ipc/CitrixVirtualChannelFeature.cs:45`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature receiver)
    {
        _ = receiver.@CopyMetadata();
    }
}
```

<a id="api-b05f73a9289a"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature.MetadataLength`

Gets the metadata byte count.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature.MetadataLength { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Ipc/CitrixVirtualChannelFeature.cs:41`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature receiver)
    {
        _ = receiver.@MetadataLength;
    }
}
```

<a id="api-57b3953fb0c7"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature.Name`

Gets the feature name.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature.Name { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Ipc/CitrixVirtualChannelFeature.cs:35`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature receiver)
    {
        _ = receiver.@Name;
    }
}
```

<a id="api-553bedb7be8f"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature.Version`

Gets the feature version.

```csharp
public System.Version CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature.Version { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Ipc/CitrixVirtualChannelFeature.cs:38`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature receiver)
    {
        _ = receiver.@Version;
    }
}
```
