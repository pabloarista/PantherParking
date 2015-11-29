using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PantherParking.Services.Registration;
using PantherParking.Data.Models;
using PantherParking.Data.Models.ResponseModels;

namespace PantherParking.Web.Controllers
{
    public class RegistrationController : BaseController
    {
        public IRegistrationService RegistrationService { get; set; }

        //This is the registration End Point 
        [Route("api/Registration/register")]
        public HttpResponseMessage PostRegister(User userData)
        {
            if (userData == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "User data was not populated. Unable to register user.");
            }//if

            if (userData.password != userData.passwordConfirm)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Passwords do not much. Unable to register user.");
            }


            RegistrationResponse  response = this.RegistrationService.Register(userData);
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }
        
    }
}
