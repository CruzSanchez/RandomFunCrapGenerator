using RandomFunCrapGeneratorLibrary.DataAccess;
using RandomFunCrapGeneratorLibrary.Models;

namespace RandomFunCrapGeneratorLibrary
{
    public class ActivityMaster
    {
        private const string RESTAURANT_FILEPATH = "Restaurants.json";
        private const string ADVENTURE_FILEPATH = "Adventures.json";

        private readonly IDataAccess _dataAccess;
        private readonly Random _rng;

        public List<Restaurant> Restaurants { get; set; }
        public List<Adventure> Adventures { get; set; }

        public ActivityMaster(IDataAccess dataAccess, Random rng)
        {
            _dataAccess = dataAccess;
            _rng = rng;
            Restaurants = _dataAccess.LoadData<Restaurant>(RESTAURANT_FILEPATH).ToList();
            Adventures = _dataAccess.LoadData<Adventure>(ADVENTURE_FILEPATH).ToList();
        }

        public void AddNew(Restaurant restaurant)
        {
            if (restaurant == null)
                throw new ArgumentNullException("Argument was null, cannot add Restaurant");

            Restaurants.Add(restaurant);
        }

        public void AddNew(Adventure adventure)
        {
            if (adventure == null)
                throw new ArgumentNullException("Argument was null, cannot add Adventure");

            Adventures.Add(adventure);
        }

        public Activity GenerateRandomRestaurant()
        {
            if (Restaurants.Count < 1)
            {
                return new Restaurant() { Name = "Generic Activity", Description = "List was empty, this is a placeholder" };
            }

            return Restaurants[_rng.Next(Restaurants.Count)];
        }

        public Activity GenerateRandomAdventure()
        {
            if (Adventures.Count < 1)
            {
                return new Adventure() { Name = "Generic Activity", Description = "List was empty, this is a placeholder" };
            }

            return Adventures[_rng.Next(Adventures.Count)];
        }

        public string GetActivityInfo(Activity a)
        {
            return a.ToJson();
        }
    }
}
