namespace AnimalSwitches
{// Замена условного оператора полиморфизмом
    internal class Cat : Animal
    {
        public override string GetRoar()
        {
            return "Meow";
        }
    }
}
