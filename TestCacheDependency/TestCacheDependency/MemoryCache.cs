using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace TestCacheDependency
{
    public class MemoryCache
    {
        protected ObjectCache Cache
        {
            get { return System.Runtime.Caching.MemoryCache.Default; }
        }

        public T Get<T>(string key)
        {
            return (T) this.Cache[key];
        }

        public void Set(string key, object data, int cacheMinutes)
        {
            if (data == null)
                return;

            Cache.Add(new CacheItem(key, data),
                new CacheItemPolicy() {AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheMinutes)});
        }

        public bool IsSet(string key)
        {
            return Cache.Contains(key);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            this.RemoveByPattern(pattern, Cache.Select(item => item.Key));
        }

        public void Clear()
        {
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }
        }

        public T GetOrAdd<T>(string key, int cacheMinutes, Func<T> factory)
        {
            if (IsSet(key))
            {
                return Get<T>(key);
            }
            else
            {
                var data = factory();
                Set(key, data, cacheMinutes);
                return data;
            }
        }

        public void RemoveByPattern(string pattern, IEnumerable<string> keys)
        {
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            foreach (var target in keys.Where(k => regex.IsMatch(k)))
            {
                Remove(target);
            }
        }

        public void Dispose()
        {
            Clear();
        }
    }
}
