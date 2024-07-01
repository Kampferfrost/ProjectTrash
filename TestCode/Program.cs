namespace TestCode
{
    enum Position
    {
        Manager,
        VicePresident
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Handler handler = new Handler();

            handler.CalculateBonusForEmployee = BonusEmployee;

            Console.WriteLine(handler.CalculateBonusForEmployee(Position.Manager));


            int BonusEmployee(Position position)
            {
                int bonus = 5;
                return bonus;
            }

        }

       

    }

    




}











