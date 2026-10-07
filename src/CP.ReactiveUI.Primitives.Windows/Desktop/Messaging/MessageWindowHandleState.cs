// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#nullable enable

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Messaging;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.Messaging;
#endif

/// <summary>Publishes handles only for the current message-loop generation.</summary>
/// <param name="publish">Publishes active handle changes.</param>
internal sealed class MessageWindowHandleState(Action<nint> publish)
{
    /// <summary>Serializes generation changes and their notifications.</summary>
    private readonly Lock _gate = new();

    /// <summary>The message-loop generation currently allowed to publish.</summary>
    private object? _owner;

    /// <summary>Activates a generation without replaying a previous window handle.</summary>
    /// <param name="owner">The new generation identity.</param>
    internal void Activate(object owner)
    {
        lock (_gate)
        {
            _owner = owner;
            publish(0);
        }
    }

    /// <summary>Publishes a handle if its generation remains active.</summary>
    /// <param name="owner">The generation publishing the handle.</param>
    /// <param name="handle">The native window handle.</param>
    internal void Publish(object owner, nint handle)
    {
        lock (_gate)
        {
            if (ReferenceEquals(_owner, owner))
            {
                publish(handle);
            }
        }
    }

    /// <summary>Invalidates the current generation before native window teardown.</summary>
    /// <param name="owner">The generation being released.</param>
    internal void Release(object owner)
    {
        lock (_gate)
        {
            if (ReferenceEquals(_owner, owner))
            {
                _owner = null;
                publish(0);
            }
        }
    }
}
