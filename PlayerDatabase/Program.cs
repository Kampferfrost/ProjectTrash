namespace PlayerDatabase
{
    internal class Program
    {
        public DataPlayers dataPlayers = new DataPlayers();
        static void Main(string[] args)
        {
            
            Controller controller = new Controller();
            ViewerMenu menu = new ViewerMenu(dataPlayers);

            while (true)
            {

                

                menu.ShowMenu();
                menu.ShowAllPlayers();
                menu.ChoseCommand();
                menu.DoCommand();


                Console.ReadKey();
                Console.Clear();


            }

            



            
        }
    }
}