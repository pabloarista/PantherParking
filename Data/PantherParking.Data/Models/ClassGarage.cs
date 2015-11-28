using Newtonsoft.Json;

namespace PantherParking.Data.Models
{
    public class ClassGarage : BaseModel
    {
        [JsonProperty("objectId")]
        public string Id { get; set; }
        public int numCheckedIn { get; set; }
        public int numSpaces { get; set; }
    }
}