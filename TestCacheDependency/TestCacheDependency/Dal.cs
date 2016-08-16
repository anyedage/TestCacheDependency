using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCacheDependency.Dtos;

namespace TestCacheDependency
{
    /// <summary>
    /// 负责数据库访问
    /// 只对Caches和Repository可见
    /// </summary>
    public class Dal
    {
        private readonly List<AppDto> _apps;
        private readonly List<AppTypeDto> _types;
        private readonly List<AppPackageDto> _packages ;

        public Dal()
        {
            var type1 = new AppTypeDto {TypeId = Guid.NewGuid(), TypeName = "社交"};
            var type2 = new AppTypeDto {TypeId = Guid.NewGuid(), TypeName = "游戏"};
            _types = new List<AppTypeDto> {type1, type2};
            _apps = new List<AppDto>
            {
                new AppDto { ApplicationId = Guid.NewGuid(), AppName = "app one", TypeId = type1 .TypeId},
                new AppDto { ApplicationId = Guid.NewGuid(), AppName = "app two", TypeId = type1 .TypeId},
                new AppDto { ApplicationId = Guid.NewGuid(), AppName = "app three", TypeId = type2 .TypeId}
            };

            var i = 1;
            _packages = new List<AppPackageDto>();
            foreach (var app in _apps)
            {
                _packages.Add(new AppPackageDto { AppId = app.ApplicationId, AppName = app.AppName, HostType = 1, PackageId = Guid.NewGuid(), Url = "url" + i++ });
                _packages.Add(new AppPackageDto { AppId = app.ApplicationId, AppName = app.AppName, HostType = 2, PackageId = Guid.NewGuid(), Url = "url" + i++ });
            }
        }

        public List<AppDto> GetApps()
        {
            return _apps;
        }

        public List<AppDetailDto> GetDetailApps()
        {
            var details = _apps.Select(
                        x =>
                            new AppDetailDto
                            {
                                AppId = x.ApplicationId,
                                AppName = x.AppName,
                                Description = x.AppName + "--" + x.AppName,
                                TypeId = x.TypeId
                            }).ToList();
            return details;
        }

        public List<AppPackageDto> GetAppPackages()
        {
            return _packages;
        }

        public List<AppTypeDto> GetAppTypes()
        {
            return _types;
        }

        public void UpdateApp(AppDto app)
        {
            var a = _apps.SingleOrDefault(x => x.Key() == app.Key());
            _apps.Remove(a);
            _apps.Add(app);
        }

        public void UpdateAppPackage(AppPackageDto pack)
        {
            var p = _packages.SingleOrDefault(x => x.Key() == pack.Key());
            _packages.Remove(p);
            _packages.Add(pack);
        }
    }
}
