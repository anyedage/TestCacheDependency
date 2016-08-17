using System;
using System.Collections.Generic;
using System.Linq;
using TestCacheDependency.Dtos;
using TestCacheDependency.Entities;

namespace TestCacheDependency.Repositories
{
    /// <summary>
    /// 负责管理所有的cache，它清楚cache数据怎样初始化（调用DAL）
    /// Caches只对Repository可见
    /// 
    /// 新增CacheSetEntity，主要涉及两个方法：InitSet、InitRelation
    /// </summary>
    public class Caches
    {
        private static readonly Dal Dal = new Dal();

        public static List<CacheSetEntity> SetList { get; private set; }
        public static List<Relation> DependRelations = new List<Relation>();

        static Caches()
        {
            InitSet();
        }

        #region public method

        public static void Handler(EventEntity eventEntity)
        {
            var sets = GetEffectedSets(eventEntity);

            //处理事件
            foreach (var cacheSet in sets)
            {
                switch (eventEntity.EventAct)
                {
                    case EventAct.C:
                        cacheSet.AddEvent(eventEntity.Key);
                        break;
                    case EventAct.D:
                        cacheSet.DeleteEvent(eventEntity.Key);
                        break;
                    case EventAct.U:
                        cacheSet.UpdateEvent(eventEntity.Key);
                        break;
                }
            }
        }

        public static CacheSetEntity GetSet(SetName setNameName)
        {
            return SetList.SingleOrDefault(x => x.SetName == setNameName);
        }

        public static void DisplayDependRelations()
        {
            var strFormater = "当前:{0} ,父:{1} ";

            foreach (var relation in DependRelations)
                Console.WriteLine(strFormater, relation.SetName, relation.DependTable);
        }

        #endregion

        #region private method

        private static List<CacheSetEntity> GetEffectedSets(EventEntity eventEntity)
        {
            var setNames = DependRelations
                .Where(x => x.DependTable == eventEntity.TableName)
                .Select(x => x.SetName)
                .Distinct();
            var sets = SetList
                .Where(x => setNames.Contains(x.SetName))
                .ToList();
            return sets;
        }

        private static void InitSet()
        {
            SetList = new List<CacheSetEntity>();
            var appSet = new CacheSetEntity(SetName.AppSet, CacheSetting.AppCache, Dal.GetApps);
            var detailSet = new CacheSetEntity(SetName.DetailSet, CacheSetting.AppCache, Dal.GetDetailApps);
            var packageSet = new CacheSetEntity(SetName.PackageSet, CacheSetting.AppCache, Dal.GetAppPackages);

            SetList.Add(appSet);
            SetList.Add(detailSet);
            SetList.Add(packageSet);

            InitRelation();
        }

        private static void AddRelation(SetName mainSetName, TableName relationTable)
        {
            DependRelations.Add(
                new Relation
                {
                    SetName = mainSetName,
                    DependTable = relationTable
                });
        }

        private static void InitRelation()
        {
            AddRelation(SetName.AppSet, TableName.Application);
            AddRelation(SetName.AppSet, TableName.AppType);
            AddRelation(SetName.DetailSet, TableName.Application);
            AddRelation(SetName.PackageSet, TableName.AppPackage);
        }

        #endregion

    }
}
