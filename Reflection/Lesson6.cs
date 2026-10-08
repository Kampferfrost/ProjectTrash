using Reflection.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection
{
    internal class Lesson6 : ILesson

    {
        public int Number => 6;

        public string Title => "Атрибуты в .NET";

        public async Task StartLessonExamplesAsync()
        {
            await StartExample();
            await RestrictionAttribute();
        }
        private async Task StartExample()
        {
            Console.WriteLine("Получим атрибут класса");
            Console.WriteLine(nameof(StartExample));
            Person cirna = new Person("Cirna", 60);
            Person bakushin = new Person("Sakura Bakushin O", 17);
            bool cirnaIsValid = ValidateUser(cirna); // 
            bool bakushinIsValid = ValidateUser(bakushin); //
            Console.WriteLine($"Результат валидации Cirna: {cirnaIsValid}");
            Console.WriteLine($"Результат валидации Sakura Bakushin O: {bakushinIsValid}");
            bool ValidateUser(Person person)
            {
                Type type = typeof(Person);
                // получаем все атрибуты класса Person
                object[] attributes = type.GetCustomAttributes(false);
                // проходим по всем атрибутам
                foreach (Attribute attribute in attributes)
                {
                    // если атрибут представляет тип AgeValidationAttribute
                    if (attribute is AgeValidationAttribute ageAttribute)
                        //в возвращаем результат проверки по возрасту
                        return person.Age >= ageAttribute.Age;

                }
                return true;
            }
        }

        private async Task RestrictionAttribute()
        {

        }


        private class AgeValidationAttribute : Attribute
        {
            public int Age { get; set; }
            public AgeValidationAttribute() { }
            public AgeValidationAttribute(int age) => Age = age;
        }
        [AgeValidation(Age = 18)]
        private class Person
        {
            public string Name { get; }
            public int Age { get; set; }
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

        }

    }
}
