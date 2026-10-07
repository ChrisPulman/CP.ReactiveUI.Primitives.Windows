<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.CountAssociatedIcons(System.String)](#api-b9ef404ff689)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.ExtractAssociatedIcon\`\`1(System.String,\`\`0)](#api-322de1ceff60)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.ExtractAssociatedIcon\`\`1(System.String,\`\`0,System.Int32,System.Boolean)](#api-87b3c65580ac)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetAppLogo\`\`1(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow,\`\`0)](#api-e262115e5566)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetAppLogo\`\`1(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow,\`\`0,System.Int32)](#api-af1b470134c9)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetFileExtensionIcon\`\`1(System.String,\`\`0,CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconSize,System.Boolean)](#api-0b07c9dd774a)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetFolderIcon\`\`1(\`\`0,CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconSize,CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.FolderIconType)](#api-6f8e4922eb93)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetIconSpacingHeight](#api-1177297b6a59)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetIconSpacingWidth](#api-1a64ac568673)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetSmallIconHeight](#api-420847f25776)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetSmallIconWidth](#api-b7a35ae688ea)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetStandardIconHeight](#api-7ef10174518a)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetStandardIconWidth](#api-0b8e0a3335da)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetSystemIconSize(CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize)](#api-3504a1f44cb1)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.IconHandleTo\`\`1(CP.ReactiveUI.Primitives.Windows.Native.Shell.SafeHandles.SafeIconHandle,\`\`0)](#api-f8306c7eaf22)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.IconHandleTo\`\`1(System.IntPtr,\`\`0)](#api-ce4a18e496e1)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.IconHandleTo\`\`1(System.IntPtr,\`\`0)](#api-670dcc413a8e)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithScaleDown\`\`1(\`\`0,System.IntPtr,System.IntPtr,System.Int32,System.Int32)](#api-db3db94067b7)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithScaleDown\`\`1(\`\`0,System.IntPtr,System.IntPtr,System.Int32,System.Int32)](#api-088d396269be)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithScaleDown\`\`1(\`\`0,System.IntPtr,System.String,System.Int32,System.Int32)](#api-cd869b7e2ba0)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithScaleDown\`\`1(\`\`0,System.IntPtr,System.String,System.Int32,System.Int32)](#api-d271371085e8)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithSystemMetrics\`\`1(\`\`0,System.IntPtr,System.IntPtr,CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize)](#api-4b897a7f07a7)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithSystemMetrics\`\`1(\`\`0,System.IntPtr,System.IntPtr,CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize)](#api-26ab4cf9b605)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithSystemMetrics\`\`1(\`\`0,System.IntPtr,System.String,CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize)](#api-7c7575c343b2)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithSystemMetrics\`\`1(\`\`0,System.IntPtr,System.String,CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize)](#api-d179a07ff4ad)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.WriteIcon(System.IO.Stream,System.Collections.Generic.IEnumerable{System.Drawing.Image})](#api-0ca0d617c252)

<a id="api-b9ef404ff689"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.CountAssociatedIcons(System.String)`

Gets the number of icons in the file.

```csharp
public static int CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.CountAssociatedIcons(string location)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:106`.

- `location` (`string`): The executable or DLL location.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.String @location, global::System.IObserver<global::System.Int32> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@CountAssociatedIcons(@location)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-322de1ceff60"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.ExtractAssociatedIcon``1(System.String,``0)`

Extracts an associated icon from an executable or DLL file.

```csharp
public static TIcon CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.ExtractAssociatedIcon<TIcon>(string filePath, TIcon iconType) where TIcon : class
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:62`.

- `filePath` (`string`): The file path.
- `iconType` (`TIcon`): The icon type marker.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TIcon>(global::System.String @filePath, TIcon @iconType, global::System.IObserver<TIcon> operationObserver)
    where TIcon : class
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@ExtractAssociatedIcon<TIcon>(@filePath, @iconType)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-87b3c65580ac"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.ExtractAssociatedIcon``1(System.String,``0,System.Int32,System.Boolean)`

Extracts an associated icon from an executable or DLL file.

```csharp
public static TIcon CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.ExtractAssociatedIcon<TIcon>(string filePath, TIcon iconType, int index, bool useLargeIcon) where TIcon : class
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:72`.

- `filePath` (`string`): The file path.
- `iconType` (`TIcon`): The icon type marker.
- `index` (`int`): The icon index.
- `useLargeIcon` (`bool`): A value indicating whether the large icon is preferred.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TIcon>(global::System.String @filePath, TIcon @iconType, global::System.Int32 @index, global::System.Boolean @useLargeIcon, global::System.IObserver<TIcon> operationObserver)
    where TIcon : class
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@ExtractAssociatedIcon<TIcon>(@filePath, @iconType, @index, @useLargeIcon)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-e262115e5566"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetAppLogo``1(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow,``0)`

Helper method to get the app logo from the applications AppxManifest.

```csharp
public static TBitmap CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetAppLogo<TBitmap>(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow interopWindow, TBitmap bitmapType) where TBitmap : class
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:40`.

- `interopWindow` (`CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow`): The interop window.
- `bitmapType` (`TBitmap`): The bitmap type marker.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TBitmap>(global::CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow @interopWindow, TBitmap @bitmapType, global::System.IObserver<TBitmap> operationObserver)
    where TBitmap : class
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@GetAppLogo<TBitmap>(@interopWindow, @bitmapType)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-af1b470134c9"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetAppLogo``1(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow,``0,System.Int32)`

Helper method to get the app logo from the applications AppxManifest.

```csharp
public static TBitmap CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetAppLogo<TBitmap>(CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow interopWindow, TBitmap bitmapType, int scale) where TBitmap : class
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:49`.

- `interopWindow` (`CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow`): The interop window.
- `bitmapType` (`TBitmap`): The bitmap type marker.
- `scale` (`int`): The requested logo scale, where 100 is the default.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TBitmap>(global::CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow @interopWindow, TBitmap @bitmapType, global::System.Int32 @scale, global::System.IObserver<TBitmap> operationObserver)
    where TBitmap : class
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@GetAppLogo<TBitmap>(@interopWindow, @bitmapType, @scale)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-0b07c9dd774a"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetFileExtensionIcon``1(System.String,``0,CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconSize,System.Boolean)`

Gets an icon for a file extension.

```csharp
public static TIcon CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetFileExtensionIcon<TIcon>(string filename, TIcon iconType, CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconSize size, bool linkOverlay) where TIcon : class
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:159`.

- `filename` (`string`): The file name.
- `iconType` (`TIcon`): The icon type marker.
- `size` (`CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconSize`): The requested icon size.
- `linkOverlay` (`bool`): A value indicating whether to include the link icon.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TIcon>(global::System.String @filename, TIcon @iconType, global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconSize @size, global::System.Boolean @linkOverlay, global::System.IObserver<TIcon> operationObserver)
    where TIcon : class
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@GetFileExtensionIcon<TIcon>(@filename, @iconType, @size, @linkOverlay)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-6f8e4922eb93"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetFolderIcon``1(``0,CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconSize,CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.FolderIconType)`

Gets a system folder icon.

```csharp
public static TIcon CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetFolderIcon<TIcon>(TIcon iconType, CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconSize size, CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.FolderIconType folderIconType) where TIcon : class
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:181`.

- `iconType` (`TIcon`): The icon type marker.
- `size` (`CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconSize`): The requested icon size.
- `folderIconType` (`CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.FolderIconType`): The folder icon type.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TIcon>(TIcon @iconType, global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconSize @size, global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.FolderIconType @folderIconType, global::System.IObserver<TIcon> operationObserver)
    where TIcon : class
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@GetFolderIcon<TIcon>(@iconType, @size, @folderIconType)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-1177297b6a59"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetIconSpacingHeight`

Gets the system-preferred height for icon grid spacing.

```csharp
public static int CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetIconSpacingHeight()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:219`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IObserver<global::System.Int32> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@GetIconSpacingHeight()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-1a64ac568673"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetIconSpacingWidth`

Gets the system-preferred width for icon grid spacing.

```csharp
public static int CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetIconSpacingWidth()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:215`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IObserver<global::System.Int32> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@GetIconSpacingWidth()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-420847f25776"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetSmallIconHeight`

Gets the system-preferred height for small icons.

```csharp
public static int CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetSmallIconHeight()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:203`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IObserver<global::System.Int32> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@GetSmallIconHeight()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-b7a35ae688ea"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetSmallIconWidth`

Gets the system-preferred width for small icons.

```csharp
public static int CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetSmallIconWidth()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:199`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IObserver<global::System.Int32> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@GetSmallIconWidth()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-7ef10174518a"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetStandardIconHeight`

Gets the system-preferred height for large or standard icons.

```csharp
public static int CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetStandardIconHeight()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:211`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IObserver<global::System.Int32> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@GetStandardIconHeight()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-0b8e0a3335da"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetStandardIconWidth`

Gets the system-preferred width for large or standard icons.

```csharp
public static int CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetStandardIconWidth()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:207`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IObserver<global::System.Int32> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@GetStandardIconWidth()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-3504a1f44cb1"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetSystemIconSize(CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize)`

Gets the system-preferred size for icons based on the metric size.

```csharp
public static System.Drawing.Size CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.GetSystemIconSize(CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize metricSize)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:224`.

- `metricSize` (`CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize`): The metric size.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize @metricSize, global::System.IObserver<global::System.Drawing.Size> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@GetSystemIconSize(@metricSize)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-f8306c7eaf22"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.IconHandleTo``1(CP.ReactiveUI.Primitives.Windows.Native.Shell.SafeHandles.SafeIconHandle,``0)`

Creates a typed icon object from the specified safe icon handle.

```csharp
public static TIcon CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.IconHandleTo<TIcon>(CP.ReactiveUI.Primitives.Windows.Native.Shell.SafeHandles.SafeIconHandle iconHandle, TIcon iconType) where TIcon : class
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:142`.

- `iconHandle` (`CP.ReactiveUI.Primitives.Windows.Native.Shell.SafeHandles.SafeIconHandle`): The safe icon handle.
- `iconType` (`TIcon`): The icon type marker.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TIcon>(global::CP.ReactiveUI.Primitives.Windows.Native.Shell.SafeHandles.SafeIconHandle @iconHandle, TIcon @iconType, global::System.IObserver<TIcon> operationObserver)
    where TIcon : class
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@IconHandleTo<TIcon>(@iconHandle, @iconType)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-ce4a18e496e1"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.IconHandleTo``1(System.IntPtr,``0)`

Creates a typed icon object from the specified icon handle.

```csharp
public static TIcon CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.IconHandleTo<TIcon>(System.IntPtr iconHandle, TIcon iconType) where TIcon : class
```

Availability: net462, net472, net48, net481. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:114`.

- `iconHandle` (`System.IntPtr`): The icon handle.
- `iconType` (`TIcon`): The icon type marker.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TIcon>(global::System.IntPtr @iconHandle, TIcon @iconType, global::System.IObserver<TIcon> operationObserver)
    where TIcon : class
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@IconHandleTo<TIcon>(@iconHandle, @iconType)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-670dcc413a8e"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.IconHandleTo``1(System.IntPtr,``0)`

Creates a typed icon object from the specified icon handle.

```csharp
public static TIcon CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.IconHandleTo<TIcon>(nint iconHandle, TIcon iconType) where TIcon : class
```

Availability: net10.0-windows, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:114`.

- `iconHandle` (`nint`): The icon handle.
- `iconType` (`TIcon`): The icon type marker.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TIcon>(nint @iconHandle, TIcon @iconType, global::System.IObserver<TIcon> operationObserver)
    where TIcon : class
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@IconHandleTo<TIcon>(@iconHandle, @iconType)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-db3db94067b7"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithScaleDown``1(``0,System.IntPtr,System.IntPtr,System.Int32,System.Int32)`

Loads an icon with automatic scaling using LoadIconWithScaleDown.

```csharp
public static TIcon CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithScaleDown<TIcon>(TIcon iconType, System.IntPtr instanceHandle, System.IntPtr iconName, int width, int height) where TIcon : class
```

Availability: net462, net472, net48, net481. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:259`.

- `iconType` (`TIcon`): The icon type marker.
- `instanceHandle` (`System.IntPtr`): A handle to the module containing the icon resource.
- `iconName` (`System.IntPtr`): The icon resource identifier.
- `width` (`int`): The desired width of the icon in pixels.
- `height` (`int`): The desired height of the icon in pixels.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TIcon>(TIcon @iconType, global::System.IntPtr @instanceHandle, global::System.IntPtr @iconName, global::System.Int32 @width, global::System.Int32 @height, global::System.IObserver<TIcon> operationObserver)
    where TIcon : class
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@LoadIconWithScaleDown<TIcon>(@iconType, @instanceHandle, @iconName, @width, @height)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-088d396269be"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithScaleDown``1(``0,System.IntPtr,System.IntPtr,System.Int32,System.Int32)`

Loads an icon with automatic scaling using LoadIconWithScaleDown.

```csharp
public static TIcon CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithScaleDown<TIcon>(TIcon iconType, nint instanceHandle, nint iconName, int width, int height) where TIcon : class
```

Availability: net10.0-windows, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:259`.

- `iconType` (`TIcon`): The icon type marker.
- `instanceHandle` (`nint`): A handle to the module containing the icon resource.
- `iconName` (`nint`): The icon resource identifier.
- `width` (`int`): The desired width of the icon in pixels.
- `height` (`int`): The desired height of the icon in pixels.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TIcon>(TIcon @iconType, nint @instanceHandle, nint @iconName, global::System.Int32 @width, global::System.Int32 @height, global::System.IObserver<TIcon> operationObserver)
    where TIcon : class
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@LoadIconWithScaleDown<TIcon>(@iconType, @instanceHandle, @iconName, @width, @height)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-cd869b7e2ba0"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithScaleDown``1(``0,System.IntPtr,System.String,System.Int32,System.Int32)`

Loads an icon with automatic scaling using LoadIconWithScaleDown.

```csharp
public static TIcon CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithScaleDown<TIcon>(TIcon iconType, System.IntPtr instanceHandle, string iconName, int width, int height) where TIcon : class
```

Availability: net462, net472, net48, net481. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:270`.

- `iconType` (`TIcon`): The icon type marker.
- `instanceHandle` (`System.IntPtr`): A handle to the module containing the icon resource.
- `iconName` (`string`): The icon resource name.
- `width` (`int`): The desired width of the icon in pixels.
- `height` (`int`): The desired height of the icon in pixels.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TIcon>(TIcon @iconType, global::System.IntPtr @instanceHandle, global::System.String @iconName, global::System.Int32 @width, global::System.Int32 @height, global::System.IObserver<TIcon> operationObserver)
    where TIcon : class
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@LoadIconWithScaleDown<TIcon>(@iconType, @instanceHandle, @iconName, @width, @height)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-d271371085e8"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithScaleDown``1(``0,System.IntPtr,System.String,System.Int32,System.Int32)`

Loads an icon with automatic scaling using LoadIconWithScaleDown.

```csharp
public static TIcon CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithScaleDown<TIcon>(TIcon iconType, nint instanceHandle, string iconName, int width, int height) where TIcon : class
```

Availability: net10.0-windows, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:270`.

- `iconType` (`TIcon`): The icon type marker.
- `instanceHandle` (`nint`): A handle to the module containing the icon resource.
- `iconName` (`string`): The icon resource name.
- `width` (`int`): The desired width of the icon in pixels.
- `height` (`int`): The desired height of the icon in pixels.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TIcon>(TIcon @iconType, nint @instanceHandle, global::System.String @iconName, global::System.Int32 @width, global::System.Int32 @height, global::System.IObserver<TIcon> operationObserver)
    where TIcon : class
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@LoadIconWithScaleDown<TIcon>(@iconType, @instanceHandle, @iconName, @width, @height)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-4b897a7f07a7"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithSystemMetrics``1(``0,System.IntPtr,System.IntPtr,CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize)`

Loads an icon at the system-preferred size using LoadIconMetric.

```csharp
public static TIcon CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithSystemMetrics<TIcon>(TIcon iconType, System.IntPtr instanceHandle, System.IntPtr iconName, CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize metricSize) where TIcon : class
```

Availability: net462, net472, net48, net481. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:238`.

- `iconType` (`TIcon`): The icon type marker.
- `instanceHandle` (`System.IntPtr`): A handle to the module containing the icon resource.
- `iconName` (`System.IntPtr`): The icon resource identifier.
- `metricSize` (`CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize`): The metric size to use.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TIcon>(TIcon @iconType, global::System.IntPtr @instanceHandle, global::System.IntPtr @iconName, global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize @metricSize, global::System.IObserver<TIcon> operationObserver)
    where TIcon : class
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@LoadIconWithSystemMetrics<TIcon>(@iconType, @instanceHandle, @iconName, @metricSize)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-26ab4cf9b605"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithSystemMetrics``1(``0,System.IntPtr,System.IntPtr,CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize)`

Loads an icon at the system-preferred size using LoadIconMetric.

```csharp
public static TIcon CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithSystemMetrics<TIcon>(TIcon iconType, nint instanceHandle, nint iconName, CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize metricSize) where TIcon : class
```

Availability: net10.0-windows, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:238`.

- `iconType` (`TIcon`): The icon type marker.
- `instanceHandle` (`nint`): A handle to the module containing the icon resource.
- `iconName` (`nint`): The icon resource identifier.
- `metricSize` (`CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize`): The metric size to use.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TIcon>(TIcon @iconType, nint @instanceHandle, nint @iconName, global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize @metricSize, global::System.IObserver<TIcon> operationObserver)
    where TIcon : class
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@LoadIconWithSystemMetrics<TIcon>(@iconType, @instanceHandle, @iconName, @metricSize)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-7c7575c343b2"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithSystemMetrics``1(``0,System.IntPtr,System.String,CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize)`

Loads an icon at the system-preferred size using LoadIconMetric.

```csharp
public static TIcon CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithSystemMetrics<TIcon>(TIcon iconType, System.IntPtr instanceHandle, string iconName, CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize metricSize) where TIcon : class
```

Availability: net462, net472, net48, net481. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:248`.

- `iconType` (`TIcon`): The icon type marker.
- `instanceHandle` (`System.IntPtr`): A handle to the module containing the icon resource.
- `iconName` (`string`): The icon resource name.
- `metricSize` (`CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize`): The metric size to use.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TIcon>(TIcon @iconType, global::System.IntPtr @instanceHandle, global::System.String @iconName, global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize @metricSize, global::System.IObserver<TIcon> operationObserver)
    where TIcon : class
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@LoadIconWithSystemMetrics<TIcon>(@iconType, @instanceHandle, @iconName, @metricSize)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-d179a07ff4ad"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithSystemMetrics``1(``0,System.IntPtr,System.String,CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize)`

Loads an icon at the system-preferred size using LoadIconMetric.

```csharp
public static TIcon CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.LoadIconWithSystemMetrics<TIcon>(TIcon iconType, nint instanceHandle, string iconName, CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize metricSize) where TIcon : class
```

Availability: net10.0-windows, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:248`.

- `iconType` (`TIcon`): The icon type marker.
- `instanceHandle` (`nint`): A handle to the module containing the icon resource.
- `iconName` (`string`): The icon resource name.
- `metricSize` (`CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize`): The metric size to use.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TIcon>(TIcon @iconType, nint @instanceHandle, global::System.String @iconName, global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize @metricSize, global::System.IObserver<TIcon> operationObserver)
    where TIcon : class
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@LoadIconWithSystemMetrics<TIcon>(@iconType, @instanceHandle, @iconName, @metricSize)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-0ca0d617c252"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.WriteIcon(System.IO.Stream,System.Collections.Generic.IEnumerable{System.Drawing.Image})`

Writes the images to the stream as an icon.

```csharp
public static void CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.WriteIcon(System.IO.Stream stream, System.Collections.Generic.IEnumerable<System.Drawing.Image> images)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Shell/Icons/IconHelper.cs:55`.

- `stream` (`System.IO.Stream`): The stream to write to.
- `images` (`System.Collections.Generic.IEnumerable<System.Drawing.Image>`): The images to write.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::System.IO.Stream @stream, global::System.Collections.Generic.IEnumerable<global::System.Drawing.Image> @images, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => global::CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper.@WriteIcon(@stream, @images)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```
