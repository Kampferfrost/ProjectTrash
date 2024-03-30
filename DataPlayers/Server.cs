namespace TestCode
{
    internal class Server
    {
        /// <summary>
        /// Игроки пидоры не донатят
        /// </summary>
        private Player[] _players;

        public Server(Player[] players)
        {
            _players = players;
        }

        public IEnumerable<string> GetPlayerNames()
        {
            List<string> names = new List<string>();
            foreach (Player name in _players) 
            { 
                names.Add(name.Name);
            }   
            
            return names;
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
                if(player.Ban == true)
                {
                    bannedPlayers.Add(player);
                }
            }
            return bannedPlayers;

        }
       
    }

}
