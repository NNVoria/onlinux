// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Communication.Messages.ScsTextMessage
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using System;

namespace OpenNos.SCS.Communication.Scs.Communication.Messages
{
  [Serializable]
  public class ScsTextMessage : ScsMessage
  {
    public string Text { get; set; }

    public ScsTextMessage()
    {
    }

    public ScsTextMessage(string text)
    {
      this.Text = text;
    }

    public ScsTextMessage(string text, string repliedMessageId)
      : this(text)
    {
      this.RepliedMessageId = repliedMessageId;
    }

    public override string ToString()
    {
      if (!string.IsNullOrEmpty(this.RepliedMessageId))
        return string.Format("ScsTextMessage [{0}] Replied To [{1}]: {2}", (object) this.MessageId, (object) this.RepliedMessageId, (object) this.Text);
      return string.Format("ScsTextMessage [{0}]: {1}", (object) this.MessageId, (object) this.Text);
    }
  }
}
