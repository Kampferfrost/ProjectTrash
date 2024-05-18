using System.Threading.Channels;

namespace TestCode
{

    internal class Program
    {
        delegate void Message();
        static void Main(string[] args)
        {


            Message mess = ShowText;



            // Просто делегат
            void ShowText()
            {
                Console.WriteLine("Просто делигат");
            }

            // Анонимный делегат
            Message mess2 = delegate ()
            {
                Console.WriteLine("Анонимный метод");
            };

            Message mess3 = () =>
                {
                    Console.WriteLine("Лямда");
                };


            mess();
            mess2();
            mess3();

        }




    }


}









