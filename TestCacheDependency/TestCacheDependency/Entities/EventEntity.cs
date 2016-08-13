using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCacheDependency.Entities
{
    /// <summary>
    /// 事件实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventEntity<T>
    {
        public EventActEnum EventAct { get; set; }
        public T Entity { get; private set; }
        public string EntityKey { get; private set; }

        public EventEntity(EventActEnum eventAct, T entity, Func<T, string> getKey)
        {
            EventAct = eventAct;
            Entity = entity;
            EntityKey = getKey(entity);
        }
    }
}
