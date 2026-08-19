using CollectionLessons.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionLessons
{
    internal class Lesson5 : ILesson
    {
        public int Number => 5;

        public string Title => "Коллекция Dictionary<K, V>";

        public async Task StartLessonExamplesAsync()
        {
            await CreateExampleDictionary();
        }

        private async Task CreateExampleDictionary()
        {
            Console.WriteLine(nameof(CreateExampleDictionary));
            var people = new Dictionary<int, string>()
            {
                { 5, "Felix" },
                { 3, "Gomer" },
                { 11, "Shreck" }
            };
            foreach (var person in people) 
            {
                Console.WriteLine($"key: {person.Key}  value: {person.Value}");
            }
            Console.WriteLine();
            foreach (var (key, val) in people)  // раскладываем объект на свойства
            {
                Console.WriteLine($"key: {key}  value: {val}");
            }
            Console.WriteLine();
            Console.WriteLine(people[11]);
            people[15] = "Kawakaze";
            Console.WriteLine($"Количество элементов в словаре{people.Count}");
        }

    }
}
