// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.ScsServices.Service.ScsServiceClientFactory
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Communication.Messengers;
using OpenNos.SCS.Communication.Scs.Server;

namespace OpenNos.SCS.Communication.ScsServices.Service
{
  internal static class ScsServiceClientFactory
  {
    public static IScsServiceClient CreateServiceClient(
      IScsServerClient serverClient,
      RequestReplyMessenger<IScsServerClient> requestReplyMessenger)
    {
      return (IScsServiceClient) new ScsServiceClient(serverClient, requestReplyMessenger);
    }
  }
}
