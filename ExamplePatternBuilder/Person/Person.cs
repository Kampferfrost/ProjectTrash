namespace ExamplePatternBuilder.Person
{
    public class Person
    {
        public string Name { get; set; }

        internal Person(string name)
        {
            Name = name;
        }
    }
}
