using Store.View;

namespace Store.Commands
{
    internal class LookProductsStore : CommandMenu
    {
        public override int IdCommand { get; set; } = 1;

        public override void Execute(Store store)
        {
            store.viewerMenu.ShowProductStore();
            
        }
    }
}

