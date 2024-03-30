using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCode
{
    internal class Player
    {


        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public bool Ban { get;  set; }

        public int Rating { get; set; }

        public decimal Dps { get; set; }

        public static void ShowRoar()
        {
            Console.WriteLine("Я пидор");
        }

    }
}
