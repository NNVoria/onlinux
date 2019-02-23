// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Client.ScsClientFactory
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Communication.EndPoints;

namespace OpenNos.SCS.Communication.Scs.Client
{
  public static class ScsClientFactory
  {
    public static IScsClient CreateClient(ScsEndPoint endpoint)
    {
      return endpoint.CreateClient();
    }

    public static IScsClient CreateClient(string endpointAddress)
    {
      return ScsClientFactory.CreateClient(ScsEndPoint.CreateEndPoint(endpointAddress));
    }
  }
}
