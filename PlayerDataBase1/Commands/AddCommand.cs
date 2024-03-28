namespace PlayerDataBase1.Commands
{
    public class AddCommand : CommandMenu
    {
        public override int Id { get; set; } = 1;

        public override void Execute(PlayerDataAbstract playerData)
        {
            playerData.AddPlayer();
        }
    }


}
