

namespace Store.View
{
    internal class ViewerMenu
    {
        public ViewerMenu(string storeName) 
        {
            StoreName = storeName;
        }
        public string StoreName { get; init; }

        public void ShowMenu()
        {
            Console.WriteLine($"Магазин {StoreName}");
            Console.WriteLine("Выбирите действие:");
            Console.WriteLine("1. Посмотреть товары магазина");
            Console.WriteLine("2. Посмотреть свои предметы в сумке");

        }
    }
}
