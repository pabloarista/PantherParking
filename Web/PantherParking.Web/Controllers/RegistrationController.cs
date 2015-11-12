using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PantherParking.Web.Controllers
{
    public class RegistrationController : ApiController
    {
        [Route("api/Registration/Test/")]
        public HttpResponseMessage PostTest()
        {
            return this.Request.CreateResponse(HttpStatusCode.OK, "Test");
        }
    }
}
