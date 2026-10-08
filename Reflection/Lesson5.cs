using Reflection.Interfaces;
using System.Reflection;

namespace Reflection
{
    internal class Lesson5 : ILesson
    {
        public int Number => 5;

        public string Title => "Динамическая загрузка сборок и позднее связывание";

        public async Task StartLessonExamplesAsync()
        {
            Console.WriteLine("С метанита");
            await ExamineMyAppBuild();
            await StartLateBinding();

            Console.WriteLine("\n\nНе с метанита");
            await StartExample();
            await StartExampleLateBindingTestLiblary();
        }

        private async Task ExamineMyAppBuild()
        {
            Assembly asm = Assembly.LoadFrom("MyApp.dll");
            if (asm is not null)
            {
                Console.WriteLine(asm.FullName);
                // получаем все типы и зсборки myApp.dll
                Type[] types = asm.GetTypes();  // тут мы получаем типы из сборки, так как там может быть несколько классов
                foreach (Type t in types)
                {
                    Console.WriteLine(t.Name);
                }
            }
            else
            {
                Console.WriteLine("Сборка не найдена");
            }
        }

        private async Task StartLateBinding()
        {
            Console.WriteLine("\nПозднее связывание");
            Console.WriteLine(nameof(StartLateBinding));
            // Загружаем сборку myApp.dll
            Assembly assembly = Assembly.LoadFrom("MyApp.dll");
            // Получаем тип класса Program по его полному имени(с namespace)
            Type? programType = assembly.GetType("MyApp.Program");
            // Получаем тип класса Person через список
            Type? personType = assembly.GetTypes().FirstOrDefault(type => type.Name == "Person");
            // Защитный код: проверяем критические зависимости на старте (Guard Clauses)
            if (programType is null || personType is null)
            {
                Console.WriteLine("Ошибка: Не удалось загрузить типы Program или Person из сборки.");
                return;
            }
            object? personInstance;
            if (personType is not null)
            {
                // Создаем экземпляр, вызывая конструктор public Person(string name)
                // Передаем аргумент для конструктора в виде массива объектов
                personInstance = Activator.CreateInstance(personType, new object[] { "Sakura bakushin O"});
                if (personInstance is not null)
                {
                    if (programType is not null)
                    {
                        // получаем метод AddAge
                        MethodInfo? addAge = programType?.GetMethod("AddAge", BindingFlags.NonPublic | BindingFlags.Static);
                        // вызываем метод
                        var result = addAge?.Invoke(null, new object[] { personInstance, 4 });
                        Console.WriteLine(result);
                    }
                    else
                        Console.WriteLine($"Тип {nameof(programType)} не найден");
                }
            }
            else
                Console.WriteLine($"Тип {nameof(personInstance)} не получен");
        }




        private async Task StartExample()
        {
            Console.WriteLine("Пример использования класса Assembly");
            Console.WriteLine(nameof(StartExample));
            Assembly? asm = null;
            try
            {
                // 1. Пытаемся загрузить библиотеку
                Assembly asmTry = Assembly.LoadFrom("TestLiblary.dll");
                asm = asmTry;
                // Если код дошел сюда, значит библиотека успешно найдена и загружена!
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Успех: Библиотека успешно найдена и загружена.");
                Console.ResetColor();
            }
            catch (FileNotFoundException)
            {
                // Ошибка: файла физически нет по указанному пути
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: Файл 'TestLiblary.dll' не найден!");
                Console.WriteLine($"Программа искала его здесь: {AppDomain.CurrentDomain.BaseDirectory}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                // Другие возможные ошибки (например, неподдерживаемый формат или заблокированный файл)
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Произошла ошибка при загрузке: {ex.Message}");
                Console.ResetColor();
            }
            if (asm is not null)
            {
                Console.WriteLine(asm.FullName);
                // получаем все типы из сборки MyApp.dll
                Type[] types = asm.GetTypes();
                foreach (Type type in types)
                {
                    Console.WriteLine(type.Name);
                }
            }

        }
        private async Task StartExampleLateBindingTestLiblary()
        {
            Console.WriteLine("\nПозднее связывание");
            Console.WriteLine(nameof(StartExampleLateBindingTestLiblary));
            Assembly asm = Assembly.LoadFrom("TestLiblary.dll");
            Type? t = asm.GetType("TestLiblary.Account");
            if (t is not null)
            {
                Console.WriteLine("Класс найден, получаем метод");
                // получаем метод
                object? accountInstance = Activator.CreateInstance(t, new object[] { 100 });
                MethodInfo? takeMethod = t.GetMethod("Take", BindingFlags.Public | BindingFlags.Instance);
                EventInfo? notifyEvent = t.GetEvent("Notify");
                if (takeMethod is not null && accountInstance is not null)
                {
                    MethodInfo? handlerMethod = typeof(Lesson5).GetMethod(nameof(OnAccountNotify), BindingFlags.NonPublic | BindingFlags.Instance);
                    if (handlerMethod is not null)
                    {
                        Delegate d = Delegate.CreateDelegate(notifyEvent?.EventHandlerType!, handlerMethod); // ОСТАНОВИЛСЯ ТУТ НА ЭТОМ МЕТОДЕ, ПЕРЕШЕЛ ДЕЛАТЬ ДРУГИЕ ЧТОБЫ ПОТОМ ЛУЧШЕ ПОНЯТЬ ЭТОТ
                    }
                    Console.WriteLine("Пробуем вызвать метод");
                    // вызываем метод на конкретном объекте accountInstance
                    // передаем аргумент sum = 5
                    takeMethod.Invoke(accountInstance, new object[] { 5 });
                    // Проверим, изменилась ли сумма ( опционально, через свойство Sum)
                    PropertyInfo? sumProp = t.GetProperty("Sum");
                    Console.WriteLine($"Текущий баланс: {sumProp?.GetValue(accountInstance)}");

                    void OnAccountNotify(string message)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"[Событие перехвачено]: {message}");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Метод не найден или объект не создан");
                    Console.ResetColor();
                }
            }
            else
                Console.WriteLine("Класс не найден в сборке. Проверьте имя и namespace.");
            Console.WriteLine($"Программа искала файл здесь: {AppDomain.CurrentDomain.BaseDirectory}");

        }
    }
}




