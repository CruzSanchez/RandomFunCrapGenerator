using RandomFunCrapGeneratorLibrary.Models;

namespace RandomFunCrapGeneratorLibrary
{
    public static class ActivityFactory
    {
        public static Activity CreateNewActivity(Type t)
        {
            if (t == typeof(Restaurant))
            {
                return new Restaurant();
            }
            else
            {
                return new Adventure();
            }
        }
    }
}
