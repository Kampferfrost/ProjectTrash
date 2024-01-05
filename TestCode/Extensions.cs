using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestCode
{
    internal static class Extensions
    {
        public static  void Foo(this ILogger logger) 
        {
            Console.WriteLine("Foo");
        }
    }
}
