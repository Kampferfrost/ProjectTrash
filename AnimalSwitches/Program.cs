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

            Console.WriteLine("Тип " + animal.GetType().Name);
            Console.WriteLine(animal.GetRoar());

            



        }
    }
}
