namespace Store.Commands
{
    internal abstract class CommandMenu : ICommandMenu
    {
        public int IdCommand { get; set; }

        public abstract void Execute(Store store);
    }
}
