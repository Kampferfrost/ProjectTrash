namespace TestCode
{
    public delegate void AccountHandler(string message, ConsoleColor color);

    internal class Account
    {
        AccountHandler? notify;
        public event AccountHandler? Notify
        {
            add
            {
                if (value != null)
                {
                    notify += value;
                    Console.WriteLine($"{value.Method.Name} добавлен");
                }
                
            }
            remove
            {
                if (value != null)
                {
                    notify -= value;
                    Console.WriteLine($"{value.Method.Name} удалён");
                }
                
            }
        }
        public int Sum { get; private set; }
        public Account(int sum) => Sum = sum;
        public void Put(int sum)
        {
            Sum += sum;
            notify?.Invoke($"На счет поступило: {sum}", ConsoleColor.Green);
        }
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                notify?.Invoke($"Со счета снято: {sum}", ConsoleColor.Yellow);
            }
            else
            {
                notify?.Invoke($"Недостаточно денег на счете. Текущий баланс: {Sum}", ConsoleColor.Red);
            }



        }

    }
}
