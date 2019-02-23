// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.ScsServices.Client.ScsServiceClientBuilder
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Communication.EndPoints;

namespace OpenNos.SCS.Communication.ScsServices.Client
{
  public class ScsServiceClientBuilder
  {
    public static IScsServiceClient<T> CreateClient<T>(
      ScsEndPoint endpoint,
      object clientObject = null)
      where T : class
    {
      return (IScsServiceClient<T>) new ScsServiceClient<T>(endpoint.CreateClient(), clientObject);
    }

    public static IScsServiceClient<T> CreateClient<T>(
      string endpointAddress,
      object clientObject = null)
      where T : class
    {
      return ScsServiceClientBuilder.CreateClient<T>(ScsEndPoint.CreateEndPoint(endpointAddress), clientObject);
    }
  }
}
