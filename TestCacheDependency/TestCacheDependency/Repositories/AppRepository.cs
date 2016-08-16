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
    public class AppRepository
    {
        private readonly Dal _dal = new Dal();

        public List<AppDto> GetApps()
        {
            var list = Caches.GetSet(SetName.AppSet).GetAll() as List<AppDto>;
            return list;
        }

        public List<AppPackageDto> GetAppPackages()
        {
            var list = Caches.GetSet(SetName.PackageSet).GetAll() as List<AppPackageDto>;
            return list;
        }

        public List<AppDetailDto> GetAppDetails()
        {
            var list = Caches.GetSet(SetName.DetailSet).GetAll() as List<AppDetailDto>;
            return list;
        }

        public List<AppTypeDto> GetAppTypes()
        {
            var list = _dal.GetAppTypes();
            return list;
        }

        public void UpdateApp(AppDto app)
        {
            //更新数据库
            _dal.UpdateApp(app);

            //CUD动作都需要向Caches出发一个Event
            Caches.Handler(new EventEntity(EventAct.U, TableName.Application, app.Key()));
        }
    }
}
