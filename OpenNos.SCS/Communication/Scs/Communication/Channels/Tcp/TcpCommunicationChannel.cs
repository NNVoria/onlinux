// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Communication.Channels.Tcp.TcpCommunicationChannel
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Communication.EndPoints;
using OpenNos.SCS.Communication.Scs.Communication.EndPoints.Tcp;
using OpenNos.SCS.Communication.Scs.Communication.Messages;
using System;
using System.Net;
using System.Net.Sockets;

namespace OpenNos.SCS.Communication.Scs.Communication.Channels.Tcp
{
  internal class TcpCommunicationChannel : CommunicationChannelBase
  {
    private readonly ScsTcpEndPoint _remoteEndPoint;
    private const int ReceiveBufferSize = 4096;
    private readonly byte[] _buffer;
    private readonly Socket _clientSocket;
    private volatile bool _running;
    private readonly object _syncLock;

    public override ScsEndPoint RemoteEndPoint
    {
      get
      {
        return (ScsEndPoint) this._remoteEndPoint;
      }
    }

    public TcpCommunicationChannel(Socket clientSocket)
    {
      this._clientSocket = clientSocket;
      this._clientSocket.NoDelay = true;
      IPEndPoint remoteEndPoint = (IPEndPoint) this._clientSocket.RemoteEndPoint;
      this._remoteEndPoint = new ScsTcpEndPoint(remoteEndPoint.Address.ToString(), remoteEndPoint.Port);
      this._buffer = new byte[4096];
      this._syncLock = new object();
    }

    public override void Disconnect()
    {
      if (this.CommunicationState != CommunicationStates.Connected)
        return;
      this._running = false;
      try
      {
        if (this._clientSocket.Connected)
          this._clientSocket.Close();
        this._clientSocket.Dispose();
      }
      catch
      {
      }
      this.CommunicationState = CommunicationStates.Disconnected;
      this.OnDisconnected();
    }

    protected override void StartInternal()
    {
      this._running = true;
      this._clientSocket.BeginReceive(this._buffer, 0, this._buffer.Length, SocketFlags.None, new AsyncCallback(this.ReceiveCallback), (object) null);
    }

    protected override void SendMessageInternal(IScsMessage message)
    {
      int offset = 0;
      lock (this._syncLock)
      {
        int num;
        for (byte[] bytes = this.WireProtocol.GetBytes(message); offset < bytes.Length; offset += num)
        {
          num = this._clientSocket.Send(bytes, offset, bytes.Length - offset, SocketFlags.None);
          if (num <= 0)
            throw new CommunicationException("Message could not be sent via TCP socket. Only " + (object) offset + " bytes of " + (object) bytes.Length + " bytes are sent.");
        }
        this.LastSentMessageTime = DateTime.Now;
        this.OnMessageSent(message);
      }
    }

    private void ReceiveCallback(IAsyncResult ar)
    {
      if (!this._running)
        return;
      try
      {
        int length = this._clientSocket.EndReceive(ar);
        if (length <= 0)
          throw new CommunicationException("Tcp socket is closed");
        this.LastReceivedMessageTime = DateTime.Now;
        byte[] receivedBytes = new byte[length];
        Array.Copy((Array) this._buffer, 0, (Array) receivedBytes, 0, length);
        foreach (IScsMessage message in this.WireProtocol.CreateMessages(receivedBytes))
          this.OnMessageReceived(message);
        if (!this._running)
          return;
        this._clientSocket.BeginReceive(this._buffer, 0, this._buffer.Length, SocketFlags.None, new AsyncCallback(this.ReceiveCallback), (object) null);
      }
      catch
      {
        this.Disconnect();
      }
    }
  }
}
