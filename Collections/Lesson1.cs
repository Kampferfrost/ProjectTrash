using CollectionLessons.Interfaces;
using System.Reflection.Emit;
using System.Collections.Generic;
namespace CollectionLessons
{
    public class Lesson1 : ILesson
    {
        public int Number => 1;

        public string Title => "Список List<T>";

        public async Task StartLessonExamplesAsync()
        {
            await PrintHelloAsync();
        }

        public async Task PrintHelloAsync()
        {
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5));
            // Output:
            // 25
            Console.WriteLine("Тут нечего было учить, по этому пропустил");
        }
    }

    class Person
    {
        private string _name { get; }
        public Person(string name) => _name = name;
    }
}
