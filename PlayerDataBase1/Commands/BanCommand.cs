namespace PlayerDataBase1.Commands
{
    public class BanCommand : CommandMenu
    {
        public override int Id { get; set; } = 2;

        public override void Execute(PlayerDataAbstract playerData)
        {
            Console.WriteLine("Бан Персонажа");
            playerData.BanPlayer();
        }
    }


}
