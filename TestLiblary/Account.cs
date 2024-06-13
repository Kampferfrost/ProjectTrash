namespace TestLiblary
{
    public delegate void AccountHandler(string message);
    public class Account
    {
        private int _sum;

        AccountHandler? taken;
        public Account(int sum) => _sum = sum;
        public void RegisterHandler(AccountHandler del)
        {
            taken = del;
        }
        public void Add(int sum) => _sum += sum;
        public void Take(int sum)
        {
            if (_sum >= sum)
            {
                _sum -= sum;
                taken?.Invoke($"Со счета списано {sum} у. е.");
            }
            else
            {
                taken?.Invoke($"Недостаточно средств: Баланс: {_sum} у.е.");
            }
        }

    }
}
