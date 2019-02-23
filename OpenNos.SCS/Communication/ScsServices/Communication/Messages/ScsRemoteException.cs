// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.ScsServices.Communication.Messages.ScsRemoteException
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using System;
using System.Runtime.Serialization;

namespace OpenNos.SCS.Communication.ScsServices.Communication.Messages
{
  [Serializable]
  public class ScsRemoteException : Exception
  {
    public ScsRemoteException()
    {
    }

    public ScsRemoteException(SerializationInfo serializationInfo, StreamingContext context)
      : base(serializationInfo, context)
    {
    }

    public ScsRemoteException(string message)
      : base(message)
    {
    }

    public ScsRemoteException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
  }
}
