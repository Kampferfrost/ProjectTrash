using PlayerDataBase1.Players;

namespace PlayerDataBase1
{
    internal class MainMenu
    {
        public string MenuText { get;} = "Список игроков:";
        public string MenuCommand { get;} = "Выберите команду:\n 1 добавить игрока\n 2 забанить игрока\n 3 удалить игрока\n 4 выход из программы";

        public void ShowMainMenu()
        {
            Console.WriteLine(MenuCommand);
            Console.WriteLine();

            Console.WriteLine(MenuText);
            Console.WriteLine();
        }

        public void ShowAllPlayer(List<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].ShowInfo();
            }
        }

        public void ShowExit()
        {
            Console.Clear();
            Console.WriteLine("Выход из программы");
            Console.WriteLine("Нажмите любую клавишу чтобы выйти из программы");
        }
    }

}
