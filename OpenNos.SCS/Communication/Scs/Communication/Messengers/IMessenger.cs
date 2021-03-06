﻿// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Communication.Messengers.IMessenger
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Communication.Messages;
using OpenNos.SCS.Communication.Scs.Communication.Protocols;
using System;

namespace OpenNos.SCS.Communication.Scs.Communication.Messengers
{
  public interface IMessenger
  {
    event EventHandler<MessageEventArgs> MessageReceived;

    event EventHandler<MessageEventArgs> MessageSent;

    IScsWireProtocol WireProtocol { get; set; }

    DateTime LastReceivedMessageTime { get; }

    DateTime LastSentMessageTime { get; }

    void SendMessage(IScsMessage message);
  }
}
