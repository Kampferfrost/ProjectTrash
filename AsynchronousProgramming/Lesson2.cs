namespace AsynchronousProgramming
{
    internal class Lesson2 : ILesson
    {
        public int Number => 2;

        public string Title => "Возвращение результата из асинхронного метода";

        public async Task StartLessonExamplesAsync()
        {
            await ReturnResultAsynchronous();
            await StartExampleEventHandlingAsync();
            await ReturnObjectTaskAsync();
            await ReturnTaskGenericAsync();
            await ReturnValueTaskAsycn();
            await TransformValueTaskToTaskAsync();
        }

        public async Task ReturnResultAsynchronous()
        {
            Console.WriteLine("\nvoid");
            PrintAsync("Hello World");
            PrintAsync("Hello Cirno");
            Console.WriteLine("ReturnResultAsynchronous End");
            await Task.Delay(3000);
            
            async void PrintAsync(string message)
            {
                await Task.Delay(1000); // имитация продолжительной работы
                Console.WriteLine(message);
            }
        }

        public async Task StartExampleEventHandlingAsync()
        {
            Account account = new Account();
            account.Added += PrintAsync;

            account.Put(500);

            await Task.Delay(2000); // ждем завершения

            async void PrintAsync(object? obj1, string message)
            {
                await Task.Delay(1000); // имитация продолжительной работы
                Console.WriteLine(message);
                if (obj1 is Account acc)
                {
                    Console.WriteLine($"{acc.text}");
                }
            }
        }
        class Account
        {
            private int _sum = 0;
            public event EventHandler<string>? Added;
            public string text { get; set; } = "Test Tiger";
            public void Put(int sum)
            {
                _sum += sum;
                Added?.Invoke(this, $"На счет поступило {_sum} $");
            }
        }

        public async Task ReturnObjectTaskAsync()
        {
            Console.WriteLine("\n");
            Console.WriteLine("ReturnObjectTaskAsync works");
            await PrintAsync("Hello Kampfer");
            var task = PrintAsync("Hello Hikita"); // задача начинает выполнсяться
            await task; // ожидаем завершения задачи
            // определение асинхронного метода
            async Task PrintAsync(string message)
            {
                await Task.Delay(1000); // имитация продолжительной работы
                Console.WriteLine(message);
            }
        }

        //Task<T>
        public async Task ReturnTaskGenericAsync()
        {
            Console.WriteLine("\nTask<T>");
            var square5 = SquareAsync(5);
            var square6 = SquareAsync(6);
            Console.WriteLine("Остальные действия в методе ReturnTaskGenericAsync");

            int n1 = await square5;
            int n2 = await square6;
            Console.WriteLine($"n1={n1} n2={n2}"); // n1=25 n2=36

            async Task<int> SquareAsync(int n)
            {
                await Task.Delay(0);
                var result = n * n;
                Console.WriteLine($"Квадрат числа {n} равен {result}");
                return result;
            }

            
        }

        //ValueTask<T> это структура
        public async Task ReturnValueTaskAsycn()
        {
            Console.WriteLine("\nValueTask<T>");
            var result = await AddAsync(4, 5);
            Console.WriteLine(result);

            ValueTask<int> AddAsync(int a, int b)
            {
                return new ValueTask<int>(a + b);
            }

        }
        public async Task TransformValueTaskToTaskAsync()
        {
            Console.WriteLine("преобразовать ValueTask в объект Task с помощью метода AsTask()");
            var getMessage = GetMessageAsync();
            string message = await getMessage.AsTask();
            Console.WriteLine(message); // hello


            async ValueTask<string> GetMessageAsync()
            {
                await Task.Delay(0);
                return "Hello";
            }
        }

    }


}
