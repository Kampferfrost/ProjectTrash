namespace PlayerDataBase1
{
    internal class Program
    {
        static void Main(string[] args)
        {


            PlayerData PlayerData = new PlayerData();

            PlayerData.WorkData = true;


            PlayerData.Work();



        }
    }

    internal class MainMenu
    {
        public string MenuText { get;} = "Список игроков:";
        public string MenuCommand { get;} = "Выберите команду:\n 1 добавить игрока\n 2 забанить игрока\n 3 удалить игрока\n 4 выход из программы";

        public void ShowMainMenu()
        {
            Console.WriteLine(MenuText);
            Console.WriteLine(MenuCommand);
        }
    }


}
