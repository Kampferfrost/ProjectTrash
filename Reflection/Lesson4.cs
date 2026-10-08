using Reflection.Interfaces;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Channels;

namespace Reflection
{
    internal class Lesson4 : ILesson
    {
        public int Number => 4;

        public string Title => "Исследование полей и свойств с помощью рефлексии";

        public async Task StartLessonExamplesAsync()
        {
            await StartExampleRetreivingFieldInformation();
            await GettindAndChangingAFieldValueExample();
            await StartExampleProperties();
        }

        internal async Task StartExampleRetreivingFieldInformation()
        {
            Console.WriteLine("\nПолучение информации о полях");
            Console.WriteLine(nameof(StartExampleRetreivingFieldInformation));
            Type myType = typeof(Person);
            Console.WriteLine("Поля:");
            foreach (FieldInfo field in myType.GetFields(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                string modificator = string.Empty;
                // получаем модификатор доступа
                if (field.IsPublic)
                    modificator += "public ";
                else if (field.IsPrivate)
                    modificator += "private ";
                else if (field.IsAssembly)
                    modificator += "internal ";
                else if (field.IsFamily)
                    modificator += "protected ";
                else if (field.IsFamilyAndAssembly)
                    modificator += "private protected ";
                else if (field.IsFamilyOrAssembly)
                    modificator += "protected internal ";

                // если поле статическое
                if (field.IsStatic)
                    modificator += "static ";
                Console.WriteLine($"{modificator}{field.FieldType.Name} {field.Name}");
            }

        }

        internal async Task GettindAndChangingAFieldValueExample()
        {
            Console.WriteLine("\nПолучение и изменение значения поля");
            Console.WriteLine(nameof(GettindAndChangingAFieldValueExample));
            Type myType = typeof(Person);
            Person cirna = new Person("Cirna", 60);
            // получаем приватное поле name
            var name = myType.GetField("_name", BindingFlags.Instance | BindingFlags.NonPublic);
            // получаем значение поля name
            var value = name?.GetValue(cirna);
            Console.WriteLine(value); // Cirna
            // изменяем значения поля name
            name?.SetValue(cirna, "Cirna the strongest");
            cirna.Print(); // Cirna the strongest - 60
        }

        internal async Task StartExampleProperties()
        {
            Console.WriteLine("\nСвойства");
            Console.WriteLine(nameof(StartExampleProperties));
            Type myType = typeof(Person);
            foreach (PropertyInfo prop in myType.GetProperties(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                Console.Write($"{prop.PropertyType} {prop.Name} {{");

                // если свойство доступное для чтения
                if (prop.CanRead)
                    Console.Write("get;");
                // если свойство доступной для записи
                if (prop.CanWrite)
                    Console.Write("set;");
                Console.WriteLine("}");
                
            }
            Console.WriteLine("\nМанипулировать значением свойства");
            Person bakushin = new Person("Sakura Bakushin O", 18);
            // получаем свойство Age
            var ageProp = myType.GetProperty("Age");
            // получаемй свойства Age у объекта bakushin
            var age = ageProp?.GetValue(bakushin);
            Console.WriteLine(age); // 18
            // устанавливаем новое значение для свойства Age объекта bakushin
            ageProp?.SetValue(bakushin, 19);
            bakushin.Print(); // Sakura Bakushin O - 19

        }

        class Person
        {
            private static int _minAge = 0;
            private string _name;
            private int _age;
            public string Name
            {
                get
                {
                    return _name;
                }
            }

            public int Age
            {
                get
                {
                    return _age;
                }
                set
                {
                    _age = value;
                }
            }
            public Person(string name, int age)
            {
                _name = name;
                _age = age;
            }
            public void Print() => Console.WriteLine($"{_name} - {_age}");
        }
    }
}
