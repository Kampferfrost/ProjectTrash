using CollectionLessons.Interfaces;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CollectionLessons
{
    internal class Lesson8 : ILesson
    {
        public int Number => 9;

        public string Title => "Итераторы и оператор yield";

        public async Task StartLessonExamplesAsync()
        {
            await StartExampleIterator();
            await StartExampleIterator2();
            await StartExampleIteratorCompany();
            await StartExampleNamedIterator();
        }

        private async Task StartExampleIterator()
        {
            Numbers numbers = new Numbers();
            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }

        }
        private class Numbers
        {
            public IEnumerator<int> GetEnumerator()
            {
                for (int i = 0; i < 6; i++)
                {
                    yield return i * i;
                }
            }
        }

        private async Task StartExampleIterator2()
        {
            foreach (var n in 5) Console.WriteLine(n);
            foreach (var n in -5) Console.WriteLine(n);

        }

        private async Task StartExampleIteratorCompany()
        {
            Console.WriteLine();
            Console.WriteLine("Коллекция Company. Используем оператор yield для перебора этой коллекции");
            Console.WriteLine(nameof(StartExampleIteratorCompany));
            var people = new Person[]
            {
                new Person("Злодейка"),
                new Person("Бульбаш"),
                new Person("Footman"),
            };
            var govnoets = new Company(people);

            foreach (Person employee in govnoets)
            {
                Console.WriteLine(employee.Name);
            }
        }
        class Person
        {
            public string Name { get; }
            public Person(string name) => Name = name;
        }
        class Company
        {
            private Person[] _personnel;
            public Company(Person[] personnel) => _personnel = personnel;
            public int Length => _personnel.Length;
            public IEnumerator<Person> GetEnumerator()
            {
                for (int i = 0; i < _personnel.Length; i++)
                {
                    yield return _personnel[i];
                }
            }
        }
        class CompanyIEnumerable
        {
            Person[] _personnel;
            public CompanyIEnumerable(Person[] personnel) => _personnel = personnel;
            public int Length => _personnel.Length;
            public IEnumerable<Person> GetPersonnel(int max)
            {
                for (int i = 0; i < max; i++)
                {
                    if (i == _personnel.Length)
                    {
                        yield break;
                    }
                    else
                    {
                        yield return _personnel[i];
                    }
                }
            }

        }

        /// <summary>
        /// NamedIterator
        /// </summary>
        /// <returns></returns>
        private async Task StartExampleNamedIterator()
        {
            Console.WriteLine("\nИменованный итератор");
            Console.WriteLine(nameof(StartExampleNamedIterator));
            var people = new Person[]
                {
                    new Person("Гэля"),
                    new Person("Шани"),
                    new Person("Porsh"),
                };
            var lifeBloom = new CompanyIEnumerable(people);
            foreach(Person employee in lifeBloom.GetPersonnel(5))
            {
                Console.WriteLine(employee.Name);
            }
        }



        
    }
    static class Int32Extension
    {
        public static IEnumerator<int> GetEnumerator(this int number)
        {
            int k = (number > 0) ? number : 0;
            for (int i = number - k; i <= k; i++) yield return i;

        }
    }

}
