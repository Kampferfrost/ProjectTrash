namespace Store.View
{
    internal class ViewerMenu
    {
        private Store _store;
        public ViewerMenu(Store store) 
        {
            StoreName = store.StoreName;
            _store = store;
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
        
        public void ShowTitle()
        {
            Console.WriteLine($"Магазин {StoreName}");
            Console.WriteLine("Выбирите действие:\n");
        }

        public void ShowCommandMenu()
        {
            
            int numbering = 1;
            if (_store.MainCommand == 0) 
            {
                foreach (string text in _textMainMenu)
                {
                    Console.WriteLine($"{numbering++}. {text}");
                }
                
            }
            if (_store.MainCommand == 1 )
            {
                {
                    ShowProductStore();
                }
            }
            if (_store.MainCommand == 2)
            {
                foreach (string text in _textStoreMenu)
                {
                    Console.WriteLine($"{numbering++}. {text}");
                }
            }
        }
        
        public void ShowProductStore()
        {
            Console.WriteLine("\nСписок товаров:\n");
            foreach (var productStore in _store.GetListProductsStore())
            {
                Console.WriteLine(productStore.Name);
            }
            Console.WriteLine();
            int numbering = 1;
            foreach (string text in _textStoreMenu)
            {
                Console.WriteLine($"{numbering++}. {text}");
            }
        }

        public void ShowItemPlayer()
        {
            Console.WriteLine("\nСписок предметов в вашей сумке");

            foreach (var productStore in _store.GetListProductsStore())
            {
                Console.WriteLine(productStore.Name);
            }

            int numbering = 1;
            foreach (string text in _textStoreMenu)
            {
                Console.WriteLine($"{numbering++}. {text}");
            }
        }
    }
}
