using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PantherParking.Services.Login;
using PantherParking.Data.Models;
using PantherParking.Data.Models.ResponseModels;
using PantherParking.Services.Location;

namespace PantherParking.Web.Controllers
{
    public class LocationController : ApiController
    {
        public ILocationService LocationService { get; set; }

        //This is the checkin End Point 
        [Route("api/Location/checkIn")]
        public HttpResponseMessage PostCheckIn(CheckIn data)
        {
            LocationResponse response = this.LocationService.CheckIn(data);
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }
        
        //This is the checkin End Point 
        [Route("api/Location/checkOut")]
        public HttpResponseMessage PostCheckOut(CheckIn data)
        {
            LocationResponse response = this.LocationService.CheckOut(data);
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }
        
    }
}
