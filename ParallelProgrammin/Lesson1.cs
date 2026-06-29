
using ParallelProgrammin.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ParallelProgrammin
{
    internal class Lesson1 : ILesson
    {
        public int Number => 1;

        public string Title => "Задачи и класс Task";

        public void CreateStartTask()
        {
            Console.WriteLine("Lesson 1 running");

            Task task1 = new Task(() => Console.WriteLine("Task1 is executed"));
            task1.Start();

            Task task2 = Task.Factory.StartNew(() => Console.WriteLine("Task2 is executed"));

            Task task3 = Task.Run(() => Console.WriteLine("Task3 is executed"));

            task1.Wait();   // ожидаем завершения задачи task1
            task2.Wait();   // ожидаем завершения задачи task2
            task3.Wait();   // ожидаем завершения задачи task3

        }

        public void StartLessonExamples()
        {
            CreateStartTask();
            StartWaitingForTaskCompletion();
            SynchronousLaunchTask();
        }

        public void StartWaitingForTaskCompletion()
        {
            //Wait() блокирует вызывающий поток
            Console.WriteLine("Main Starts");
            // создаем задачу
            Task task1 = new Task(() =>
            {
                Console.WriteLine("Task Start");
                Thread.Sleep(1000); // задержка на 1 секунду - имитация долгой работы
                Console.WriteLine("Task Ends");
            });
            task1.Start(); // запускаем задачу
            task1.Wait(); // ожидаем выполения задачи
            Console.WriteLine("Main Ends");
        }

        public void SynchronousLaunchTask()
        {
            // Синхронный запуск задачи
            Console.WriteLine("Main Starts");
            // создаем задачу
            Task task1 = new Task(() =>
            {
                Console.WriteLine($"Task{Task.CurrentId} Start");
                Thread.Sleep(1000);
                Console.WriteLine($"Task{Task.CurrentId} Ends");
            });
            task1.RunSynchronously(); // запускаем задачу синхронно
                Console.WriteLine($"task1 Id: {task1.Id}"); 
                Console.WriteLine($"task1 is Completed: {task1.IsCompleted}"); 
                Console.WriteLine($"task1 Status {task1.Status}"); 
            Console.WriteLine("Main Ends"); // этот вызов ждет завершения задачи task1
        }
    }
}
