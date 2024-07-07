namespace TestCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = new(100);
            account.Notify += DisplayMessage;
            account.Put(20);    // добавляем на счет 20
            Console.WriteLine($"Сумма на счете: {account.Sum}");
            account.Take(70);   // пытаемся снять со счета 70
            Console.WriteLine($"Сумма на счете: {account.Sum}");
            account.Take(180);  // пытаемся снять со счета 180
            Console.WriteLine($"Сумма на счете: {account.Sum}");

            account.Notify -= DisplayMessage;

            void DisplayMessage(ConsoleColor color, Account sender, AccountEventArgs e)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }

        }
    }

}











