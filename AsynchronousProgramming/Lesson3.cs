using System.Net.NetworkInformation;

namespace AsynchronousProgramming
{
    internal class Lesson3 : ILesson
    {
        public int Number => 3;

        public string Title => "Последовательное и параллельное выполнение. Task.WhenAll и Task.WhenAny";

        public async Task StartLessonExamplesAsync()
        {
            await RunDeterministicExampleAsync();
            await RunNonDeterministicExampleAsync();
            await RunNonDeterministicWithWaitAllExampleAsync();
            await RunWaitAnyTaskAsync();
            await GetResultAsync();
        }

        public async Task RunDeterministicExampleAsync()
        {
            Console.WriteLine("\nДетерминированое выполнение асинхронной задачи");
            await PrintAsync("Hello C#");
            await PrintAsync("Hello World");
            await PrintAsync("Hello WoW");


            async Task PrintAsync(string message)
            {
                await Task.Delay(2000); // имитация продолжительной операции
                Console.WriteLine(message);
            }
        }

        public async Task RunNonDeterministicExampleAsync()
        {
            Console.WriteLine("\nНедетерминирован выполнение асинхронной задачи");
            var task1 = PrintAsync("Hello C#");
            var task2 = PrintAsync("Hello world");
            var task3 = PrintAsync("Hello Reimu");

            await task1;
            await task2;
            await task3;

            async Task PrintAsync(string message)
            {
                await Task.Delay(2000); // имитация продолжительной операции
                Console.WriteLine(message);
            }
        }

        public async Task RunNonDeterministicWithWaitAllExampleAsync()
        {
            // определяем и запускаем задачи
            Console.WriteLine("\nНедетерминирован выполнение асинхронной задачи c Task.WhenAll");
            var task1 = PrintAsync("Hello Monkey");
            var task2 = PrintAsync("Hello Dog");
            var task3 = PrintAsync("Hello Slam");

            // ожидаем завершения всех задач
            await Task.WhenAll(task1, task2, task3);
            async Task PrintAsync(string message)
            {
                await Task.Delay(2000); // имитация продолжительной операции
                Console.WriteLine(message);
            }
        }

        public async Task RunWaitAnyTaskAsync()
        {
            Console.WriteLine("\nОжидания выполения хотя бы одной задачи c помощью Task.WhenAny()");
            var task1 = PrintAsync("Hello Cirno");
            var task2 = PrintAsync("Hello Manhattan Cafe");
            var task3 = PrintAsync("Hello Rem");
            await Task.WhenAny(task1, task2, task3);
            async Task PrintAsync(string message)
            {
                await Task.Delay(new Random().Next(1000, 2000)); // имитация продолжительной операции
                Console.WriteLine(message);
            }
        }


        // Получение результата
        public async Task GetResultAsync()
        {
            Console.WriteLine("\nПолучение результата в массив с помощью Task.WhenAll");
            // определяем и запускаем задачи
            var task1 = SquareAsync(4);
            var task2 = SquareAsync(5);
            var task3 = SquareAsync(6);

            // ожидаем завершения всех задач
            int[] results = await Task.WhenAll(task1, task2, task3);
            // получаем результаты:
            foreach( int result in results)
                Console.WriteLine(result);
            Console.WriteLine("После завершения задачи ее результат можно получить стандартным образом через свойство Result");
            Console.WriteLine($"task2 result:  {task2.Result}");

            async Task<int> SquareAsync(int n)
            {
                await Task.Delay(1000);
                return n * n;
            }
        }

    }
}
