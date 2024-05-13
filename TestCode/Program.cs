namespace TestCode
{
    
    internal class Program
    {
        delegate string PersonTellTrue();
        delegate void Message(); // 1. Объявляем делегат
        static void Main(string[] args)
        {

            Person person = new Person();

            Console.WriteLine(person.TellTrue());
            PersonTellTrue Mess;

            Mess = person.TellTrue;

            Console.WriteLine(Mess());
        }


    }


}









