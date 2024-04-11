namespace AnimalSwitches
{// Замена условного оператора полиморфизмом
    internal class UnknownAnimal : Animal
    {
        public override string GetRoar()
        {
            return "Unknown";
        }
    }
}
