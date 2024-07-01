namespace TestCode
{
    internal class Handler
    {
        public delegate int CalculateBonus(Position position);

        public CalculateBonus? CalculateBonusForEmployee { get; set; }

        
    }
}
