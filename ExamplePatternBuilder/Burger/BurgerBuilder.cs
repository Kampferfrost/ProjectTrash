// Паттерн Builder (Строитель)

// Ниже пример, что писать в точке входа:

//var builder = new BurgerBuilder();
//var myBurger = builder
//    .AddPatty()
//    .AddCucumbers()
//    .Build();

namespace ExamplePatternBuilder.Burger
{
    public class BurgerBuilder : IBurgerBuilder
    {
        private bool _hasPatty;
        private bool _hasLettuce;
        private bool _hasTomatoes;
        private bool _hasCucumbers;
        private bool _hasOnions;
        private bool _hasCheese;
        private bool _hasKetchup;

        public IBurgerBuilder AddPatty()
        {
            _hasPatty = true;
            return this; // Возвращаем интерфейс
        }
        public IBurgerBuilder AddLettuce()
        {
            _hasLettuce = true;
            return this;
        }

        public IBurgerBuilder AddTomatoes()
        {
            _hasTomatoes = true;
            return this;
        }

        public IBurgerBuilder AddCucumbers()
        {
            _hasCucumbers = true;
            return this;
        }

        public IBurgerBuilder AddOnions()
        {
            _hasOnions = true;
            return this;
        }

        public IBurgerBuilder AddCheese()
        {
            _hasCheese = true;
            return this;
        }

        public IBurgerBuilder AddKetchup()
        {
            _hasKetchup = true;
            return this;
        }

        public Burger Build()
        {
            return new Burger(_hasPatty, _hasLettuce, _hasTomatoes,
                              _hasCucumbers, _hasOnions, _hasCheese,
                              _hasKetchup);
        }

    }
}
