using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCacheDependency.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public enum SetName
    {
        AppSet, DetailSet, PackageSet,//TypeSet不在缓存中
    }

    public enum TableName
    {
        Application, AppType, AppPackage,//AppDetail不在数据库中
    }
}
