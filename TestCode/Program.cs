using System.Threading.Channels;

namespace TestCode
{

    internal class Program
    {
        delegate void Message();
        delegate void Message2(string text);
        delegate int Message3(int numberOne, int numberTwo);
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

            Message mess4 = () => Console.WriteLine("Сокращение");

            Message2 mess5 = (text) => Console.WriteLine(text);

            Message3 mess6 = (numberOne, numberTwo) =>
            {
                int numberResult = numberOne + numberTwo;

                return numberResult;
            };

            mess();
            mess2();
            mess3();
            mess4();
            mess5("Этот текст я передал делегатам");
            Console.WriteLine(mess6(5, 3));
            

        }




    }


}









