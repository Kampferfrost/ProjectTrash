using Store.Model;

namespace Store
{
    internal class Store
    {
        private List<ProductStore> _productsStore = new List<ProductStore>();


       
        public Store(string storename) 
        {
            StoreName = storename;
        }



        #region StoreName

        public string StoreName { get; private set; }


        #endregion

        #region ProductsStore
        public void AddProduct(ProductStore productStore)
        {
            foreach(var product in _productsStore)
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
            List<ProductStore> productStore = new List<ProductStore>();
            foreach( var product in _productsStore)
            {
                productStore.Add(product);
            }
            return productStore;
        }

        /// <summary>
        /// Поиск предмета по имени в List
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ProductStore GetProduct(string name) 
        {
            ProductStore productStore = _productsStore[0];
            foreach(var product in _productsStore)
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
