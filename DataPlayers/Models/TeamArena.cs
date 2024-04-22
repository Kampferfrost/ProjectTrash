namespace DataPlayers.Models
{
    internal class TeamArena
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public int CountPlayers { get; set; }
        public int Win { get; set; }
        public int Loss {  get; set; }
        public List<Player> Players { get; set; }
        //лимит 2 игрока в команде, странно ну ладно
    }

}
