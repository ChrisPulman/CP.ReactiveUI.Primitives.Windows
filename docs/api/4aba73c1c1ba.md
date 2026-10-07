<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress

Package: `CP.ReactiveUI.Primitives.Windows.Integrations`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.#ctor](#api-f933108548f1)
- [M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.Equals(CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress)](#api-fdddb27ac9ca)
- [M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.Equals(System.Object)](#api-bc7017e9d8df)
- [M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.GetHashCode](#api-d794f92e61ec)
- [M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.ToString](#api-86b2915ef6fc)
- [M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.op_Equality(CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress,CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress)](#api-8e6e3415b1f2)
- [M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.op_Inequality(CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress,CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress)](#api-56635fcb4b88)
- [P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.AddressFamily](#api-a45cd1b7248a)
- [P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.IpAddress](#api-b5aadb4d2da2)

<a id="api-f933108548f1"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.#ctor`

Creates the default ClientAddress value.

```csharp
public CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.ClientAddress()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Structs/ClientAddress.cs:9`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress();
    }
}
```

<a id="api-fdddb27ac9ca"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.Equals(CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress)`

Indicates whether the current object is equal to another object of the same type.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.Equals(CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress other)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Structs/ClientAddress.cs:130`.

- `other` (`CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress`): An object to compare with this object.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress receiver, global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress @other)
    {
        _ = receiver.@Equals(@other);
    }
}
```

<a id="api-bc7017e9d8df"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.Equals(System.Object)`

Indicates whether this instance and a specified object are equal.

```csharp
public override bool CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.Equals(object obj)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Structs/ClientAddress.cs:127`.

- `obj` (`object`): The object to compare with the current instance.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress receiver, global::System.Object @obj)
    {
        _ = receiver.@Equals(@obj);
    }
}
```

<a id="api-d794f92e61ec"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.GetHashCode`

Returns the hash code for this instance.

```csharp
public override int CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.GetHashCode()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Structs/ClientAddress.cs:134`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress receiver)
    {
        _ = receiver.@GetHashCode();
    }
}
```

<a id="api-86b2915ef6fc"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.ToString`

Returns the fully qualified type name of this instance.

```csharp
public override string CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.ToString()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Structs/ClientAddress.cs:147`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress receiver)
    {
        _ = receiver.@ToString();
    }
}
```

<a id="api-8e6e3415b1f2"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.op_Equality(CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress,CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress)`

Determines whether two values are equal.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.operator ==(CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress left, CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Structs/ClientAddress.cs:118`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress`): The first value.
- `right` (`CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress`): The second value.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress @left, global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress @right)
    {
        _ = @left == @right;
    }
}
```

<a id="api-56635fcb4b88"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.op_Inequality(CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress,CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress)`

Determines whether two values are not equal.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.operator !=(CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress left, CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Structs/ClientAddress.cs:124`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress`): The first value.
- `right` (`CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress`): The second value.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress @left, global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress @right)
    {
        _ = @left != @right;
    }
}
```

<a id="api-a45cd1b7248a"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.AddressFamily`

Gets the address family.

```csharp
public System.Net.Sockets.AddressFamily CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.AddressFamily { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Structs/ClientAddress.cs:109`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress receiver)
    {
        _ = receiver.@AddressFamily;
    }
}
```

<a id="api-b5aadb4d2da2"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.IpAddress`

Gets the IP address used.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress.IpAddress { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows.Integrations/Citrix/Structs/ClientAddress.cs:112`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress receiver)
    {
        _ = receiver.@IpAddress;
    }
}
```
