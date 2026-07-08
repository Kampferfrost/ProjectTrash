//var builder = new PersonBuilder();
//var person = builder
//    .WithName("Tiger")
//    .Build();
//Console.WriteLine(person.Name);


namespace ExamplePatternBuilder.Person
{

    internal class PersonBuilder : IPersonBuilder
    {
        private string _name = string.Empty;
        public Person Build()
        {
            return new Person(_name);
        }

        public IPersonBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
    }
}
