using Newtonsoft.Json;

namespace PantherParking.Data.Models.Parse
{
    public class ObjectCreatedResponse : BaseModel
    {
        public System.DateTime? createdAt { get; set; }
        public string error { get; set; }
        public string sessionToken { get; set; }
    }
}