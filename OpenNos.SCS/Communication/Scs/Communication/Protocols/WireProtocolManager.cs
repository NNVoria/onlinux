// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Communication.Protocols.WireProtocolManager
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Communication.Protocols.BinarySerialization;

namespace OpenNos.SCS.Communication.Scs.Communication.Protocols
{
  internal static class WireProtocolManager
  {
    public static IScsWireProtocolFactory GetDefaultWireProtocolFactory()
    {
      return (IScsWireProtocolFactory) new BinarySerializationProtocolFactory();
    }

    public static IScsWireProtocol GetDefaultWireProtocol()
    {
      return (IScsWireProtocol) new BinarySerializationProtocol();
    }
  }
}
