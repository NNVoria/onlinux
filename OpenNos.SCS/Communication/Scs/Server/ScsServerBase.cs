// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Server.ScsServerBase
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Collections;
using OpenNos.SCS.Communication.Scs.Communication.Channels;
using OpenNos.SCS.Communication.Scs.Communication.Protocols;
using System;
using System.Runtime.CompilerServices;

namespace OpenNos.SCS.Communication.Scs.Server
{
  internal abstract class ScsServerBase : IScsServer
  {
    private IConnectionListener _connectionListener;

    [CompilerGenerated]
    public event EventHandler<ServerClientEventArgs> ClientConnected;

    [CompilerGenerated]
    public event EventHandler<ServerClientEventArgs> ClientDisconnected;

    public IScsWireProtocolFactory WireProtocolFactory { get; set; }

    public ThreadSafeSortedList<long, IScsServerClient> Clients { get; private set; }

    protected ScsServerBase()
    {
      this.Clients = new ThreadSafeSortedList<long, IScsServerClient>();
      this.WireProtocolFactory = WireProtocolManager.GetDefaultWireProtocolFactory();
    }

    public virtual void Start()
    {
      this._connectionListener = this.CreateConnectionListener();
      this._connectionListener.CommunicationChannelConnected += new EventHandler<CommunicationChannelEventArgs>(this.ConnectionListener_CommunicationChannelConnected);
      this._connectionListener.Start();
    }

    public virtual void Stop()
    {
      if (this._connectionListener != null)
        this._connectionListener.Stop();
      foreach (IScsServerClient allItem in this.Clients.GetAllItems())
        allItem.Disconnect();
    }

    protected abstract IConnectionListener CreateConnectionListener();

    private void ConnectionListener_CommunicationChannelConnected(
      object sender,
      CommunicationChannelEventArgs e)
    {
      ScsServerClient scsServerClient = new ScsServerClient(e.Channel) { ClientId = ScsServerManager.GetClientId(), WireProtocol = this.WireProtocolFactory.CreateWireProtocol() };
      scsServerClient.Disconnected += new EventHandler(this.Client_Disconnected);
      this.Clients[scsServerClient.ClientId] = (IScsServerClient) scsServerClient;
      this.OnClientConnected((IScsServerClient) scsServerClient);
      e.Channel.Start();
    }

    private void Client_Disconnected(object sender, EventArgs e)
    {
      IScsServerClient client = (IScsServerClient) sender;
      this.Clients.Remove(client.ClientId);
      this.OnClientDisconnected(client);
    }

    protected virtual void OnClientConnected(IScsServerClient client)
    {
      EventHandler<ServerClientEventArgs> clientConnected = this.ClientConnected;
      if (clientConnected == null)
        return;
      clientConnected((object) this, new ServerClientEventArgs(client));
    }

    protected virtual void OnClientDisconnected(IScsServerClient client)
    {
      EventHandler<ServerClientEventArgs> clientDisconnected = this.ClientDisconnected;
      if (clientDisconnected == null)
        return;
      clientDisconnected((object) this, new ServerClientEventArgs(client));
    }
  }
}
