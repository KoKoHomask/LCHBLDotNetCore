using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCHBLDotNetCore.Other
{
    public class EasyCache<T>
    {
        public class EashCacheMemory<T>
        {
            public DateTime ExpirationTime
            {
                get;
                set;
            }
            public T Data
            {
                get;
                set;
            }
        }
        private static readonly ConcurrentDictionary<string, EashCacheMemory<T>> list = new ConcurrentDictionary<string, EashCacheMemory<T>>();//Dictionary
        string _key;
        TimeSpan _time;
        public EasyCache(string key, TimeSpan time)
        {
            _key = key;
            _time = time;
        }
        public bool AddData(T data)
        {
            bool flag2 = EasyCache<T>.list.ContainsKey(this._key);
            if (flag2)
                return false;
            EashCacheMemory<T> obj = new EashCacheMemory<T>() { Data = data, ExpirationTime = DateTime.Now.Add(_time) };
            if (list.TryAdd(_key, obj))
                return true;
            return false;
        }
        public EashCacheMemory<T> GetData()
        {
            if (list.ContainsKey(_key))
            {
                var obj = list[_key];
                if (obj.ExpirationTime.Ticks < DateTime.Now.Ticks)
                {
                    EashCacheMemory<T> eashCacheMemory;
                    list.TryRemove(_key, out eashCacheMemory);
                    return null;
                }
                return obj;
            }
            return null;
        }
    }
}
