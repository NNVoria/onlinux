﻿// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Server.ServerClientEventArgs
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using System;

namespace OpenNos.SCS.Communication.Scs.Server
{
  public class ServerClientEventArgs : EventArgs
  {
    public IScsServerClient Client { get; private set; }

    public ServerClientEventArgs(IScsServerClient client)
    {
      this.Client = client;
    }
  }
}
