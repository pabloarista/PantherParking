using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PantherParking.Services.Login;
using PantherParking.Data.Models;
using PantherParking.Data.Models.ResponseModels;
using PantherParking.Services.HistoricalData;

namespace PantherParking.Web.Controllers
{
    public class HistoricalDataController : BaseController
    {
        public IHistoricalDataService HistoricalDataService { get; set; }

        //This is the historicaldata End Point 
        [Route("api/HistoricalData/getLastFiveWeeks")]
        public HttpResponseMessage GetLastFiveWeeks()
        {
            HistoricalDataResponse response = this.HistoricalDataService.GetLastFiveWeeks();
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }
        
        //This is the historicaldata End Point 
        [Route("api/HistoricalData/getWeeklyHistory")]
        public HttpResponseMessage GetWeeklyHistory([FromBody] int weekId)
        {
            HistoricalDataResponse response = this.HistoricalDataService.GetWeeklyHistory(weekId);
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }
        
        //This is the historicaldata End Point 
        [Route("api/HistoricalData/getColor")]
        public HttpResponseMessage GetColor([FromBody] int lotId)
        {
            HistoricalDataResponse response = this.HistoricalDataService.GetColor(lotId);
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }
        
        //This is the historicaldata End Point 
        [Route("api/HistoricalData/getSpacesAvailable")]
        public HttpResponseMessage GetSpacesAvailable([FromBody] int lotId)
        {
            HistoricalDataResponse response = this.HistoricalDataService.GetSpacesAvailable(lotId);
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }
        
    }
}
