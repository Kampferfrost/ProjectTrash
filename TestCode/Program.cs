using System.Net;
using System.Runtime.InteropServices;

namespace TestCode
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game();

            game.ShowInfo();


        }
    }

    class Game 
    {
        private List<Character> _characters = new List<Character>();

        public Game() 
        {
            _characters.Add(new Character("Clarissa", "Damager"));
            _characters.Add(new Character("Fishl", "Archer"));
        }

        public void ShowInfo()
        {
            for (int i = 0; i < _characters.Count; i++)
            {
                _characters[i].ShowInfo();
            }
        }

    }

    class Character
    {
        private string _name;
        private string _class;

        public Character(string name, string description)
        {
            _name = name;
            _class = description;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_name} {_class}");
        }
    }



}


