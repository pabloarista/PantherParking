using System;

namespace PantherParking.Data.Models
{
    public class CheckIn : BaseModel
    {
        public string username { get; set; }
        public string garageId { get; set; }
        public string sessionToken { get; set; }
    }
}