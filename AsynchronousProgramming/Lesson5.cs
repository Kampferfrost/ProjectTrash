using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AsynchronousProgramming
{
    // Недостаток знаний паттерна Enumerable, будем исправлять
    internal class Lesson5 : ILesson
    {
        public int Number => 5;

        public string Title => "Асинхронные стримы";

        public async Task StartLessonExamplesAsync()
        {
            await ReturnStreamExampleAsync();
            await ReturnStorageExampleAsync();
        }

        //GetNumbersAsync метод является асинхронным.
        //Его возвращаемый тип - IAsyncEnumerable<int>. А его суть сводится к тому, что он возвращает с помощью yield return каждые 100 миллисекунд некоторое число
        public async Task ReturnStreamExampleAsync()
        {
            await foreach (var number in GetNumbersAsync())
            {
                Console.WriteLine(number);
            }

            async IAsyncEnumerable<int> GetNumbersAsync()
            {
                for (int i = 0; i < 10; i++)
                {
                    await Task.Delay(100);
                    yield return i;
                }
            }

        }

        public async Task ReturnStorageExampleAsync()
        {
            Repository repo = new Repository();
            IAsyncEnumerable<string> data = repo.GetDataAsync();
            await foreach (var name in data)
            {
                Console.WriteLine(name);
            } 
        }
        class Repository
        {
            string[] data = { "Tom", "Sam", "Kate", "Alice", "Bob" };
            public async IAsyncEnumerable<string> GetDataAsync()
            {
                for (int i = 0; i < data.Length; i++)
                {
                    Console.WriteLine($"Получаем {i + 1} элемент");
                    await Task.Delay(100);
                    yield return data[i];
                }
            }
        }

    }
}
