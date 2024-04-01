using System.Net;
using System.Runtime.InteropServices;
using System;
using System.Security.Cryptography.X509Certificates;
using TestCode;
using System.Numerics;
using System.Reflection.Emit;
using System.Collections;

namespace TestCode
{



    internal class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Список игроков");
            List<Player> _players = new List<Player>()
            {
                new Player() {SerialNumber = 1, Name = "Хлеб", Level = 60, Ban = false, Rating = 120, Dps = 60 },
                new Player() {SerialNumber = 2, Name = "Хикита", Level = 60, Ban = false,Rating = 700, Dps = 1000 },
                new Player() {SerialNumber = 3, Name = "Слэм", Level = 60, Ban = true ,Rating = 2350, Dps = 18567},
                new Player() {SerialNumber = 3, Name = "Гэля", Level = 60, Ban = false ,Rating = 1900, Dps = 70},
                new Player() {SerialNumber = 3, Name = "Ира", Level = 60, Ban = true,Rating = 0, Dps = 10},
                new Player() {SerialNumber = 3, Name = "Корова", Level = 60, Ban = false, Rating = 500, Dps = 480},
                new Player() {SerialNumber = 3, Name = "Пидор", Level = 60, Ban = true,Rating = 2700, Dps = 5000},

            };
            foreach (var player in _players)
            {
                Console.WriteLine(player.GetType().Name);
                Console.WriteLine(player.Name);
                Player.ShowRoar();
            }

            List<Player> listBanPlayers = new List<Player>();
            
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

            Server server = new Server(_players.ToArray());

            var PlayerNames = server.GetPlayerNames();

            foreach (var player in PlayerNames)
            {
                Console.WriteLine(player + " ");
            }

            Console.WriteLine();
            var BannedPlayers = server.GetBannedPlayers();

            foreach (var player in BannedPlayers)
            {
                Console.WriteLine("Забанен "+ player.Name);
            }

        }



    }


}









