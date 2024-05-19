namespace TaskExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Container<int>() { Data = 1 };
            new Container<string>() { Data = "one" };
            new Container<int>() { Data = 1 };
        }
    }


}
