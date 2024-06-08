using System.ComponentModel.DataAnnotations;

namespace TestCode
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(200);
            account.RegisterHandler(PrintSimpleMessage);
            account.RegisterHandler(PrintColorMessage);

            account.Take(100);
            account.Take(150);

            account.UnregisterHandler(PrintColorMessage);

            account.Take(50);


            void PrintSimpleMessage(string message) => Console.WriteLine(message);
            void PrintColorMessage(string message)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }

    }


}

// Короче Лежишь в чем-то торчишь вот тебе задания:
// Todo: 1) класс Account сделай в dll
// Todo: 2) этот файл тебе нужно будет подключить и использовать
// Todo: 3) ...
// ...
// Todo: 3) profit






