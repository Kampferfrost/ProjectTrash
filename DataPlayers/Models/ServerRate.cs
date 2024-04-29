namespace DataPlayers.Models
{
    /// <summary>
    /// Множители сервера
    /// </summary>
    internal class ServerRate
    {
        /// <summary>
        /// Множитель опыта
        /// </summary>
        public int ExpRate { get; set; }

        /// <summary>
        /// Множитель золота
        /// </summary>
        public int GoldRate { get; set; }

        /// <summary>
        /// Множитель Очков чести
        /// </summary>
        public int HonorRate { get; set; }

        /// <summary>
        /// Стартовый уровень персонажей
        /// </summary>
        public int StartLevel { get; set; }

        /// <summary>
        /// Макскимальное количество игроков которые были онлайн
        /// </summary>
        public int MaxPlayersOnlineOneServer { get; set; }


    }
}
