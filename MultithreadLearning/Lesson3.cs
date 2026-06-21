using System;
using System.Threading;
// Создание потоков. Делегат ThreadStart
namespace MultithreadLearning
{
    internal class Lesson3
    {
        public Lesson3()
        {
        }

        public void StartLessonExamples()
        {
            Console.WriteLine("\n*---------------------------------------------*\n");
            Console.WriteLine(GetType());
            CreateThread();
            CreateTreadTogether();
        }
        void CreateThread()
        {
            Thread myThread1 = new Thread(new ParameterizedThreadStart(Print));
            Thread myThread2 = new Thread(Print);
            Thread myThread3 = new Thread((message) => Console.WriteLine(message));

            myThread1.Start("Hello");
            myThread2.Start("Ohae");
            myThread3.Start("Salut");

            int number = 4;
            Thread myThread4 = new Thread(PrintMultiply);
            myThread4.Start(number);

            Person Hikita = new Person("Hikita", 40);
            Thread myThread5 = new Thread(PrintPerson);
            myThread5.Start(Hikita);

            Person slam = new Person("Slam", 9);
            Thread myThread6 = new Thread(slam.Print);
            myThread6.Start();


        }

        void CreateTreadTogether()
        {
            

        }

        void PrintWithSleep()
        {
            

        }


        void Print(object? message) => Console.WriteLine(message);

        void PrintMultiply(object? obj)
        {
            if (obj is int n)
            {
                Console.WriteLine($"n * n = {n * n}");
            }
        }

        void PrintPerson(object? obj)
        {
            if (obj is Person person)
            {
                Console.WriteLine($"Name = {person.Name}");
                Console.WriteLine($"Age = {person.Age}");
            }
        }
    }

    record class Person(string Name, int Age)
    {
        public void Print()
        {
            Console.WriteLine($"Name = {Name}");
            Console.WriteLine($"Age = {Age}");
        }
    }
}
