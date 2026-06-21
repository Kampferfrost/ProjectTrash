using System;
using System.Threading;
namespace MultithreadLearning
{
    // lesson 1
    internal class ClassThread : IClassThread

    {
        public void GetThreadInfo()
        {
            // получаем текущий поток
            Thread currentThread = Thread.CurrentThread;

            // получаем имя потока
            Console.WriteLine($"Имя потока: {currentThread.Name}");
            currentThread.Name ??= "Метод Main";
            Console.WriteLine($"Имя потока: {currentThread.Name}");

            Console.WriteLine($"Запущен ли поток: {currentThread.IsAlive}");
            Console.WriteLine($"Id потока: {currentThread.ManagedThreadId}");
            Console.WriteLine($"Приоритет потока: {currentThread.Priority}");
            Console.WriteLine($"Статус потока: {currentThread.ThreadState}");


        }

        public void CheckSleepMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);      // задержка выполнения на 500 миллисекунд
                Console.WriteLine(i);
            }
        }
    }
}
