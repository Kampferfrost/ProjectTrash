namespace Store.Commands
{
    internal interface ICommandMenu
    {
        public int IdCommand { get; set; }
        public void Execute(Store store);
        
    }
}
