
namespace Store.Commands
{
    internal class LookPlayerItems : CommandMenu
    {
        public override int IdCommand { get; set; } = 2;

        public override void Execute(Store store)
        {
            store.viewerMenu.ShowItemPlayer();
        }
    }
}
