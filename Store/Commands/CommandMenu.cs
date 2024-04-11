namespace Store.Commands
{
    internal abstract class CommandMenu : ICommandMenu
    {
        public abstract int IdCommand { get; set; }

        public abstract void Execute(Store store);
    }
}
