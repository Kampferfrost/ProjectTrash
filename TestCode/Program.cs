namespace TestCode
{

    internal class Program
    {
        static void Main(string[] args)
        {
            int number;
            Console.WriteLine("Введите число");

            if(int.TryParse(Console.ReadLine(), out number))
            {
                Console.Clear();
                Console.WriteLine($"Номер {number}");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Некорректный ввод числа");

            }



        }
    }



}









