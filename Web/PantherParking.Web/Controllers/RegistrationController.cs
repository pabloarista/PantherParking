using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PantherParking.Services.Registration;
using PantherParking.Data.Models;
using PantherParking.Data.Models.ResponseModels;
using PantherParking.Services.HistoricalData;
using PantherParking.Web.Models.Registration;

namespace PantherParking.Web.Controllers
{
    public class RegistrationController : BaseController
    {
        public IRegistrationService RegistrationService { get; set; }
        public IHistoricalDataService HistoricalDataService { get; set; }

        //This is the registration End Point 
        [Route("api/Registration/register")]
        public HttpResponseMessage PostRegister(RegistrationRequest request)
        {
            try
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

                RegistrationResponse response = this.RegistrationService.Register(u);
                HttpStatusCode code = response?.HttpStatusCode ?? HttpStatusCode.InternalServerError;
                if (response != null)
                {
                    response.Garages = this.HistoricalDataService.GetSpacesAvailable(response.User?.sessionToken);
                }//if
                return this.Request.CreateResponse(code, response);
            }
            catch (Exception)
            {
                return base.CreateUnknownErrorResponse();
            }
        }
    }
}