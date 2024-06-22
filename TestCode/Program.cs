using TestLiblary;

namespace TestCode
{

    internal class Program
    {
        static void Main(string[] args)
        {
            StockExchangeMonitor stockExchangeMonitor = new StockExchangeMonitor();
            stockExchangeMonitor.PriceChangeHandler = ShowPrice;
            stockExchangeMonitor.Start();


            void ShowPrice(int price) => Console.WriteLine($"New price is: {price}");

        }


    }


}

// Короче Лежишь в чем-то торчишь вот тебе задания:
// Todo: 1) класс Account сделай в dll
// Todo: 2) этот файл тебе нужно будет подключить и использовать
// Todo: 3) ...
// ...
// Todo: 3) profit






