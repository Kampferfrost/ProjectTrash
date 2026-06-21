using System;
using System.Threading;

namespace MultithreadLearning
{
    internal class Lesson4
    {
        public int X { get; set; } = 0;
        private readonly object locker = new(); // объект-заглушка

        public void StartLessonExamples()
        {
            Console.WriteLine("\n*---------------------------------------------*\n");
            Console.WriteLine(GetType());
            CreateThread();
        }
        void CreateThread()
        {

            // запускаем пять потоков
            for (int i = 1; i < 6; i++)
            {
                Thread myThread = new(Print);
                myThread.Name = $"Поток {i}"; // устанавливаем имя для каждого потока
                myThread.Start();
            }

        }

        void Print()
        {
            lock (locker)
            {
                X = 1;
                for (int i = 1; i < 6; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {X}");
                    X++;
                    Thread.Sleep(100);
                }
            }
   

        }

    }
}
