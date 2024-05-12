using PassengerTrain.Models;

namespace PassengerTrain.Mosels
{
    internal class TrainDirections
    {
        public string DirectionName { get; set; }
        public City FromCity { get; set; }
        public City ToCity { get; set; }
    }
}





// У вас есть программа, которая помогает пользователю составить план поезда.
// Есть 4 основных шага в создании плана:
// -Создать направление - создает направление для поезда(к примеру Бийск - Барнаул)
