namespace PlayerDataBase1.Players
{
    internal interface IPerson
    {
        bool Ban { get; }
        int Level { get; }
        string Name { get; }
        int SerialNumber { get; }
    }
}