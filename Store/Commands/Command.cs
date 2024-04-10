namespace Store.Commands
{
    internal abstract class Command : ICommandMenu
    {
        public int IdCommand { get; set; }

        public abstract void Execute(Store store);
    }
}
