using Newtonsoft.Json;

namespace PantherParking.Data.Models
{
    public class Garage : BaseModel
    {
        public string garageId { get; set; }
        [JsonProperty("availableSpaces")]
        public int numCheckedIn { get; set; }
        [JsonProperty("totalSpaces")]
        public int numSpaces { get; set; }
    }
}