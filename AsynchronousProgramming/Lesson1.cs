namespace AsynchronousProgramming
{
    public class Lesson1 : ILesson
    {
        public int Number => 1;

        public string Title => "Асинхронные методы, async и await";

        public async void StartLessonExamples()
        {
            await StartFirstMethod();
            await StartExampleDelaingAnAsynchronous();
            await BenefitsOfAsynchrony();
            await BenefitsOfOptimizationAsynchronyAcync();
            await StartExampleAsynchronyLambdaAsync();
        }
        // Рассмотрим простейший пример определения и вызова асинхронного метода:
        // Асинхронный метод Main
        public async Task StartFirstMethod()
        {
            await PrintAsync(); // вызов асинхронного метода
            Console.WriteLine("Некоторые действия в методе  StartFirstMethod");

            void Print()
            {
                Thread.Sleep(3000); // имитация продолжительной работы
                Console.WriteLine("Hello METANIT.COM");
            }

            async Task PrintAsync()
            {
                Console.WriteLine("Начало метода PrintAsync"); // выполняется синхронно
                await Task.Run(Print);
                Console.WriteLine("Конец метода PrintAcync");
                
            }

        }

        public async Task StartExampleDelaingAnAsynchronous()
        {
            Console.WriteLine("\nЗадержка асинхронной операции и Task.Delay");
            await PrintAsync(); // вызов асинхронного метода
            Console.WriteLine("Некоторые действия в методе StartExammpleDelaingAnAsynchronous");

            async Task PrintAsync()
            {
                await Task.Delay(3000); // имитация продолжительной работы
                // или так
                // await Task.Delay(TimeSpan.FromMillisecons(3000));
                Console.WriteLine("Hello TIger");
            }
        }
        // Преимущества асинхронности
        public async Task BenefitsOfSynchronous()
        {
            Console.WriteLine("\nПреимущества асинхронности");
            PrintName("Tom");
            PrintName("Bob");
            PrintName("Sam");


            async void PrintName(string name)
            {
                Thread.Sleep(3000); // имитация продолжительной работы
                Console.WriteLine(name);
            }
        }
        public async Task BenefitsOfAsynchrony()
        {
            Console.WriteLine("\nИзменим в программе синхронный метод PrintName на асинхронный:");
            await PrintNameAcync("Tom");
            await PrintNameAcync("Bob");
            await PrintNameAcync("Sam");

            async Task PrintNameAcync(string name)
            {
                await Task.Delay(3000); // имитация продолжительной работы
                Console.WriteLine(name);
            }
        }
        public async Task BenefitsOfOptimizationAsynchronyAcync()
        {
            Console.WriteLine("\nТеперь оптимизируем программу:");
            var bikerTask = PrintNameAsync("Biker");
            var tigerTask = PrintNameAsync("Tiger");
            var hikitaTask = PrintNameAsync("Hikita");

            async Task PrintNameAsync(string name)
            {
                await Task.Delay(3000); // имитация продолжительной работы
                Console.WriteLine(name);
            }
        }

        // Определение асинхронного лямбда - выражения
        public async Task StartExampleAsynchronyLambdaAsync()
        {
            // асинхронное лямда-выражение
            Console.WriteLine("\nОпределение асинхронного лямбда - выражения");
            Func<string, Task> printer = async (string message) =>
            {
                await Task.Delay(1000);
                Console.WriteLine(message);
            };

            await printer("Hello Tiger");
            await printer("Hello Touhou Project");

        }



    }
}
