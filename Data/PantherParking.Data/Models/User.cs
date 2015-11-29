using System;
using Newtonsoft.Json;

namespace PantherParking.Data.Models
{
    public class User : BaseModel
    {
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        [JsonIgnore]
        public string passwordConfirm { get; set; }
        public bool adminUser { get; set; }
        public bool locked { get; set; }
        public DateTime lastLoginDateTime { get; set; }
        public DateTime lastFailedLoginDateTime { get; set; }
        public int numberOfFailedLogins { get; set; }
        public string sessionToken { get; set; }
        public DateTime tokenExpirationDateTime { get; set; }
        public string garageID { get; set; }
        public bool emailVerified { get; set; }
        public DateTime createdAt { get; set; }

        public bool ShouldSerializeemailVerified()
        {
            return false;
        }
        public bool ShouldSerializecreatedAt()
        {
            return false;
        }
    }
}