using Store.Model;
using Store.View;
using Store.Commands;

namespace Store
{
    internal class Store
    {
        private List<ProductStore> _productsStore = new List<ProductStore>();
        private List<ItemPlayer> _ItemPlayer = new List<ItemPlayer>();

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
        public int MainCommand
        {
            get
            {
                return mainCommand;
            }
        }
        private bool _setMainCommand()
        {
            return int.TryParse(Console.ReadLine(), out mainCommand);
        }

        private int storeCommand = 0;
        public int StoreCommand
        {
            get
            {
                return storeCommand;
            }
        }

        private bool _setStoreCommand()
        {
            mainCommand = 0;
            return int.TryParse(Console.ReadLine(), out storeCommand);
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

                if (_setMainCommand())
                {
                    ICommandMenu commandMenu;
                    foreach (var command in _commandMenus)
                    {
                        if (command.IdCommand == MainCommand)
                        {
                            commandMenu = command;
                            command.Execute(this);
                            while (storeCommand != 2)
                            {
                                _setStoreCommand();
                                if (storeCommand == 1)
                                {
                                    viewerMenu.ShowTextStorePay();
                                    string? nameProduct = string.Empty;
                                    nameProduct = Console.ReadLine().ToLower();
                                    foreach (var product in _productsStore)
                                    {
                                        if (product.Name.ToLower() == nameProduct)
                                        {
                                            _ItemPlayer.Add(new ItemPlayer() { Name = product.Name });
                                            _productsStore.Remove(product);
                                            Console.WriteLine($"Вы приобрели предмет {product.Name}");
                                            storeCommand = 2;
                                            Console.ReadKey();
                                            break;
                                        }
                                    }
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
        /// <summary>
        /// Добавляет начальный список продуктов магазина
        /// </summary>
        /// <param name="productStore"></param>
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

        /// <summary>
        /// Добавляет начальный список предметов игрока
        /// </summary>
        /// <param name="itemPlayer"></param>
        public void AddItemPlayer(ItemPlayer itemPlayer)
        {
            foreach (var item in _ItemPlayer)
            {
                if (itemPlayer.Name == item.Name)
                {
                    return;
                }
            }
            _ItemPlayer.Add(itemPlayer);
        }

        public List<ProductStore> GetListProductsStore()
        {
            return _productsStore;
        }

        public List<ItemPlayer> GetListItemPlayer()
        {
            return _ItemPlayer;
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
