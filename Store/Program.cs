using Store.Model;
using Store.View;
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
            Store store1 = new Store("Шестерочка");
            bool isOpen = true;

            List<ProductStore> productsStore = new List<ProductStore>()
            {
                new ProductStore(){ Name = "Колбаса", Description = "Съедобная" },
                new ProductStore(){ Name = "Хлеб", Description = "Свежий" },
                new ProductStore(){ Name = "Перчатки", Description = "Рабочие" },
                new ProductStore(){ Name = "Кефир", Description = "А где батон?" },
                new ProductStore(){ Name = "Батон", Description = "К нему нужно что-то еще?" },
            };
            foreach (var productStore in productsStore)
            {
                store1.AddProduct(productStore);
            }

            List<ItemPlayer> itemPlayers = new List<ItemPlayer>()
            {
                new ItemPlayer() { Name = "Носки" },
                new ItemPlayer() {Name = "Мыло"},
                new ItemPlayer() {Name = "Яблоко"}
            };
            foreach (var item in itemPlayers)
            {
                store1.AddItemPlayer(item);
            }



            store1.Work(isOpen);






        }
    }
}
