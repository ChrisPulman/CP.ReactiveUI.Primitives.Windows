<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.#ctor](#api-0e04fd619bc6)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.ToString](#api-a22787460326)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.AuthorizedCDFPrefix](#api-8efa01b92d09)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Comments](#api-f9e3b226b2a6)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Contact](#api-33a6c5732b89)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.DisplayName](#api-19c9a0e1cd33)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.DisplayVersion](#api-6ddb2a697ea4)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.EstimatedSize](#api-95cb9badea75)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.HelpLink](#api-6b1fadbdfea8)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.HelpTelephone](#api-f2c182f2493e)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Id](#api-337e8c23beac)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.InstallDate](#api-01accdfb1030)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.InstallLocation](#api-a290cc60b4d3)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.InstallSource](#api-2a40b1ae37c8)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Language](#api-f28e6a0530f7)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.ModifyPath](#api-5448e69cafd7)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.NoModify](#api-6c209b4a8962)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.NoRepair](#api-a8030b0c5c74)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Publisher](#api-8ac338d5fbbe)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Readme](#api-0b4746845d94)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Size](#api-50b6ef53ba41)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.SystemComponent](#api-d4bff143a03e)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.URLInfoAbout](#api-65b5e9cac766)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.URLUpdateInfo](#api-bd33f2038f92)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.UninstallString](#api-5efb14d03bd6)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Version](#api-46c521360094)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.VersionMajor](#api-193d0616b0ac)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.VersionMinor](#api-6d8ea24f3def)
- [P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.WindowsInstaller](#api-3475bc4005d3)

<a id="api-0e04fd619bc6"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.#ctor`

Creates the default SoftwareDetails value.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.SoftwareDetails()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:11`.

```csharp
internal static class ApiExample
{
    internal static void Call()
    {
        new global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails();
    }
}
```

<a id="api-a22787460326"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.ToString`

Returns a string that represents the current object.

```csharp
public override string CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.ToString()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:95`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.IObserver<global::System.String> operationObserver)
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@ToString()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-8efa01b92d09"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.AuthorizedCDFPrefix`

Gets or sets the ARPAUTHORIZEDCDFPREFIX property.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.AuthorizedCDFPrefix { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:17`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.String configurableValue)
    {
        receiver.@AuthorizedCDFPrefix = configurableValue;
        _ = receiver.@AuthorizedCDFPrefix;
    }
}
```

<a id="api-f9e3b226b2a6"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Comments`

Gets or sets comments provided to the Add or Remove Programs control panel.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Comments { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:23`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.String configurableValue)
    {
        receiver.@Comments = configurableValue;
        _ = receiver.@Comments;
    }
}
```

<a id="api-33a6c5732b89"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Contact`

Gets or sets the ARPCONTACT property.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Contact { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:20`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.String configurableValue)
    {
        receiver.@Contact = configurableValue;
        _ = receiver.@Contact;
    }
}
```

<a id="api-19c9a0e1cd33"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.DisplayName`

Gets or sets the ProductName property.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.DisplayName { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:26`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.String configurableValue)
    {
        receiver.@DisplayName = configurableValue;
        _ = receiver.@DisplayName;
    }
}
```

<a id="api-6ddb2a697ea4"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.DisplayVersion`

Gets or sets the display version derived from the ProductVersion property.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.DisplayVersion { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:29`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.String configurableValue)
    {
        receiver.@DisplayVersion = configurableValue;
        _ = receiver.@DisplayVersion;
    }
}
```

<a id="api-95cb9badea75"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.EstimatedSize`

Gets or sets the estimated size determined by the Windows Installer.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.EstimatedSize { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:32`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.Int32 configurableValue)
    {
        receiver.@EstimatedSize = configurableValue;
        _ = receiver.@EstimatedSize;
    }
}
```

<a id="api-6b1fadbdfea8"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.HelpLink`

Gets or sets the ARPHELPLINK property.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.HelpLink { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:35`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.String configurableValue)
    {
        receiver.@HelpLink = configurableValue;
        _ = receiver.@HelpLink;
    }
}
```

<a id="api-f2c182f2493e"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.HelpTelephone`

Gets or sets the ARPHELPTELEPHONE property.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.HelpTelephone { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:38`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.String configurableValue)
    {
        receiver.@HelpTelephone = configurableValue;
        _ = receiver.@HelpTelephone;
    }
}
```

<a id="api-337e8c23beac"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Id`

Gets or sets the application's product code GUID.

```csharp
public System.Guid? CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Id { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:14`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.Guid? configurableValue)
    {
        receiver.@Id = configurableValue;
        _ = receiver.@Id;
    }
}
```

<a id="api-01accdfb1030"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.InstallDate`

Gets or sets the last time this product received service.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.InstallDate { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:41`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.String configurableValue)
    {
        receiver.@InstallDate = configurableValue;
        _ = receiver.@InstallDate;
    }
}
```

<a id="api-a290cc60b4d3"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.InstallLocation`

Gets or sets the ARPINSTALLLOCATION property.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.InstallLocation { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:47`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.String configurableValue)
    {
        receiver.@InstallLocation = configurableValue;
        _ = receiver.@InstallLocation;
    }
}
```

<a id="api-2a40b1ae37c8"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.InstallSource`

Gets or sets the SourceDir property.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.InstallSource { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:50`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.String configurableValue)
    {
        receiver.@InstallSource = configurableValue;
        _ = receiver.@InstallSource;
    }
}
```

<a id="api-f28e6a0530f7"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Language`

Gets or sets the ProductLanguage property.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Language { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:53`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.Int32 configurableValue)
    {
        receiver.@Language = configurableValue;
        _ = receiver.@Language;
    }
}
```

<a id="api-5448e69cafd7"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.ModifyPath`

Gets or sets the modify path determined by the Windows Installer.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.ModifyPath { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:56`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.String configurableValue)
    {
        receiver.@ModifyPath = configurableValue;
        _ = receiver.@ModifyPath;
    }
}
```

<a id="api-6c209b4a8962"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.NoModify`

Gets or sets a value indicating whether modify operations are disabled.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.NoModify { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:89`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.Boolean configurableValue)
    {
        receiver.@NoModify = configurableValue;
        _ = receiver.@NoModify;
    }
}
```

<a id="api-a8030b0c5c74"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.NoRepair`

Gets or sets a value indicating whether repair operations are disabled.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.NoRepair { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:92`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.Boolean configurableValue)
    {
        receiver.@NoRepair = configurableValue;
        _ = receiver.@NoRepair;
    }
}
```

<a id="api-8ac338d5fbbe"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Publisher`

Gets or sets the Manufacturer property advertised for the product.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Publisher { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:59`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.String configurableValue)
    {
        receiver.@Publisher = configurableValue;
        _ = receiver.@Publisher;
    }
}
```

<a id="api-0b4746845d94"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Readme`

Gets or sets the readme path or URL.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Readme { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:62`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.String configurableValue)
    {
        receiver.@Readme = configurableValue;
        _ = receiver.@Readme;
    }
}
```

<a id="api-50b6ef53ba41"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Size`

Gets or sets the installed size.

```csharp
public long CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Size { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:65`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.Int64 configurableValue)
    {
        receiver.@Size = configurableValue;
        _ = receiver.@Size;
    }
}
```

<a id="api-d4bff143a03e"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.SystemComponent`

Gets or sets a value indicating whether the software is a system component.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.SystemComponent { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:44`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.Boolean configurableValue)
    {
        receiver.@SystemComponent = configurableValue;
        _ = receiver.@SystemComponent;
    }
}
```

<a id="api-65b5e9cac766"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.URLInfoAbout`

Gets or sets the ARPURLINFOABOUT property.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.URLInfoAbout { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:71`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.String configurableValue)
    {
        receiver.@URLInfoAbout = configurableValue;
        _ = receiver.@URLInfoAbout;
    }
}
```

<a id="api-bd33f2038f92"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.URLUpdateInfo`

Gets or sets the ARPURLUPDATEINFO property.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.URLUpdateInfo { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:74`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.String configurableValue)
    {
        receiver.@URLUpdateInfo = configurableValue;
        _ = receiver.@URLUpdateInfo;
    }
}
```

<a id="api-5efb14d03bd6"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.UninstallString`

Gets or sets the uninstall string determined by Windows Installer.

```csharp
public string CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.UninstallString { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:68`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.String configurableValue)
    {
        receiver.@UninstallString = configurableValue;
        _ = receiver.@UninstallString;
    }
}
```

<a id="api-46c521360094"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Version`

Gets or sets the version derived from the ProductVersion property.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.Version { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:77`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.Int32 configurableValue)
    {
        receiver.@Version = configurableValue;
        _ = receiver.@Version;
    }
}
```

<a id="api-193d0616b0ac"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.VersionMajor`

Gets or sets the major version derived from the ProductVersion property.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.VersionMajor { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:80`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.Int32 configurableValue)
    {
        receiver.@VersionMajor = configurableValue;
        _ = receiver.@VersionMajor;
    }
}
```

<a id="api-6d8ea24f3def"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.VersionMinor`

Gets or sets the minor version derived from the ProductVersion property.

```csharp
public int CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.VersionMinor { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:83`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.Int32 configurableValue)
    {
        receiver.@VersionMinor = configurableValue;
        _ = receiver.@VersionMinor;
    }
}
```

<a id="api-3475bc4005d3"></a>

## `P:CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.WindowsInstaller`

Gets or sets a value indicating whether Windows Installer manages the software.

```csharp
public bool CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails.WindowsInstaller { get; set; }
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Software/SoftwareDetails.cs:86`.

```csharp
internal static class ApiExample
{
    internal static void Call(global::CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails receiver, global::System.Boolean configurableValue)
    {
        receiver.@WindowsInstaller = configurableValue;
        _ = receiver.@WindowsInstaller;
    }
}
```
