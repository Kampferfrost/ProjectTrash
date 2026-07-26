
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProofCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Присвоить метод делегату Action<int>
            Action<int> a1 = PrintNumberSquared;
            a1.Invoke(4);
            void PrintNumberSquared(int x1)
            {
                Console.WriteLine(x1 * x1);
            }

            // 2.Присвоить лямбду Action<string>
            Action<string> a2 = ((text2 => Console.WriteLine(text2.Length)));

            // 3. Передать Action<double> в метод

            ExecuteDouble((double x3) => Console.WriteLine(x3));
            void ExecuteDouble(Action<double> act)
            {
                act.Invoke(3.14);
            }

            // 4. Создать Action<Task>
            Action<Task> a4 = PrintIdTask;
            a4.Invoke(new Task(() => Console.WriteLine("Id текущей задачи: ")));

            void PrintIdTask(Task task4)
            {
                task4.Start();
                Console.Write(task4.Id);
                task4.Wait();
            }

            // 5. Присвоить Func<int, string>

            string? input = "5";
            bool result = int.TryParse(input, out var number);
            Func<int, string> f1 = GetText5;
            Console.WriteLine(f1.Invoke(number));
            string GetText5(int str)
            {
                int a5 = str % 2;
                if (a5 == 0)
                {
                    return "Even";
                }

                else
                {
                    return "Odd";
                }
            }

            // 6. Присвоить Func<string, bool>
            Func<string, bool> f2 = ((string input6) => input6 != string.Empty);

            // 7.Передать Func<int, int, int> в метод
            int result6 = Calc((int a6, int b6) => a6 + b6);
            Console.WriteLine(result6);
            int Calc(Func<int, int, int> op)
            {
                return op.Invoke(5, 6);
            }

            // 8. Присвоить Func<Task<int>>
            Func<Task<int>> f3 = (() =>
            {
                return Task.Run(() => 8);
            });

            // 9. Создать Task, который использует переменную из замыкания
            int counter9 = 0;
            Task t9 = new Task(() => counter9 = counter9 + 1);

            //10.Создать Task<int>, который возвращает сумму массива
            int[] nums = { 1, 2, 3, 4 };
            Task<int> t10 = new Task<int>(() =>
            {
                return nums.Sum();
            });

            // 11.Создать Task<string>, который возвращает текущее время
            Task<string> t11 = new Task<string>(() => DateTime.Now.ToString("T"));

            // 12. Создать Task<int>, который использует метод Func<int>
            Func<int> f12 = () => 999;
            Task<int> t12 = new Task<int>(() => f12());

            //// 13.Почему нельзя передать Task в Action<Task<int>> ?
            //Action<Task<int>> a13;
            //Task t = new Task(() => { });

            //a13(t); // Нельзя потому что он a13 хочет Task с <int>

            //// 14.Почему нельзя присвоить Func<int> в Action<int> ?
            //Func<int> f14 = () => 5;
            //Action<int> a14 = f14; // ошибка
            //// Нельзя потому что Action возвращает Void а не int

            ////15.Почему нельзя передать Task<int> в Action<Task> ?
            //Action<Task> a15;
            //Task<int> t15 = new Task<int>(() => 10);

            //a15(t);
            //// Нельзя, потому что Action<Task> принимает Task, а Task<int> — другой тип. Task<int> не является наследником Task.

            //16. Создать Task<int> и передать его в метод, принимающий Func<Task<int>>
            Task<int> t16 = new Task<int>(() => 5);
            Execute16(() => t16);
            Task<int> Execute16(Func<Task<int>> creator)
            {
                t16.Start();
                t16.Wait();
                return t16;
            }

            // 17. Создать Action<Task<int>>, который выводит результат задачи
            Action<Task<int>> printer17 = ((Task<int> d17) => Console.WriteLine(d17.Result));
            Task<int> t17 = new Task<int>(() => 123);
            t17.Start();
            t17.Wait();
            printer17.Invoke(t17);

            // 18.Создать Task<string>, который использует Func<string, string>
            Func<string, string> upper = s => s.ToUpper();
            Task<string> t = new Task<string>(() => upper.Invoke("tiger"));

            // 19. Создать Task<int>, который использует Action<int> внутри
            Action<int> logger19 = x19 => Console.WriteLine($"Value: {x19}");
            Task<int> t19 = new Task<int>(() =>  
            {
                int number19 = 19;
                logger19.Invoke(number19);
                return number19;
            });

            // 20. Создать Task<int>, который вызывает Func<int, int> и возвращает результат
            Func<int, int> doubler20 = x => x * 2;
            Task<int> t20 = new Task<int>(() => doubler20.Invoke(5));


        }


    }

}



