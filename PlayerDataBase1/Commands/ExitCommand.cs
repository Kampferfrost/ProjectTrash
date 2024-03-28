namespace PlayerDataBase1.Commands
{
    public class ExitCommand : CommandMenu
    {
        public override int Id { get; set; } = 4;
        public override void Execute(PlayerDataAbstract playerData)
        {
            playerData.ExitApp();

        }
    }


}
