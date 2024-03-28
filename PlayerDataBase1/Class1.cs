using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerDataBase1
{
    interface ICommand
    {

    }

    public abstract class Command : ICommand
    {
        public abstract void Execute(PlayerDataAbstract playerData);



    }


    public class ExitCommand : Command
    {

        public override void Execute(PlayerDataAbstract playerData)
        {
            playerData.ExitApp();

        }
    }


    public class AddCommand : Command
    {
        public override void Execute(PlayerDataAbstract playerData)
        {
            Console.WriteLine("Добавляю персонажа");
            playerData.AddCoomand();
        }
    }
}
