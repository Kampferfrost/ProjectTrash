namespace TestCode
{
    public delegate void AccountHandler( ConsoleColor color, Account sender, AccountEventArgs e);

    public class Account
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
            notify?.Invoke( ConsoleColor.Green, this, new AccountEventArgs($"На счет поступило: {sum}", sum));
        }
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                notify?.Invoke( ConsoleColor.Yellow, this, new AccountEventArgs($"Со счета снято: {sum}", sum));
            }
            else
            {
                notify?.Invoke(ConsoleColor.Red, this, new AccountEventArgs($"Недостаточно денег на счете. Текущий баланс: {Sum}", Sum));
            }



        }

    }
}
