namespace PlayerDataBase1
{
    public class PlayerDataAbstract : IPlayerData
    {
        private bool _workData = true;

        public int SerialNumber { get; }
        public string Name { get; } = "Name";
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

        MainMenu mainMenu = new MainMenu();

        private List<Player> _players = new List<Player>()
        {
            new Player(1, "Cirno", 60, false),
            new Player(2, "Reimu", 58, false),
            new Player(3, "Tigr", 28, false),
            new Player(4, "PowerPidor", 120, true)

        };



        



        public void Work()
        {

            
            while (WorkData)
            {

                mainMenu.ShowMainMenu();

                mainMenu.ShowAllPlayer(_players);

                Command exitCommand = new ExitCommand();
                exitCommand.Execute(this);

                Command AddCommand = new AddCommand();
                AddCommand.Execute(this);


                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        AddPlayer();
                        break;
                    case 2:
                        BanPlayer();
                        break;
                    case 3:
                        RemovePlayer();
                        break;
                    case 4:
                        ExitApp();
                        break;
                    default:
                        break;
                }


                
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void AddPlayer()
        {
            string? name = "name";
            int level;
            int serialNumber;

            Console.Clear();

            Console.WriteLine("Добавить Игрока");
            Console.WriteLine();
            Console.WriteLine("Введите имя игрока");
            name = Console.ReadLine();

            Console.WriteLine("Введите уровень игрока");
            level = Convert.ToInt32(Console.ReadLine());
            serialNumber = _players.Count + 1;

            _players.Add(new Player(serialNumber, name, level, false));


            Console.WriteLine($"Игрок {name} добавлен");

        }

        public void BanPlayer()
        {
            Console.Clear();
            Console.WriteLine("Забанить Игрока");

            _players[4].SetStatusBan(true);

            

        }

        public void CommandSwitch()
        {

        }

        public void ExitApp()
        {   
            
            WorkData = false;
            mainMenu.ShowExit();
        }

        public void AddCoomand()
        {
            Console.WriteLine("PlayerData.AddCommand");
        }
        

        public void RemovePlayer() 
        {
            Console.Clear();
            Console.WriteLine("Удаляем игрока");

            Console.WriteLine();
            mainMenu.ShowAllPlayer(_players);

            Console.WriteLine();
            Console.WriteLine("Введите номер удаляемого игрока");



        }



    }


}
