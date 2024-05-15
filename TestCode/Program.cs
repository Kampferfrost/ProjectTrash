using System.Threading.Channels;

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

            Task task = new Task(()) => Console.WriteLine();
            task.Start();
            //как это есть?




        }


}


}









