using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCode
{
    internal class Person : ISchool, IUniversity
    {
        void ISchool.Study() => Console.WriteLine("Учеба в школе");
        void IUniversity.Study() => Console.WriteLine("Учеба в университете");
    }
}
