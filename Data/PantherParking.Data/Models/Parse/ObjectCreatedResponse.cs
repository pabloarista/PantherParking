using Newtonsoft.Json;

namespace PantherParking.Data.Models.Parse
{
    public class ObjectCreatedResponse
    {
        [JsonProperty("createdAt")]
        public System.DateTime CreatedAt { get; set; }
        [JsonProperty("objectId")]
        public string ObjectId { get; set; }
    }
}