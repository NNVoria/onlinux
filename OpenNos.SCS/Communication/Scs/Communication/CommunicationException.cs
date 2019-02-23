// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Communication.CommunicationException
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using System;
using System.Runtime.Serialization;

namespace OpenNos.SCS.Communication.Scs.Communication
{
  [Serializable]
  public class CommunicationException : Exception
  {
    public CommunicationException()
    {
    }

    public CommunicationException(SerializationInfo serializationInfo, StreamingContext context)
      : base(serializationInfo, context)
    {
    }

    public CommunicationException(string message)
      : base(message)
    {
    }

    public CommunicationException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
  }
}
