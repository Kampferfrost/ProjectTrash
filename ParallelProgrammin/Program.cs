using System;
using ParallelProgrammin.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Linq;

//using System.Threading.Tasks;

namespace ParallelProgrammin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            //services.AddTransient<ILesson, Lesson1>(); 
            //var serviceProvider = services.BuildServiceProvider();
            //var lesson1Servise = serviceProvider.GetRequiredService<ILesson>();
            //lesson1Servise.StartLessonExamples();

            // Автоматически регистрируем все классы, реализующие ILesson
            var lessonsAssembly = Assembly.GetAssembly(typeof(ILesson));
            var lessonTypes = lessonsAssembly
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
