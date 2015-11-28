using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PantherParking.Services.Login;
using PantherParking.Data.Models;
using PantherParking.Data.Models.ResponseModels;

namespace PantherParking.Web.Controllers
{
    public class LoginController : ApiController
    {
        public ILoginService LoginService { get; set; }

        //This is the login End Point 
        [Route("api/LogIn/login")]
        public HttpResponseMessage PostLogin([FromBody] User userData)
        {
            LoginResponse response = this.LoginService.Login(userData);
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }

        //This is the logout End Point 
        [Route("api/LogIn/logout")]
        public HttpResponseMessage PostLogout([FromBody] User userData)
        {
            LoginResponse response = this.LoginService.Logout(userData);
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
