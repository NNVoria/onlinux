// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Communication.Protocols.IScsWireProtocol
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Communication.Messages;
using System.Collections.Generic;

namespace OpenNos.SCS.Communication.Scs.Communication.Protocols
{
  public interface IScsWireProtocol
  {
    byte[] GetBytes(IScsMessage message);

    IEnumerable<IScsMessage> CreateMessages(byte[] receivedBytes);

    void Reset();
  }
}
