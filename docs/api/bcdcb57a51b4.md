<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->

# CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue>

Package: `CP.ReactiveUI.Primitives.Windows`. [API index](../api-reference-generated.md).

## Callable members

- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler\`2.AddApplyAction(System.Action{\`1},\`0)](#api-e3f2286d54db)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler\`2.AddApplyAction(System.Action{\`1},\`0,System.Boolean)](#api-13d6d1318050)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler\`2.AddTarget(System.Windows.Forms.Button,\`0,System.Func{\`1,System.Drawing.Bitmap})](#api-30927e8515a6)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler\`2.AddTarget(System.Windows.Forms.Button,\`0,System.Func{\`1,System.Drawing.Bitmap},System.Boolean)](#api-5f691ae9cbc7)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler\`2.AddTarget(System.Windows.Forms.ToolStripItem,\`0,System.Func{\`1,System.Drawing.Bitmap})](#api-8f34f706ee5e)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler\`2.AddTarget(System.Windows.Forms.ToolStripItem,\`0,System.Func{\`1,System.Drawing.Bitmap},System.Boolean)](#api-d2c3d82c48e0)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler\`2.Dispose](#api-06898d473c67)
- [M:CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler\`2.RemoveTarget(System.Object)](#api-8418310c0aa9)

<a id="api-e3f2286d54db"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler`2.AddApplyAction(System.Action{`1},`0)`

Add an action which applies a bitmap.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue> CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue>.AddApplyAction(System.Action<TValue> apply, TKey imageKey)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Display/Dpi/BitmapScaleHandler{TKey,TValue}.cs:54`.

- `apply` (`System.Action<TValue>`): Action which assigns a bitmap.
- `imageKey` (`TKey`): Key of the image.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TKey, TValue>(global::CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue> receiver, global::System.Action<TValue> @apply, TKey @imageKey, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue>> operationObserver)
    where TValue : global::System.IDisposable
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@AddApplyAction(@apply, @imageKey)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-13d6d1318050"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler`2.AddApplyAction(System.Action{`1},`0,System.Boolean)`

Add an action which applies a bitmap.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue> CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue>.AddApplyAction(System.Action<TValue> apply, TKey imageKey, bool execute)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Display/Dpi/BitmapScaleHandler{TKey,TValue}.cs:61`.

- `apply` (`System.Action<TValue>`): Action which assigns a bitmap.
- `imageKey` (`TKey`): Key of the image.
- `execute` (`bool`): A value indicating whether the assignment is executed immediately.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TKey, TValue>(global::CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue> receiver, global::System.Action<TValue> @apply, TKey @imageKey, global::System.Boolean @execute, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue>> operationObserver)
    where TValue : global::System.IDisposable
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@AddApplyAction(@apply, @imageKey, @execute)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-30927e8515a6"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler`2.AddTarget(System.Windows.Forms.Button,`0,System.Func{`1,System.Drawing.Bitmap})`

Add a button as a bitmap target.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue> CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue>.AddTarget(System.Windows.Forms.Button button, TKey imageKey, System.Func<TValue, System.Drawing.Bitmap> valueConverter)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Display/Dpi/BitmapScaleHandler{TKey,TValue}.cs:87`.

- `button` (`System.Windows.Forms.Button`): The target button.
- `imageKey` (`TKey`): Key of the image.
- `valueConverter` (`System.Func<TValue, System.Drawing.Bitmap>`): Function that converts the value to a bitmap.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TKey, TValue>(global::CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue> receiver, global::System.Windows.Forms.Button @button, TKey @imageKey, global::System.Func<TValue, global::System.Drawing.Bitmap> @valueConverter, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue>> operationObserver)
    where TValue : global::System.IDisposable
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@AddTarget(@button, @imageKey, @valueConverter)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-5f691ae9cbc7"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler`2.AddTarget(System.Windows.Forms.Button,`0,System.Func{`1,System.Drawing.Bitmap},System.Boolean)`

Add a button as a bitmap target.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue> CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue>.AddTarget(System.Windows.Forms.Button button, TKey imageKey, System.Func<TValue, System.Drawing.Bitmap> valueConverter, bool execute)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Display/Dpi/BitmapScaleHandler{TKey,TValue}.cs:95`.

- `button` (`System.Windows.Forms.Button`): The target button.
- `imageKey` (`TKey`): Key of the image.
- `valueConverter` (`System.Func<TValue, System.Drawing.Bitmap>`): Function that converts the value to a bitmap.
- `execute` (`bool`): A value indicating whether the assignment is executed immediately.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TKey, TValue>(global::CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue> receiver, global::System.Windows.Forms.Button @button, TKey @imageKey, global::System.Func<TValue, global::System.Drawing.Bitmap> @valueConverter, global::System.Boolean @execute, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue>> operationObserver)
    where TValue : global::System.IDisposable
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@AddTarget(@button, @imageKey, @valueConverter, @execute)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-8f34f706ee5e"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler`2.AddTarget(System.Windows.Forms.ToolStripItem,`0,System.Func{`1,System.Drawing.Bitmap})`

Add a tool strip item as a bitmap target.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue> CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue>.AddTarget(System.Windows.Forms.ToolStripItem toolStripItem, TKey imageKey, System.Func<TValue, System.Drawing.Bitmap> valueConverter)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Display/Dpi/BitmapScaleHandler{TKey,TValue}.cs:106`.

- `toolStripItem` (`System.Windows.Forms.ToolStripItem`): The target tool strip item.
- `imageKey` (`TKey`): Key of the image.
- `valueConverter` (`System.Func<TValue, System.Drawing.Bitmap>`): Function that converts the value to a bitmap.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TKey, TValue>(global::CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue> receiver, global::System.Windows.Forms.ToolStripItem @toolStripItem, TKey @imageKey, global::System.Func<TValue, global::System.Drawing.Bitmap> @valueConverter, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue>> operationObserver)
    where TValue : global::System.IDisposable
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@AddTarget(@toolStripItem, @imageKey, @valueConverter)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-d2c3d82c48e0"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler`2.AddTarget(System.Windows.Forms.ToolStripItem,`0,System.Func{`1,System.Drawing.Bitmap},System.Boolean)`

Add a tool strip item as a bitmap target.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue> CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue>.AddTarget(System.Windows.Forms.ToolStripItem toolStripItem, TKey imageKey, System.Func<TValue, System.Drawing.Bitmap> valueConverter, bool execute)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Display/Dpi/BitmapScaleHandler{TKey,TValue}.cs:118`.

- `toolStripItem` (`System.Windows.Forms.ToolStripItem`): The target tool strip item.
- `imageKey` (`TKey`): Key of the image.
- `valueConverter` (`System.Func<TValue, System.Drawing.Bitmap>`): Function that converts the value to a bitmap.
- `execute` (`bool`): A value indicating whether the assignment is executed immediately.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TKey, TValue>(global::CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue> receiver, global::System.Windows.Forms.ToolStripItem @toolStripItem, TKey @imageKey, global::System.Func<TValue, global::System.Drawing.Bitmap> @valueConverter, global::System.Boolean @execute, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue>> operationObserver)
    where TValue : global::System.IDisposable
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@AddTarget(@toolStripItem, @imageKey, @valueConverter, @execute)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-06898d473c67"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler`2.Dispose`

Dispose implementation.

```csharp
public void CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue>.Dispose()
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Display/Dpi/BitmapScaleHandler{TKey,TValue}.cs:125`.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TKey, TValue>(global::CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue> receiver, global::System.IObserver<global::ReactiveUI.Primitives.RxVoid> operationObserver)
    where TValue : global::System.IDisposable
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@Dispose()).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```

<a id="api-8418310c0aa9"></a>

## `M:CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler`2.RemoveTarget(System.Object)`

Remove a previously added target.

```csharp
public CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue> CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue>.RemoveTarget(object target)
```

Availability: net10.0-windows, net462, net472, net48, net481, net8.0-windows, net9.0-windows. Source: `src/CP.ReactiveUI.Primitives.Windows/Desktop/Display/Dpi/BitmapScaleHandler{TKey,TValue}.cs:134`.

- `target` (`object`): The target to remove.

```csharp
internal static class ApiExample
{
    internal static global::System.IDisposable Call<TKey, TValue>(global::CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue> receiver, global::System.Object @target, global::System.IObserver<global::CP.ReactiveUI.Primitives.Windows.Desktop.Display.Dpi.BitmapScaleHandler<TKey, TValue>> operationObserver)
    where TValue : global::System.IDisposable
    {
        return global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => receiver.@RemoveTarget(@target)).Select(value => value).Observe().Subscribe(operationObserver);
    }
}
```
