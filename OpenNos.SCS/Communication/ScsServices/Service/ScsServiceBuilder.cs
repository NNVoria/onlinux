// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.ScsServices.Service.ScsServiceBuilder
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Communication.EndPoints;
using OpenNos.SCS.Communication.Scs.Server;

namespace OpenNos.SCS.Communication.ScsServices.Service
{
  public static class ScsServiceBuilder
  {
    public static IScsServiceApplication CreateService(ScsEndPoint endPoint)
    {
      return (IScsServiceApplication) new ScsServiceApplication(ScsServerFactory.CreateServer(endPoint));
    }
  }
}
