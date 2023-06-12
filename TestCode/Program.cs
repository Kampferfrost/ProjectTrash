using System.Net;
using System.Runtime.InteropServices;

namespace TestCode
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game("Epic Seven");
            Character character = new Character("Clarissa", game);

            character.Print();




        }
    }

    class Game
    {
        private string _nameGame;

        public Game(string nameGame)
        {
            _nameGame = nameGame;
        }

        public void Print()
        {
            Console.WriteLine($"Название игры {_nameGame}");
        }
    }

    class Character
    {
        private string _name;
        private Game _game;

        public Character(string name, Game game)
        {
            _name = name;
            _game = game;
        }

        public void Print()
        {
            _game.Print();
            Console.WriteLine($"Персонаж: {_name}");
        }
    }




}


