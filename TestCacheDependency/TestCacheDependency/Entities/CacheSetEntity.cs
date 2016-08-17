using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCacheDependency.Cache;
using TestCacheDependency.Dtos;

namespace TestCacheDependency.Entities
{
    /// <summary>
    /// 负责Cache实体的事件处理（包括初始化事件）
    /// </summary>
    public class CacheSetEntity
    {
        public CacheSetEntity(SetName setName, CacheSetting cacheSetting, Func<object> listFactory)
        {
            _listFactory = listFactory;
            _cache = CacheFactory.Instance();

            SetName = setName;
            CacheSetting = cacheSetting;
        }

        private readonly Func<object> _listFactory;
        private bool _isChanged = true;
        private readonly ICache _cache;

        public SetName SetName { get; private set; }
        public CacheSetting CacheSetting { get; private set; }
        
        public object GetAll()
        {
            object list;
            if (_isChanged)
            {
                 list = _listFactory();
                SetAll(list);//list写入
                _isChanged = false;
            }

            //取缓存
            list = _cache.Get<object>(SetName.ToString());

            return list;
        }

        public object GetSingle<T>(string key)
            where T : IKey
        {
            var list = GetAll() as List<T>;
            return list.SingleOrDefault(x => x.Key() == key);
        }

        private void SetAll(object list)
        {
            _cache.Set(SetName.ToString(),list);
        }

        public void AddEvent(string key)
        {
            _isChanged = true;
        }

        public void UpdateEvent(string key)
        {
            _isChanged = true;
        }

        public void DeleteEvent(string key)
        {
            _isChanged = true;
        }
    }
}
