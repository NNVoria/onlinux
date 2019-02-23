// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Client.Tcp.TcpHelper
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using System;
using System.Net;
using System.Net.Sockets;

namespace OpenNos.SCS.Communication.Scs.Client.Tcp
{
  internal static class TcpHelper
  {
    public static Socket ConnectToServer(EndPoint endPoint, int timeoutMs)
    {
      Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
      try
      {
        socket.Blocking = false;
        socket.Connect(endPoint);
        socket.Blocking = true;
        return socket;
      }
      catch (SocketException ex)
      {
        if (ex.ErrorCode != 10035)
        {
          socket.Close();
          throw;
        }
        else
        {
          if (!socket.Poll(timeoutMs * 1000, SelectMode.SelectWrite))
          {
            socket.Close();
            throw new TimeoutException("The host failed to connect. Timeout occured.");
          }
          socket.Blocking = true;
          return socket;
        }
      }
    }
  }
}
