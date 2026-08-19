using CollectionLessons.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionLessons
{
    internal class Lesson4 : ILesson
    {
        public int Number => 4;

        public string Title => "Коллекция Stack<T>";

        public async Task StartLessonExamplesAsync()
        {
            await CreateExampleQueue();
        }

        private async Task CreateExampleQueue()
        {
            Console.WriteLine(nameof(CreateExampleQueue));
            var employess = new List<string> { "Ehidna", "Rem", "Ram" };
            Stack<string> people = new Stack<string>(employess);
            people.Push("Felix");
            // получаем первый элемент стека без его удаления 
            people.TryPeek(out var headPerson);
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine($"Персона {headPerson} у тебя первый");
        }
    }
}
