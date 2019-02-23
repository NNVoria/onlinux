// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Server.ScsServerFactory
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Communication.EndPoints;

namespace OpenNos.SCS.Communication.Scs.Server
{
  public static class ScsServerFactory
  {
    public static IScsServer CreateServer(ScsEndPoint endPoint)
    {
      return endPoint.CreateServer();
    }
  }
}
