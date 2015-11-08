using System;

namespace PantherParking.Data.Models
{
    public class User
    {
        //public long ID { get; set; }
        public string Username { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string Email { get; set; }
        public bool AdminUser { get; set; }
        public bool Locked { get; set; }
        public DateTime LastLoginDateTime { get; set; }
        public DateTime LastFailedLoginDateTime { get; set; }
        public int NumberOfFailedLogins { get; set; }
        public string Token { get; set; }

    }
}