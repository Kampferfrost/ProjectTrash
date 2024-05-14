namespace TestCode
{

    internal class Program
    {
        delegate void MessageHandler(string message);
        static void Main(string[] args)
        {
            MessageHandler handler = delegate (string mes)
            {
                Console.WriteLine(mes);
            };

            handler("tigr");



        }


    }


}









