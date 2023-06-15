using System.Net;
using System.Runtime.InteropServices;

namespace TestCode
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Меню");
            Console.WriteLine("Choose an operation");
            Console.WriteLine("1 - Вывести всех персонажей");
            Console.WriteLine("2 - Добавить персонажа");
            Console.WriteLine("");

            Game game = new Game();

            int choose = 0;
            choose = Convert.ToInt32(Console.ReadLine());
            if (choose == 2) 
            {
                game.AddListGame(new Character("Clarissa"));
                game.PrintAllCharactersGames();
            }
            else
            {
                Console.WriteLine("Ты что, ожидал тут что-то увидеть логику, МММММ?\nТут только трешь битарда");
            }

            Console.WriteLine("\nВсе сегодня больше не программируешь. Мяу");
            


        }
    }

    class Game
    {
        private List<Character> _characters = new List<Character>();

        public void AddListGame(Character characters)
        {
            _characters.Add(characters);
        }

        public void PrintAllCharactersGames()
        {
            for (int i = 0; i < _characters.Count; i++)
            {
                _characters[i].PrintInfo();
            }
        }

    }

    class Character
    {
        private string _name;

        public Character(string name)
        {
            _name = name;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Имя пернажа {_name}");
        }
    }


}


