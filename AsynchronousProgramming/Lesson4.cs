using System;
using System.Collections.Generic;
using System.Text;

namespace AsynchronousProgramming
{
    internal class Lesson4 : ILesson
    {
        public int Number => 4;

        public string Title => "Обработка ошибок в асинхронных методах";

        public async Task StartLessonExamplesAsync()
        {
            await RunErrorHanderAsync();
            await RunCatchInMethodAsync();
            await RunExclusionStudyAsync();
            await RunSomeExceptionWhenAllAsync();

        }
        public async Task RunErrorHanderAsync()
        {
            Console.WriteLine("\nДля обработки ошибок выражение await помещается в блок try:");
            try
            {
                await PrintAsync("Hello wacraft.by");
                await PrintAsync("Ho");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                
            async Task PrintAsync(string message)
            {
                // если длина строки меньше 3 символов, генерируем исключение
                if (message.Length < 3)
                    throw new ArgumentException($"Invalid string length: {message.Length}");
                await Task.Delay(100); // имитация продолжительной операции
                Console.WriteLine(message);
            }
        }

        // Обработка исключения в самом асинхронном методе
        public async Task RunCatchInMethodAsync()
        {
            Console.WriteLine("\nОбработка исключения в самом асинхронном методе");
            PrintAsync("Hello Sailor Moon");
            PrintAsync("N");
            await Task.Delay(1000); // ждем завершенияч задач

            async void PrintAsync(string message)
            {
                try
                {
                    // если длина строки меньше 3 символов, генерируем исклоючение
                    if (message.Length < 3)
                        throw new ArgumentException($"Invalid string length: {message}");
                    await Task.Delay(100); // имитация продолжительной операции
                    Console.WriteLine(message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        // Исследование исключения
        public async Task RunExclusionStudyAsync()
        {
            Console.WriteLine("\nИсследование исключения");
            Task task = PrintAsync("Hi");
            try
            {
                await task;
            }
            catch
            {
                Console.WriteLine(task.Exception?.InnerException?.Message); // invalid string length: 2
                Console.WriteLine($"IsFaulted: {task.IsFaulted}"); // IsFaulted: True
                Console.WriteLine($"Status: {task.Status}"); // Ssatus: Faulted

            }


            async Task PrintAsync(string message)
            {
                if (message.Length < 3)
                    throw new ArgumentException($"Invalid string length: {message.Length}");
                await Task.Delay(1000);
                Console.WriteLine(message);
            }

        }

        // Обработка нескольких исключений. WhenAll
        public async Task RunSomeExceptionWhenAllAsync()
        {
            Console.WriteLine("\nОбработка нескольких исключений. WhenAll");
            var task1 = PrintAsync("H");
            var task2 = PrintAsync("Hi");
            var allTasks = Task.WhenAll(task1, task2);
            try
            {
                await allTasks;
            }
            catch(Exception ex )
            {
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine($"IsFaulted: {allTasks.IsFaulted}");
                if(allTasks.Exception is not null)
                {
                    foreach(var exception in allTasks.Exception.InnerExceptions)
                    {
                        Console.WriteLine($"InnerException: {exception.Message}");
                    }
                }
            }

            async Task PrintAsync(string message)
            {
                if (message.Length < 3)
                    throw new ArgumentException($"Invalid string: {message}");
                await Task.Delay(1000);
                Console.WriteLine(message);
            }
        }


    }
}
