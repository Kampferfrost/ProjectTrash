using DataPlayers.Models;
using DataPlayers.Services;

namespace DataPlayers
{



    internal class Program
    {
        static private ServerPlatform platform;

        static void Main(string[] args)
        {
            ServerRate serverRate1 = new ServerRate() { ExpRate = 1, GoldRate = 1, HonorRate = 1, StartLevel = 1 };
            Server server1 = new Server(serverRate1, "WotLK x1");

            ServerRate serverRate100 = new ServerRate() { ExpRate = 100, GoldRate = 100, HonorRate = 100, StartLevel = 1 };
            Server server2 = new Server(serverRate100, "WotLK x100");

            ServerRate serverRateFun = new ServerRate() { ExpRate = 1, GoldRate = 1, HonorRate = 1, StartLevel = 80 };
            Server server3 = new Server(serverRateFun, "WotLK FUN");

            List<Server> servers = new List<Server>() { server1, server2, server3 };
            platform = new ServerPlatform(servers, "Warcraft.by");

            Console.WriteLine("Список игроков из Main List\n");
            List<Player> _players = new List<Player>()
            {
                new Player() {SerialNumber = 1, Name = "Хлеб", Level = 60, Ban = false, Rating = 120, Dps = 60, BannedTime = DateTime.MinValue, EndBanTime = DateTime.MinValue },
                new Player() {SerialNumber = 2, Name = "Хикита", Level = 60, Ban = false,Rating = 700, Dps = 1000, BannedTime = DateTime.MinValue, EndBanTime = DateTime.MinValue },
                new Player() {SerialNumber = 3, Name = "Слэм", Level = 60, Ban = false ,Rating = 2350, Dps = 18567, BannedTime = new DateTime(2021, 03, 03), EndBanTime = new DateTime(2021, 03, 10), ArenaNameTwoVsTwo = "Плачь и смотри"},
                new Player() {SerialNumber = 3, Name = "Гэля", Level = 60, Ban = false, Rating = 1900, Dps = 70, BannedTime = DateTime.MinValue, EndBanTime = DateTime.MinValue, ArenaNameTwoVsTwo = "Кокосики"},
                new Player() {SerialNumber = 3, Name = "Ира", Level = 60, Ban = true,Rating = 0, Dps = 10, BannedTime = new DateTime(2023, 08, 25), EndBanTime = DateTime.MinValue},
                new Player() {SerialNumber = 3, Name = "Корова", Level = 60, Ban = false, Rating = 500, Dps = 480, BannedTime = DateTime.MinValue, EndBanTime = DateTime.MinValue},
                new Player() {SerialNumber = 3, Name = "Пидор", Level = 60, Ban = true, Rating = 2700, Dps = 5000, BannedTime = new DateTime(2024, 04, 17), EndBanTime = new DateTime(2024, 06, 17)},
                new Player() {SerialNumber = 3, Name = "ГрибоСлэм", Level = 60, Ban = false, Rating = 2801, Dps = 5000,BannedTime = DateTime.MinValue, EndBanTime = DateTime.MinValue, ArenaNameTwoVsTwo = "Плачь и смотри"},

            };

            

            foreach (var player in _players)
            {
                server1.AddPlayer(player);
            }

            Console.WriteLine("########Arena############");
            server1.AddTeamArena(new TeamArena() { Name = "Плачь и смотри" }); //не работает
            List<TeamArena> testArena = server1.GetListTeamArenas();
            foreach (var team in testArena)
            {
                Console.WriteLine(team.Name);
            }
            Console.WriteLine("########EndArena############");

            Console.WriteLine(server1.SetPlayerStatusBan("Корова", 1));
            Console.WriteLine(server1.SetPlayerStatusUnbanned("Пидор"));
            

            Console.WriteLine($"\nСервер: {server1.Name} Игроки:");
            foreach (var playerName in server1.GetPlayerNames())
            {
                Console.WriteLine(playerName);
            }
            Console.WriteLine($"\nСписок забанненых игроков на сервере {server1.Name}:");
            foreach (var player in server1.GetBannedPlayers())
            {
                string dateBanned = "";
                if(player.BannedTime == DateTime.MinValue)
                {
                    dateBanned = "Нет даты";
                }
                else
                {
                    dateBanned = Convert.ToString(player.BannedTime);
                }
                Console.WriteLine($"{player.Name} Дата Бана: {dateBanned}, Дата разбана: {player.EndBanTime}");
            }


            Console.WriteLine($"\nDPS Игроков {server1.Name}:");
            foreach (var playerDPS in server1.GetDPS())
            {
                Console.WriteLine(playerDPS);
            }

            Console.WriteLine($"\nСуммарный ДПС Игкроков {server1.Name}:");
            Console.WriteLine(server1.GetAllDPSPlayers());

            Console.WriteLine($"\nСамый большой ДПС {server1.Name}: ");
            var playerWithMaxDps = server1.GetPlayerMaxDps();
            Console.WriteLine(playerWithMaxDps.Name);
            Console.WriteLine(playerWithMaxDps.Dps);


            //OldMethod(_players);

        }

        private static void OldMethod(List<Player> _players)
        {
            foreach (var player in _players)
            {
                Console.WriteLine(player.GetType().Name);
                Console.WriteLine(player.Name);
                Player.ShowRoar();
            }


            //1500 до 1800
            List<Player> raitingList = new List<Player>();

            Console.WriteLine();
            Console.WriteLine();

            foreach (var player in _players)
            {
                if (player.Ban == true)
                {
                    Console.Write($"{player.Name} Рейтинг {player.Rating}");
                    Console.WriteLine($" {player.Name} забанен ");
                }
                if (player.Rating >= 200 && player.Rating <= 2000)
                {
                    raitingList.Add(player);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Список игроков с рейтингом с 1500 до 1800");
            Console.WriteLine();
            Console.WriteLine("Список игроков сервера");
        }
    }


}









