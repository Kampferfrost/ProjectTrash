using PassengerTrain.Models;
using PassengerTrain.Mosels;

namespace PassengerTrain
{
    internal class Handler
    {
        

        #region City

        private List<City> _cities = new List<City>();

        public void AddCity(City city)
        {
            foreach (City cityItem in _cities)
            {
                if(cityItem.Name == city.Name)
                {
                    return;
                }
            }

            _cities.Add(city);
        }

        #endregion Ciry

        #region TrainDirections

        private List<TrainDirections> _trainDirections = new List<TrainDirections>();
        public void AddTrainDirections()
        {

        }

        #endregion TrainDirections
    }
}
