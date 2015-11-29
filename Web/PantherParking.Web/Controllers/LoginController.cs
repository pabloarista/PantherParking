using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PantherParking.Services.Login;
using PantherParking.Data.Models;
using PantherParking.Data.Models.ResponseModels;
using PantherParking.Web.Models.Login;

namespace PantherParking.Web.Controllers
{
    public class LoginController : BaseController
    {
        public ILoginService LoginService { get; set; }

        //This is the login End Point 
        [Route("api/LogIn/login")]
        public HttpResponseMessage PostLogin(LoginRequest request)
        {
            if (request == null)
            {
                return base.CreateErrorEmptyResponse();
            }//if

            User u = new User
            {
                username = request.username,
                password = request.password
            };
            LoginResponse response = this.LoginService.Login(u);
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }

        //This is the logout End Point 
        [Route("api/LogIn/logout")]
        public HttpResponseMessage PostLogout(LogoutRequest request)
        {
            if (request == null)
            {
                return base.CreateErrorEmptyResponse();
            }//if

            User u = new User
            {
                username = request.username,
                sessionToken = request.sessionToken
            };
            LoginResponse response = this.LoginService.Logout(u);
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}