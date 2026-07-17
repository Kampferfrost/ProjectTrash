using ParallelProgrammin.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgrammin

{
    internal class Lesson5 : ILesson

    {
        public int Number => 5;

        public string Title => "Отмена задач и параллельных операций. CancellationToken";

        public void StartLessonExamples()
        {
            StartSoftCancellationToken();
            StopTaskWithExeptionGeneration();
            StopTaskWithComplectionProcessing();
            StartTaskPassingToExternalmethod();
            CanсelParallelOperationExample();
        }

        // Мягкий выход из задачи без исключения OperationCanceledException
        private void StartSoftCancellationToken()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            // задача вычисляет квадраты чисел
            Task task = new Task(() =>
            {
                for (int i = 1; i < 10; i++)
                {
                    if (token.IsCancellationRequested) // проверяем наличие сигнала отмены задачи
                    {
                        Console.WriteLine("Операция прервана");
                        return; // выходим из метода и тем самым завершаем задачу
                    }
                    Console.WriteLine($"Квадрат числа {i} равен {i * i}");
                    Thread.Sleep(200);
                }
            }, token);
            task.Start();

            Thread.Sleep(1000);
            // После задержки по времени отменяем выполнение задачи
            cancelTokenSource.Cancel();
            // ожидаем завершения задачи
            Thread.Sleep(1000);
            // проверяем статус задачи
            Console.WriteLine($"Task Status: {task.Status}");
            task.Wait();
            cancelTokenSource.Dispose(); // освобождаем ресурсы

        }
        // Отмена задачи с помощью генерации исключения
        private void StopTaskWithExeptionGeneration()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            Task task = new Task(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    if (token.IsCancellationRequested)
                        token.ThrowIfCancellationRequested(); // генерирует исключение

                    Console.WriteLine($"Квадрат числа {i} равен {i * i}");
                    Thread.Sleep(200);
                }
            }, token);
            try
            {
                task.Start();
                Thread.Sleep(1000);
                // после задержки по времени отменяем выполение задачи
                cancelTokenSource.Cancel();

                task.Wait(); // ожидаем завершение задачи
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                        Console.WriteLine("Операция прервана");
                    else
                        Console.WriteLine(e.Message);
                }
            }
            finally
            {
                cancelTokenSource.Dispose();
            }

            // проверяем статус задачи
            Console.WriteLine($"Task Status: {task.Status}");
        }

        // Регистрация обработчика отмены задачи
        private void StopTaskWithComplectionProcessing()
        {
            Console.WriteLine();
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            // задача вычисляет квадраты чисел
            Task task = new Task(() =>
            {
                int i = 0;
                token.Register(() =>
                {
                    Console.WriteLine("Операция прервана");
                    i = 10;
                });
                for (; i < 10; i++)
                {
                    Console.WriteLine($"Квадрат числа {i} равень {i * i}");
                    Thread.Sleep(400);
                }
            }, token);
            task.Start();

            Thread.Sleep(1000);
            // после задержки по времени отменяем выполение задачи
            cancelTokenSource.Cancel();
            // ожидаем завершения задачи
            Thread.Sleep(1000);
            // проверяем статус задачи
            Console.WriteLine($"Task Status: {task.Status}");
            cancelTokenSource.Dispose(); // освобождаем ресурсы
        }

        // Передача токена во внешний метод
        private void StartTaskPassingToExternalmethod()
        {
            Console.WriteLine("\nПередача токена во внешний метод");
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            Task task = new Task(() => PrintSquares(token), token);
            try
            {
                task.Start();
                Thread.Sleep(1000);
                // после задержки по времени отменяем выполение задачи
                cancelTokenSource.Cancel();

                // ожидаем завершения задачи
                task.Wait();
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                        Console.WriteLine("Операция прервана");
                    else
                        Console.WriteLine(e.Message);
                }
            }
            finally
            {
                cancelTokenSource.Dispose();
            }

            // проверяем статус задачи
            Console.WriteLine($"Task Status: {task.Status}");



            void PrintSquares(CancellationToken token)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (token.IsCancellationRequested)
                        token.ThrowIfCancellationRequested(); // генерируем исключение

                    Console.WriteLine($"Квадрат числа {i} равень {i * i}");
                    Thread.Sleep(200);
                }
            }
        }

        // Отмена параллельных операций Parallel
        private void CanсelParallelOperationExample()
        {
            Console.WriteLine("\nОтмена параллельных операций Parallel");
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            // в другой задаче посылаем сигнал отметы
            new Task(() =>
            {
                Thread.Sleep(400);
                cancelTokenSource.Cancel();
            }).Start();

            try
            {
                Parallel.ForEach<int>(new List<int>() { 1, 2, 3, 4, 5 },
                                new ParallelOptions { CancellationToken = token }, Square);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Операция прервана");
            }
            finally
            {
                cancelTokenSource.Dispose();
            }

            void Square(int n)
            {
                Thread.Sleep(3000);
                Console.WriteLine($"Квадрат числа {n} равен {n * n}");
            }
        }
    }
}
