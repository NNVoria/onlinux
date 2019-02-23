// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Communication.Channels.ConnectionListenerBase
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using System;
using System.Runtime.CompilerServices;

namespace OpenNos.SCS.Communication.Scs.Communication.Channels
{
  internal abstract class ConnectionListenerBase : IConnectionListener
  {
    [CompilerGenerated]
    public event EventHandler<CommunicationChannelEventArgs> CommunicationChannelConnected;

    public abstract void Start();

    public abstract void Stop();

    protected virtual void OnCommunicationChannelConnected(ICommunicationChannel client)
    {
      EventHandler<CommunicationChannelEventArgs> channelConnected = this.CommunicationChannelConnected;
      if (channelConnected == null)
        return;
      channelConnected((object) this, new CommunicationChannelEventArgs(client));
    }
  }
}
