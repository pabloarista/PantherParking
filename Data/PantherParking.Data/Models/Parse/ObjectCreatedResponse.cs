using Newtonsoft.Json;

namespace PantherParking.Data.Models.Parse
{
    public class ObjectCreatedResponse : BaseModel
    {
        public System.DateTime createdAt { get; set; }
        public string objectId { get; set; }
    }
}