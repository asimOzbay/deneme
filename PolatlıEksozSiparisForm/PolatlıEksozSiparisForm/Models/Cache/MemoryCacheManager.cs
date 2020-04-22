using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace PolatlıEksozSiparisForm.Models.Cache
{
    public class MemoryCacheManager : ICacheHelper
    {
        ObjectCache cache;

        public MemoryCacheManager()
        {
            cache = MemoryCache.Default;
        }

        public void Add<T>(string key, T source)
        {
            //60 dakika boyunca cache'de tutacak
            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(60) };
            cache.Add(key, source, policy);
        }

        public bool Contains(string key)
        {
            return cache.Contains(key);
        }

        public T Get<T>(string key)
        {
            var varMi = Contains(key);
            if (varMi)
                return (T)cache.Get(key);
            else
                return default(T);
        }

        public void Remove(string key)
        {
            cache.Remove(key);
        }
    }
}