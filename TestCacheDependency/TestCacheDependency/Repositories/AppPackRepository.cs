using System.Collections.Generic;
using TestCacheDependency.Dtos;
using TestCacheDependency.Entities;

namespace TestCacheDependency.Repositories
{
    /// <summary>
    /// 数据仓储
    /// 是业务获取数据的唯一入口
    /// 数据仓储的数据源可能是DB、Cache
    /// 任何CUD动作都需要向Caches出发一个Event，至于这个Event的后续处理则由Caches自己决定
    /// </summary>
    public class AppPackRepository
    {
        public List<AppPackageDto> GetApps()
        {
            var list = Caches.GetSet(SetName.PackageSet).GetAll() as List<AppPackageDto>;
            return list;
        }

        public void UpdateAppPackage(AppPackageDto pack)
        {
            //更新数据库
            new Dal().UpdateAppPackage(pack);

            //发出更新事件
            Caches.Handler(new EventEntity(EventAct.U, TableName.AppPackage, pack.Key()));
        }
    }
}
