using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofCheck
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Animal[] animals = new Animal[4];
            Cat cat = new Cat();
            cat.Name = "Barsik";
            Dog dog = new Dog();
            dog.Name = "Tuzin";
            Horse horse = new Horse();
            horse.Name = "Sakura Bakushin O";
            Boozer boozer = new Boozer();
            boozer.Name = "Dyadya Vitya";
            animals[0] = cat;
            animals[1] = dog;
            animals[2] = horse;
            animals[3] = boozer;
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.Name);
                animal.GetRoar();
                Console.WriteLine();
            }
        }
    }

    internal class Animal
    {
        public string Name { get; set; }
        public virtual void GetRoar()
        {
            Console.WriteLine("Абстрактный клич");
        }
    }
    internal class Cat : Animal
    {
        public override void GetRoar()
        {
            Console.WriteLine("Meow meow");
        }
    }
    internal class Dog : Animal
    {
        public override void GetRoar()
        {
            Console.WriteLine("Gaf gaf");
        }
    }
    internal class Horse : Animal
    {
        public override void GetRoar()
        {
            Console.WriteLine("Bakushin Bakushin Bakushin!");
        }
    }
    internal class Boozer : Animal
    {
        public override void GetRoar()
        {
            Console.WriteLine("Hochu buhat");
        }
    }

}






