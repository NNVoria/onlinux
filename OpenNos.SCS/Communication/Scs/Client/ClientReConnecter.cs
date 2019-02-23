// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Client.ClientReConnecter
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Communication;
using OpenNos.SCS.Threading;
using System;

namespace OpenNos.SCS.Communication.Scs.Client
{
  public class ClientReConnecter : IDisposable
  {
    private readonly IConnectableClient _client;
    private readonly Timer _reconnectTimer;
    private volatile bool _disposed;

    public int ReConnectCheckPeriod
    {
      get
      {
        return this._reconnectTimer.Period;
      }
      set
      {
        this._reconnectTimer.Period = value;
      }
    }

    public ClientReConnecter(IConnectableClient client)
    {
      if (client == null)
        throw new ArgumentNullException(nameof (client));
      this._client = client;
      this._client.Disconnected += new EventHandler(this.Client_Disconnected);
      this._reconnectTimer = new Timer(20000);
      this._reconnectTimer.Elapsed += new EventHandler(this.ReconnectTimer_Elapsed);
      this._reconnectTimer.Start();
    }

    public void Dispose()
    {
      if (this._disposed)
        return;
      this._disposed = true;
      this._client.Disconnected -= new EventHandler(this.Client_Disconnected);
      this._reconnectTimer.Stop();
    }

    private void Client_Disconnected(object sender, EventArgs e)
    {
      this._reconnectTimer.Start();
    }

    private void ReconnectTimer_Elapsed(object sender, EventArgs e)
    {
      if (!this._disposed)
      {
        if (this._client.CommunicationState != CommunicationStates.Connected)
        {
          try
          {
            this._client.Connect();
            this._reconnectTimer.Stop();
            return;
          }
          catch
          {
            return;
          }
        }
      }
      this._reconnectTimer.Stop();
    }
  }
}
