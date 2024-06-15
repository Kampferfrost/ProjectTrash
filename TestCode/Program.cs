using TestLiblary;

namespace TestCode
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(100);
            account.Notify += DisplayMessage;
            account.Put(20);
            Console.WriteLine($"Сумма на счете: {account.Sum}");
            account.Take(70);
            Console.WriteLine($"Сумма на счете: {account.Sum}");
            account.Take(180);
            Console.WriteLine($"Сумма на счете: {account.Sum}");

            void DisplayMessage(string message) => Console.WriteLine(message);
        }

    }


}

// Короче Лежишь в чем-то торчишь вот тебе задания:
// Todo: 1) класс Account сделай в dll
// Todo: 2) этот файл тебе нужно будет подключить и использовать
// Todo: 3) ...
// ...
// Todo: 3) profit






