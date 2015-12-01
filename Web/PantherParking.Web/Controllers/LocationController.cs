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
using PantherParking.Web.Models.Location;

namespace PantherParking.Web.Controllers
{
    public class LocationController : BaseController
    {
        public ILocationService LocationService { get; set; }

        //This is the checkin End Point 
        [Route("api/Location/checkIn")]
        public HttpResponseMessage PostCheckIn(CheckinRequest request)
        {
            //request.sessionToken = Request.Headers["sessionToken"];
            try
            {
                if (request == null || !base.LoginService.ValidateSession(request.sessionToken, request.username))
                {
                    return base.CreateErrorEmptyResponse();
                }//if

                User u = new User
                {
                    username = request.username,
                    garageID = request.garageId,
                    sessionToken = request.sessionToken,
                };
                LocationResponse response = this.LocationService.CheckIn(u);
                return this.Request.CreateResponse(response?.HttpStatusCode ?? HttpStatusCode.InternalServerError, response);
            }//try
            catch (Exception)
            {
                return base.CreateUnknownErrorResponse();
            }
        }
        
        //This is the checkin End Point 
        [Route("api/Location/checkOut")]
        public HttpResponseMessage PostCheckOut(CheckoutRequest request)
        {
            try
            {
                if (request == null || !base.LoginService.ValidateSession(request.sessionToken, request.username))
                {
                    return base.CreateErrorEmptyResponse();
                }//if

                User u = new User
                {
                    username = request.username,
                    sessionToken = request.sessionToken,
                };

                LocationResponse response = this.LocationService.CheckOut(u);
                return this.Request.CreateResponse(HttpStatusCode.OK, response);
            }//try
            catch (Exception)
            {
                return CreateUnknownErrorResponse();
            }//catch
        }
    }
}