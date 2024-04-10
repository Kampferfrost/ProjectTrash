using Store.Model;

namespace Store
{
    internal class Customer
    {
        public Player Player { get; set; }

        public Customer(Player player) 
        {
            Player = player;
        }

        #region CustomerName
        public string Name { get; private set; }
        #endregion

        #region ItemListCustomer
        private List<ProductStore> _productStores = new List<ProductStore>();

        public void AddProductCustomer(ProductStore productStore) 
        {
            _productStores.Add(productStore);
        }


        #endregion

    }
}
