// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Communication.CommunicationStateException
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using System;
using System.Runtime.Serialization;

namespace OpenNos.SCS.Communication.Scs.Communication
{
  [Serializable]
  public class CommunicationStateException : CommunicationException
  {
    public CommunicationStateException()
    {
    }

    public CommunicationStateException(
      SerializationInfo serializationInfo,
      StreamingContext context)
      : base(serializationInfo, context)
    {
    }

    public CommunicationStateException(string message)
      : base(message)
    {
    }

    public CommunicationStateException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
  }
}
