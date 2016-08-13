using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCacheDependency.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CacheSetEntity<T>
    {
        public CacheSetEntity(string keyField)
        {
            KeyField = keyField;
        }
        public string CacheSetName
        {
            get { return "c_" + typeof (T).Name; }
        }
        public string KeyField { get; private set; }

        
        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetByKey()
        {
            throw new NotImplementedException();
        }

        public void SetAll(List<T> list)
        {
            throw new NotImplementedException();
        }

        public void Set(T item)
        {
            throw new NotImplementedException();
        }
    }
}
