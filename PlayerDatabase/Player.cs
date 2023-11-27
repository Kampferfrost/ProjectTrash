using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerDatabase
{
    internal class Player
    {
        private int _numberPlayer;
        private string? _nickName;
        private int _levelPlayer;
        private bool _ban;
        private int _kkkk;

        public Player(int numberPlayer, string nickName, int levelPlayer, bool ban)
        {
            _numberPlayer = numberPlayer;
            _nickName = nickName;
            _levelPlayer = levelPlayer;
            _ban = ban;
        }

        public void ShowPlayer()
        {
            Console.WriteLine($"{_numberPlayer}. Имя: {_nickName} Уровень: {_levelPlayer} Бан: {_ban}");
        }



    }
}
