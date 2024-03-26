namespace PlayerDataBase1
{
    abstract class PlayerDataAbstract : IPlayerData
    {
        private bool _workData = true;

        public int SerialNumber { get; }
        public string Name { get; }
        public int Level { get; }
        public bool Ban { get; }

        public bool WorkData
        {
            set
            {
                _workData = value;
            }

            get
            {
                return _workData;
            }
        }

        private List<Player> _players = new List<Player>()
        {
            new Player(1, "Cirno", 60, false),
            new Player(2, "Reimu", 58, false),
            new Player(3, "Tigr", 28, false),
            new Player(4, "PowerPidor", 120, true)

        };

        MainMenu mainMenu = new MainMenu();


        public void Work()
        {
            while (WorkData)
            {
                
                mainMenu.ShowMainMenu();

                _players[0].ShowInfo();

                for (int i = 0; i < _players.Count; i++)
                {
                    _players[i].ShowInfo();
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        public void ExitApp()
        {
            WorkData = false;
        }

        public void AddPlayer()
        {

        }

    }

    class PlayerData : PlayerDataAbstract
    {

    }

}
