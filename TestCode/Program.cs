namespace TestCode
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(100);
            account.Put(20); // добавляем на счет 20
            Console.WriteLine($"Сумма на счете: {account.Sum}");

            account.Take(70); // пытаемся снять со счета 70
            Console.WriteLine($"Сумма на счете: {account.Sum}");

            account.Take(180);
            Console.WriteLine($"Сумма на счете: {account.Sum}");

        }

    }


}









