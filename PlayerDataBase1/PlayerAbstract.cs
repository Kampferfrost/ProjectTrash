namespace PlayerDataBase1
{
    abstract class PlayerAbstract : IPerson
    {
        public int SerialNumber { get; }
        public string Name { get; }
        public int Level { get; }

        public bool Ban { get; }

        public PlayerAbstract(int serialNumber, string name, int level, bool ban)
        {
            SerialNumber = serialNumber;
            Name = name;
            Level = level;
            Ban = ban;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Номер:{SerialNumber} Имя: {Name} Уровень:{Level} Статус бана:{Ban} ");
        }

    }

    class Player : PlayerAbstract
    {
        public Player(int serialNumber, string name, int level, bool ban) : base(serialNumber, name, level, ban)
        {
            
        }
    }



}
