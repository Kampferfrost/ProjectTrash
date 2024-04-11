using Store.Model;
using Store.View;
using Store.Commands;

namespace Store
{
    internal class Store
    {
        private List<ProductStore> _productsStore = new List<ProductStore>();


        #region IsRunning
        public bool IsOpen { get; private set; } = false;

        public void OpenStore()
        {
            IsOpen = true;
        }

        public void CloseStore()
        {
            IsOpen = false;
        }
        #endregion

        private List<ICommandMenu> _commandMenus = new List<ICommandMenu>()
        {
            new LookProductsStore(),
            new LookPlayerItems(),
        };

        #region WorkStore
        private int numberCommand = 0;
        public int NumberCommand 
        {
            get
            {
                return numberCommand;
            }

        }
        public void Work(bool isOpen)
        {
            IsOpen = isOpen;
            
            ViewerMenu viewerMenu = new ViewerMenu(StoreName);
            while (IsOpen)
            {
                viewerMenu.ShowMainMenu(numberCommand);

                if (int.TryParse(Console.ReadLine(), out numberCommand))
                {
                    foreach (var commandMenu in _commandMenus)
                    {
                        if (commandMenu.IdCommand == NumberCommand)
                        {
                            commandMenu.Execute(this);
                            
                            break;

                        }
                    }
                }

                
                Console.ReadKey();
                Console.Clear();
            }
        }

        #endregion

        public Store(string storename)
        {
            StoreName = storename;
        }

        #region StoreName

        public string StoreName { get; private set; } = "sdf";


        #endregion

        #region ProductsStore
        public void AddProduct(ProductStore productStore)
        {
            foreach (var product in _productsStore)
            {
                if (productStore.Name == product.Name)
                {
                    return;
                }
            }
            _productsStore.Add(productStore);
        }

        public List<ProductStore> GetListProductsStore()
        {
            return _productsStore;
        }

        /// <summary>
        /// Поиск предмета по имени в List
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ProductStore GetProduct(string name)
        {
            ProductStore productStore = _productsStore[0];
            foreach (var product in _productsStore)
            {
                if (product.Name == name)
                {
                    productStore = product;
                }
            }
            return productStore;
        }

        #endregion



    }


}
