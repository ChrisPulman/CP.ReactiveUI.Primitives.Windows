// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using CP.ReactiveUI.Primitives.Windows.Operations;

#if REACTIVE_SHIM
namespace CP.ReactiveUI.Primitives.Windows.Reactive.Desktop.Input.Keyboard;
#else
namespace CP.ReactiveUI.Primitives.Windows.Desktop.Input.Keyboard;
#endif

/// <summary>Provides fluent configuration and deferred keyboard event processing.</summary>
public static class KeyboardHandlerExtensions
{
    /// <summary>Provides deferred processing for keyboard events.</summary>
    /// <param name="handler">The keyboard event handler.</param>
    extension(IKeyboardHookEventHandler handler)
    {
        /// <summary>Creates a deferred operation that processes a keyboard event once per capture or subscription.</summary>
        /// <param name="keyboardEvent">The event to process.</param>
        /// <returns>The operation reporting whether the event matched the handler.</returns>
        public WindowsOperation<bool> HandleOperation(KeyboardHookEventArgs keyboardEvent)
        {
            Throw.IfNull(handler, nameof(handler));
            Throw.IfNull(keyboardEvent, nameof(keyboardEvent));
            return WindowsOperation.From(() => handler.Handle(keyboardEvent));
        }
    }

    /// <summary>Provides fluent configuration for a key combination.</summary>
    /// <param name="handler">The handler to configure.</param>
    extension(KeyCombinationHandler handler)
    {
        /// <summary>Configures a key combination and returns its handler for further configuration.</summary>
        /// <param name="keys">The combination keys.</param>
        /// <returns>The configured handler.</returns>
        public KeyCombinationHandler ConfigureFluent(IEnumerable<VirtualKeyCode> keys)
        {
            Throw.IfNull(handler, nameof(handler));
            Throw.IfNull(keys, nameof(keys));
            handler.Configure(keys);
            return handler;
        }
    }

    /// <summary>Provides fluent configuration for a key sequence.</summary>
    /// <param name="handler">The handler to configure.</param>
    extension(KeySequenceHandler handler)
    {
        /// <summary>Configures a key sequence and returns its handler for further configuration.</summary>
        /// <param name="handlers">The handlers making up the sequence.</param>
        /// <returns>The configured handler.</returns>
        public KeySequenceHandler ConfigureFluent(IEnumerable<IKeyboardHookEventHandler> handlers)
        {
            Throw.IfNull(handler, nameof(handler));
            Throw.IfNull(handlers, nameof(handlers));
            handler.Configure(handlers);
            return handler;
        }
    }
}
