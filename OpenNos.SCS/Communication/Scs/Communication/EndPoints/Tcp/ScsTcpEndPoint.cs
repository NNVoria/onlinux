// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Communication.EndPoints.Tcp.ScsTcpEndPoint
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Client;
using OpenNos.SCS.Communication.Scs.Client.Tcp;
using OpenNos.SCS.Communication.Scs.Server;
using OpenNos.SCS.Communication.Scs.Server.Tcp;
using System;

namespace OpenNos.SCS.Communication.Scs.Communication.EndPoints.Tcp
{
  public sealed class ScsTcpEndPoint : ScsEndPoint
  {
    public string IpAddress { get; set; }

    public int TcpPort { get; private set; }

    public ScsTcpEndPoint(int tcpPort)
    {
      this.TcpPort = tcpPort;
    }

    public ScsTcpEndPoint(string ipAddress, int port)
    {
      this.IpAddress = ipAddress;
      this.TcpPort = port;
    }

    public ScsTcpEndPoint(string address)
    {
      string[] strArray = address.Trim().Split(':');
      this.IpAddress = strArray[0].Trim();
      this.TcpPort = Convert.ToInt32(strArray[1].Trim());
    }

    internal override IScsServer CreateServer()
    {
      return (IScsServer) new ScsTcpServer(this);
    }

    internal override IScsClient CreateClient()
    {
      return (IScsClient) new ScsTcpClient(this);
    }

    public override string ToString()
    {
      if (string.IsNullOrEmpty(this.IpAddress))
        return "tcp://" + (object) this.TcpPort;
      return "tcp://" + this.IpAddress + ":" + (object) this.TcpPort;
    }
  }
}
