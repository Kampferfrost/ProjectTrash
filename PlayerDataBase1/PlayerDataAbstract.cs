using PlayerDataBase1.Commands;
using PlayerDataBase1.Players;

namespace PlayerDataBase1
{
    public class PlayerDataAbstract : IPlayerData
    {
        private bool _workData = true;

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

        MainMenu _mainMenu = new MainMenu();

        private List<Player> _players = new List<Player>()
        {
            new Player(1, "Cirno", 60, false),
            new Player(2, "Reimu", 58, false),
            new Player(3, "Tigr", 28, false),
            new Player(4, "PowerPidor", 120, true)
        };



        private List<CommandMenu> _commandMenus = new List<CommandMenu>()
        {
            new AddCommand(),
            new BanCommandAbstract(),
            new RemoveCommand(),
            new ExitCommand()
        };


        public void Work()
        {

            while (WorkData)
            {
                _mainMenu.ShowMainMenu();
                _mainMenu.ShowAllPlayer(_players);

                int setNumberCommand;

                if(int.TryParse(Console.ReadLine(), out setNumberCommand))
                {
                    foreach (var command in _commandMenus)
                    {
                        if (command.Id == setNumberCommand)
                        {
                            command.Execute(this);
                            break;
                        }
                    }

                    Console.ReadKey();
                    Console.Clear();
                    
                }
                else
                {
                    Console.Clear();
                    continue;

                }            
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
            _mainMenu.ShowAllPlayer(_players);
            Console.WriteLine();

            Console.WriteLine("Введите номер игрока");
            int serialNumber = Convert.ToInt32(Console.ReadLine());

            foreach (var player in _players)
            {
                if (player.SerialNumber == serialNumber)
                {
                    player.SetStatusBan(true);
                    break;
                }
            }
        }

        public void RemovePlayer()
        {

            Console.Clear();
            Console.WriteLine("Удаляем игрока");

            Console.WriteLine();
            _mainMenu.ShowAllPlayer(_players);

            Console.WriteLine();
            Console.WriteLine("Введите номер удаляемого игрока");

            int serialNumber = Convert.ToInt32(Console.ReadLine());

            string name = "";

            foreach (var player in _players)
            {
                if (player.SerialNumber == serialNumber)
                {
                    name = player.Name;
                    _players.Remove(player);
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Игрок {name} удален"); ;


            //недописано 

        }

        public void ExitApp()
        {
            WorkData = false;
            _mainMenu.ShowExit();
        }



        



    }


}
