using PlayerDataBase1.Commands;
using PlayerDataBase1.Players;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        MainMenu mainMenu = new MainMenu();

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
            new BanCommand(),
            new RemoveCommand(),
            new ExitCommand()
        };


        public void Work()
        {

            while (WorkData)
            {
                mainMenu.ShowMainMenu();
                mainMenu.ShowAllPlayer(_players);

                int Number = Convert.ToInt32(Console.ReadLine());

                foreach (var command in _commandMenus)
                {
                    if (command.Id == Number)
                    {
                        command.Execute(this);
                        break;
                    }

                }

                //switch (Convert.ToInt32(Console.ReadLine()))
                //{
                //    case 1:
                //        AddCommand.Execute(this);
                //        break;
                //    case 2:
                //        BanPlayer();
                //        break;
                //    case 3:
                //        exitCommand.Execute(this);
                //        break;
                //    case 4:
                //        ExitApp();
                //        break;
                //    default:
                //        break;
                //}

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
            mainMenu.ShowAllPlayer(_players);
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

        public void ExitApp()
        {
            WorkData = false;
            mainMenu.ShowExit();
        }



        public void RemovePlayer()
        {
            Console.Clear();
            Console.WriteLine("Удаляем игрока");

            Console.WriteLine();
            mainMenu.ShowAllPlayer(_players);

            Console.WriteLine();
            Console.WriteLine("Введите номер удаляемого игрока");

            int serialNumber = Convert.ToInt32(Console.ReadLine());


            foreach (var player in _players)
            {
                if (player.SerialNumber == serialNumber)
                {
                    
                    break;
                }
            }

            _players.RemoveAt(1);

            //недописано 



        }



    }


}
