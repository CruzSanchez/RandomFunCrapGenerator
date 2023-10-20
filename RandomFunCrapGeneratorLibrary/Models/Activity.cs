using System.Text.Json.Serialization;

namespace RandomFunCrapGeneratorLibrary.Models
{
    public abstract class Activity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeOnly OptimalTime { get; set; }
        public int StarRating { get; set; }
        [JsonIgnore]
        public ValidationTicket ValidationTicket { get; set; }

    }
}