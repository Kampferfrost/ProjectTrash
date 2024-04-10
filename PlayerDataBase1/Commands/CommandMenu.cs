namespace PlayerDataBase1.Commands
{
    interface ICommand
    {

    }

    public abstract class CommandMenu : ICommand
    {
        public abstract int Id { get; set; }
        public abstract void Execute(PlayerDataAbstract playerData);

    }


}
