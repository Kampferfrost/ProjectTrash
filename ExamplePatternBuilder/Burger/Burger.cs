namespace ExamplePatternBuilder.Burger
{

    // Наш пример класса который мы будем создавать с помошью BurgerBuilder
    public class Burger
    {
        //Состав Бургера
        private bool _hasPatty;
        private bool _hasLettuce;
        private bool _hasTomatoes;
        private bool _hasCucumbers;
        private bool _hasOnions;
        private bool _hasCheese;
        private bool _hasKetchup;

        internal Burger(bool hasPatty, bool hasLettuce, bool hasTomatoes,
                      bool hasCucumbers, bool hasOnions, bool hasCheese,
                      bool hasKetchup)

        {
            _hasPatty = hasPatty;
            _hasLettuce = hasLettuce;
            _hasTomatoes = hasTomatoes;
            _hasCucumbers = hasCucumbers;
            _hasOnions = hasOnions;
            _hasCheese = hasCheese;
            _hasKetchup = hasKetchup;
        }

    }
}
