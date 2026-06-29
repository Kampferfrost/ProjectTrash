using ParallelProgrammin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParallelProgrammin
{
    internal class LessonRunner
    {
        private readonly IEnumerable<ILesson> _lessons;

        public LessonRunner(IEnumerable<ILesson> lessons)
        {
            _lessons = lessons.OrderBy (l => l.Number);
        }

        public void RunMenu()
        {
            while(true)
            {
                Console.WriteLine("\nВыберите урок:");
                foreach (var lesson in _lessons)
                    Console.WriteLine($"{lesson.Number}. {lesson.Title}");
                Console.WriteLine("0. Выход");

                Console.Write("\nВаш выбор: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                    continue;

                if (choice == 0)
                    return;

                var selected = _lessons.FirstOrDefault(l => l.Number == choice);
                if (selected == null)
                {
                    Console.WriteLine("Нет такого урока.");
                    continue;
                }

                Console.WriteLine($"\n=== Запуск урока {selected.Number}: {selected.Title} ===\n");
                selected.StartLessonExamples();
            }
        }
    }
}
