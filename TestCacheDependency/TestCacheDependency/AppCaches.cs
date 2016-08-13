using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCacheDependency.Dtos;
using TestCacheDependency.Entities;

namespace TestCacheDependency
{
    public class AppCaches
    {
        private static MemoryCache _memoryCache;

        public static CacheSetEntity<AppDto> SetEntity { get; private set; }
        public static CacheSetEntity<AppDetailDto> DetailSetEntity { get; private set; }
        public static CacheSetEntity<AppPackageDto> PackageSetEntity { get; private set; }
        public static CacheSetEntity<AppTypeDto> TypeSetEntity { get; private set; }

        public static List<DependRelation> DependRelations = new List<DependRelation>();
        
        static AppCaches()
        {
            _memoryCache = new MemoryCache();

            InitSet();
        }
        private static void InitSet()
        {
            SetEntity = new CacheSetEntity<AppDto>( "AppId");
            DetailSetEntity = new CacheSetEntity<AppDetailDto>("AppId");
            PackageSetEntity = new CacheSetEntity<AppPackageDto>("PackageId");
            TypeSetEntity = new CacheSetEntity<AppTypeDto>("TypeId");

            InitRelation();
        }

        public static void DisplayDependRelations()
        {
            var currMaxLen = DependRelations.Max(x => x.CurrentSet.Length);
            var baseMaxLen = DependRelations.Max(x => x.BaseSet.Length);
            var strFormater = "当前 = {0,-" + currMaxLen + "} ,父 = {1,-" + baseMaxLen + "} ,有外键 = {2} ,外键 = {3} ";

            foreach(var relation in DependRelations)
                Console.WriteLine(strFormater, relation.CurrentSet, relation.BaseSet, relation.HasForeignKey, relation.ForeignKey);
        }

        public static void AddRelation<T, TBase>(CacheSetEntity<T> mainSetEntity, CacheSetEntity<TBase> baseSetEntity, bool hasForeignKey, string foreignKey = "")
        {
            if (hasForeignKey&&string.IsNullOrEmpty(foreignKey))
                throw new Exception("hasForeignKey为true时，foreignKey不能为空！");

            DependRelations.Add(
            new DependRelation
            {
                CurrentSet = mainSetEntity.CacheSetName,
                BaseSet = baseSetEntity.CacheSetName,
                HasForeignKey = true,
                ForeignKey = foreignKey
            });
        }
        
        private static void InitRelation()
        {
            AddRelation(SetEntity, TypeSetEntity, false);
            AddRelation(DetailSetEntity, SetEntity, true,"ApplicationId");
            AddRelation(DetailSetEntity, TypeSetEntity, false);
            AddRelation(PackageSetEntity, SetEntity, true,"ApplicationId");
        }
    }
}
