using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop2
{
    internal class Player
    {
        private int _x = 2;
        public int X { get; private set; } = 5;


        private int _y = 2;

        public int Y
        {
            get 
            { 
                return _y; 
            }
            set 
            { 
                _y = value; 
            }
        }

        
    }
}
