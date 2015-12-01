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
using PantherParking.Web.Models.Login;

namespace PantherParking.Web.Controllers
{
    public class LoginController : BaseController
    {
        public IHistoricalDataService HistoricalDataService { get; set; }

        //This is the login End Point 
        [Route("api/LogIn/login")]
        public HttpResponseMessage PostLogin([FromBody]LoginRequest request)
        {
            try
            {
                if (request == null || string.IsNullOrWhiteSpace(request.username) || string.IsNullOrWhiteSpace(request.password))
                {
                    return base.CreateErrorEmptyResponse();
                }//if

                User u = new User
                {
                    username = request.username,
                    password = request.password
                };
                LoginResponse response = this.LoginService.Login(u);

                HttpStatusCode code = response?.HttpStatusCode ?? HttpStatusCode.InternalServerError;

                if (response != null)
                {
                    response.Garages = this.HistoricalDataService.GetSpacesAvailable(response.User?.sessionToken);
                }//if

                HttpResponseMessage r = this.Request.CreateResponse(code, response);
                if (!string.IsNullOrWhiteSpace(response?.User?.sessionToken))
                {
                    response.User.updateModel = false;
                    r.Headers.Add("sessionToken", response.User?.sessionToken);
                }//if
                return r;
            }
            catch (Exception ex)
            {
                return base.CreateUnknownErrorResponse();
            }
        }

        //This is the logout End Point 
        [Route("api/LogIn/logout")]
        public HttpResponseMessage PostLogout(LogoutRequest request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request?.username) || string.IsNullOrWhiteSpace(request.sessionToken) || !this.LoginService.ValidateSession(request.sessionToken, request.username))
                {
                    return base.CreateErrorEmptyResponse();
                }//if

                User u = new User
                {
                    username = request.username,
                    sessionToken = request.sessionToken
                };
                LoginResponse response = this.LoginService.Logout(u);
                HttpStatusCode code = response?.HttpStatusCode ?? HttpStatusCode.InternalServerError;
                HttpResponseMessage r = this.Request.CreateResponse(code, response);
                r.Headers.Add("sessionToken", "");

                return r;
            }//try
            catch (Exception)
            {
                return CreateUnknownErrorResponse();
            }
        }
    }
}