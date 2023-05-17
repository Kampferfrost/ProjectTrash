using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop2
{
    internal class RendererPlayer
    {
        private char _playerSymbol = 'a';


        internal void ShowPlayer()
        {
            Player player = new Player();
            int x = player.X;
            int y = player.Y;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(_playerSymbol);
        }

        

    }
}
