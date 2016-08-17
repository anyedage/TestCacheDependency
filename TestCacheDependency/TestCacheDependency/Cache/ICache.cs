using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCacheDependency.Cache
{
    public interface ICache
    {
        T Get<T>(string key);
        void Set(string key, object data);
        void Remove(string key);
    }
}
