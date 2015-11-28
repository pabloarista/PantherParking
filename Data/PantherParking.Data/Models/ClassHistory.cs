using Newtonsoft.Json;

namespace PantherParking.Data.Models
{
    public class ClassHistory : BaseModel
    {
        [JsonProperty("objectId")]
        public string Id { get; set; }
        public string garageId { get; set; }
        public System.DateTime Date { get; set; }
        public int countAt9 { get; set; }
        public int countAt12 { get; set; }
        public int countAt4 { get; set; }
    }
}