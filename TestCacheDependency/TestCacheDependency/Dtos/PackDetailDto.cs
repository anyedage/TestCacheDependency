using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCacheDependency.Dtos
{
    public class PackDetailDto
    {
        public Guid Id { get; set; }
        public Guid PackageId { get; set; }
        public Guid AppId { get; set; }
        public int HostType { get; set; }
        public string Url { get; set; }
    }
}
