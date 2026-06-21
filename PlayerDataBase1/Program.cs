using PlayerDataBase1.Players;

namespace PlayerDataBase1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayerDataAbstract PlayerData = new PlayerData();

            PlayerData.WorkData = true;
            PlayerData.Work();
        }
    }

}
