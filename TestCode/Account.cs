namespace TestCode
{
    public delegate void AccountHandler(string message, ConsoleColor color);

    internal class Account
    {
        public event AccountHandler? Notify;
        public int Sum { get; private set; }
        public Account(int sum) => Sum = sum;
        public void Put(int sum)
        {
            Sum += sum;
            Notify?.Invoke($"На счет поступило: {sum}", ConsoleColor.Green);
        }
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                Notify?.Invoke($"Со счета снято: {sum}", ConsoleColor.Yellow);
            }
            else
            {
                Notify?.Invoke($"Недостаточно денег на счете. Текущий баланс: {Sum}", ConsoleColor.Red);
            }



        }

    }
}
