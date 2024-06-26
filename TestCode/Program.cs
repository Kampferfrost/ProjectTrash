namespace TestCode
{
    delegate void MoveHandler(); // нужно протестировать, запихнем в разные cs файлы. Будет ли он работать тогде?
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








