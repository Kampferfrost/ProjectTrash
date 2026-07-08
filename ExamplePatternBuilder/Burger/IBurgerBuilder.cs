namespace ExamplePatternBuilder.Burger
{
    public interface IBurgerBuilder
    {
        IBurgerBuilder AddPatty();
        IBurgerBuilder AddLettuce();
        IBurgerBuilder AddTomatoes();
        IBurgerBuilder AddCucumbers();
        IBurgerBuilder AddOnions();
        IBurgerBuilder AddCheese();
        IBurgerBuilder AddKetchup();
        Burger Build();

    }
}
