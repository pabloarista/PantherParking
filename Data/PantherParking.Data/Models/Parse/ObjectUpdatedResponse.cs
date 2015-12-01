using Newtonsoft.Json;

namespace PantherParking.Data.Models.Parse
{
    public class ObjectUpdatedResponse : BaseModel
    {
        public System.DateTime? updatedAt { get; set; }
    }
}