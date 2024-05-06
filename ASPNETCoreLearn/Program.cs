namespace ASPNETCoreLearn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "Nep Nep");

            app.Run();
        }
    }
}
