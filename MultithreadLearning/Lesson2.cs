using System;
using System.Threading;
// Создание потоков. Делегат ThreadStart
namespace MultithreadLearning
{
    internal class Lesson2
    {

        public void StartLessonExamples()
        {
            Console.WriteLine("\n*---------------------------------------------*\n");
            Console.WriteLine(GetType());
            CreateThread();
            CreateTreadTogether();
        }
        void CreateThread()
        {
            Thread myThread1 = new Thread(Print);
            Thread myThread2 = new Thread(new ThreadStart(Print));
            Thread myThread3 = new Thread(()=>Console.WriteLine("Hello Threads"));

            myThread1.Start();  // запускаем поток myThread1
            myThread2.Start();  // запускаем поток myThread2
            myThread3.Start();  // запускаем поток myThread3

        }

        void CreateTreadTogether()
        {
            // создаем новый поток
            Thread myThread = new Thread(PrintWithSleep);
            // запускаем поток myThread
            myThread.Start();

            // действия, выполняемые в главном потоке
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Главный поток: {i}");
                Thread.Sleep(300);
            }

            // действия, выполняемые во втором потокке


        }

        void PrintWithSleep()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Второй поток: {i}");
                Thread.Sleep(400);
            }
            
        }


        void Print() => Console.WriteLine("Hello Threads");
    }
}
