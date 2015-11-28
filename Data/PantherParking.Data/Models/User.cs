using System;
using Newtonsoft.Json;

namespace PantherParking.Data.Models
{
    public class User : BaseModel
    {
<<<<<<< HEAD
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
=======
        //public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        
        //User Internal Info
        public bool AdminUser { get; set; }
        public bool Locked { get; set; }
        public DateTime LastLoginDateTime { get; set; }
        public DateTime LastFailedLoginDateTime { get; set; }
        public int NumberOfFailedLogins { get; set; }
        public string Token { get; set; }

>>>>>>> master
    }
}