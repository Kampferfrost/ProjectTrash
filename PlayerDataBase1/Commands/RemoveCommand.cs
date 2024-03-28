namespace PlayerDataBase1.Commands
{
    public class RemoveCommand : CommandMenu
    {
        public override int Id { get; set; } = 3;

        public override void Execute(PlayerDataAbstract playerData)
        {
            Console.WriteLine("");
            playerData.RemovePlayer();
        }
    }


}
