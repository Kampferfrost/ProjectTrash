using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop2
{
    internal class Player
    {
        private int _x = 5;
        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                if (value <= 0)
                {
                    _x = value;
                }
                else
                {
                    Console.WriteLine("X должен быть больше или ровно 0");
                }
            }
        }


        private int _y = 2;

        public int Y
        {
            get 
            { 
                return _y; 
            }
            set 
            { 
                if (value <= 0)
                {
                    _y = value;
                }
                else
                {
                    Console.WriteLine("Y должен быть больше или ровно 0");
                }
            }
        }

        
    }
}
