using System.Threading.Channels;

namespace TestCode
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Counter counter1 = new Counter() { Seconds = 115 };

            Timer timer = counter1;
            Console.WriteLine($"{timer.Hours}:{timer.Minutes}:{timer.Seconds}"); //0:1:55

            Counter counter2 = (Counter)timer;
            Console.WriteLine(counter2.Seconds); //115




        }

    }


}









