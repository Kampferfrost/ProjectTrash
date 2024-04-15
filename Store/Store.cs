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
        private int mainCommand = 0;
        private bool _setMainCommand()
        {
            return int.TryParse(Console.ReadLine(), out mainCommand);
        }
        private int storeCommand = 0;

        private bool _setStoreCommand()
        {
            return int.TryParse(Console.ReadLine(), out storeCommand);
        }

        public int NumberCommand 
        {
            get
            {
                return mainCommand;
            }
        }

        public ViewerMenu viewerMenu;
        public void Work(bool isOpen)
        {
            IsOpen = isOpen;
            
            viewerMenu = new ViewerMenu(this);
            while (IsOpen)
            {
                Console.Clear();
                viewerMenu.ShowTitle();
                viewerMenu.ShowCommandMenu();

                mainCommand = 0;
                if (_setMainCommand())
                {
                    ICommandMenu commandMenu;
                    foreach (var command in _commandMenus)
                    {
                        if (command.IdCommand == NumberCommand)
                        {
                            commandMenu = command;
                            command.Execute(this);
                            while (storeCommand != 3)
                            {
                                if (_setStoreCommand())
                                {

                                }
                            }
                            storeCommand = 0;
                            break;
                        }
                    }
                    
                }

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
