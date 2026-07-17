using ParallelProgrammin.Interfaces;
using System;
using System.Threading.Tasks;
using System.Threading;
using System.Threading.Channels;

namespace ParallelProgrammin
{
    internal class Lesson3 : ILesson
    {
        public int Number => 3;

        public string Title => "Задачи продолжения";

        public void StartLessonExamples()
        {
            ShowId();
            ShowIdWithResult();
            StartTaskChain();

        }

        

        public void ShowId()
        {
            Task task1 = new Task(() =>
            {
                Console.WriteLine($"Id задачи: {Task.CurrentId}");
            });

            // задача продолжения - task2 выполняется после task1
            Task task2 = task1.ContinueWith(PrintTask);


            task1.Start();

            // ждем окончания второй задачи
            task2.Wait();
            Console.WriteLine("Конец метода Main");

            void PrintTask(Task t) 
            {
                Console.WriteLine($"Id Задачи: {Task.CurrentId}");
                Console.WriteLine($"Id предыдущей задачи: {t.Id}");
                Thread.Sleep(3000);
            }
        }


        public void ShowIdWithResult()
        {
            Task<int> sumTask = new Task<int>(() => Sum(4, 5));

            // задача продолжения
            Task printTask = sumTask.ContinueWith((Task<int> Jopa) => PrintResult(Jopa.Result));

            sumTask.Start();
            printTask.Wait();
            Console.WriteLine("Конец метода Main");


            int Sum(int a, int b) => a + b;
            void PrintResult(int sum) => Console.WriteLine($"Sum: {sum}");
        }

        public void StartTaskChain()
        {
            Task task1 = new Task(() => Console.WriteLine($"Current Task: {Task.CurrentId}"));

            // задача продолжения
            Task task2 = task1.ContinueWith(t => 
                Console.WriteLine($"Current Task: {Task.CurrentId} Previous Task: {t.Id}"));

            Task task3 = task2.ContinueWith(t =>
                Console.WriteLine($"Current Task: {Task.CurrentId} Previous Task: {t.Id}"));

            Task task4 = task3.ContinueWith(t =>
                Console.WriteLine($"Current Task: {Task.CurrentId} Previous Task: {t.Id}"));

            task1.Start();
            task4.Wait();
            Console.WriteLine("Конец метода");
        }

    }
}
