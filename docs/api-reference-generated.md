# Public callable API reference

Every public method, overload, constructor, operator, conversion, delegate invocation, property and indexer has an exact signature, description and compiled C# example in the linked reference pages. Availability is recorded for each target framework. Examples accept valid existing typed inputs and are compiled without execution; retain native resources for their required lifetime. Observable sources subscribe directly; operation adapters observe their result before subscribing. Subscription examples return an IDisposable that the caller retains and disposes to control the subscription lifetime. Synchronous desktop methods support deferred fluent observation. Native buffer, pointer, span and by-reference methods retain direct calls.

Regenerate: `pwsh ./tools/Update-ApiReference.ps1`.

## CP.ReactiveUI.Primitives.Windows.Core

### CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations

- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WindowsMessages](api/2cf081ec3bab.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WindowsMessagesExtensions](api/499ea87d0c89.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Enumerations.WtsSessionChangeEvents](api/0c2bc78d6c93.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Native

- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Native.WndProc](api/539d4cf6a64e.md) — 5 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Structs

- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Structs.Msg](api/e05f8454f37c.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.Structs.WindowMessage](api/0de1d2a3a88a.md) — 7 callable members.

### CP.ReactiveUI.Primitives.Windows.Interop.Com

- [CP.ReactiveUI.Primitives.Windows.Interop.Com.ComProgIdAttribute](api/ebccf0099889.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Interop.Com.DisposableCom](api/f050cd85f8f9.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Interop.Com.IDisposableCom<T>](api/8896458d7eb4.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Interop.Com.IOleCommandTarget](api/6916915ef95e.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Interop.Com.IOleWindow](api/a07b4bb66a66.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Interop.Com.Ole32Api](api/7f54299001e3.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Interop.Com.OleAut32Api](api/02c1b378cab9.md) — 4 callable members.

### CP.ReactiveUI.Primitives.Windows.Native

- [CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel>](api/bedd72fbe4c9.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessor<TPixel>.ProcessRowDelegate<TRowPixel>](api/903a74804804.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.BitmapAccessorExtensions](api/1a15fcc51968.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Win32](api/2b2db3f5a9f4.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.WindowsVersion](api/536b4464d39b.md) — 16 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Enums

- [CP.ReactiveUI.Primitives.Windows.Native.Enums.AdjacentTo](api/08c43bab4e54.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Enums.HResult](api/4b3ffbd1eaa5.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Enums.Win32Error](api/467d54215bf2.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Extensions

- [CP.ReactiveUI.Primitives.Windows.Native.Extensions.EnumExtensions](api/042189dd27df.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Extensions.HResultExtensions](api/c529088acf3f.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Extensions.NativePointExtensions](api/fd60733b4cbd.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Extensions.NativePointFloatExtensions](api/f73be8ab4325.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Extensions.NativeRectExtensions](api/6699d3b8d801.md) — 31 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Extensions.NativeRectFloatExtensions](api/2272271a220e.md) — 31 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Extensions.NativeSizeExtensions](api/f691aeea2ecc.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Extensions.NativeSizeFloatExtensions](api/b3e7ce397505.md) — 3 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Gdi

- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Gdi32Api](api/689c43fb36d6.md) — 16 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.GdiExtensions](api/10c13f2df83a.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.GdiPlusApi](api/a07b075273ed.md) — 3 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Gdi.Enums

- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Enums.BitmapCompressionMethods](api/71ab7197e8eb.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Enums.ColorSpace](api/625bb485c4ff.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Enums.DeviceCaps](api/3ceefd54bcb0.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Enums.DibColors](api/8a3e3c6e91d6.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Enums.GdiPlusStatus](api/e03d89f441fe.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Enums.GpUnit](api/b3449925d4fa.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Enums.RasterOperations](api/93300528c710.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles

- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeCompatibleDcHandle](api/737a79251d91.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeDibSectionHandle](api/62a0f98e32ba.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeGraphicsDcHandle](api/a5beb50b9fba.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeHBitmapHandle](api/d3ba5d6017c6.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeNonDisposableObjectHandle](api/9c04cd06a0cb.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeRegionHandle](api/21656a9dbe1c.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeSelectObjectHandle](api/92f5fc502dd1.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.SafeHandles.SafeWindowDcHandle](api/ad5e679102a2.md) — 8 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs

- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitfieldColorMask](api/62ac2e258f0b.md) — 16 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapFileHeader](api/edcfea9bc9e9.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapInfoHeader](api/c32033b1e41c.md) — 21 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapV4Header](api/f657b72fef6e.md) — 30 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BitmapV5Header](api/7bff0e3230c7.md) — 34 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.BlurParams](api/caec2331bb2a.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.CieXyz](api/466a12ce66a0.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.CieXyzTriple](api/7b5994ac6489.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.GdiBitmap](api/609fdee79873.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Gdi.Structs.RgbQuad](api/d7470fd951c2.md) — 10 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Kernel

- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Kernel32Api](api/46eb5f44d720.md) — 46 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Kernel32ApiExtensions](api/7034b84ab6d9.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.PackageInfo](api/547d4fd85ec7.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.PsApi](api/9b66a5074834.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.RestartManager](api/6a9a21d06376.md) — 20 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.RestartManagerApi](api/af854a4900ab.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.RmStatusCallback](api/2dcfa58617f2.md) — 5 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums

- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums.DefaultDllDirectories](api/15e32245b754.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums.GlobalMemorySettings](api/ae3e8dff6a31.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums.ProcessAccessRights](api/33276baf3b43.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums.RmAppStatus](api/f99aff0b136e.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums.RmAppType](api/f38ee5e717da.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums.RmRebootReason](api/0a62b6aa7c63.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums.RmShutdownType](api/379d3342b611.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums.ThreadAccess](api/65279dd1e806.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums.WindowsProducts](api/2a90b8255bf3.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums.WindowsProductTypes](api/c95c1a3fe671.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Enums.WindowsSuites](api/9bb029ddd5c4.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Kernel.Structs

- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Structs.OsVersionInfoEx](api/e71f8164030a.md) — 16 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Structs.RmProcessInfo](api/3ff29615d076.md) — 14 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Kernel.Structs.RmUniqueProcess](api/c3dfd91f285e.md) — 9 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Security

- [CP.ReactiveUI.Primitives.Windows.Native.Security.Advapi32Api](api/4ccf7d79d006.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Security.RegistryMonitor](api/e4eefe9f45ea.md) — 4 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Security.Enums

- [CP.ReactiveUI.Primitives.Windows.Native.Security.Enums.RegistryKeySecurityAccessRights](api/462b6104a66d.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Security.Enums.RegistryNotifyFilter](api/98d4394204ab.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Security.Enums.RegistryOpenOptions](api/bcc3250b6991.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Security.Enums.TokenInformationClasses](api/6c95c1e7d8fe.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Shell

- [CP.ReactiveUI.Primitives.Windows.Native.Shell.Shell32Api](api/3432d5fce17d.md) — 5 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Shell.Enums

- [CP.ReactiveUI.Primitives.Windows.Native.Shell.Enums.AppBarEdges](api/c5753f215fc6.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Shell.Enums.AppBarMessages](api/4805b2d422fc.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Shell.Enums.AppBarStates](api/20e3d798d3e6.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Shell.Enums.ShellFileAttributeFlags](api/f4f7363918a9.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Shell.Enums.ShellGetFileInfoFlags](api/7f8e621fe6ff.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Shell.SafeHandles

- [CP.ReactiveUI.Primitives.Windows.Native.Shell.SafeHandles.SafeIconHandle](api/648ca7a71caa.md) — 6 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Shell.Structs

- [CP.ReactiveUI.Primitives.Windows.Native.Shell.Structs.AppBarData](api/58ed7912ebb9.md) — 14 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Shell.Structs.ShellFileInfo](api/511278719998.md) — 11 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Structs

- [CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePoint](api/013cc49f0dca.md) — 19 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Structs.NativePointFloat](api/071d16bedec7.md) — 22 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeRect](api/d1d5e0d6e6d2.md) — 40 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeRectFloat](api/85ec8e5d8b47.md) — 45 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeSize](api/d089f4919591.md) — 30 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Structs.NativeSizeFloat](api/4becf0a65dc9.md) — 35 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.Structs.PixelFormats

- [CP.ReactiveUI.Primitives.Windows.Native.Structs.PixelFormats.Bgr24](api/ac04c9305663.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Structs.PixelFormats.Bgra32](api/5dfd1a7316ae.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.Structs.PixelFormats.Indexed8](api/b1ef488190bf.md) — 9 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.TypeConverters

- [CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativePointFloatTypeConverter](api/ca5e10e91bb6.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativePointTypeConverter](api/304695a128a7.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectFloatTypeConverter](api/a4f6f01e0074.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeRectTypeConverter](api/f282eadcda03.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeSizeFloatTypeConverter](api/de25fa645857.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.TypeConverters.NativeSizeTypeConverter](api/e4f04d3e3c58.md) — 5 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.UserInterface

- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.DisplayInfo](api/828f5b8d09ee.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.User32Api](api/8ad32c22b8ed.md) — 143 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.User32Api.EnumWindowsProc](api/a1b58f0f38a5.md) — 7 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums

- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.ClassLongIndex](api/e69c6046e7a4.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.CursorInfoFlags](api/de52ee71db44.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.DesktopAccessRight](api/ec2f3671f402.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.ExtendedWindowStyleFlags](api/282e67d38679.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.GetWindowCommands](api/3d18ae7fe6eb.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.MonitorFrom](api/c997b4fa106e.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.MonitorInfoFlags](api/f820bc30b49b.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.ObjectIdentifiers](api/4e3a68972402.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.ObjectStates](api/becb1d62606b.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.PrintWindowFlags](api/e2d4a52acaab.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.RegionResults](api/1bf2a7a99be9.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.ScrollBarCommands](api/096965c1c336.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.ScrollBarStateIndexes](api/3e4e52c96ef5.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.ScrollBarTypes](api/078e177a3c58.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.ScrollInfoMask](api/b4778e73e53b.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.ScrollModes](api/8705f8501a0e.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SendMessageTimeoutFlags](api/d093a52f0e55.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.ShowWindowCommands](api/b76603271c87.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SysCommands](api/46e80610fcc3.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SystemColorIndex](api/0b1b863bea6b.md) — 40 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SystemMetric](api/f127cce27129.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SystemParametersInfoActions](api/7167c8e12718.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.SystemParametersInfoBehaviors](api/7dd40b8b3f7d.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.TitleBarInfoIndexes](api/84f66cc67f55.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.WindowDisplayAffinity](api/d77ba7eb9323.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.WindowLongIndex](api/76ae0f0403bd.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.WindowPlacementFlags](api/20f366ef4be4.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.WindowPos](api/248f34b94b8e.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.WindowsClassStyles](api/5236c1c5430a.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Enums.WindowStyleFlags](api/e6f20592833a.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.UserInterface.SafeHandles

- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.SafeHandles.SafeCurrentInputDesktopHandle](api/79c1f493f9fa.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.SafeHandles.SafeCursorReferenceHandle](api/cf0b947fac81.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.SafeHandles.SafeMonitorHandle](api/c76ce59645af.md) — 3 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs

- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.AnimationInfo](api/c93fbc3c9c31.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.CursorInfo](api/5e017dfc489e.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.MonitorInfoEx](api/ecbce1452f0a.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.ScrollBarInfo](api/6c23c6129071.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.ScrollInfo](api/6d129ba591a1.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.TitleBarInfoEx](api/7f86f467c606.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.WindowInfo](api/040435cbe426.md) — 16 callable members.
- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.Structs.WindowPlacement](api/290aa8191096.md) — 13 callable members.

### CP.ReactiveUI.Primitives.Windows.Native.UserInterface.TypeConverters

- [CP.ReactiveUI.Primitives.Windows.Native.UserInterface.TypeConverters.WindowPlacementTypeConverter](api/0624db128a96.md) — 5 callable members.

### CP.ReactiveUI.Primitives.Windows.Operations

- [CP.ReactiveUI.Primitives.Windows.Operations.WindowsAsyncOperation<T>](api/f63719be3b08.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation](api/0831277ff95c.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation<T>](api/17eca6807c62.md) — 4 callable members.

## CP.ReactiveUI.Primitives.Windows.Integrations

### CP.ReactiveUI.Primitives.Windows.Integrations

- [CP.ReactiveUI.Primitives.Windows.Integrations.IntegrationOperationExtensions](api/7856522c415c.md) — 15 callable members.

### CP.ReactiveUI.Primitives.Windows.Integrations.Browser

- [CP.ReactiveUI.Primitives.Windows.Integrations.Browser.ExtendedWebBrowser](api/ff2055f379ac.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Browser.InternetExplorerVersion](api/8569876cbc58.md) — 9 callable members.

### CP.ReactiveUI.Primitives.Windows.Integrations.Citrix

- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.WinFrame](api/2da8c03a27a6.md) — 6 callable members.

### CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Enums

- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Enums.ConnectStates](api/6fe0b14ae608.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Enums.EventMask](api/a4f328091bf5.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Enums.InfoClasses](api/d7f06c4bd388.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host

- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host.CcmHostOperationResult](api/73461aeb0111.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host.CcmHostSessionInformation](api/e1b4795ac78c.md) — 40 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host.CcmHostSessionInformationResult](api/4e47662a1d1c.md) — 14 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host.CitrixHostSessionManagement](api/c50f270c83f7.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host.DelegatingCitrixCcmHostSessionApi](api/728716cf7839.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host.DelegatingWtsSessionNotificationApi](api/d72671c15660.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host.ICitrixCcmHostSessionApi](api/884cd90feb72.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host.IWtsSessionNotificationApi](api/51d9263463c9.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host.NativeCitrixCcmHostSessionApi](api/c87a1716b088.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host.WtsSessionNotificationRegistration](api/a95e55a4c04b.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host.WtsSessionNotificationScope](api/0aeb19e05d2d.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc

- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelCloseResult](api/16fe2004e239.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelData](api/8c9bfe560a7b.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelEvent](api/fc8047e257c0.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelEventKind](api/58779c86d458.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeature](api/7bd6dffbf419.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelFeatureRegistration](api/04455733a282.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelHandle](api/6d74ea4ac18a.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelIpc](api/3c31f686c752.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenRequest](api/90576e6df796.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelOpenResult](api/aadfde401cad.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelSession](api/d0e44228c151.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelStatus](api/52333b4d4a4f.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelWriteRequest](api/4b1f78e5cf18.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.CitrixVirtualChannelWriteResult](api/26f299d13c2a.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc.ICitrixVirtualDriverAdapter](api/4cf29ca98c12.md) — 6 callable members.

### CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle

- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixConnectEvent](api/7178637a4eab.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixDisconnectEvent](api/f563a962baf9.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixICAFileInfo](api/254db8968d5d.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixICAFileParseEvent](api/3bece47b7d47.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixLifecycleEvent](api/e945bb583adc.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixLifecycleExtensions](api/8b3e937130d6.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixLifecycleObservables](api/0d9f92c68cc9.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixLoginEvent](api/8c851e983ac0.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixObservableLifecycleEventSource](api/9d8b4e0fee19.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixSessionInfo](api/0ac399a40687.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixSessionLifecycleEvent](api/3f5107a8c9b9.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixSessionStateChangeEvent](api/26e2a87fb799.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixWindowCreatedEvent](api/f2ab9ef92876.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixWindowDestroyedEvent](api/c081c7c31af5.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixWindowInfo](api/b0fb240f1513.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.CitrixWinFrameLifecycleEventSource](api/81a22bbf7d2c.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Lifecycle.ICitrixLifecycleEventSource](api/587d9d476e0c.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs

- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.AppInfo](api/d2b98b70e34b.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientAddress](api/4aba73c1c1ba.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientDisplay](api/0d17a984984a.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientInfo](api/159c19086c1e.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.ClientLatency](api/e28b9dd5467c.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.OsVersionInfo](api/d7d62aa1b67e.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.SessionTime](api/f5d4cc057fb2.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Structs.UserInfo](api/6cc36529f726.md) — 10 callable members.

### CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry

- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixApplicationFailureTelemetryEntity](api/eef983f1022b.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMachineResourceUtilizationTelemetryEntity](api/07b5c8b05a58.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetry](api/55a2a9c43472.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetryOptions](api/084e1d09a894.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetryRequest](api/aab84466fbd3.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetrySnapshot](api/9becf60b9ff9.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.CitrixMonitorTelemetryUriBuilder](api/70e2f7b8041e.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.DelegateCitrixMonitorTelemetryTransport](api/fe831b5825f4.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Telemetry.ICitrixMonitorTelemetryTransport](api/a226a8b235ac.md) — 1 callable members.

## CP.ReactiveUI.Primitives.Windows.Reactive

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Apps

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Apps.AppQueryExtensions](api/e4930b2b1e7f.md) — 12 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardAccessDeniedException](api/73462c39930d.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardByteExtensions](api/000d1abb6cc0.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardCloudExtensions](api/eaab28489254.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardFileExtensions](api/aaafbcc5140b.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardFormatExtensions](api/e310bd76ba0f.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardMiscExtensions](api/32976518a9e0.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardNative](api/8fa9e5939f2a.md) — 27 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardObservation](api/08e7f5cb1150.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardRenderFormatRequest](api/8eec2d69aa42.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardStreamExtensions](api/d20da702192a.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardStringExtensions](api/80958bc275ef.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.ClipboardUpdateInformation](api/eac9cdc5a0b1.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.IClipboardAccessToken](api/be31ea83ce42.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Clipboard.StandardClipboardFormats](api/fcf5dec3f920.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Composition

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Composition.DwmApi](api/856edf7d040e.md) — 38 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Composition.Enums

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Composition.Enums.DwmBlurBehindFlags](api/de17838084c0.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Composition.Enums.DwmSetIconicLivePreviewFlags](api/aedaf8c43b2b.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Composition.Enums.DwmThumbnailPropertyFlags](api/aa823da67670.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Composition.Enums.DwmWindowAttributes](api/8597aff539bd.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Composition.Enums.DwmWindowCornerPreference](api/f12c47781124.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Composition.Structs

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Composition.Structs.DwmBlurBehind](api/e1a61dd8f6c6.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Composition.Structs.DwmThumbnailProperties](api/7105877ca428.md) — 11 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.DeviceInterfaceChangeInfo](api/e90de83f1df1.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.DeviceNotification](api/228afd813663.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.DeviceNotificationEvent](api/b52e16ea6891.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.VolumeInfo](api/4595e2b45150.md) — 3 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.Enums

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.Enums.DeviceBroadcastDeviceType](api/3c41a9978458.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.Enums.DeviceChangeEvent](api/0f3da537eec6.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.Enums.DeviceInterfaceClass](api/973a689077f9.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.Enums.DeviceNotifyFlags](api/6b6d0413f259.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.Structs

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.Structs.DevBroadcastDeviceInterface](api/f66d98013f8d.md) — 22 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.Structs.DevBroadcastHandle](api/af020073c217.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.Structs.DevBroadcastHeader](api/a38063928394.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.Structs.DevBroadcastPort](api/1e2f1ffa1ff4.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Devices.Structs.DevBroadcastVolume](api/39cef5f7f404.md) — 9 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.DisplayTopology](api/bc8b01c30bb9.md) — 4 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.BitmapScaleHandler](api/fb9f1d71db52.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue>](api/40534641540c.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.DpiApi](api/70ff418d0b62.md) — 18 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.DpiCalculator](api/d63207ee80c9.md) — 30 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.DpiChangeInfo](api/ad091ecd0cbc.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.DpiHandler](api/4b1705fdc824.md) — 31 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.NativeDpiMethods](api/5d5a2933d188.md) — 40 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Enums

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Enums.DialogDpiChangeBehaviors](api/4c9cdb3db133.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Enums.DialogScalingBehaviors](api/e72ded9c4d60.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Enums.DpiAwareness](api/9ab4102698b6.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Enums.DpiAwarenessContext](api/89bb890aef2f.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Enums.DpiHostingBehavior](api/b5c8280d8e84.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Enums.MonitorDpiType](api/fd324cdbdfbf.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Forms

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Forms.DpiAwareFormBehavior](api/5558d9e32432.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Forms.DpiUnawareFormBehavior](api/169b82f45587.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Forms.FormsDpiExtensions](api/a07fe374dbdd.md) — 4 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Wpf

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Display.Dpi.Wpf.WindowDpiExtensions](api/fb2b23f995b6.md) — 2 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.InputOperationExtensions](api/35b05363b6ac.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.InputOperations](api/48c4e32ef542.md) — 21 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.NativeInput](api/f3ef2b2697de.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.RawInputApi](api/860b37aa8ebb.md) — 20 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.RawInputDeviceChangeEventArgs](api/9063c8851607.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.RawInputDeviceInformation](api/7516ed275831.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.RawInputDeviceMonitor](api/5ac84c14ad30.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.RawInputEventArgs](api/06334e316492.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.RawInputMonitor](api/8a15035a49e6.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.ExtendedKeyFlags](api/7e93eb421431.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.ExtendedMouseFlags](api/0ef0195e156e.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.HidUsagePages](api/0897d48fde3c.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.HidUsagesConsumer](api/40db543ca357.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.HidUsagesGeneric](api/0a8987323a7d.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.HookTypes](api/4b4723b89f54.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.InputTypes](api/f19c426f4377.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.KeyEventFlags](api/fa6400d08078.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.MouseButtons](api/95aa590c2000.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.MouseButtonStates](api/dbbfadf80953.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.MouseEventFlags](api/4f962dfe0b94.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.MouseStates](api/120a17adbdc6.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.RawInputDataCommands](api/91edf8ef0067.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.RawInputDeviceFlags](api/34ecc0b9ac43.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.RawInputDeviceInfoCommands](api/8d1975046d00.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.RawInputDevices](api/8798ba436180.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.RawInputDeviceTypes](api/d04a566826d9.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.RawKeyboardFlags](api/c70c5d1c6d29.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Enums.VirtualKeyCode](api/d92eb45b66ac.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard.IKeyboardHookEventHandler](api/56b304b61f95.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard.KeyboardHandlerExtensions](api/ab0e6175f8ed.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard.KeyboardHook](api/7207b6ffe22e.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard.KeyboardHookEventArgs](api/8c34c449ba20.md) — 30 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard.KeyboardHookExtensions](api/3264882ce1c3.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard.KeyboardInputGenerator](api/2a79521b6478.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard.KeyCombinationHandler](api/579816142837.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard.KeyHelper](api/0311dd9e0f2b.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard.KeyOrCombinationHandler](api/f7263cf9d240.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard.KeySequenceHandler](api/600dc15505b2.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard.VirtualKeyCodeExtensions](api/6dbcc84ce006.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Mouse

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Mouse.MouseHook](api/0fd5aae2277d.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Mouse.MouseHookEventArgs](api/e4b355c71d6b.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Mouse.MouseInputGenerator](api/f9f36c89c67b.md) — 14 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.HardwareInput](api/172ac1893651.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.Input](api/afb3513499e4.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.InputUnion](api/c349a75e2174.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.KeyboardInput](api/6bcfb8a34abe.md) — 17 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.KeyboardLowLevelHookStruct](api/6a7333e9fe24.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.LastInputInfo](api/333243d3edf9.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.MouseInput](api/475e6fa6a5b0.md) — 23 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.MouseLowLevelHookStruct](api/2b988d18b13e.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawDevice](api/7843b8787876.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawHID](api/2194fcabc587.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawInput](api/337cac7c3211.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawInputDevice](api/59ad24c706da.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawInputDeviceInfo](api/918ab1e87df9.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawInputDeviceInfoHID](api/510555a13488.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawInputDeviceInfoKeyboard](api/1223894827b3.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawInputDeviceInfoMouse](api/907f8be9f24e.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawInputDeviceList](api/6ba251ae1160.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawInputHeader](api/3884ea7b2fb4.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawKeyboard](api/7e61cdce7a68.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Structs.RawMouse](api/feb3fff1e45a.md) — 12 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.ApplicationRestartManager](api/a8fb4920b90f.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.EndSessionMessage](api/b817bf0deee5.md) — 13 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.Enums

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.Enums.ApplicationRestartFlags](api/59eee43728fe.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Lifecycle.Enums.EndSessionReasons](api/98fe47ca0497.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Media

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Media.WinMm](api/3624e0399f44.md) — 6 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Media.Enums

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Media.Enums.SoundSettings](api/50460cae413a.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Media.Enums.SystemSounds](api/fcea4bb140c1.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.MessageLoop](api/9ac2b31b98b5.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.MessageLoop.MessageProc](api/125a7b207f15.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.SessionChangeEventArgs](api/52abcaf3c48a.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.SharedMessageWindow](api/d945639a635a.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowMessageInfo](api/06f7a95e3bda.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsMessage](api/788d22585fac.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WindowsSessionListener](api/b3a8a0d0caca.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WinProcFormsExtensions](api/29a7eb327fec.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WinProcHandler](api/9897d01f4c8e.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WinProcHandlerHook](api/56e6fb80ccf8.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WinProcListener](api/208071362219.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging.WinProcWindowsExtensions](api/b202b1ce865f.md) — 2 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Power

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Power.PowerBroadcastListener](api/ea4df67468df.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Power.PowerManagementApi](api/c2de32f97108.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Power.SystemStateApi](api/3d2092853b12.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Power.WaitableTimer](api/d7ae510fb59d.md) — 21 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Power.Enums

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Power.Enums.ExitWindowsFlags](api/44611dbe08d2.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Power.Enums.PowerBroadcastEvent](api/a7d72860ca16.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Power.Enums.ThreadExecutionStateFlags](api/742c79d6dd38.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialog](api/d9a0851950a1.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogOperationExtensions](api/a6eb2f692ebb.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileDialogResult](api/1769dedde7fd.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileOpenDialogBuilder](api/0ca72c94306c.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FileSaveDialogBuilder](api/bac92a04f64a.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Dialogs.FolderPickerBuilder](api/6b22d1edf130.md) — 6 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.BitmapIconExtensions](api/f75e7d3fbb1f.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.CapturedCursor](api/b473c69dca04.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.CursorHelper](api/0187fea7601f.md) — 14 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.IconExtensions](api/bf04dcb116c7.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.IconFileWriter](api/53f2d26e0db5.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.IconHelper](api/746e182e6dc2.md) — 26 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.IconStreamExtensions](api/e07308fe7035.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.NativeIconMethods](api/df5b5a380b7f.md) — 16 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Enums

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Enums.CopyImageFlags](api/b45a393da8b9.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Enums.DrawIconExFlags](api/7ec51bacc7c7.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Enums.FolderIconType](api/04b48b171567.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Enums.IconMetricSize](api/32c8f74c8a0d.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Enums.IconSize](api/62c43b928447.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Enums.ImageType](api/c140e07bfe1a.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Enums.LoadImageFlags](api/81eb0f6b6481.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Structs

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Structs.GrpIconDir](api/5f478fc2e177.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Structs.GrpIconDirEntry](api/234022707c5f.md) — 18 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Structs.IconDir](api/51b6fc398ef2.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Structs.IconDirEntry](api/47e1af12edd3.md) — 18 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Structs.IconInfo](api/337a250de39e.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Shell.Icons.Structs.IconInfoEx](api/463312b37630.md) — 16 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Software

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Software.InstallationInformation](api/5412044e292a.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Software.SoftwareDetails](api/10e50f70d4a2.md) — 29 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessDisplay](api/b0df249e61fa.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessMonitoring](api/ebb8afac5fab.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessPanel](api/f866f6e92d1c.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessSample](api/be104d821ad2.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessSnapshot](api/6337dd0c713d.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.BrightnessTransport](api/638c3b83c049.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.CpuMonitoring](api/5e716a482f48.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.CpuSample](api/f119094cfafe.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.CpuUtilization](api/8a2c65ccb0b1.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsAdapter](api/92094b180928.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsEngineSample](api/12f305072fa5.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsMonitoring](api/aecdc5881dde.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.GraphicsSnapshot](api/ff8f064b0cdc.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareBaseboard](api/a7d0650875ac.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareBios](api/718487488913.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareDisk](api/50ccd3f206f7.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareMachine](api/c4c0174b05f3.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareMemoryArray](api/59db47253080.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareMemoryModule](api/8c03e7f3067a.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareMonitoring](api/8a32e5971b51.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareOperatingSystem](api/113a044cf944.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwarePhysicalDisk](api/906314d7b075.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwarePnpDevice](api/f51e3c1270ae.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareProcessor](api/42cd1defede4.md) — 16 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.HardwareSnapshot](api/12aa9462e906.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.IThermalSensorProvider](api/6ad9ebacdd0a.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.LogicalProcessorSample](api/28649362479f.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.MemoryMonitoring](api/dd1891fd2ed7.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.MemorySample](api/686b60a0ce2d.md) — 17 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.MonitoringOperationExtensions](api/8a1ca2a63f8f.md) — 19 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.MonitoringResult<T>](api/09d6da1a588d.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.MonitoringSections](api/148e7863fa8c.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.MonitoringStatus](api/b4a9115cdf47.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkConnectionsSnapshot](api/6f2b22dabcb2.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkInterfaceSnapshot](api/7f19058c0595.md) — 27 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkMonitoring](api/7018932c354a.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkProtocolStatistics](api/76cdbacc7a70.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkSnapshot](api/3e44349c1b64.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NetworkTcpConnection](api/20031da81541.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.NvidiaSensorProvider](api/4ae749e31872.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PerformanceCounterMonitoring](api/75bfe737e72a.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PerformanceCounterQuery](api/24dbaa8bc432.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PerformanceCounterSample](api/14d9b79df1e6.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerBatteryFlags](api/3652e2dcafa2.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerConnection](api/b3b57c45673c.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerMonitoring](api/82dbaaf9feec.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerPlan](api/8626281dbe0b.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerPlans](api/992325b866ff.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerSample](api/941e238abff4.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.PowerSettings](api/41884d0cf64e.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessInfo](api/670f117db9b6.md) — 26 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessMonitoring](api/469dd46d3170.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessSnapshot](api/ef7995ac35a0.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ProcessTarget](api/ae6c3de7f6c0.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ServiceControlResult](api/fe349a513dcf.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ServiceInfo](api/e9f1fb5ec930.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ServiceMonitoring](api/e2cf13c919f7.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ServiceSnapshot](api/bb784f8198e0.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ServiceStartMode](api/a5887080a11b.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ServiceTarget](api/4ca383f8027f.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.StorageDiskSnapshot](api/070ffe6f596b.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.StorageDriveSnapshot](api/b1057afbaf84.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.StorageMonitoring](api/efdfb7843eef.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.StorageSnapshot](api/00b29de45223.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.SystemMonitorBuilder](api/4a0530204a60.md) — 23 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.SystemSnapshot](api/ee973004876c.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalMonitoring](api/47b19004cb6f.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSensorSample](api/c5fdbc4eb5f2.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.ThermalSnapshot](api/d73f26709a8b.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.WindowsManagement](api/f8ad7bd3faef.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.WindowsSystem](api/416f45ef28b3.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.WmiQueryResult](api/fa2cd19589df.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.WmiQueryStatus](api/d8d572bcbfff.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.SystemMonitoring.WmiRow](api/fcd77033adcf.md) — 2 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.BitmapExtensions](api/695004bc172e.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.EnvironmentChangedEventArgs](api/b321f2f05ac7.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.EnvironmentMonitor](api/624540f3b3ca.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.FormsExtensions](api/3c6b451e9019.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.IInteropWindow](api/2ea25f9be999.md) — 25 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.InteropWindow](api/2a772169f548.md) — 29 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.InteropWindowExtensions](api/74b7e19be511.md) — 54 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.InteropWindowFactory](api/2cb7e4721871.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.InteropWindowObservationExtensions](api/2d2906768d3c.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.InteropWindowQueryExtensions](api/6eeaa5194e41.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.SafeNativeWindowHandle](api/d373c8c6949c.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.SafeWinEventHookHandle](api/0ab93d942b08.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowScroller](api/265ca526a033.md) — 22 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsEnumerator](api/fdb3d181f0f4.md) — 16 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsExtensions](api/04321bdfc7e2.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMove](api/fce9c9d9cdd0.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WindowsMoveBlockMode](api/e5c2433927be.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WinEventHook](api/104051b9cbdd.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.WinEventInfo](api/29bb4b069de6.md) — 11 callable members.

### CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.Enums

- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.Enums.InteropWindowRetrieveSettings](api/e107d516fbc7.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.Enums.WinEventHookFlags](api/0b6e6a24c512.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Windows.Enums.WinEvents](api/6f2895a417f3.md) — 1 callable members.

## CP.ReactiveUI.Primitives.Windows

### CP.ReactiveUI.Primitives.Windows.Desktop.Apps

- [CP.ReactiveUI.Primitives.Windows.Desktop.Apps.AppQueryExtensions](api/dac13e9af2cc.md) — 12 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard

- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardAccessDeniedException](api/6900ad4e7acd.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardByteExtensions](api/3989b339175d.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardCloudExtensions](api/c55c90bee84a.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardFileExtensions](api/280ded5c2a55.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardFormatExtensions](api/b05740b2c6fd.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardMiscExtensions](api/bd1835557a11.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardNative](api/92ab593ec1a3.md) — 27 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardObservation](api/e47146e53efe.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardRenderFormatRequest](api/24f380393feb.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStreamExtensions](api/5863c84aeb77.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardStringExtensions](api/cbe4edf10c79.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.ClipboardUpdateInformation](api/e41c14736320.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.IClipboardAccessToken](api/31a94bdab7dd.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Clipboard.StandardClipboardFormats](api/d87d5492e3ad.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Composition

- [CP.ReactiveUI.Primitives.Windows.Desktop.Composition.DwmApi](api/d19bf56e4cdf.md) — 38 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Enums

- [CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Enums.DwmBlurBehindFlags](api/9fc69ffdba4e.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Enums.DwmSetIconicLivePreviewFlags](api/b12c21a2deb9.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Enums.DwmThumbnailPropertyFlags](api/f6d6b1ccfd7d.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Enums.DwmWindowAttributes](api/80ef324cbcac.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Enums.DwmWindowCornerPreference](api/e6137e274aba.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs

- [CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmBlurBehind](api/3cdf82bf79ca.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Composition.Structs.DwmThumbnailProperties](api/108b0561b55b.md) — 11 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Devices

- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.DeviceInterfaceChangeInfo](api/615b1cc02bc1.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.DeviceNotification](api/0684ae916143.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.DeviceNotificationEvent](api/a9140dfea4e4.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.VolumeInfo](api/a81695674338.md) — 3 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Enums

- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Enums.DeviceBroadcastDeviceType](api/b3d519389eaf.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Enums.DeviceChangeEvent](api/86ebe0eadb21.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Enums.DeviceInterfaceClass](api/ea9f4d0cd8c2.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Enums.DeviceNotifyFlags](api/9e7b18daea1a.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs

- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastDeviceInterface](api/6fbf95ebbba8.md) — 22 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastHandle](api/52fe3c70c3a0.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastHeader](api/fd1e3c18287b.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastPort](api/9e9148995421.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Devices.Structs.DevBroadcastVolume](api/a66cfb2d1ba7.md) — 9 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Display

- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.DisplayTopology](api/34ee41b785b2.md) — 4 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi

- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler](api/e98397f687db.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue>](api/bcdcb57a51b4.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.DpiApi](api/b7e59d391117.md) — 18 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.DpiCalculator](api/d2bbce2afcdc.md) — 30 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.DpiChangeInfo](api/23f8279a92aa.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.DpiHandler](api/a4810db616a4.md) — 31 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.NativeDpiMethods](api/c2f2854905f7.md) — 40 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Enums

- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Enums.DialogDpiChangeBehaviors](api/487fb48643a6.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Enums.DialogScalingBehaviors](api/991089b2f409.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Enums.DpiAwareness](api/ba4f46665a41.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Enums.DpiAwarenessContext](api/2f44b7644b3a.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Enums.DpiHostingBehavior](api/df4a2403dd33.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Enums.MonitorDpiType](api/18b0266a655d.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Forms

- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Forms.DpiAwareFormBehavior](api/8cda5b93fa5a.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Forms.DpiUnawareFormBehavior](api/c429fc28b36f.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Forms.FormsDpiExtensions](api/816d654b9902.md) — 4 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Wpf

- [CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.Wpf.WindowDpiExtensions](api/c6a407d507bc.md) — 2 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Input

- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperationExtensions](api/9c1bc93f4010.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.InputOperations](api/a769aa9cb7ef.md) — 21 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.NativeInput](api/1a6b9f812fcb.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.RawInputApi](api/d435165faf94.md) — 20 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.RawInputDeviceChangeEventArgs](api/c8c661a343ac.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.RawInputDeviceInformation](api/3048e8faf071.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.RawInputDeviceMonitor](api/84403513f568.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.RawInputEventArgs](api/ed44fd1008b4.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.RawInputMonitor](api/0ad80cf6193d.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums

- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.ExtendedKeyFlags](api/538cafa70e90.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.ExtendedMouseFlags](api/7a67129c5252.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.HidUsagePages](api/0e9c19b60926.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.HidUsagesConsumer](api/6f25d2c31a7e.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.HidUsagesGeneric](api/e7b390f1607c.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.HookTypes](api/ec5b5d7b1a07.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.InputTypes](api/c3bf653443d7.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.KeyEventFlags](api/4b14a1c10646.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtons](api/aaae8649a743.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseButtonStates](api/61dc0c443949.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseEventFlags](api/c69c299f51db.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.MouseStates](api/4b14d53d568a.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.RawInputDataCommands](api/91e2b62b7d36.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.RawInputDeviceFlags](api/87ce9fd0f9b5.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.RawInputDeviceInfoCommands](api/f66f2b1e82d1.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.RawInputDevices](api/add68c6d4696.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.RawInputDeviceTypes](api/b43863226566.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.RawKeyboardFlags](api/30c480e9b456.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Enums.VirtualKeyCode](api/1810ba78d5d2.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard

- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.IKeyboardHookEventHandler](api/cfb67567e8eb.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHandlerExtensions](api/12c9af82ed8a.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHook](api/1b111112e33d.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookEventArgs](api/0efe4adfeda9.md) — 30 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardHookExtensions](api/4072fdea3a1a.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyboardInputGenerator](api/570373e9d6a4.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyCombinationHandler](api/ca178d42481e.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyHelper](api/654af6dc4d60.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeyOrCombinationHandler](api/8e927ac0e440.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.KeySequenceHandler](api/b50778b88629.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard.VirtualKeyCodeExtensions](api/c70fc86868aa.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Input.Mouse

- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Mouse.MouseHook](api/9f1436d26742.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Mouse.MouseHookEventArgs](api/c7f0cafa99f8.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Mouse.MouseInputGenerator](api/4d743dc992ab.md) — 14 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs

- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.HardwareInput](api/f71a16d2f03b.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.Input](api/206b79b935ba.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.InputUnion](api/c54ef6644a83.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardInput](api/43c0aedabca9.md) — 17 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.KeyboardLowLevelHookStruct](api/9291f1ff4fef.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.LastInputInfo](api/eb64fba03161.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseInput](api/a61dacb8c6e0.md) — 23 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.MouseLowLevelHookStruct](api/c8d927bf6f19.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawDevice](api/962d05637871.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawHID](api/15c99f489457.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInput](api/d2040535061d.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDevice](api/22d159c9b813.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfo](api/7faaf8cc4275.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoHID](api/e777defc5756.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoKeyboard](api/ebbda0ae57e5.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceInfoMouse](api/2e97c6bfb50a.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputDeviceList](api/27bbbd1fab66.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawInputHeader](api/297d14bb419d.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawKeyboard](api/77f29679b1a9.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Input.Structs.RawMouse](api/bd7ee0c4dd5a.md) — 12 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle

- [CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.ApplicationRestartManager](api/0cbab8d99ebf.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.EndSessionMessage](api/5651fdab1d63.md) — 13 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums

- [CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.ApplicationRestartFlags](api/d1609b9b5aef.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Lifecycle.Enums.EndSessionReasons](api/091cab8b9a2a.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Media

- [CP.ReactiveUI.Primitives.Windows.Desktop.Media.WinMm](api/b436329080b9.md) — 6 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Media.Enums

- [CP.ReactiveUI.Primitives.Windows.Desktop.Media.Enums.SoundSettings](api/8ad1fe5519ba.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Media.Enums.SystemSounds](api/a8dea39301f2.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Messaging

- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop](api/fcb36746e826.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.MessageLoop.MessageProc](api/dd5db9325eee.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.SessionChangeEventArgs](api/af7d9d3b47ae.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.SharedMessageWindow](api/51512b94fb1a.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WindowMessageInfo](api/6ed54e685b85.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WindowsMessage](api/ecd541e5914e.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WindowsSessionListener](api/78d384b36ef2.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcFormsExtensions](api/83e98fc7139a.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcHandler](api/1debbd1583e7.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcHandlerHook](api/eed464a6e4de.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcListener](api/15a762a322b3.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Messaging.WinProcWindowsExtensions](api/9fc2c4a91afb.md) — 2 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Power

- [CP.ReactiveUI.Primitives.Windows.Desktop.Power.PowerBroadcastListener](api/bd1d55e2045e.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Power.PowerManagementApi](api/7c65f00d0989.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Power.SystemStateApi](api/17e82683d24a.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Power.WaitableTimer](api/e0cfdd7ec1aa.md) — 21 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Power.Enums

- [CP.ReactiveUI.Primitives.Windows.Desktop.Power.Enums.ExitWindowsFlags](api/f8f598f8b22b.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Power.Enums.PowerBroadcastEvent](api/5d0dc7c112aa.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Power.Enums.ThreadExecutionStateFlags](api/72b817cde3fa.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Dialogs

- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Dialogs.FileDialog](api/f050e584353e.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Dialogs.FileDialogOperationExtensions](api/2352d6f92955.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Dialogs.FileDialogResult](api/6ef7c64f3fbd.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Dialogs.FileOpenDialogBuilder](api/af6e8e0fec6b.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Dialogs.FileSaveDialogBuilder](api/345175dcc950.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Dialogs.FolderPickerBuilder](api/c0d0069e1d9d.md) — 6 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons

- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.BitmapIconExtensions](api/28efb5befbdb.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.CapturedCursor](api/9f45c2e15358.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.CursorHelper](api/8887ce04c5fd.md) — 14 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconExtensions](api/6ce189e5a59b.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconFileWriter](api/91836a046b02.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconHelper](api/fd73ddd1c6ae.md) — 26 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.IconStreamExtensions](api/1b02c181b844.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.NativeIconMethods](api/c75d146bb0be.md) — 16 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums

- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.CopyImageFlags](api/2a6fbdf51df9.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.DrawIconExFlags](api/e98c4ef4e249.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.FolderIconType](api/1ca56c0e7a9b.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconMetricSize](api/1e98429e903f.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.IconSize](api/2fcc1ab82ba1.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.ImageType](api/6b81269f1f7e.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Enums.LoadImageFlags](api/62d277bb8386.md) — 1 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Structs

- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Structs.GrpIconDir](api/ad4267fa5043.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Structs.GrpIconDirEntry](api/496555cc0a99.md) — 18 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Structs.IconDir](api/51da61d45e42.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Structs.IconDirEntry](api/c8157e313cbd.md) — 18 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Structs.IconInfo](api/0e0026d6c95d.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Shell.Icons.Structs.IconInfoEx](api/8aaec6105676.md) — 16 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Software

- [CP.ReactiveUI.Primitives.Windows.Desktop.Software.InstallationInformation](api/bb9577972ecc.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Software.SoftwareDetails](api/facfb0f1f98b.md) — 29 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring

- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessDisplay](api/33eaa4fe75ae.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessMonitoring](api/0b24d3ae4924.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessPanel](api/9cda2188931a.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessSample](api/870518ea5d2d.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessSnapshot](api/0d31345b16d2.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.BrightnessTransport](api/a87eb827f76e.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.CpuMonitoring](api/f0452510d823.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.CpuSample](api/ddb88f099754.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.CpuUtilization](api/06f8abf6079b.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.GraphicsAdapter](api/2bb419565cf7.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.GraphicsEngineSample](api/1c6bcd7a5275.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.GraphicsMonitoring](api/e62b5e2cfd51.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.GraphicsSnapshot](api/c8e3fac10246.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareBaseboard](api/78b88670efab.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareBios](api/310aea3cc4f5.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareDisk](api/41513a1bac81.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareMachine](api/00bd952c0b9c.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareMemoryArray](api/943d40ee83a3.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareMemoryModule](api/499e8d958dbb.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareMonitoring](api/2dcb615d8e86.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareOperatingSystem](api/32487dccf3f2.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwarePhysicalDisk](api/fc1ca8c15ce4.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwarePnpDevice](api/041806aed722.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareProcessor](api/7eec3c003d5c.md) — 16 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.HardwareSnapshot](api/aab40a1ff0f2.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.IThermalSensorProvider](api/f2d854378cd5.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.LogicalProcessorSample](api/d7889d1865f7.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MemoryMonitoring](api/e8522a311ee5.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MemorySample](api/a465f0a9eb04.md) — 17 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringOperationExtensions](api/dfee4f5bd422.md) — 19 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringResult<T>](api/5a7d1aa32461.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringSections](api/5e263ff56fed.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.MonitoringStatus](api/cd15af85a04e.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkConnectionsSnapshot](api/1d459ae4116d.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkInterfaceSnapshot](api/2d8dfbc2efd7.md) — 27 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkMonitoring](api/207c8ed4b2df.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkProtocolStatistics](api/35659947a38a.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkSnapshot](api/2d5f4cd1d68d.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NetworkTcpConnection](api/884b5f4fb16c.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.NvidiaSensorProvider](api/1a28f5b0bd6f.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PerformanceCounterMonitoring](api/75e282d37b75.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PerformanceCounterQuery](api/4352382459a3.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PerformanceCounterSample](api/18ff167cee0f.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerBatteryFlags](api/469c7b617684.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerConnection](api/74bc703be61f.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerMonitoring](api/78809c107068.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlan](api/27a3b8116c02.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerPlans](api/1e39b7893ba8.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerSample](api/1e609403c5ff.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.PowerSettings](api/a17fa8273e5b.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessInfo](api/40bf72f9a5ca.md) — 26 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessMonitoring](api/40b12f0ea559.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessSnapshot](api/8ac0ec4cbdaa.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ProcessTarget](api/3a73701fef83.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceControlResult](api/abc688eb4e68.md) — 5 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceInfo](api/620d08370219.md) — 12 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceMonitoring](api/add01a13d70e.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceSnapshot](api/7f253375eedf.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceStartMode](api/9a07194413c6.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ServiceTarget](api/3faa56d05e72.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.StorageDiskSnapshot](api/9442da77856c.md) — 11 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.StorageDriveSnapshot](api/d4d988669aa4.md) — 10 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.StorageMonitoring](api/7ffbae2abd90.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.StorageSnapshot](api/d4a0f5f56949.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.SystemMonitorBuilder](api/b397292f92a4.md) — 23 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.SystemSnapshot](api/3ce4fe1b5552.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ThermalMonitoring](api/8a5d20b3cc2f.md) — 4 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ThermalSensorSample](api/ed04a7f7f50c.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.ThermalSnapshot](api/3e3df4efa1cc.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WindowsManagement](api/5ea07c0192ce.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WindowsSystem](api/b995515601c3.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiQueryResult](api/fd7c53a6cc9a.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiQueryStatus](api/6f65bd489142.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.SystemMonitoring.WmiRow](api/57f1748508d9.md) — 2 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Windows

- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.BitmapExtensions](api/47d062ac404d.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentChangedEventArgs](api/b4efbfcd9fc0.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.EnvironmentMonitor](api/d56bec0b0b37.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.FormsExtensions](api/e2a81596fd7b.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.IInteropWindow](api/b154fd9efc97.md) — 25 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.InteropWindow](api/7a076401f9aa.md) — 29 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.InteropWindowExtensions](api/f9fd17d527c2.md) — 54 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.InteropWindowFactory](api/0c6f767a69bf.md) — 3 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.InteropWindowObservationExtensions](api/5fba84ae21f4.md) — 8 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.InteropWindowQueryExtensions](api/4638b93c7b60.md) — 13 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.SafeNativeWindowHandle](api/1f822191f93e.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.SafeWinEventHookHandle](api/082c70f7c77d.md) — 2 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowScroller](api/5279081a13ea.md) — 22 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsEnumerator](api/9d317935b8aa.md) — 16 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsExtensions](api/0dffca382eb4.md) — 9 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsMove](api/1fc51f6c18b4.md) — 7 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WindowsMoveBlockMode](api/9c1dca44a146.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WinEventHook](api/6252b0d5d6c1.md) — 6 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.WinEventInfo](api/1293277fd9dc.md) — 11 callable members.

### CP.ReactiveUI.Primitives.Windows.Desktop.Windows.Enums

- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.Enums.InteropWindowRetrieveSettings](api/7fa708fa8f48.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.Enums.WinEventHookFlags](api/ba24f3a0018c.md) — 1 callable members.
- [CP.ReactiveUI.Primitives.Windows.Desktop.Windows.Enums.WinEvents](api/98905557e9ab.md) — 1 callable members.
