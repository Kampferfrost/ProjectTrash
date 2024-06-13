

using TestLiblary;

namespace TestCode
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(200);
            account.RegisterHandler(PrintSimpleMessage);
            account.Take(100);
            account.Take(150);
            
            void PrintSimpleMessage(string message) => Console.WriteLine(message);

        }

    }


}

// Короче Лежишь в чем-то торчишь вот тебе задания:
// Todo: 1) класс Account сделай в dll
// Todo: 2) этот файл тебе нужно будет подключить и использовать
// Todo: 3) ...
// ...
// Todo: 3) profit






