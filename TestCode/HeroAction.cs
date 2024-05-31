using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCode
{
    internal class HeroAction : BaseAction, IAction
    {
        void IAction.Move() => Console.WriteLine("Move in HeroAction");
    }
}
