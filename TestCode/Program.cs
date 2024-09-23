namespace TestCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = new(100);
            account.Notify += DisplayMessage;
            account.Put(20);    // добавляем на счет 20
            
            account.Take(70);   // пытаемся снять со счета 70
            account.Take(180);  // пытаемся снять со счета 180


            account.Notify -= DisplayMessage;

            void DisplayMessage(ConsoleColor color, Account sender, AccountEventArgs e)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                Console.WriteLine($"Сумма на счете: {sender.Sum}");
            }

            Guid g = new Guid();
            g = Guid.NewGuid();
            Console.WriteLine(g);

        }
    }

}











