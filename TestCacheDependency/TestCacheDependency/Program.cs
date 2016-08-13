using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCacheDependency
{
    class Program
    {
        static void Main(string[] args)
        {
            AppCaches.DisplayDependRelations();

            Console.ReadKey();
        }
    }
}
