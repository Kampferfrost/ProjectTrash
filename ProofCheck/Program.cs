using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofCheck
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Person tom = new Person("Tom", 35);
            Person bob = new Person("Bob", 16);
            bool tomIsValid = ValidateUser(tom);
            bool bobIsValid = ValidateUser(bob);

            Console.WriteLine($"Результат валидации тома: {tomIsValid}");
            Console.WriteLine($"Результат валидации боба: {bobIsValid}");

            bool ValidateUser(Person person)
            {
                Type type = typeof(Person);
                // получаем все атрибуты класса Person
                object[] attributes = type.GetCustomAttributes(false);

                // проходим по всем атрибутем
                foreach (Attribute attr in attributes)
                {
                    // если атрибут представляет тип AgeValidationAttribute
                    if (attr is AgeValidationAttribute ageAttribute)
                        // возвращаем результат проверки по возрасту
                        return person.Age >= ageAttribute.Age;
                }
                return true;
            }
        }
    }

    internal class AgeValidationAttribute : Attribute
    {
        public int Age { get; }
        public AgeValidationAttribute() { }
        public AgeValidationAttribute(int age) => Age = age;
    }

    [AgeValidation(18)]
    internal class Person
    {
        public string? Name { get; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

}






