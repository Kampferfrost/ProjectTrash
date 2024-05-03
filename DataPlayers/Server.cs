using DataPlayers.Models;

namespace DataPlayers
{
    /// <summary>
    ///  Лучший сервер в Бульбашии
    /// </summary>
    internal class Server
    {
        public ServerRate ServerRate { get; private set; }

        public Server(ServerRate serverRate, string name)
        {
            ServerRate = serverRate;
            Name = name;
        }

        #region IsRunning

        public bool IsRunning { get; private set; } = false;

        public void RunServer()
        {
            IsRunning = true;
        }

        public void StopServer()
        {
            IsRunning = false;
        }

        #endregion

        #region ServerName

        public string Name { get; private set; } = "Warcraft.by";

        public void SetName(string name)
        {
            Name = name;
        }

        public void ResetName()
        {
            Name = string.Empty;
        }


        #endregion

        #region Players

        /// <summary>
        /// Игроки не донатят
        /// </summary>
        private List<Player> _players = new List<Player>();


        /// <summary>
        /// Добавление Игрока с проверкой если уже игрок с таким именем
        /// </summary>
        public void AddPlayer(Player player)
        {
            foreach (var item in _players)
            {
                if (item.Name == player.Name)
                {
                    return;
                }
            }

            _players.Add(player);

        }

        public IEnumerable<string> GetPlayerNames()
        {
            List<string> names = new List<string>();
            foreach (Player player in _players)
            {
                names.Add(player.Name);
            }

            return names;
        }

        public List<decimal> GetDPS()
        {
            List<decimal> dps = new List<decimal>();
            foreach (Player player in _players)
            {
                dps.Add(player.Dps);
            }

            return dps;
        }

        public decimal GetAllDPSPlayers()
        {
            decimal dpsPlayers = 0;
            foreach (var player in _players)
            {
                dpsPlayers += player.Dps;
            }

            return dpsPlayers;
        }

        public Player GetPlayerMaxDps()
        {
            Player playerMaxDps = _players[0];

            foreach (var player in _players)
            {
                if (playerMaxDps.Dps <= player.Dps)
                {
                    playerMaxDps = player;
                }
            }

            return playerMaxDps;
        }


        // 
        /// <summary>
        ///     возврат забаненных игроков
        /// </summary>
        /// <returns> список игроков</returns>
        public IList<Player> GetBannedPlayers()
        {
            List<Player> bannedPlayers = new List<Player>();
            foreach (Player player in _players)
            {
                if (player.Ban == true)
                {
                    bannedPlayers.Add(player);
                }
            }
            return bannedPlayers;
        }

        //возврат игроков по рейтингу от и до

        // 1 задание бан
        public string SetPlayerStatusBan(string name, int hour)
        {
            Player player = GetPlayerByName(name);
            string banStatus = "Неопределен";
            if (player.Ban == false)
            {
                player.Ban = true;
                player.BannedTime = DateTime.Now;
                player.EndBanTime = player.BannedTime.AddHours(hour);
                banStatus = $"Игрок {player.Name} Забанен на: {player.EndBanTime.Subtract(player.BannedTime)}";
            }
            else
            {
                banStatus = "Игрок не может быть забанен, так как уже имеет статус бан";
            }
            return banStatus;
        }
        
        public string SetPlayerStatusUnbanned(string name)
        {
            Player player = GetPlayerByName(name);
            string banStatus = "Неопределен";
            if (player.Ban == true)
            {
                player.Ban = false;
                player.EndBanTime = DateTime.Now;
                banStatus = $"Игрок {player.Name} Разбанен";
            }
            else
            {
               banStatus =  $"Игрок {player.Name}не может быть разбанен, так как не имеет статус бан";
            }
            return banStatus;
        }




        /// <summary>
        /// Дает ссылку на игрока из списка сервера
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Player GetPlayerByName(string name)
        {
            Player playerSourse = _players[0];
            foreach (var player in _players)
            {
                if (player.Name == name)
                {
                    playerSourse = player;
                    break;
                }
            }
            return playerSourse;
        }

        public Player GetPlayerById(int id)
        {
            Player playerSourse = _players[0];
            foreach (var player in _players)
            {
                if (player.Id == id)
                {
                    playerSourse = player;
                    break;
                }
            }
            return playerSourse;
        }

        public int GetCountPlayersOnlineOnServer()
        {
            int count = 0;
            foreach (var player in _players)
            {
                if (player.IsPlayerOnline == true)
                { 
                    count =+ 1;
                }
            }
            return count;
        }

        #endregion

        #region TeamArena

        private List<TeamArena> _teamArenas = new List<TeamArena>();

        public void CreatTeamArena(TeamArena teamArena, string namePlayer)
        {
            Player playerCreaterArena = GetPlayerByName(namePlayer);
            foreach (var team in _teamArenas)
            {
                if(team.Name == teamArena.Name && team.IdFirstPlayer == playerCreaterArena.Id)
                {
                    return;
                }
               
            }

            _teamArenas.Add(teamArena);
            teamArena.Id = _teamArenas.Count;
            teamArena.IdFirstPlayer = playerCreaterArena.Id;
            playerCreaterArena.IdArenaTwoVSTwo = teamArena.Id; 

        }

        public List<TeamArena> GetListTeamArenas()
        {
            return _teamArenas;
        }

        #endregion


        public int MaxPlayerOnline { get; private set; }
        

        

        // а как сделать людей онлайн?
        // создать лист онлайн игроков 
        // не придумал
        // допустим заведу поле статус игрока на сервере онлайн офлайн(true false) и от них уже считать онлайн

        //Todo: 1) Бан/разбана игрока на сервере по имени игрока #готово
        //Todo: 2) Дата бана игрока, дата разбана игрока #готово
        //Todo: 3) Дата бана с, дата бана по #готово
        //Todo: 4) Команды арены (игроки, рейтинг, лимит 2 игрока в команде, название) #готово
        //Todo: 5) Завести пару команд с игроками #готово
        //Todo: 6) Online server, максимальный онлайн сервера 
        //Todo: 7) Uptime server 
        //Todo: 8) Дата падения/поднятия server

    }

}
