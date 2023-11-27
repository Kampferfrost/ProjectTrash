using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerDatabase
{
    internal class DataPlayers //Model
    {
        private List<Player> _players = new List<Player>()
        {
            new Player(1, "Clarissa", 60, false),
            new Player(2, "Angelica", 60, false),
            new Player(3, "Kampfer", 80, true),
            new Player(4, "Rem", 70, false),
        };

        public DataPlayers() 
        { 
        }

        public void ShowAllPlayers()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                _players[i].ShowPlayer();
            }
            Console.WriteLine();
        }

        public void AddPlayer(string name, int levelPlayer, bool ban)
        {
            string _name = name;
            int _levelPlayer = levelPlayer;
            bool _ban = ban;


            _players.Add(new Player(_players.Count + 1, _name, _levelPlayer, _ban));
       

        }


    }
}
