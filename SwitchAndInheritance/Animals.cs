using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAndInheritance
{
    public abstract class Animal
    {
        public string Name = "Animal";

        public double Height = 0;

        public virtual void Do()
        {

        }
    }

    public class Cat : Animal
    {
        public new string Name = "Cat";

        public override void Do()
        {

        }
    }
}
