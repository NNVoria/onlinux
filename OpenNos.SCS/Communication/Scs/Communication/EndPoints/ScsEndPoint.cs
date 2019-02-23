// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Communication.EndPoints.ScsEndPoint
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using OpenNos.SCS.Communication.Scs.Client;
using OpenNos.SCS.Communication.Scs.Communication.EndPoints.Tcp;
using OpenNos.SCS.Communication.Scs.Server;
using System;

namespace OpenNos.SCS.Communication.Scs.Communication.EndPoints
{
  public abstract class ScsEndPoint
  {
    public static ScsEndPoint CreateEndPoint(string endPointAddress)
    {
      if (string.IsNullOrEmpty(endPointAddress))
        throw new ArgumentNullException(nameof (endPointAddress));
      string str = endPointAddress;
      if (!str.Contains("://"))
        str = "tcp://" + str;
      string[] strArray = str.Split(new string[1]{ "://" }, StringSplitOptions.RemoveEmptyEntries);
      if (strArray.Length != 2)
        throw new ApplicationException(endPointAddress + " is not a valid endpoint address.");
      string lower = strArray[0].Trim().ToLower();
      string address = strArray[1].Trim();
      if (lower == "tcp")
        return (ScsEndPoint) new ScsTcpEndPoint(address);
      throw new ApplicationException("Unsupported protocol " + lower + " in end point " + endPointAddress);
    }

    internal abstract IScsServer CreateServer();

    internal abstract IScsClient CreateClient();
  }
}
