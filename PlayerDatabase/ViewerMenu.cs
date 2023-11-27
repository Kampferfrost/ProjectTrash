using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PlayerDatabase
{
    //реализовать отображения меню, и ввод данных
    internal class ViewerMenu
    {
        DataPlayers _dataPlayers;

        public ViewerMenu (DataPlayers dataPlayers)
        {
            _dataPlayers = dataPlayers;
        }


        private int _choseCommand;


        private Dictionary<int, string> _menuList = new Dictionary<int, string>()
        {
            {1, "Добавить игрока" },
            {2, "Бан игрока по порядковому номеру" },
            {3, "Разбана игрока по порядковому номеру" },
            {4, "Удаление игрока" },
            {5, "Выход" },

        };

        private Dictionary<int, Command> _commandList = new Dictionary<int, Command>()
        {
            {1,new AddPlayer() },
            {2,new BanPlayer() },
            {3,new AddPlayer() },
            {4,new AddPlayer() },
        };


        public ViewerMenu()
        {



        }



        public void DoCommand()
        {
            var commandRun = _commandList[_choseCommand];
            commandRun.RunCommand(); 


        }

        public void ShowAllPlayers()
        {
            Console.WriteLine();
            _dataPlayers.ShowAllPlayers();

        }


        public void ShowMenu()
        {
            Console.WriteLine("Menu");

            foreach (var item in _menuList)
            {

                Console.WriteLine($"{item.Key} {item.Value}");
            }

        }

        public void ChoseCommand()
        {
            Console.WriteLine("Выберете команду");
            _choseCommand =  Convert.ToInt32(Console.ReadLine());
        }
    }


    internal abstract class Command
    {

        DataPlayers _dataPlayers;



        public abstract void RunCommand();
    }

    internal class AddPlayer : Command
    {


        public override void RunCommand()
        {
            Console.WriteLine("Введите имя персонажа");



            Console.WriteLine("Введите уроветь персонажа");
        }


    }

    internal class BanPlayer : Command
    {
        public override void RunCommand()
        {
            throw new NotImplementedException();
        }
    }

    internal class UnbanPlayer : Command
    {
        public override void RunCommand()
        {
            throw new NotImplementedException();
        }
    }

    internal class DeletePlayer : Command
    {
        public override void RunCommand()
        {
            throw new NotImplementedException();
        }
    }

    internal class ExitMenu : Command
    {
        public override void RunCommand()
        {
            throw new NotImplementedException();
        }
    }
}
