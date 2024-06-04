using System.ComponentModel.DataAnnotations;

namespace TestCode
{
    delegate void Message();
    internal class Program
    {
        static void Main(string[] args)
        {
            //Account account = new Account(100);
            //account.Put(20); // добавляем на счет 20
            //Console.WriteLine($"Сумма на счете: {account.Sum}");

            //account.Take(70); // пытаемся снять со счета 70
            //Console.WriteLine($"Сумма на счете: {account.Sum}");

            //account.Take(180);
            //Console.WriteLine($"Сумма на счете: {account.Sum}");

            //Console.WriteLine();

            Hello hello = new Hello();
            Message message1;
            message1 = hello.Display;

            Welcome welcome = new Welcome();
            Message message2;
            message2 = welcome.Print;

            message1.Invoke();
            message2.Invoke();




        }

    }


}









