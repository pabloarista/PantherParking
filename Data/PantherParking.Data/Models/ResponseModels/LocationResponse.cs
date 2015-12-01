using System;

namespace PantherParking.Data.Models.ResponseModels
{
    public class LocationResponse : BaseResponse
    {
        public bool ResponseValue { get; set; }
        public string ResponseMessage { get; set; }
    }
}