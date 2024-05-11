namespace ASPNETCoreLearn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.Run(async (context) => await context.Response.WriteAsync("Hello METANIT.COM"));
            app.Run();



            //это метод делает объект но,  чтобы вызвать нужно run. ран вшит в жопе интерфеса, интерфеса который создается из жопы билдера билдер при этом находится не в жопе а в очень легкой форме 
            //шизофрениии так что давайте забьем на них и поговорим об еще методах из жопы, прокоторые мы тоже забьем, а да вот так их вызвать можно, только в новом .net вам уже не вызвать
            //asp.net Это легко и просто)
            //бросим это дело это было 11.05.2024 в 23:57
        }
    }
}
