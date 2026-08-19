using CollectionLessons.Interfaces;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CollectionLessons
{
    internal class Lesson6 : ILesson
    {
        public int Number => 6;

        public string Title => "Класс ObservableCollection";

        public async Task StartLessonExamplesAsync()
        {
            await CreateExampleObservableCollection();
            await GetCollectionCareNotice();
        }
        private async Task CreateExampleObservableCollection()
        {
            Console.WriteLine(nameof(CreateExampleObservableCollection));
            Console.WriteLine("Обращение к элементам коллекции");
            var people = new ObservableCollection<string>(new string[] { "Mike", "Alice", "Kate" })
            {
                "Reimu", "Razen", "Sakuya"
            };
            Console.WriteLine("Вывод первого элемента");
            Console.WriteLine(people[0]);
            Console.WriteLine("\nПеребор с помощью foreach");
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine("\nПеребор с помощью for");
            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine(people[i]);
            }

        }
        private async Task GetCollectionCareNotice()
        {
            Console.WriteLine("\nУведомление об измении коллекции");
            Console.WriteLine(nameof(GetCollectionCareNotice));
            var people = new ObservableCollection<Person>()
            {
                new Person("Hikita"),
                new Person("Slam")
            };
            // подписываемся на события изменения коллекции
            people.CollectionChanged += People_CollectionChanged;
            people.Add(new Person("Gelya"));
            people.RemoveAt(1);
            people[0] = new Person("Rat");
            Console.WriteLine("\nСписок пользователей");
            foreach (var person in people)
            {
                Console.WriteLine(person.Name);
            }
            // обработчик изменения коллекции
            void People_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add: // если добавление
                        if (e.NewItems?[0] is Person newPerson)
                            Console.WriteLine($"Добавлен новый объект: {newPerson.Name}");
                        break;
                    case NotifyCollectionChangedAction.Remove: // если удаление
                        if (e.OldItems?[0] is Person oldPerson)
                            Console.WriteLine($"Удален объект: {oldPerson.Name}");
                        break;
                    case NotifyCollectionChangedAction.Replace: // если замена
                        if ((e.NewItems?[0] is  Person replacingPerson) &&
                            (e.OldItems?[0] is Person preplacedPerson))
                            Console.WriteLine($"Объект {preplacedPerson.Name} заменен объектом {replacingPerson.Name}");
                        break;
                        
                }
            }
        }
        private record Person(string Name);


    }
}
