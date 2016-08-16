using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCacheDependency.Repositories;

namespace TestCacheDependency
{
    class Program
    {
        static void Main(string[] args)
        {
            Caches.DisplayDependRelations();

            Console.ReadKey();
        }
    }
}
