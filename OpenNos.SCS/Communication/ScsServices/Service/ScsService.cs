// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.ScsServices.Service.ScsService
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using System;

namespace OpenNos.SCS.Communication.ScsServices.Service
{
  public abstract class ScsService
  {
    [ThreadStatic]
    private static IScsServiceClient _currentClient;

    protected internal IScsServiceClient CurrentClient
    {
      get
      {
        if (ScsService._currentClient == null)
          throw new Exception("Client channel can not be obtained. CurrentClient property must be called by the thread which runs the service method.");
        return ScsService._currentClient;
      }
      internal set
      {
        ScsService._currentClient = value;
      }
    }
  }
}
