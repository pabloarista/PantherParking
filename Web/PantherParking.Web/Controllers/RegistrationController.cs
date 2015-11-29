using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PantherParking.Services.Registration;
using PantherParking.Data.Models;
using PantherParking.Data.Models.ResponseModels;
using PantherParking.Web.Models.Registration;

namespace PantherParking.Web.Controllers
{
    public class RegistrationController : BaseController
    {
        public IRegistrationService RegistrationService { get; set; }

        //This is the registration End Point 
        [Route("api/Registration/register")]
        public HttpResponseMessage PostRegister(RegistrationRequest request)
        {
            if (request == null)
            {
                return base.CreateErrorEmptyResponse();
            }//if
            
            if (request.password != request.passwordConfirm)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Passwords do not much. Unable to register user.");
            }


            User u = new User
            {
                username = request.username,
                firstName = request.firstName,
                lastName = request.lastName,
                email = request.email,
                password = request.password,
            };

            RegistrationResponse  response = this.RegistrationService.Register(u);
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }  
    }
}