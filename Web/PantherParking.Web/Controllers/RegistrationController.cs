using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PantherParking.Services.Registration;

namespace PantherParking.Web.Controllers
{
    public class RegistrationController : ApiController
    {
        public IRegistrationService RegistrationService { get; set; }


        [Route("api/Registration/Test/")]
        public HttpResponseMessage PostRegister()
        {
            bool b = this.RegistrationService.Register("", "", "","");
            return this.Request.CreateResponse(HttpStatusCode.OK, "Test");
        }
    }
}
