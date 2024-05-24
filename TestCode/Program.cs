using System.Threading.Channels;

namespace TestCode
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Counter counter1 = new Counter() { Value = 50 };
            Counter counter2 = new Counter() { Value = 45 };

            bool result = counter1 > counter2;
            Console.WriteLine(result);

            Counter counter3 = counter1 + counter2;
            Console.WriteLine(counter3.Value);

            Counter counter4 = counter1 - counter2;
            Console.WriteLine(counter4.Value);

        }

    }

    class Counter
    {
        public int Value { get; set; }

        public static Counter operator +(Counter counter1, Counter counter2)
        {
            return new Counter { Value = counter1.Value + counter2.Value };
        }

        public static Counter operator -(Counter counter1, Counter counter2)
        {
            return new Counter { Value = counter1.Value - counter2.Value };
        }

        public static bool operator >(Counter counter1, Counter counter2)
        {
            return counter1.Value > counter2.Value;
        }

        public static bool operator <(Counter counter1, Counter counter2)
        {
            return counter1.Value < counter2.Value;
        }
    }


}









