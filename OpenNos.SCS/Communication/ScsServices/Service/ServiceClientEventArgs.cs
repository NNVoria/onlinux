﻿// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.ScsServices.Service.ServiceClientEventArgs
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using System;

namespace OpenNos.SCS.Communication.ScsServices.Service
{
  public class ServiceClientEventArgs : EventArgs
  {
    public IScsServiceClient Client { get; private set; }

    public ServiceClientEventArgs(IScsServiceClient client)
    {
      this.Client = client;
    }
  }
}
