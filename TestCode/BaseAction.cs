using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCode
{
    public class BaseAction : IAction
    {
        public void Move() => Console.WriteLine("Move in BaseAction");
    }
}
