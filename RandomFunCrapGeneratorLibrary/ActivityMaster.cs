using RandomFunCrapGeneratorLibrary.DataAccess;
using RandomFunCrapGeneratorLibrary.Models;
using static RandomFunCrapGeneratorLibrary.ActivityValidator;

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

        public void AddNew(Restaurant restaurant, Action<string> validationAlert)
        {
            if (restaurant == null)
                throw new ArgumentNullException("Argument was null, cannot add Restaurant");

            validationAlert("Validating your activity");
            Validate(restaurant);

            if (!restaurant.ValidationTicket.PassedValidationCheck)
                validationAlert($"Could not validate your activity for the following reason: {restaurant.ValidationTicket.DenialReason}");

            validationAlert("Your activity is valid! Adding to the list");
            Restaurants.Add(restaurant);
        }

        public void AddNew(Adventure adventure, Action<string> validationAlert)
        {
            if (adventure == null)
                throw new ArgumentNullException("Argument was null, cannot add Adventure");

            validationAlert("Validating your activity");
            Validate(adventure);

            if (!adventure.ValidationTicket.PassedValidationCheck)
                validationAlert($"Could not validate your activity for the following reason: {adventure.ValidationTicket.DenialReason}");

            validationAlert("Your activity is valid! Adding to the list");
            Adventures.Add(adventure);
        }

        public Activity GenerateRandomRestaurant()
        {
            if (Restaurants.Count < 1)
            {
                Activity a = ActivityFactory.CreateNewActivity(typeof(Restaurant));
                a.Name = "Generic Activity";
                a.Description = "List was empty, this is a placeholder";

                return a;
            }

            return Restaurants[_rng.Next(Restaurants.Count)];
        }

        public Activity GenerateRandomAdventure()
        {
            if (Adventures.Count < 1)
            {
                Activity a = ActivityFactory.CreateNewActivity(typeof(Restaurant));
                a.Name = "Generic Activity";
                a.Description = "List was empty, this is a placeholder";

                return a;
            }

            return Adventures[_rng.Next(Adventures.Count)];
        }

        public string GetActivityInfo(Activity a)
        {
            return a.ToJson();
        }

        public void SaveListsToFile()
        {
            _dataAccess.SaveData(Restaurants, RESTAURANT_FILEPATH);
            _dataAccess.SaveData(Adventures, ADVENTURE_FILEPATH);
        }
    }
}
