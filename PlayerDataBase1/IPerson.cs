namespace PlayerDataBase1
{
    internal interface IPerson
    {
        bool Ban { get; }
        int Level { get; }
        string Name { get; }
        int SerialNumber { get; }
    }
}