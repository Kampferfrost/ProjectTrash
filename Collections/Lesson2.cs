using CollectionLessons.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionLessons
{
    internal class Lesson2 : ILesson
    {
        public int Number => 2;

        public string Title => "Двухсвязный список LinkedList<T>";

        public async Task StartLessonExamplesAsync()
        {
            await RunExampleLinkedListAsync();
            await UseLinkedList();
        }
        public async Task RunExampleLinkedListAsync()
        {
            Console.WriteLine("\nСоздание связанного списка");
            var employees = new List<string> { "Tom", "Sam", "Bob" };

            LinkedList<string> people = new LinkedList<string>(employees);
            foreach(string person in people)
            {
                Console.WriteLine(person);
                
            }
        }

        public async Task UseLinkedList()
        {
            Console.WriteLine("\nСвойства LinkedList");
            var employess = new List<string> { "Cirno", "Reimu", "Agnes Tachyon" };
            LinkedList<string> people = new LinkedList<string>(employess);
            Console.WriteLine("\nот начала до конца");
            var currentNode = people.First;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
            Console.WriteLine("\nс конца до начала списка");
            currentNode = people.Last;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Previous;
            }

        }
    }
}
