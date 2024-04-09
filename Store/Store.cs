using Store.Model;

namespace Store
{
    internal class Store
    {
        private List<Model.ProductStore> _products = new List<Model.ProductStore>();


       
        public Store(string storename) 
        {
            StoreName = storename;
        }



        #region StoreName

        public string StoreName { get; private set; }

        public string GetStoreName()
        {
            return StoreName;
        }

        #endregion

        #region ProductsStore
        public void AddProduct(ProductStore productStore)
        {
            foreach(var product in _products)
            {
                if (productStore.Name == product.Name)
                {
                    return;
                }
            }
            _products.Add(productStore);
        }

        public List<ProductStore> GetListProductsStore() 
        {
            List<ProductStore> productStore = new List<ProductStore>();
            foreach( var product in _products)
            {
                productStore.Add(product);
            }
            return productStore;

        }


        #endregion



    }


}
