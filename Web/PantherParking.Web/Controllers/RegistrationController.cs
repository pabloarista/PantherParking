using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PantherParking.Services.Registration;
using PantherParking.Data.Models;

namespace PantherParking.Web.Controllers
{
    public class RegistrationController : ApiController
    {
        public IRegistrationService RegistrationService { get; set; }

        //This is the registration End Point 
        [Route("api/Registration/register")]
        public HttpResponseMessage PostRegister(User userData)
        {
            RegistrationResponse  response = this.RegistrationService.Register(userData);
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }
        
    }
}
