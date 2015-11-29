using Newtonsoft.Json;

namespace PantherParking.Data.Models
{
    public class Garage : BaseModel
    {
        public string garageId { get; set; }
        public int numCheckedIn { get; set; }
        public int numSpaces { get; set; }
    }
}