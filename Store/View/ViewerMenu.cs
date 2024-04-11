namespace Store.View
{
    internal class ViewerMenu
    {
        public ViewerMenu(string storeName) 
        {
            StoreName = storeName;
        }
        public string StoreName { get; init; }
        private List<string> _textMainMenu = new List<string>()
        {
            "Посмотреть товары магазина",
            "Посмотреть свои товары"
        };

        private List<string> _textStoreMenu = new List<string>()
        {
            "Купить товар",
            "Выйти из списка товаров"
        };

        public void ShowMainMenu(int numberCommand)
        {
            Console.WriteLine($"Магазин {StoreName}");
            Console.WriteLine("Выбирите действие:");
            int numbering = 1;
            if (numberCommand == 1) 
            {
                foreach (string text in _textMainMenu)
                {
                    Console.WriteLine($"{numbering++}. {text}");
                }
            }
            if (numberCommand == 2)
            {
                foreach (string text in _textStoreMenu)
                {
                    Console.WriteLine($"{numbering++}. {text}");
                }
            }
            
            

        }
    }
}
