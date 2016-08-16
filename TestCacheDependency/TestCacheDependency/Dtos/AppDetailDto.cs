using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCacheDependency.Dtos
{
    public class AppDetailDto : IKey

    {
        public Guid AppId { get; set; }
        public string AppName { get; set; }
        public string Description { get; set; }
        public Guid TypeId { get; set; }

        public string Key()
        {
            return AppId.ToString();
        }
    }
}
