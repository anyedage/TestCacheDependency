using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCacheDependency.Dtos
{
    public class AppPackageDto
    {
        public Guid PackageId { get; set; }
        public Guid AppId { get; set; }
        public string AppName { get; set; }
        public int HostType { get; set; }
        public string Url { get; set; }
    }
}
