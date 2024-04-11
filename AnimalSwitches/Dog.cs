namespace AnimalSwitches
{// Замена условного оператора полиморфизмом
    internal class Dog : Animal
    {
        public override string GetRoar()
        {
            return "Bark";
        }
    }
}
