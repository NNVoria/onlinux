﻿// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Communication.Protocols.BinarySerialization.BinarySerializationProtocol
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Communication.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

namespace OpenNos.SCS.Communication.Scs.Communication.Protocols.BinarySerialization
{
  public class BinarySerializationProtocol : IScsWireProtocol
  {
    private const int MaxMessageLength = 134217728;
    private MemoryStream _receiveMemoryStream;

    public BinarySerializationProtocol()
    {
      this._receiveMemoryStream = new MemoryStream();
    }

    public byte[] GetBytes(IScsMessage message)
    {
      byte[] numArray = this.SerializeMessage(message);
      int length = numArray.Length;
      if (length > 134217728)
        throw new CommunicationException("Message is too big (" + (object) length + " bytes). Max allowed length is " + (object) 134217728 + " bytes.");
      byte[] buffer = new byte[length + 4];
      BinarySerializationProtocol.WriteInt32(buffer, 0, length);
      Array.Copy((Array) numArray, 0, (Array) buffer, 4, length);
      return buffer;
    }

    public IEnumerable<IScsMessage> CreateMessages(byte[] receivedBytes)
    {
      this._receiveMemoryStream.Write(receivedBytes, 0, receivedBytes.Length);
      List<IScsMessage> scsMessageList = new List<IScsMessage>();
      do
        ;
      while (this.ReadSingleMessage((ICollection<IScsMessage>) scsMessageList));
      return (IEnumerable<IScsMessage>) scsMessageList;
    }

    public void Reset()
    {
      if (this._receiveMemoryStream.Length <= 0L)
        return;
      this._receiveMemoryStream = new MemoryStream();
    }

    protected virtual byte[] SerializeMessage(IScsMessage message)
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        new BinaryFormatter().Serialize((Stream) memoryStream, (object) message);
        return memoryStream.ToArray();
      }
    }

    protected virtual IScsMessage DeserializeMessage(byte[] bytes)
    {
      using (MemoryStream memoryStream = new MemoryStream(bytes))
      {
        memoryStream.Position = 0L;
        return (IScsMessage) new BinaryFormatter() { AssemblyFormat = FormatterAssemblyStyle.Simple, Binder = ((SerializationBinder) new BinarySerializationProtocol.DeserializationAppDomainBinder()) }.Deserialize((Stream) memoryStream);
      }
    }

    private bool ReadSingleMessage(ICollection<IScsMessage> messages)
    {
      this._receiveMemoryStream.Position = 0L;
      if (this._receiveMemoryStream.Length < 4L)
        return false;
      int length = BinarySerializationProtocol.ReadInt32((Stream) this._receiveMemoryStream);
      if (length > 134217728)
        throw new Exception("Message is too big (" + (object) length + " bytes). Max allowed length is " + (object) 134217728 + " bytes.");
      if (length == 0)
      {
        if (this._receiveMemoryStream.Length == 4L)
        {
          this._receiveMemoryStream = new MemoryStream();
          return false;
        }
        byte[] array = this._receiveMemoryStream.ToArray();
        this._receiveMemoryStream = new MemoryStream();
        this._receiveMemoryStream.Write(array, 4, array.Length - 4);
        return true;
      }
      if (this._receiveMemoryStream.Length < (long) (4 + length))
      {
        this._receiveMemoryStream.Position = this._receiveMemoryStream.Length;
        return false;
      }
      byte[] bytes = BinarySerializationProtocol.ReadByteArray((Stream) this._receiveMemoryStream, length);
      messages.Add(this.DeserializeMessage(bytes));
      byte[] buffer = BinarySerializationProtocol.ReadByteArray((Stream) this._receiveMemoryStream, (int) (this._receiveMemoryStream.Length - (long) (4 + length)));
      this._receiveMemoryStream = new MemoryStream();
      this._receiveMemoryStream.Write(buffer, 0, buffer.Length);
      return buffer.Length > 4;
    }

    private static void WriteInt32(byte[] buffer, int startIndex, int number)
    {
      buffer[startIndex] = (byte) (number >> 24 & (int) byte.MaxValue);
      buffer[startIndex + 1] = (byte) (number >> 16 & (int) byte.MaxValue);
      buffer[startIndex + 2] = (byte) (number >> 8 & (int) byte.MaxValue);
      buffer[startIndex + 3] = (byte) (number & (int) byte.MaxValue);
    }

    private static int ReadInt32(Stream stream)
    {
      byte[] numArray = BinarySerializationProtocol.ReadByteArray(stream, 4);
      return (int) numArray[0] << 24 | (int) numArray[1] << 16 | (int) numArray[2] << 8 | (int) numArray[3];
    }

    private static byte[] ReadByteArray(Stream stream, int length)
    {
      byte[] buffer = new byte[length];
      int num;
      for (int offset = 0; offset < length; offset += num)
      {
        num = stream.Read(buffer, offset, length - offset);
        if (num <= 0)
          throw new EndOfStreamException("Can not read from stream! Input stream is closed.");
      }
      return buffer;
    }

    protected sealed class DeserializationAppDomainBinder : SerializationBinder
    {
      public override Type BindToType(string assemblyName, string typeName)
      {
        string toAssemblyName = assemblyName.Split(',')[0];
        return ((IEnumerable<Assembly>) AppDomain.CurrentDomain.GetAssemblies()).Where<Assembly>((Func<Assembly, bool>) (assembly => assembly.FullName.Split(',')[0] == toAssemblyName)).Select<Assembly, Type>((Func<Assembly, Type>) (assembly => assembly.GetType(typeName))).FirstOrDefault<Type>();
      }
    }
  }
}
