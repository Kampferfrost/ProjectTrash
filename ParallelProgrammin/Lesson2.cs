using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ParallelProgrammin.Interfaces;

namespace ParallelProgrammin
{
    internal class Lesson2 : ILesson
    {
        public int Number => 2;

        public string Title => "Работа с классом Task";

        public void StartLessonExamples()
        {
            StartNestedTasks();
            StartTaskArray();
            ReturningResultsFromTasks();
        }
        public void StartNestedTasks()
        {
            //Вложенные задачи
            var outer = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Outer task id {Task.CurrentId} startin...");
                var inner = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine($"Inner task id {Task.CurrentId} starting...");
                    Thread.Sleep(2000);
                    Console.WriteLine($"Inner task id {Task.CurrentId} finished.");
                }, TaskCreationOptions.AttachedToParent);
            });
            outer.Wait(); // ожидаем выполнения внешней задачи
            Console.WriteLine("End of Main");

        }

        public void StartTaskArray()
        {
            Task[] tasks1 = new Task[3]
            {
                new Task(() => Console.WriteLine("First Task")),
                new Task(() => Console.WriteLine("Second Task")),
                new Task(() => Console.WriteLine("Third Task")),

            };
            // запуск задач в массиве
            foreach (var task in tasks1)
            {
                task.Start();
            }
            Task.WaitAll(tasks1);

            Task[] tasks = new Task[3];
            for (var i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task(() =>
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine($"Task id {Task.CurrentId} {i} finished");
                    });
                tasks[i].Start();

            }
            Console.WriteLine("Завершение метода TaskArray");
            //Task.WaitAll(tasks); // ожидаем завершения всех задач
            Task.WaitAny(tasks);
        }

        void ReturningResultsFromTasks()
        {
            //Возвращение результатов из задач
            int n1 = 4, n2 = 5;
            Task<int> task = new Task<int>(() => Sum(n1, n2));
            Task<int> sumTask = new Task<int>(() => n1 + n2);
            Task proofTask = new Task(() => {
                int a = n1;
                int b = n2;
            });
            sumTask.Start();

            int result = sumTask.Result;
            Console.WriteLine($"{n1} + {n2} = {result}");
        }

        int Sum(int a, int b) => a + b;



    }
}
