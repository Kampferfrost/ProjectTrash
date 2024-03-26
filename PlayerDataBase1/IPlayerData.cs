namespace PlayerDataBase1
{
    internal interface IPlayerData
    {
        bool Ban { get; }
        int Level { get; }
        string Name { get; }
        int SerialNumber { get; }

        bool WorkData { get; set; }
    }
}