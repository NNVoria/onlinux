// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.ScsServices.Communication.RemoteInvokeProxy`2
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Communication.Messages;
using OpenNos.SCS.Communication.Scs.Communication.Messengers;
using OpenNos.SCS.Communication.ScsServices.Communication.Messages;
using System;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace OpenNos.SCS.Communication.ScsServices.Communication
{
  internal class RemoteInvokeProxy<TProxy, TMessenger> : RealProxy where TMessenger : IMessenger
  {
    private readonly RequestReplyMessenger<TMessenger> _clientMessenger;

    public RemoteInvokeProxy(RequestReplyMessenger<TMessenger> clientMessenger)
      : base(typeof (TProxy))
    {
      this._clientMessenger = clientMessenger;
    }

    public override IMessage Invoke(IMessage msg)
    {
      IMethodCallMessage mcm = msg as IMethodCallMessage;
      if (mcm == null)
        return (IMessage) null;
      ScsRemoteInvokeMessage remoteInvokeMessage = new ScsRemoteInvokeMessage() { ServiceClassName = typeof (TProxy).Name, MethodName = mcm.MethodName, Parameters = mcm.InArgs };
      ScsRemoteInvokeReturnMessage invokeReturnMessage = (ScsRemoteInvokeReturnMessage) null;
      if (remoteInvokeMessage.ServiceClassName.EndsWith("Client"))
      {
        this._clientMessenger.SendMessage((IScsMessage) remoteInvokeMessage);
      }
      else
      {
        invokeReturnMessage = this._clientMessenger.SendMessageAndWaitForResponse((IScsMessage) remoteInvokeMessage) as ScsRemoteInvokeReturnMessage;
        if (invokeReturnMessage == null)
          return (IMessage) null;
      }
      if (invokeReturnMessage == null)
        return (IMessage) new ReturnMessage((object) null, (object[]) null, 0, mcm.LogicalCallContext, mcm);
      if (invokeReturnMessage.RemoteException == null)
        return (IMessage) new ReturnMessage(invokeReturnMessage.ReturnValue, (object[]) null, 0, mcm.LogicalCallContext, mcm);
      return (IMessage) new ReturnMessage((Exception) invokeReturnMessage.RemoteException, mcm);
    }
  }
}
