// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.ScsServices.Service.IScsServiceApplication
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using System;

namespace OpenNos.SCS.Communication.ScsServices.Service
{
  public interface IScsServiceApplication
  {
    event EventHandler<ServiceClientEventArgs> ClientConnected;

    event EventHandler<ServiceClientEventArgs> ClientDisconnected;

    void Start();

    void Stop();

    void AddService<TServiceInterface, TServiceClass>(TServiceClass service)
      where TServiceInterface : class
      where TServiceClass : ScsService, TServiceInterface;

    bool RemoveService<TServiceInterface>() where TServiceInterface : class;
  }
}
