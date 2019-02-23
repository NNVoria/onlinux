// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.ScsServices.Service.ScsServiceClient
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Communication;
using OpenNos.SCS.Communication.Scs.Communication.EndPoints;
using OpenNos.SCS.Communication.Scs.Communication.Messengers;
using OpenNos.SCS.Communication.Scs.Server;
using OpenNos.SCS.Communication.ScsServices.Communication;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Proxies;

namespace OpenNos.SCS.Communication.ScsServices.Service
{
  internal class ScsServiceClient : IScsServiceClient
  {
    private readonly IScsServerClient _serverClient;
    private readonly RequestReplyMessenger<IScsServerClient> _requestReplyMessenger;
    private RealProxy _realProxy;

    [CompilerGenerated]
    public event EventHandler Disconnected;

    public long ClientId
    {
      get
      {
        return this._serverClient.ClientId;
      }
    }

    public ScsEndPoint RemoteEndPoint
    {
      get
      {
        return this._serverClient.RemoteEndPoint;
      }
    }

    public CommunicationStates CommunicationState
    {
      get
      {
        return this._serverClient.CommunicationState;
      }
    }

    public ScsServiceClient(
      IScsServerClient serverClient,
      RequestReplyMessenger<IScsServerClient> requestReplyMessenger)
    {
      this._serverClient = serverClient;
      this._serverClient.Disconnected += new EventHandler(this.Client_Disconnected);
      this._requestReplyMessenger = requestReplyMessenger;
    }

    public void Disconnect()
    {
      this._serverClient.Disconnect();
    }

    public T GetClientProxy<T>() where T : class
    {
      this._realProxy = (RealProxy) new RemoteInvokeProxy<T, IScsServerClient>(this._requestReplyMessenger);
      return (T) this._realProxy.GetTransparentProxy();
    }

    private void Client_Disconnected(object sender, EventArgs e)
    {
      this._requestReplyMessenger.Stop();
      this.OnDisconnected();
    }

    private void OnDisconnected()
    {
      EventHandler disconnected = this.Disconnected;
      if (disconnected == null)
        return;
      disconnected((object) this, EventArgs.Empty);
    }
  }
}
