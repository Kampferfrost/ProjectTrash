using Reflection.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Reflection
{
    internal class Lesson7 : ILesson
    {
        delegate int Operation(int x, int y);
        public int Number => 7;

        public string Title => "Делагаты и рефлексия(Не метанит)"; // нейрослоп проверенный мной

        public async Task StartLessonExamplesAsync()
        {
            await StartExample();
            await StartExampleCreateDelegateForStaticMethod();
        }

        private async Task StartExample()
        {
            Console.WriteLine("Func");
            Console.WriteLine(nameof(StartExample));
            //Calculator calculator = new Calculator();
            //int result = Calculator.Add(5, 4);
            //Console.WriteLine(result);
            MethodInfo? methodInfo = typeof(Calculator).GetMethod("Add");
            if (methodInfo != null)
            {
                Func<int, int, int> del = (Func<int, int, int>)Delegate.CreateDelegate(typeof(Func<int, int, int>), methodInfo);
                int result = del(5, 10);
                Console.WriteLine($"Результат: {result}");
            }
        }

        private async Task StartExampleCreateDelegateForStaticMethod()
        {
            Console.WriteLine("\nСоздание делегата для статического метода");
            Console.WriteLine(nameof(StartExampleCreateDelegateForStaticMethod));
            MethodInfo? methodInfo = typeof(Calculator).GetMethod("Add");
            if(methodInfo is not null)
            {
                Operation del = (Operation)Delegate.CreateDelegate(typeof(Operation), methodInfo);
            }
        }



    }

    class Calculator
    {
        delegate int Operation(int x, int y);
        public static int Add(int a, int b) => a + b;
    }
}

