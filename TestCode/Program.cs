using System.ComponentModel.DataAnnotations;

namespace TestCode
{
    delegate void Message();

    delegate T Operation<T, K>(K val);
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

            Operation<decimal, int> squareOperation = Square;
            decimal result1 = squareOperation.Invoke(5);
            Console.WriteLine(result1);

            Operation<int, int> doubleOperation = Double;
            Console.WriteLine(doubleOperation.Invoke(7));




            decimal Square(int n) => n * n;
            int Double(int n) => n + n;


        }

    }


}









