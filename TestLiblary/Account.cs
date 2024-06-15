namespace TestLiblary
{
    public delegate void AccountHandler(string message);
    public class Account
    {
        public int Sum { get; private set; }
        public event AccountHandler? Notify;
        public Account(int sum) => Sum = sum;
        public void Put(int sum)
        {
            Sum += sum;
            Notify?.Invoke($"На счет поступило: {sum}");
        }
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                Notify?.Invoke($"Со счета списано {sum} у. е.");
            }
            else
            {
                Notify?.Invoke($"Недостаточно средств: Баланс: {Sum} у.е.");
            }
        }

    }
}
