// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Communication.Messages.ScsRawDataMessage
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using System;

namespace OpenNos.SCS.Communication.Scs.Communication.Messages
{
  [Serializable]
  public class ScsRawDataMessage : ScsMessage
  {
    public byte[] MessageData { get; set; }

    public ScsRawDataMessage()
    {
    }

    public ScsRawDataMessage(byte[] messageData)
    {
      this.MessageData = messageData;
    }

    public ScsRawDataMessage(byte[] messageData, string repliedMessageId)
      : this(messageData)
    {
      this.RepliedMessageId = repliedMessageId;
    }

    public override string ToString()
    {
      int num = this.MessageData == null ? 0 : this.MessageData.Length;
      if (!string.IsNullOrEmpty(this.RepliedMessageId))
        return string.Format("ScsRawDataMessage [{0}] Replied To [{1}]: {2} bytes", (object) this.MessageId, (object) this.RepliedMessageId, (object) num);
      return string.Format("ScsRawDataMessage [{0}]: {1} bytes", (object) this.MessageId, (object) num);
    }
  }
}
