using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StructureMap;
namespace PantherParking.Web.Controllers
{
    public class BaseController : ApiController
    {
        public BaseController()
        {
            ObjectFactory.BuildUp(this);
        }

        protected HttpResponseMessage CreateErrorEmptyResponse()
        {
            return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Request headers are empty, unable to complete request.");
        }
    }
}
