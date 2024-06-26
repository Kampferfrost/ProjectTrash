namespace TestCode
{
    delegate void MoveHandler(); 
    internal class Program
    {
        static void Main(string[] args)
        {
            IMovable tom = new Person("Tom");

            tom.MoveEvent += () => Console.WriteLine($"{tom.Name} is moving");
            tom.Move();
            
        }


    }


}








