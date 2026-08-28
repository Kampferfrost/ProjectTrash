using LINQ.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
// MetanitLessonsStart is a god class(God Object) for classes metanit

namespace MetanitLessonsStart
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            // Автоматически регистрируем все классы, реализующие ILesson
            var lessonTypes = Assembly.GetAssembly(typeof(ILesson))
                .GetTypes()
                .Where(t => typeof(ILesson).IsAssignableFrom(t) && t.IsClass);

            foreach (var type in lessonTypes)
                services.AddTransient(typeof(ILesson), type);

            services.AddTransient<LessonRunner>();

            var provider = services.BuildServiceProvider();

            var runner = provider.GetRequiredService<LessonRunner>();
            runner.RunMenu();

            

        }
    }
}
