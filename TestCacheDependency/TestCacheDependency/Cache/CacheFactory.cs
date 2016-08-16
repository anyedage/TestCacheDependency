using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCacheDependency.Cache
{
    public class CacheFactory
    {
        public static ICache Instance()
        {
            return new MemoryCache();
        }
    }
}
