// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.ScsServices.Communication.AutoConnectRemoteInvokeProxy`2
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Client;
using OpenNos.SCS.Communication.Scs.Communication;
using OpenNos.SCS.Communication.Scs.Communication.Messengers;
using System.Runtime.Remoting.Messaging;

namespace OpenNos.SCS.Communication.ScsServices.Communication
{
  internal class AutoConnectRemoteInvokeProxy<TProxy, TMessenger> : RemoteInvokeProxy<TProxy, TMessenger>
    where TMessenger : IMessenger
  {
    private readonly IConnectableClient _client;

    public AutoConnectRemoteInvokeProxy(
      RequestReplyMessenger<TMessenger> clientMessenger,
      IConnectableClient client)
      : base(clientMessenger)
    {
      this._client = client;
    }

    public override IMessage Invoke(IMessage msg)
    {
      if (this._client.CommunicationState == CommunicationStates.Connected)
        return base.Invoke(msg);
      this._client.Connect();
      try
      {
        return base.Invoke(msg);
      }
      finally
      {
        this._client.Disconnect();
      }
    }
  }
}
