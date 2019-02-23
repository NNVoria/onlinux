// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.ScsServices.Client.IScsServiceClient`1
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Client;
using System;

namespace OpenNos.SCS.Communication.ScsServices.Client
{
  public interface IScsServiceClient<out T> : IConnectableClient, IDisposable
    where T : class
  {
    T ServiceProxy { get; }

    int Timeout { get; set; }
  }
}
