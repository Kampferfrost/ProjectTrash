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

            Counter counter2 = x;
            
            Console.WriteLine(counter2.Seconds);

        }

    }


}









