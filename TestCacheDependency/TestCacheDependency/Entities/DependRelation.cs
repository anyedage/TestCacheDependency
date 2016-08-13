using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCacheDependency.Entities
{
    public class DependRelation
    {
        public string CurrentSet { get; set; }
        public string BaseSet { get; set; }
        public bool HasForeignKey { get; set; }
        public string ForeignKey { get; set; }
    }
}
