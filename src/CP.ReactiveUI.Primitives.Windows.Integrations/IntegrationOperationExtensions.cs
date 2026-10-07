// Copyright (c) 2019-2026 Chris Pulman and contributors. All rights reserved.
// Chris Pulman and contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Threading;
using CP.ReactiveUI.Primitives.Windows.Integrations.Browser;
using CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Host;
using CP.ReactiveUI.Primitives.Windows.Integrations.Citrix.Ipc;
using CP.ReactiveUI.Primitives.Windows.Operations;
using ReactiveUI.Primitives;

namespace CP.ReactiveUI.Primitives.Windows.Integrations;

/// <summary>Creates deferred operations on existing integration instances. Receivers remain owned by the caller.</summary>
public static class IntegrationOperationExtensions
{
    /// <summary>Deferred operations for the caller-owned session.</summary>
    /// <param name="session">The existing integration instance.</param>
    extension(CitrixVirtualChannelSession session)
    {
        /// <summary>Defers explicitly closing an existing session through its idempotent close method.</summary>
        /// <returns>The deferred operation.</returns>
        public WindowsOperation<CitrixVirtualChannelCloseResult> CloseOperation() =>
            session.CloseOperation(CancellationToken.None);

        /// <summary>Defers explicitly closing an existing session through its idempotent close method.</summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deferred operation.</returns>
        public WindowsOperation<CitrixVirtualChannelCloseResult> CloseOperation(CancellationToken cancellationToken)
        {
            Throw.IfNull(session);
            return WindowsOperation.From(() => session.Close(cancellationToken));
        }
    }

    /// <summary>Deferred operations for the caller-owned browser.</summary>
    /// <param name="browser">The existing integration instance.</param>
    extension(ExtendedWebBrowser browser)
    {
        /// <summary>Defers navigation until execution on the browser's owning UI thread.</summary>
        /// <param name="url">The operation input.</param>
        /// <returns>The deferred operation.</returns>
        public WindowsOperation<RxVoid> NavigateOperation(Uri url)
        {
            Throw.IfNull(browser);
            Throw.IfNull(url);
            return WindowsOperation.From(() => browser.Navigate(url));
        }

        /// <summary>Defers refreshing until execution on the browser's owning UI thread.</summary>
        /// <returns>The deferred operation.</returns>
        public WindowsOperation<RxVoid> RefreshOperation()
        {
            Throw.IfNull(browser);
            return WindowsOperation.From(browser.Refresh);
        }
    }

    /// <summary>Deferred operations for the caller-owned api.</summary>
    /// <param name="api">The existing integration instance.</param>
    extension(ICitrixCcmHostSessionApi api)
    {
        /// <summary>Defers retrieving CCM session information.</summary>
        /// <param name="sessionId">The operation input.</param>
        /// <returns>The deferred operation.</returns>
        public WindowsOperation<CcmHostSessionInformationResult> GetSessionInfoOperation(int sessionId)
        {
            Throw.IfNull(api);
            return WindowsOperation.From(() => api.GetSessionInfo(sessionId));
        }

        /// <summary>Defers disconnecting a CCM session.</summary>
        /// <param name="sessionId">The operation input.</param>
        /// <returns>The deferred operation.</returns>
        public WindowsOperation<CcmHostOperationResult> DisconnectSessionOperation(int sessionId)
        {
            Throw.IfNull(api);
            return WindowsOperation.From(() => api.DisconnectSession(sessionId));
        }

        /// <summary>Defers logging off a CCM session.</summary>
        /// <param name="sessionId">The operation input.</param>
        /// <returns>The deferred operation.</returns>
        public WindowsOperation<CcmHostOperationResult> LogoffSessionOperation(int sessionId)
        {
            Throw.IfNull(api);
            return WindowsOperation.From(() => api.LogoffSession(sessionId));
        }
    }

    /// <summary>Deferred operations for the caller-owned adapter.</summary>
    /// <param name="adapter">The existing integration instance.</param>
    extension(ICitrixVirtualDriverAdapter adapter)
    {
        /// <summary>Defers opening a virtual channel. The resulting session must be disposed by its caller.</summary>
        /// <param name="request">The operation input.</param>
        /// <returns>The deferred operation.</returns>
        public WindowsOperation<CitrixVirtualChannelSession> DriverOpenOperation(CitrixVirtualChannelOpenRequest request) =>
            adapter.DriverOpenOperation(request, CancellationToken.None);

        /// <summary>Defers opening a virtual channel. The resulting session must be disposed by its caller.</summary>
        /// <param name="request">The operation input.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deferred operation.</returns>
        public WindowsOperation<CitrixVirtualChannelSession> DriverOpenOperation(CitrixVirtualChannelOpenRequest request, CancellationToken cancellationToken)
        {
            Throw.IfNull(adapter);
            Throw.IfNull(request);
            return WindowsOperation.From(() => new CitrixVirtualChannelSession(adapter, adapter.DriverOpen(request, cancellationToken)));
        }

        /// <summary>Defers closing a virtual channel.</summary>
        /// <param name="channel">The operation input.</param>
        /// <returns>The deferred operation.</returns>
        public WindowsOperation<CitrixVirtualChannelCloseResult> DriverCloseOperation(CitrixVirtualChannelHandle channel) =>
            adapter.DriverCloseOperation(channel, CancellationToken.None);

        /// <summary>Defers closing a virtual channel.</summary>
        /// <param name="channel">The operation input.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deferred operation.</returns>
        public WindowsOperation<CitrixVirtualChannelCloseResult> DriverCloseOperation(CitrixVirtualChannelHandle channel, CancellationToken cancellationToken)
        {
            Throw.IfNull(adapter);
            return WindowsOperation.From(() => adapter.DriverClose(channel, cancellationToken));
        }

        /// <summary>Defers writing to a virtual channel.</summary>
        /// <param name="request">The operation input.</param>
        /// <returns>The deferred operation.</returns>
        public WindowsOperation<CitrixVirtualChannelWriteResult> DriverWriteOperation(CitrixVirtualChannelWriteRequest request) =>
            adapter.DriverWriteOperation(request, CancellationToken.None);

        /// <summary>Defers writing to a virtual channel.</summary>
        /// <param name="request">The operation input.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deferred operation.</returns>
        public WindowsOperation<CitrixVirtualChannelWriteResult> DriverWriteOperation(CitrixVirtualChannelWriteRequest request, CancellationToken cancellationToken)
        {
            Throw.IfNull(adapter);
            Throw.IfNull(request);
            return WindowsOperation.From(() => adapter.DriverWrite(request, cancellationToken));
        }

        /// <summary>Defers registering a virtual-channel feature.</summary>
        /// <param name="feature">The operation input.</param>
        /// <returns>The deferred operation.</returns>
        public WindowsOperation<CitrixVirtualChannelFeatureRegistration> RegisterFeatureOperation(CitrixVirtualChannelFeature feature) =>
            adapter.RegisterFeatureOperation(feature, CancellationToken.None);

        /// <summary>Defers registering a virtual-channel feature.</summary>
        /// <param name="feature">The operation input.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deferred operation.</returns>
        public WindowsOperation<CitrixVirtualChannelFeatureRegistration> RegisterFeatureOperation(CitrixVirtualChannelFeature feature, CancellationToken cancellationToken)
        {
            Throw.IfNull(adapter);
            Throw.IfNull(feature);
            return WindowsOperation.From(() => adapter.VdRegisterFeature(feature, cancellationToken));
        }
    }
}
