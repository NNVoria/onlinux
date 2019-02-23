// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Communication.Messengers.SynchronizedMessenger`1
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Communication.Messages;
using System;
using System.Collections.Generic;
using System.Threading;

namespace OpenNos.SCS.Communication.Scs.Communication.Messengers
{
  public class SynchronizedMessenger<T> : RequestReplyMessenger<T> where T : IMessenger
  {
    private readonly Queue<IScsMessage> _receivingMessageQueue;
    private readonly ManualResetEventSlim _receiveWaiter;
    private volatile bool _running;

    public int IncomingMessageQueueCapacity { get; set; }

    public SynchronizedMessenger(T messenger)
      : this(messenger, int.MaxValue)
    {
    }

    public SynchronizedMessenger(T messenger, int incomingMessageQueueCapacity)
      : base(messenger)
    {
      this._receiveWaiter = new ManualResetEventSlim();
      this._receivingMessageQueue = new Queue<IScsMessage>();
      this.IncomingMessageQueueCapacity = incomingMessageQueueCapacity;
    }

    public override void Start()
    {
      lock (this._receivingMessageQueue)
        this._running = true;
      base.Start();
    }

    public override void Stop()
    {
      base.Stop();
      lock (this._receivingMessageQueue)
      {
        this._running = false;
        this._receiveWaiter.Set();
      }
    }

    public IScsMessage ReceiveMessage()
    {
      return this.ReceiveMessage(-1);
    }

    public IScsMessage ReceiveMessage(int timeout)
    {
      while (this._running)
      {
        lock (this._receivingMessageQueue)
        {
          if (!this._running)
            throw new Exception("SynchronizedMessenger is stopped. Can not receive message.");
          if (this._receivingMessageQueue.Count > 0)
            return this._receivingMessageQueue.Dequeue();
          this._receiveWaiter.Reset();
        }
        if (!this._receiveWaiter.Wait(timeout))
          throw new TimeoutException("Timeout occured. Can not received any message");
      }
      throw new Exception("SynchronizedMessenger is stopped. Can not receive message.");
    }

    public TMessage ReceiveMessage<TMessage>() where TMessage : IScsMessage
    {
      return this.ReceiveMessage<TMessage>(-1);
    }

    public TMessage ReceiveMessage<TMessage>(int timeout) where TMessage : IScsMessage
    {
      IScsMessage message = this.ReceiveMessage(timeout);
      if (!(message is TMessage))
        throw new Exception("Unexpected message received. Expected type: " + typeof (TMessage).Name + ". Received message type: " + message.GetType().Name);
      return (TMessage) message;
    }

    protected override void OnMessageReceived(IScsMessage message)
    {
      lock (this._receivingMessageQueue)
      {
        if (this._receivingMessageQueue.Count < this.IncomingMessageQueueCapacity)
          this._receivingMessageQueue.Enqueue(message);
        this._receiveWaiter.Set();
      }
    }
  }
}
