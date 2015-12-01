using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        
        ////This is the historicaldata End Point 
        //[Route("api/HistoricalData/getWeeklyHistory")]
        //public HttpResponseMessage PostGetWeeklyHistory(User user, int weekId)
        //{
        //    if (request == null || !base.LoginService.ValidateSession(request.sessionToken, request.username))
        //    {
        //        return base.CreateErrorEmptyResponse();
        //    }//if

        //    HistoricalDataResponse response = this.HistoricalDataService.GetWeeklyHistory(weekId);
        //    return this.Request.CreateResponse(HttpStatusCode.OK, response);
        //}
        
        ////This is the historicaldata End Point 
        //[Route("api/HistoricalData/getSpacesAvailable")]
        //public HttpResponseMessage GetSpacesAvailable(int lotId)
        //{
        //    if (request == null || !base.LoginService.ValidateSession(request.sessionToken, request.username))
        //    {
        //        return base.CreateErrorEmptyResponse();
        //    }//if

        //    HistoricalDataResponse response = this.HistoricalDataService.GetSpacesAvailable(lotId);
        //    return this.Request.CreateResponse(HttpStatusCode.OK, response);
        //}
        
    }
}

namespace PantherParking.Web.Models.HistoricalData
{

}

