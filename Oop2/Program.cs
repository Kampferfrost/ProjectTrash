namespace Oop2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Player player = new Player();

            int x = player.X; 
            int y = player.Y;

            Console.SetCursorPosition(x, y);
            Console.ReadKey();
        }
    }
}