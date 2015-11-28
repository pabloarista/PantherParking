using System;
using Newtonsoft.Json;

namespace PantherParking.Data.Models
{
    public class User : BaseModel
    {
        [JsonProperty("objectId")]
        public string ID { get; set; }
        public string username { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string email { get; set; }
        public bool adminUser { get; set; }
        public bool locked { get; set; }
        public DateTime lastLoginDateTime { get; set; }
        public DateTime lastFailedLoginDateTime { get; set; }
        public int numberOfFailedLogins { get; set; }
        public string token { get; set; }
        public string garageID { get; set; }
    }
}