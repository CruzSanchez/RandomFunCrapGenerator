using System.Text.Json;
using System.Text.Json.Serialization;

namespace RandomFunCrapGeneratorLibrary.Models
{
    public abstract class Activity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public TimeOnly OptimalTime { get; set; }
        public float StarRating { get; set; }

        [JsonIgnore]
        public ValidationTicket ValidationTicket { get; set; }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

    }
}