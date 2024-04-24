namespace DataPlayers.Models
{
    internal class TeamArena
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public int CountPlayers { get; set; }
        public int Win { get; set; }
        public int Loss {  get; set; }
        public Player FirstPlayer { get; set; } //А надо ли?
        public Player SecondPlayer { get; set; } //А надо ли?

        
    }

}
