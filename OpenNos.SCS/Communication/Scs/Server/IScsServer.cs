// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Server.IScsServer
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Collections;
using OpenNos.SCS.Communication.Scs.Communication.Protocols;
using System;

namespace OpenNos.SCS.Communication.Scs.Server
{
  public interface IScsServer
  {
    event EventHandler<ServerClientEventArgs> ClientConnected;

    event EventHandler<ServerClientEventArgs> ClientDisconnected;

    IScsWireProtocolFactory WireProtocolFactory { get; set; }

    ThreadSafeSortedList<long, IScsServerClient> Clients { get; }

    void Start();

    void Stop();
  }
}
