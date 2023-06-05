using System.Net;

namespace TestCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person<int> tom = new Person<int>(234, "Pidor");
            Person<string> bob = new Person<string>("abc123", "Bob");
            //Person <PersonIntString> = new Person<PersonIntString>(new PersonIntString(234, "sdfsd"));

            

            int tomId = tom.Id;
            string bobId = bob.Id;

            Console.WriteLine(tomId);
            Console.WriteLine(bobId);



        }
    }

    class PersonIntString
    {
        public int Id { get; }
        public string Name { get; }
        public PersonIntString(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    class Person<T>
    {
        public T Id { get; set; }
        public string Name { get; set; }
        public Person(T id, string name) 
        {
            Id = id;
            Name = name;
        }
    }

    class Company<P>
    {
        public P CEO { get; set; }
        
        public Company (P ceo)
        {
            CEO = ceo;
        }
    }


}