using ParallelProgrammin.Interfaces;
using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;


namespace ParallelProgrammin
{
    internal class Lesson4 : ILesson
    {
        public int Number => 4;

        public string Title => "Класс Parallel";

        public void StartLessonExamples()
        {
            StartParallel();
            StartExampleParallelFor();
            StartExampleParallelForEach();
            StartExampleParallelExit();
        }

        private void StartParallel()
        {
            // метод Parallel.Invoke выполняет три метода
            Parallel.Invoke(
                Print,
                () =>
                {
                    Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                    Thread.Sleep(3000);
                },
                () => Square(5)
                );

            void Print()
            {
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Thread.Sleep(3000);
            }

            void Square(int n)
            {
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Thread.Sleep(3000);
                Console.WriteLine($"Результат {n * n}");
            }

        }

        // Parallel.For
        private void StartExampleParallelFor()
        {
            
            Parallel.For(0, 5, Square);

            void Square(int n)
            {
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Console.WriteLine($"Квадрат числа {n} равен {n * n}");
                Thread.Sleep(2000);
            }
        }

        private void StartExampleParallelForEach()
        {
            Console.WriteLine("\nParallelForEach");
            ParallelLoopResult result = Parallel.ForEach<int>(
                new List<int>() { 1, 3, 5, 8 },
                Square
                );

            // вычисляем квадрат числа
            void Square(int n)
            {
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Console.WriteLine($"Квадрат числа {n} равен {n * n}");
                Thread.Sleep(2000);
            }
        }

        // Выход из цикла
        private void StartExampleParallelExit()
        {
            Console.WriteLine("\n Выход из цикла");
            ParallelLoopResult result = Parallel.For(1, 10, Square);
            if (!result.IsCompleted)
                Console.WriteLine($"Выполение цикла завершено на итерации {result.LowestBreakIteration}");

            void Square(int n, ParallelLoopState pls)
            {
                if (n == 5) pls.Break(); // если передано 5, выходим из цикла

                Console.WriteLine($"Квадрат числа {n} равен {n * n}");
                Thread.Sleep(2000);
            }
        }
    }
}
