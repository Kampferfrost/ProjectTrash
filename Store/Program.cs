using Store.Model;
namespace Store
{
    internal class Program
    {
        /*
          *Существует продавец, он имеет у себя список товаров и при нужде может вам его показать,
          *также продавец может продать вам товар. После продажи товар переходит к вам, и вы можете также посмотреть свои вещи.
        */

        static void Main(string[] args)
        {
            List<ProductStore> productsStore = new List<ProductStore>()
            {
                new ProductStore(){ Name = "Колбаса", Description = "Съедобная" },
                new ProductStore(){ Name = "Хлеб", Description = "Свежий" },
                new ProductStore(){ Name = "Перчатки", Description = "Рабочие" },
                new ProductStore(){ Name = "Кефир", Description = "А где батон?" },
                new ProductStore(){ Name = "Батон", Description = "К нему нужно что-то еще?" },
            };

            Store store1 = new Store("Шестерочка");
            
            foreach (var productStore in productsStore)
            {
                store1.AddProduct(productStore);
            }

            Console.WriteLine(store1.StoreName);

            foreach (var productStore in store1.GetListProductsStore())
            {
                Console.WriteLine(productStore.Name);
            }


            Customer customer = new Customer(new Player() {Name = "Hikita", Gold = 2500 });

            Console.WriteLine(customer.Player.Name);



            customer.Player.Name = "Tiger"; //почему принял?

            Console.WriteLine(customer.Player.Name);

        }
    }
}
