using Reflection.Interfaces;

namespace Reflection
{
    public class Lesson1 : ILesson
    {
        public int Number => 1;

        public string Title => "Введение в рефлексию. Класс System.Type";

        public async Task StartLessonExamplesAsync()
        {
            await StartExamplesGetTypeAsync();
            await StartExampleSearchImplementedInterfaces();
        }

        private async Task StartExamplesGetTypeAsync()
        {
            Console.WriteLine("Получение типа");
            Console.WriteLine(nameof(StartExamplesGetTypeAsync));

            Console.WriteLine("3 способа получения типа");
            Console.WriteLine("Получение типа через typeof:");
            Type myType1 = typeof(Person);
            Console.WriteLine(myType1);
            // остановился здесь
            Console.WriteLine("Получение типа через метод GetType:");
            Person tom = new Person("Tom");
            Type myType2 = tom.GetType();
            Console.WriteLine(myType2);
            Console.WriteLine("Получение типа через статический метод Type.GetType():");
            Type? myType3 = Type.GetType("Reflection.Person", false, true);
            if (myType3 is null)
            {
                Console.WriteLine($"Переменая:{nameof(myType3)} = null");
            }
            else
            {
                Console.WriteLine(myType3);
            }
            Console.WriteLine("Теперь исследуем тип и получим некоторую информацию о нем:");
            Console.WriteLine($"Name: {myType1.Name}");
            Console.WriteLine($"Full Name: {myType1.FullName}");
            Console.WriteLine($"Namespace: {myType1.Namespace}");
            Console.WriteLine($"Is struct: {myType1.IsValueType}");
            Console.WriteLine($"Is class {myType1.IsClass}");

        }

        private async Task StartExampleSearchImplementedInterfaces()
        {
            Console.WriteLine("\nПоиск реализованных интерфейсов");
            Console.WriteLine(nameof(StartExampleSearchImplementedInterfaces));
            Type myType = typeof(Person);
            Console.WriteLine("Реализованные интерфейсы:");
            foreach (Type i in myType.GetInterfaces())
            {
                Console.WriteLine(i.Name);
            }

        }
    }
    public class Person : IEater, IMovable
    {
        public string Name { get; }
        public Person(string name) => Name = name;

        public void Move()
        {
            Console.WriteLine($"{Name} moves");
        }

        public void Eat()
        {
            Console.WriteLine($"{Name} eats");
        }
    }

    internal interface IEater
    { 
        void Eat();
    }

    internal interface IMovable
    {
        void Move();
    }
}
