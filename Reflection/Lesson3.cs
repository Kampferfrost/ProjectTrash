using Reflection.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;

namespace Reflection
{
    internal class Lesson3 : ILesson
    {
        public int Number => 3;

        public string Title => "Исследование методов и конструкторов с помощью рефлексии";

        public async Task StartLessonExamplesAsync()
        {
            await StartExampleGetInfoAboutMethods();
            await StartExampleBindingFlags();
            await StartExampleParameterAnalysis();
            await StartExampleMethodCalls();
            await StartExampleObtainingConstructors();
        }

        private async Task StartExampleGetInfoAboutMethods()
        {
            Console.WriteLine("\nПолучение информации о методах");
            Console.WriteLine(nameof(StartExampleGetInfoAboutMethods));
            Type myType = typeof(Printer);
            Console.WriteLine("Методы:");
            foreach (MethodInfo method in myType.GetMethods())
            {
                string modificator = "";
                // если метод статический
                if (method.IsStatic)
                {
                    modificator += "static ";
                }
                // если метод виртуальный
                if (method.IsVirtual)
                {
                    modificator += "virtual ";
                }
                Console.WriteLine($"{modificator}{method.ReturnType.Name} {method.Name}()");

            }
        }

        private async Task StartExampleBindingFlags()
        {
            Console.WriteLine("\nBindingFlags");
            Console.WriteLine(nameof(StartExampleBindingFlags));
            Type myType = typeof(Printer);
            Console.WriteLine("Методы:");
            foreach (MethodInfo method in myType.GetMethods(BindingFlags.DeclaredOnly
                        | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                Console.WriteLine($"Возвращаемый тип метода: {method.ReturnType.Name} Имя метода: {method.Name} ()");
            }
        }

        private async Task StartExampleParameterAnalysis()
        {
            Console.WriteLine("\nИсследование параметров");
            Console.WriteLine(nameof(StartExampleParameterAnalysis));
            foreach (MethodInfo method in typeof(Printer).GetMethods())
            {
                Console.Write($"{method.ReturnType.Name} {method.Name} (");
                // получаем все параметры
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    var param = parameters[i];
                    // получаем модификаторы параметра
                    string modificator = string.Empty;
                    if (param.IsIn)
                        modificator = "in";
                    else if (param.IsOut) modificator = "out";

                    Console.Write($"Тип параметра {param.ParameterType.Name} модификатор: {modificator} {param.Name}");
                    // если параметр имеет значение по умолчанию
                    if (param.HasDefaultValue)
                        Console.Write($"={param.DefaultValue}");
                    // если не последний параметр, доавляем запятую
                    if (i < parameters.Length - 1)
                        Console.Write(", ");
                }
                Console.WriteLine(")");
            }
        }

        private async Task StartExampleMethodCalls()
        {
            Console.WriteLine("\nВызов методов");
            Console.WriteLine(nameof(StartExampleMethodCalls));
            var myPrinter = new Printer("Hello Sakura Bakushin O");
            // получаем метод Print
            var print = typeof(Printer).GetMethod("Print");
            // вызываем метод Print
            print?.Invoke(myPrinter, parameters: null); // Hello

            // Вызываем приватный метод
            Console.WriteLine("Вызываем приватный метод:");
            var printPrivate = typeof(Printer).GetMethod("PrintPrivate", 
                                                BindingFlags.Instance | 
                                                BindingFlags.Public | 
                                                BindingFlags.NonPublic);

            // вызываем метод PrintPrivate
            printPrivate?.Invoke(myPrinter, parameters: null);
            Console.WriteLine("Передача параметрав в метод и вызова его:");
            var printMessage = typeof(Printer).GetMethod("PrintMessage");

            // вызываем метод PrintMessage, перевавая ему два аргумента
            printMessage?.Invoke(myPrinter, new object[] { "Umamusume", 3 });

            Console.WriteLine("\nВызов обобщенного метода:");
            // получаем метод PrintValue
            var printValue = typeof(Printer).GetMethod("PrintValue");
            // получаем обобщенную версию метода для типа string
            var printStringValue = printValue?.MakeGenericMethod(typeof(string));
            // вызываем метод PrintValue, передавая ему строку
            printStringValue?.Invoke(myPrinter, new object[] { "Hello world" });


        }
        
        private async Task StartExampleObtainingConstructors()
        {
            Type myType = typeof(Person);

            Console.WriteLine("Конструкторы:");
            foreach (ConstructorInfo ctor in myType.GetConstructors(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                string modificator = string.Empty;

                // получаем модификатор досутпа
                if (ctor.IsPublic)
                    modificator += "public ";
                else if (ctor.IsPrivate)
                    modificator += "private ";
                else if (ctor.IsAssembly)
                    modificator += "internal ";
                else if (ctor.IsFamilyAndAssembly)
                    modificator += "private protected ";
                else if (ctor.IsFamilyOrAssembly)
                    modificator += "protected internal";

                Console.Write($"{modificator} {myType.Name}(");
                // получаем параметры конструктора
                ParameterInfo[] parameters = ctor.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    var param = parameters[i];
                    Console.Write($"{param.ParameterType.Name} {param.Name}");
                    if (i < parameters.Length - 1) Console.Write(", ");
                }
                Console.WriteLine(")");
                // не ну пример вывода всех параметров в консоль тут еще тот мусор, ну пример есть пример
            }
        }

        internal class Printer
        {
            public string DefauldMessage { get; set; } = "Hello";
            public string Text { get; } = string.Empty;
            public Printer()
            {

            }
            public Printer(string text) => Text = text;

            public void PrintMessage(string message, int times = 1)
            {
                while (times-- > 0)
                    Console.WriteLine(message);
            }
            public void Print() => Console.WriteLine(Text);
            private void PrintPrivate() => Console.WriteLine($"Приватный метод {nameof(PrintPrivate)} {Text}");
            public string CreateMessage() => DefauldMessage;
            public void PrintValue<T>(T value)
            {
                Console.WriteLine(value);
            }

        }
        internal class Person
        {
            public string Name { get; }
            public int Age { get; }
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
            public Person(string name) : this(name, 1) { }
            private Person() : this("Tom") { }
        }
    }
}

