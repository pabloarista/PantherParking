using System;

namespace PantherParking.Data.Models.ResponseModels
{
    public class HistoricalDataResponse : BaseResponse
    {
        public string ResponseMessage { get; set; }
		//The ResponseData type may be different check implementation
        public History[] ResponseData { get; set; }
        
    }
}