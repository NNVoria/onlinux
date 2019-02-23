// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.ScsServices.Communication.Messages.ScsRemoteInvokeReturnMessage
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Communication.Messages;
using System;

namespace OpenNos.SCS.Communication.ScsServices.Communication.Messages
{
  [Serializable]
  public class ScsRemoteInvokeReturnMessage : ScsMessage
  {
    public object ReturnValue { get; set; }

    public ScsRemoteException RemoteException { get; set; }

    public override string ToString()
    {
      return string.Format("ScsRemoteInvokeReturnMessage: Returns {0}, Exception = {1}", this.ReturnValue, (object) this.RemoteException);
    }
  }
}
