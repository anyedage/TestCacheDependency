using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCacheDependency.Entities
{
    /// <summary>
    /// 事件实体
    /// </summary>
    public class EventEntity
    {
        public EventAct EventAct { get; set; }
        public TableName TableName { get; private set; }
        public string Key { get; private set; }

        public EventEntity(EventAct eventAct, TableName tableName, string key)
        {
            EventAct = eventAct;
            TableName = tableName;
            Key = key;
        }
    }
}
