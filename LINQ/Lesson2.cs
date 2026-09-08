using LINQ.Interfaces;

namespace LINQ
{
    internal class Lesson2 : ILesson
    {
        public int Number => 2;

        public string Title => "Проекция данных";

        public async Task StartLessonExamplesAsync()
        {

            await StartExampleBeginer();
            await StartExampleMethodExtensionSelect();
            await StartExampleMethodExtensionSelectWithAnonimous();
            await StartExampleLetOperator();
            await StartExampleSelectionFromSeveralSources();
            await StartExampleSelectMany();
            await StartExampleSelectMany2();
        }
        private async Task StartExampleBeginer()
        {
            Console.WriteLine(nameof(StartExampleBeginer));
            var people = new List<Person>
            {
                new Person("Cirno", 23),
                new Person("Reimu", 26),
                new Person("Marisa", 24),
                new Person("Gold Ship", 18)
            };

            var names = from p in people select p.Name;
            foreach (string n in names)
                Console.WriteLine(n);

        }

        private async Task StartExampleMethodExtensionSelect()
        {
            Console.WriteLine();
            Console.WriteLine(nameof(StartExampleMethodExtensionSelect));
            var people = new List<Person>
            {
                new Person("Cirno", 23),
                new Person("Reimu", 26),
                new Person("Marisa", 24),
                new Person("Gold Ship", 18),
                new Person("Hikita", 29)
            };
            var names = people.Select(u => u.Name);

            foreach (string n in names)
                Console.WriteLine(n);

        }

        private async Task StartExampleMethodExtensionSelectWithAnonimous()
        {
            Console.WriteLine();
            Console.WriteLine(nameof(StartExampleMethodExtensionSelectWithAnonimous));
            var people = new List<Person>
            {
                new Person("Cirno", 23),
                new Person("Reimu", 26),
                new Person("Marisa", 24),
                new Person("Gold Ship", 18),
                new Person("Hikita", 29),
                new Person("Gordon Frimen", 34)
            };
            var personel = from p in people
                           select new
                           {
                               FirstName = p.Name,
                               Year = DateTime.Now.Year - p.Age
                           };

            //foreach (var n in names)
            //    Console.WriteLine(n);
            foreach (var p in personel)
            {
                Console.WriteLine($"{p.FirstName} - {p.Year}");
            }

        }

        private async Task StartExampleLetOperator()
        {
            Console.WriteLine("\nПеременые в запросах и оператор let");
            Console.WriteLine(nameof(StartExampleLetOperator));
            var people = new List<Person>
            {
                new Person ("Sektor", 23),
                new Person ("Shark", 19)
            };
            var personnel = from p in people
                            let name = $"Mr {p.Name}"
                            let year = DateTime.Now.Year - p.Age
                            select new
                            {
                                Name = name,
                                Year = year
                            };
            foreach (var p in personnel)
                Console.WriteLine($"{p.Name} - {p.Year}");

        }

        private async Task StartExampleSelectionFromSeveralSources()
        {
            Console.WriteLine("\nВыборка из нескольких источников");
            Console.WriteLine(nameof(StartExampleSelectionFromSeveralSources));
            var courses = new List<Course> { new Course("C#"), new Course("Java") };
            var students = new List<Student> { new Student("Tom"), new Student("Bob") };

            var enrollments = from course in courses // выбираем по одному курсу
                              from student in students // выбираем по одному студенту
                              select new
                              {
                                  Student = student.Name,
                                  Course = course.Title
                              };

            foreach (var enrollment in enrollments)
            {
                Console.WriteLine($"{enrollment.Student} - {enrollment.Course}");
            }

        }
        private async Task StartExampleSelectMany()
        {
            Console.WriteLine("\nSelectMany и сведение объектов");
            Console.WriteLine(nameof(StartExampleSelectMany));
            var companies = new List<Company>
            {
                new Company("Lifebloom", new List<Person> {new Person("Hikita"), new Person("Buldozer")}),
                new Company("Blades", new List<Person> {new Person("Ligalaiz"), new Person("Roghka")})
            };

            var employess = companies.SelectMany(c => c.Staff);

            foreach (var employes in employess)
                Console.WriteLine($"{employes.Name}");
            Console.WriteLine("Аналогичный пример с помощью операторов LINQ:");
            var employessWithOperatorLINQ = from c in companies
                                            from emp in c.Staff
                                            select emp;
            foreach (var employes in employessWithOperatorLINQ)
                Console.WriteLine($"{employes.Name}");
        }

        private async Task StartExampleSelectMany2()
        {
            Console.WriteLine("\nДругая версия метода SelectMany");
            Console.WriteLine(nameof(StartExampleSelectMany2));
            var companies = new List<Company>
            {
                new Company("Alians", new List<Person> {new Person("Hikita"), new Person("Buldozer")}),
                new Company("Horda", new List<Person> {new Person("Ligalaiz"), new Person("Roghka")})
            };
            var employess = companies.SelectMany(c => c.Staff,
                                                 (c, emp) => new { Name = emp.Name, Company = c.Name });
            foreach (var emp in employess)
                Console.WriteLine($"{emp.Name} - {emp.Company}");
            Console.WriteLine("Аналогичный пример с помощью операторов запросов:");
            var employessWithQueryOperators = from c in companies
                                              from emp in c.Staff
                                              select new
                                              {
                                                  Name = emp.Name,
                                                  Company = c.Name
                                              };
            foreach (var emp in employess)
                Console.WriteLine($"{emp.Name} - {emp.Company}");

        }


    }
    public class Person
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }

        public Person(string name)
        {
            Name = name;
        }
        public Person(string name, int age) : this(name)
        {
            Age = age;
        }

    }
    record class Course(string Title); // учебный курс
    record class Student(string Name); // студент
    record class Company(string Name, List<Person> Staff);


}



