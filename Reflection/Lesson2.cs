using Reflection.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection
{
    internal class Lesson2 : ILesson
    {
        public int Number => 2;

        public string Title => "Применение рефлексии и исследование типов";

        public async Task StartLessonExamplesAsync()
        {
            await StartExampleGetAllComponentTypes();
        }

        private async Task StartExampleGetAllComponentTypes()
        {
            Console.WriteLine("Получение всех компонентов типа");
            Console.WriteLine(nameof(StartExampleGetAllComponentTypes));

        }
    }
}
