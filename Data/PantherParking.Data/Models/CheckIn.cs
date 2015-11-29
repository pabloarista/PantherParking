using System;

namespace PantherParking.Data.Models
{
    public class CheckIn : BaseModel
    {
        public string Username { get; set; }
        public string GarageId { get; set; }
        public string Token { get; set; }
    }
}