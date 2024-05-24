using System.Threading.Channels;

namespace TestCode
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Counter counter1 = new Counter { Seconds = 23 };

            int x = (int)counter1;
            Console.WriteLine(x);
            
            Counter counter2 = new Counter { Seconds = 23 };
            
            Console.WriteLine((string)counter2);

        }

    }


}









