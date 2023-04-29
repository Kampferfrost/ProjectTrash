namespace ProjectTrash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Kamper", 80);
            player.ShowInfo();
        }
    }

    class Player
    {
        private string Name { get; }
        private int _level;
        public int Level
        {
            get
            {
                return _level;
            }
            private set { _level = value; }
        }

        public Player(string name, int level)
        {
            Name = name;
            Level = level;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Ник: {Name}\nУровень персонажа: {Level}");
        }
    }

}