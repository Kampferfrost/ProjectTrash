namespace Store.Commands
{
    internal class LookProductsStore : CommandMenu
    {
        public override int IdCommand { get; set; } = 1;

        public override void Execute(Store store)
        {
            foreach (var productStore in store.GetListProductsStore())
            {
                Console.WriteLine(productStore.Name);
            }
            
        }
    }
}

