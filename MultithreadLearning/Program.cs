using Microsoft.Extensions.DependencyInjection;
namespace MultithreadLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IClassThread, ClassThread>(); // lesson 1
            services.AddScoped<Lesson2>(); 
            services.AddScoped<Lesson3>(); 
            services.AddScoped<Lesson4>(); 

            using var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope(); 

            var lesson1 = scope.ServiceProvider.GetRequiredService<IClassThread>();
            var lesson2 = scope.ServiceProvider.GetRequiredService<Lesson2>();
            var lesson3 = scope.ServiceProvider.GetRequiredService<Lesson3>();
            var lesson4 = scope.ServiceProvider.GetRequiredService<Lesson4>();

            #region lesson 1

            lesson1.GetThreadInfo();
            lesson1.CheckSleepMethod();

            #endregion

            #region lesson 2

            lesson2.StartLessonExamples();

            #endregion

            #region lesson 3

            lesson3.StartLessonExamples();

            #endregion

            #region lesson 4

            lesson4.StartLessonExamples();

            #endregion

            // lesson5 Мониторы, оставим на потом, переходим на Главу 15. Параллельное программирование и библиотека TPL
        }
    }
}
