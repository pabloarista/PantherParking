using System;

namespace PantherParking.Data.Models.ResponseModels
{
    public class HistoricalDataResponse
    {
        public string ResponseMessage { get; set; }
		//The ResponseData type may be different check implementation
        public int[] ResponseData { get; set; }
        
        //These values will only get populated when calling the get color and get available spaces
        public string Color { get; set; }
        public int AvailableSpaces { get; set;}
    }
}