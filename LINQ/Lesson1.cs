using LINQ.Interfaces;
namespace LINQ
{
    public class Lesson1 : ILesson

    {
        public int Number => 1;

        public string Title => "Основы LINQ";

        public async Task StartLessonExamplesAsync()
        {
            string text = "test";
            text = text.ToUpper();
            Console.WriteLine(text);
            await StartExampleLINQQueryOperators();
            await StartExampleLINQExtensionMethods();
        }

        private async Task StartExampleLINQQueryOperators()
        {
            Console.WriteLine("\nОператоры запросов LINQ");
            Console.WriteLine(nameof(StartExampleLINQQueryOperators));
            string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };

            // создаем новый список для результатов
            var selectedPeople = from p in people // передаем каждый элемент из people в переменную p
                                 where p.ToUpper().StartsWith("T") // фильтрация по критерию
                                 orderby p // упорядочиваем по возрастанию
                                 select p; //выбираем объект в создаваему коллекцию

            foreach (var person in selectedPeople)
            {
                Console.WriteLine(person);
            }
        }
        private async Task StartExampleLINQExtensionMethods()
        {
            Console.WriteLine("\nМетоды расширения LINQ");
            Console.WriteLine(nameof(StartExampleLINQExtensionMethods));
            string[] people = { "Tom", "Hikita", "Slam", "Tim", "Tomas", "Bill" };
            var selectedPeople = people.Where(p => p.ToUpper().StartsWith("T")).OrderBy(p => p);
            foreach (string person in selectedPeople)
                Console.WriteLine(person);
            int number = (from p in people where p.ToUpper().StartsWith("T") select p).Count();
            Console.WriteLine(number);

        }
    }
}
