// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Communication.Scs.Server.ScsServerManager
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using System.Threading;

namespace OpenNos.SCS.Communication.Scs.Server
{
  internal static class ScsServerManager
  {
    private static long _lastClientId;

    public static long GetClientId()
    {
      return Interlocked.Increment(ref ScsServerManager._lastClientId);
    }
  }
}
