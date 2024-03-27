namespace AnimalSwitches
{// Замена условного оператора полиморфизмом
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, IAnimal> animalList = new Dictionary<int, IAnimal>()
            {
                { 0, new UnknownAnimal()},
                { 1, new Cat()},
                { 2, new Dog()}
            };


            int typeAnimal;
            Console.WriteLine("Введите номер животного:\n" +
                "1 Кот\n" +
                "2 Собака");
            typeAnimal = Convert.ToInt32(Console.ReadLine());

            IAnimal animal = animalList[typeAnimal];

            Console.WriteLine(animal.GetType().Name);

            Console.WriteLine(animal.GetRoar());


        }
    }

    public interface IAnimal
    {
        string GetRoar();
    }

    internal abstract class Animal : IAnimal
    {
        public abstract string GetRoar();
    }

    internal class Cat : Animal
    {
        public override string GetRoar()
        {
            return "Meow";
        }
    }

    internal class Dog : Animal
    {
        public override string GetRoar()
        {
            return "Bark";
        }
    }

    internal class UnknownAnimal : Animal
    {
        public override string GetRoar()
        {
            return "Unknown";
        }
    }
}
