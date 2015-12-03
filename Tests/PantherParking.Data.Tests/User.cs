﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherParking.Data.UnitTests
{
    class User: BaseModel
    {
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
        public DateTime tokenExpirationDateTime { get; set; }
        public string garageID { get; set; }
        public bool emailVerified { get; set; }
        public DateTime createdAt { get; set; }
    }
}