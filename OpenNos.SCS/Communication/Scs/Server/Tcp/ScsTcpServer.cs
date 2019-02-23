// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Server.Tcp.ScsTcpServer
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Communication.Channels;
using OpenNos.SCS.Communication.Scs.Communication.Channels.Tcp;
using OpenNos.SCS.Communication.Scs.Communication.EndPoints.Tcp;

namespace OpenNos.SCS.Communication.Scs.Server.Tcp
{
  internal class ScsTcpServer : ScsServerBase
  {
    private readonly ScsTcpEndPoint _endPoint;

    public ScsTcpServer(ScsTcpEndPoint endPoint)
    {
      this._endPoint = endPoint;
    }

    protected override IConnectionListener CreateConnectionListener()
    {
      return (IConnectionListener) new TcpConnectionListener(this._endPoint);
    }
  }
}
