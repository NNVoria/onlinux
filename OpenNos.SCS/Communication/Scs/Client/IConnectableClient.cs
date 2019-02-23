// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Client.IConnectableClient
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Communication;
using System;

namespace OpenNos.SCS.Communication.Scs.Client
{
  public interface IConnectableClient : IDisposable
  {
    event EventHandler Connected;

    event EventHandler Disconnected;

    int ConnectTimeout { get; set; }

    CommunicationStates CommunicationState { get; }

    void Connect();

    void Disconnect();
  }
}
