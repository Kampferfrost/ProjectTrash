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

        #region Name

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
        /// Игроки пидоры не донатят
        /// </summary>
        private List<Player> _players = new List<Player>();

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
            
            foreach(var player in _players)
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
        #endregion

        //Todo: 1) Бан/разбана игрока на сервере по имени игрока
        //Todo: 2) Дата бана игрока, дата разбана игрока
        //Todo: 3) Дата бана с, дата бана по
        //Todo: 4) Команды арены (игроки, рейтинг, лимит 2 игрока в команде, название)
        //Todo: 5) Завести пару команд с игроками
        //Todo: 6) Online server, максимальная онлайн сервера
        //Todo: 7) Uptime server
        //Todo: 8) Дата падения/поднятия server

    }

}
