using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PantherParking.Services.Login;
using StructureMap;
namespace PantherParking.Web.Controllers
{
    public class BaseController : ApiController
    {
        public ILoginService LoginService { get; set; }
        public BaseController()
        {
            ObjectFactory.BuildUp(this);
        }

        protected HttpResponseMessage CreateErrorEmptyResponse()
        {
            return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Request is empty or incomplete, unable to complete request.");
        }
        
        protected HttpResponseMessage CreateUnknownErrorResponse()
        {
            return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Unknown error occurred.");
        }
    }
}
