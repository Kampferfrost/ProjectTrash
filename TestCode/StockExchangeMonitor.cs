using System.Threading;

namespace TestCode
{
    internal class StockExchangeMonitor
    {

        public delegate void PriceChange(int price);
        public bool StatusDLL { get; set; } = true;
        public PriceChange PriceChangeHandler { get; set; }

        public void Start()
        {
            while (StatusDLL)
            {
                int bankOfAmericaPrice = (new Random()).Next(100);

                PriceChangeHandler(bankOfAmericaPrice);

                Thread.Sleep(2000);
            }
        }
    }
}
