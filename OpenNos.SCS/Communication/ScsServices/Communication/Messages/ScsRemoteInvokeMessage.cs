// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.ScsServices.Communication.Messages.ScsRemoteInvokeMessage
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Communication.Messages;
using System;

namespace OpenNos.SCS.Communication.ScsServices.Communication.Messages
{
  [Serializable]
  public class ScsRemoteInvokeMessage : ScsMessage
  {
    public string ServiceClassName { get; set; }

    public string MethodName { get; set; }

    public object[] Parameters { get; set; }

    public override string ToString()
    {
      return string.Format("ScsRemoteInvokeMessage: {0}.{1}(...)", (object) this.ServiceClassName, (object) this.MethodName);
    }
  }
}
