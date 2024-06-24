using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCode
{
    internal class Person : IMovable
    {
        string _name;

        MoveHandler? moveHandler;
        event MoveHandler IMovable.MoveEvent
        {
            add => moveEvent += value;
            remove => moveEvent -= value;
        }
        string IMovable.Name { get => _name; }
        public Person(string name) => _name = name;

        void IMovable.Move()
        {
            Console.WriteLine(($"{_name} is walking");
            moveEvent?.Invoke();
        }

        
    }
}
