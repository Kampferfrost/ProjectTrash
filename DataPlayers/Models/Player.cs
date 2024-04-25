namespace DataPlayers.Models
{
    internal class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public bool Ban { get; set; }
        public int Rating { get; set; }
        public decimal Dps { get; set; }
        public DateTime BannedTime { get; set; }
        public DateTime EndBanTime { get; set; }
        public int IdArenaTwoVSTwo { get; set; }


        public static string ShowRoar()
        {
            return "Я пидор";
        }

    }
}
