using System;

namespace PantherParking.Data.Models.ResponseModels
{
    public class LoginResponse : BaseResponse
    {
        public bool ResponseValue { get; set; }
        public string ResponseMessage { get; set; }
        public User User { get; set; }
        public Garage[] Garages { get; set; }
    }
}