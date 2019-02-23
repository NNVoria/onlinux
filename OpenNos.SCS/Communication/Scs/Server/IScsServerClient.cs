// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Server.IScsServerClient
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Communication;
using OpenNos.SCS.Communication.Scs.Communication.EndPoints;
using OpenNos.SCS.Communication.Scs.Communication.Messengers;
using System;

namespace OpenNos.SCS.Communication.Scs.Server
{
  public interface IScsServerClient : IMessenger
  {
    event EventHandler Disconnected;

    long ClientId { get; }

    ScsEndPoint RemoteEndPoint { get; }

    CommunicationStates CommunicationState { get; }

    void Disconnect();
  }
}
