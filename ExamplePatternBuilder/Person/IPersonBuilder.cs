namespace ExamplePatternBuilder.Person
{
    public interface IPersonBuilder
    {
        IPersonBuilder WithName(string name);
        Person Build();
    }
}
