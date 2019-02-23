// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Client.Tcp.ScsTcpClient
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Communication.Channels;
using OpenNos.SCS.Communication.Scs.Communication.Channels.Tcp;
using OpenNos.SCS.Communication.Scs.Communication.EndPoints.Tcp;
using System.Net;

namespace OpenNos.SCS.Communication.Scs.Client.Tcp
{
  internal class ScsTcpClient : ScsClientBase
  {
    private readonly ScsTcpEndPoint _serverEndPoint;

    public ScsTcpClient(ScsTcpEndPoint serverEndPoint)
    {
      this._serverEndPoint = serverEndPoint;
    }

    protected override ICommunicationChannel CreateCommunicationChannel()
    {
      return (ICommunicationChannel) new TcpCommunicationChannel(TcpHelper.ConnectToServer(!this.IsStringIp(this._serverEndPoint.IpAddress) ? (EndPoint) new DnsEndPoint(this._serverEndPoint.IpAddress, this._serverEndPoint.TcpPort) : (EndPoint) new IPEndPoint(IPAddress.Parse(this._serverEndPoint.IpAddress), this._serverEndPoint.TcpPort), this.ConnectTimeout));
    }

    private bool IsStringIp(string address)
    {
      IPAddress address1 = (IPAddress) null;
      return IPAddress.TryParse(address, out address1);
    }
  }
}
