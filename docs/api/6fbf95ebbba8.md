<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.#ctor](#api-f6e0fa7728ad)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.Create](#api-483d1b37133d)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.Equals(CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface)](#api-3307459946f1)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.Equals(System.Object)](#api-a4ef24e448c6)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.GetHashCode](#api-c275f97e0d1d)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.Test(System.String)](#api-4a6e0329b59d)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.Test(System.String,CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Enums.DeviceInterfaceClass)](#api-7ce9143da560)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.op_Equality(CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface,CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface)](#api-f9c52919cb72)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.op_Inequality(CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface,CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface)](#api-ccc3b8541eda)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.DeviceClass](#api-e38c6fde0c50)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.DeviceClassGuid](#api-dd3f00b112dd)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.DeviceId](#api-7379b5c0b50f)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.DeviceSetupClassGuid](#api-7ade5aa54304)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.DeviceType](#api-7dc0764dc412)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.DisplayName](#api-842441d96b29)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.FriendlyDeviceName](#api-560a078d9f53)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.IsPci](#api-12151fd98710)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.IsUsb](#api-a806f243e060)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.Name](#api-46fce797cf88)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.ProductId](#api-6dbfbd434cb3)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.UsbDeviceInfoUri](#api-91f7a380fc7e)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.VendorId](#api-dedbacf747b7)

<a id="api-f6e0fa7728ad"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.#ctor`

Creates the default DevBroadcastDeviceInterface value.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.DevBroadcastDeviceInterface()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Devices/Structs/DevBroadcastDeviceInterface.cs:20`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface();
    }
}
```

<a id="api-483d1b37133d"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.Create`

Factory for an empty, but initialized, DevBroadcastDeviceInterface.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.Create()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Devices/Structs/DevBroadcastDeviceInterface.cs:184`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.@Create()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-3307459946f1"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.Equals(CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface)`

Indicates whether the current object is equal to another object of the same type.

```csharp
public readonly bool CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.Equals(CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface other)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Devices/Structs/DevBroadcastDeviceInterface.cs:233`.

- `other` (`CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface`): An object to compare with this object.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface receiver, global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface @other, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Equals(@other)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-a4ef24e448c6"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.Equals(System.Object)`

Indicates whether this instance and a specified object are equal.

```csharp
public override readonly bool CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.Equals(object obj)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Devices/Structs/DevBroadcastDeviceInterface.cs:230`.

- `obj` (`object`): The object to compare with the current instance.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface receiver, global::System.Object @obj, global::System.IObserver<global::System.Boolean> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Equals(@obj)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-c275f97e0d1d"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.GetHashCode`

Returns the hash code for this instance.

```csharp
public override readonly int CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.GetHashCode()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Devices/Structs/DevBroadcastDeviceInterface.cs:240`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface receiver, global::System.IObserver<global::System.Int32> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@GetHashCode()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-4a6e0329b59d"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.Test(System.String)`

Used for testing.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.Test(string deviceName)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Devices/Structs/DevBroadcastDeviceInterface.cs:193`.

- `deviceName` (`string`): string

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.String @deviceName, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.@Test(@deviceName)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-7ce9143da560"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.Test(System.String,CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Enums.DeviceInterfaceClass)`

Used for testing.

```csharp
public static CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.Test(string deviceName, CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Enums.DeviceInterfaceClass deviceClass)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Devices/Structs/DevBroadcastDeviceInterface.cs:199`.

- `deviceName` (`string`): string
- `deviceClass` (`CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Enums.DeviceInterfaceClass`): DeviceInterfaceClass

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.String @deviceName, global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Enums.DeviceInterfaceClass @deviceClass, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.@Test(@deviceName, @deviceClass)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-f9c52919cb72"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.op_Equality(CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface,CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface)`

Determines whether two values are equal.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.operator ==(CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface left, CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Devices/Structs/DevBroadcastDeviceInterface.cs:215`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface`): The first value.
- `right` (`CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface`): The second value.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface @left, global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface @right)
    {
        _ = @left == @right;
    }
}
```

<a id="api-ccc3b8541eda"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.op_Inequality(CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface,CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface)`

Determines whether two values are not equal.

```csharp
public static bool CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.operator !=(CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface left, CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface right)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Devices/Structs/DevBroadcastDeviceInterface.cs:224`.

- `left` (`CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface`): The first value.
- `right` (`CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface`): The second value.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface @left, global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface @right)
    {
        _ = @left != @right;
    }
}
```

<a id="api-e38c6fde0c50"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.DeviceClass`

Gets or sets use an enum for handling the device class, instead of guid.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Enums.DeviceInterfaceClass CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.DeviceClass { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Devices/Structs/DevBroadcastDeviceInterface.cs:169`.

```csharp
internal static class ApiExample
{
    internal static void Call(ref global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface receiver, global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Enums.DeviceInterfaceClass configurableValue)
    {
        receiver.@DeviceClass = configurableValue;
        _ = receiver.@DeviceClass;
    }
}
```

<a id="api-dd3f00b112dd"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.DeviceClassGuid`

Gets or sets the GUID for the interface device class. The GUID for the interface device class. This is the Device Interface Class GUID that comes from the device notification message. For the Device Setup Class GUID shown in Device Manager, use P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.DeviceSetupClassGuid instead.

```csharp
public System.Guid CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.DeviceClassGuid { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Devices/Structs/DevBroadcastDeviceInterface.cs:74`.

```csharp
internal static class ApiExample
{
    internal static void Call(ref global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface receiver, global::System.Guid configurableValue)
    {
        receiver.@DeviceClassGuid = configurableValue;
        _ = receiver.@DeviceClassGuid;
    }
}
```

<a id="api-7379b5c0b50f"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.DeviceId`

Gets returns the Device ID of the device.

```csharp
public readonly string CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.DeviceId { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Devices/Structs/DevBroadcastDeviceInterface.cs:136`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface receiver)
    {
        _ = receiver.@DeviceId;
    }
}
```

<a id="api-7ade5aa54304"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.DeviceSetupClassGuid`

Gets returns the Device Setup Class GUID from the Windows registry. This is the Class GUID shown in Device Manager (e.g., {4d36e968-e325-11ce-bfc1-08002be10318} for Display adapters). This differs from P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.DeviceClassGuid, which is the notification Device Interface Class GUID. Returns null if the registry key cannot be accessed or the ClassGUID value is not found.

```csharp
public readonly System.Guid? CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.DeviceSetupClassGuid { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Devices/Structs/DevBroadcastDeviceInterface.cs:113`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface receiver)
    {
        _ = receiver.@DeviceSetupClassGuid;
    }
}
```

<a id="api-7dc0764dc412"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.DeviceType`

Gets returns the device type, e.g. USB or HID.

```csharp
public readonly string CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.DeviceType { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Devices/Structs/DevBroadcastDeviceInterface.cs:120`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface receiver)
    {
        _ = receiver.@DeviceType;
    }
}
```

<a id="api-842441d96b29"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.DisplayName`

Gets the display name of the device.

```csharp
public readonly string CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.DisplayName { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Devices/Structs/DevBroadcastDeviceInterface.cs:84`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface receiver)
    {
        _ = receiver.@DisplayName;
    }
}
```

<a id="api-560a078d9f53"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.FriendlyDeviceName`

Gets returns a more friendly name for the device.

```csharp
public readonly string CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.FriendlyDeviceName { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Devices/Structs/DevBroadcastDeviceInterface.cs:105`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface receiver)
    {
        _ = receiver.@FriendlyDeviceName;
    }
}
```

<a id="api-12151fd98710"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.IsPci`

Gets is this a PCI device?

```csharp
public readonly bool CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.IsPci { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Devices/Structs/DevBroadcastDeviceInterface.cs:133`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface receiver)
    {
        _ = receiver.@IsPci;
    }
}
```

<a id="api-a806f243e060"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.IsUsb`

Gets is this a USB device?

```csharp
public readonly bool CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.IsUsb { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Devices/Structs/DevBroadcastDeviceInterface.cs:130`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface receiver)
    {
        _ = receiver.@IsUsb;
    }
}
```

<a id="api-46fce797cf88"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.Name`

Gets the name of the device.

```csharp
public readonly string CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.Name { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Devices/Structs/DevBroadcastDeviceInterface.cs:81`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface receiver)
    {
        _ = receiver.@Name;
    }
}
```

<a id="api-6dbfbd434cb3"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.ProductId`

Gets returns the Vendor ID of the device.

```csharp
public readonly string CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.ProductId { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Devices/Structs/DevBroadcastDeviceInterface.cs:156`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface receiver)
    {
        _ = receiver.@ProductId;
    }
}
```

<a id="api-91f7a380fc7e"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.UsbDeviceInfoUri`

Gets try to generate a Uri which might include more information about the device.

```csharp
public readonly System.Uri CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.UsbDeviceInfoUri { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Devices/Structs/DevBroadcastDeviceInterface.cs:166`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface receiver)
    {
        _ = receiver.@UsbDeviceInfoUri;
    }
}
```

<a id="api-dedbacf747b7"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.VendorId`

Gets returns the Vendor ID of the device.

```csharp
public readonly string CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface.VendorId { get; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Devices/Structs/DevBroadcastDeviceInterface.cs:146`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface receiver)
    {
        _ = receiver.@VendorId;
    }
}
```
