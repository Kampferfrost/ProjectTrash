using Reflection.Interfaces;
using System.Reflection;

namespace Reflection
{
    internal class Lesson2 : ILesson
    {
        public int Number => 2;

        public string Title => "Применение рефлексии и исследование типов";

        public async Task StartLessonExamplesAsync()
        {
            await StartExampleGetAllComponentTypes();
            await StartExampleBindingFlags();
            await StartExampleGetSingleComponentByName();
        }

        private async Task StartExampleGetAllComponentTypes()
        {
            Console.WriteLine("Получение всех компонентов типа");
            Console.WriteLine(nameof(StartExampleGetAllComponentTypes));
            Type myType = typeof(Person);
            foreach (MemberInfo member in myType.GetMembers())
            {
                Console.WriteLine($"{member.DeclaringType} {member.MemberType} {member.Name}");
            }
            // Обратите внимание, что в данном случае мы получаем только все публичные компоненты класса, и нам не выводится информация о приватной переменной _name.
        }

        private async Task StartExampleBindingFlags()
        {
            Console.WriteLine("\nBindingFlags");
            Console.WriteLine(nameof(StartExampleBindingFlags));
            Type myType = typeof(Person);
            foreach (MemberInfo member in myType.GetMembers(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                Console.WriteLine($"{member.DeclaringType} {member.MemberType} {member.Name}");
            }

        }

        private async Task StartExampleGetSingleComponentByName()
        {
            Console.WriteLine("\nПолучение одного компонента по имени");
            Console.WriteLine(nameof(StartExampleGetSingleComponentByName));
            Type myType = typeof(Person);
            // получаем метод print
            MemberInfo[] print = myType.GetMember("Print", BindingFlags.Instance | BindingFlags.Public);
            foreach (MemberInfo member in print)
            {
                Console.WriteLine($"Тип: {member.MemberType} Имя:  {member.Name}");
            }
        }

        public class Person
        {
            private string _name = string.Empty;
            public int Age { get; set; }
            public Person(string name, int age)
            {
                _name = name;
                Age = age;
            }
            public void Print() => Console.WriteLine($"Name: {_name} Age: {Age}");
        }
    }



}
