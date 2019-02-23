// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Communication.Messages.ScsPingMessage
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using System;

namespace OpenNos.SCS.Communication.Scs.Communication.Messages
{
  [Serializable]
  public sealed class ScsPingMessage : ScsMessage
  {
    public ScsPingMessage()
    {
    }

    public ScsPingMessage(string repliedMessageId)
      : this()
    {
      this.RepliedMessageId = repliedMessageId;
    }

    public override string ToString()
    {
      if (!string.IsNullOrEmpty(this.RepliedMessageId))
        return string.Format("ScsPingMessage [{0}] Replied To [{1}]", (object) this.MessageId, (object) this.RepliedMessageId);
      return string.Format("ScsPingMessage [{0}]", (object) this.MessageId);
    }
  }
}
