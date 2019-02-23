// Decompiled with JetBrains decompiler
// Type: OpenNos.SCS.Collections.ThreadSafeSortedList`2
// Assembly: OpenNos.SCS, Version=1.2.6505.26681, Culture=neutral, PublicKeyToken=null
// MVID: 70588587-7BDF-49BF-B8A9-D75EC914A8EE
// Assembly location: C:\Users\Nizar\Desktop\OpenNos.SCS.dll

using System.Collections.Generic;
using System.Threading;

namespace OpenNos.SCS.Collections
{
  public class ThreadSafeSortedList<TK, TV>
  {
    protected readonly SortedList<TK, TV> _items;
    protected readonly ReaderWriterLockSlim _lock;

    public TV this[TK key]
    {
      get
      {
        this._lock.EnterReadLock();
        try
        {
          return this._items.ContainsKey(key) ? this._items[key] : default (TV);
        }
        finally
        {
          this._lock.ExitReadLock();
        }
      }
      set
      {
        this._lock.EnterWriteLock();
        try
        {
          this._items[key] = value;
        }
        finally
        {
          this._lock.ExitWriteLock();
        }
      }
    }

    public int Count
    {
      get
      {
        this._lock.EnterReadLock();
        try
        {
          return this._items.Count;
        }
        finally
        {
          this._lock.ExitReadLock();
        }
      }
    }

    public ThreadSafeSortedList()
    {
      this._items = new SortedList<TK, TV>();
      this._lock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
    }

    public bool ContainsKey(TK key)
    {
      this._lock.EnterReadLock();
      try
      {
        return this._items.ContainsKey(key);
      }
      finally
      {
        this._lock.ExitReadLock();
      }
    }

    public bool ContainsValue(TV item)
    {
      this._lock.EnterReadLock();
      try
      {
        return this._items.ContainsValue(item);
      }
      finally
      {
        this._lock.ExitReadLock();
      }
    }

    public bool Remove(TK key)
    {
      this._lock.EnterWriteLock();
      try
      {
        if (!this._items.ContainsKey(key))
          return false;
        this._items.Remove(key);
        return true;
      }
      finally
      {
        this._lock.ExitWriteLock();
      }
    }

    public List<TV> GetAllItems()
    {
      this._lock.EnterReadLock();
      try
      {
        return new List<TV>((IEnumerable<TV>) this._items.Values);
      }
      finally
      {
        this._lock.ExitReadLock();
      }
    }

    public void ClearAll()
    {
      this._lock.EnterWriteLock();
      try
      {
        this._items.Clear();
      }
      finally
      {
        this._lock.ExitWriteLock();
      }
    }

    public List<TV> GetAndClearAllItems()
    {
      this._lock.EnterWriteLock();
      try
      {
        List<TV> vList = new List<TV>((IEnumerable<TV>) this._items.Values);
        this._items.Clear();
        return vList;
      }
      finally
      {
        this._lock.ExitWriteLock();
      }
    }
  }
}
