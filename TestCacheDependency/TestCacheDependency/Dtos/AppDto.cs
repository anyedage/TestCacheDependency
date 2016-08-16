using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCacheDependency.Dtos
{
    public class AppDto : IKey
    {
        public Guid ApplicationId { get; set; }
        public string AppName { get; set; }
        public Guid TypeId { get; set; }

        public string Key()
        {
            return ApplicationId.ToString();
        }
    }
}
