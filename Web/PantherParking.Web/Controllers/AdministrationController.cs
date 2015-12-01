using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PantherParking.Services.Administration;
using PantherParking.Web.Models;
using PantherParking.Web.Models.Administration;

namespace PantherParking.Web.Controllers
{
    public class AdministrationController : BaseController
    {
        public IAdministrationService AdministrationService { get; set; }

        //This is the login End Point 
        [Route("api/Admin/AcademicCalendar")]
        public HttpResponseMessage PostAcademicCalendar(AcademicCalendarRequest request)
        {
            try
            {
                if (request == null || !base.LoginService.ValidateSession(request.sessionToken, request.username))
                {
                    return base.CreateErrorEmptyResponse();
                }//if

                bool created =
                    this.AdministrationService.SetAcademicCalendar
                    (request.begin
                    , request.end
                    , request.username
                    , request.sessionToken);

                AdministrationResponse r = new AdministrationResponse
                {
                    ResponseMessage = !created ? "Error adding holliday" : "",
                    ResponseValue = created
                };
                return this.Request.CreateResponse(created ? HttpStatusCode.OK : HttpStatusCode.InternalServerError, r);
            }//try
            catch (Exception)
            {
                return base.CreateUnknownErrorResponse();
            }
        }

        //This is the login End Point 
        [Route("api/Admin/Holiday")]
        public HttpResponseMessage PostHoliday(HolidayRequest request)
        {
            try
            {
                if (request == null || !base.LoginService.ValidateSession(request.sessionToken, request.username))
                {
                    return base.CreateErrorEmptyResponse();
                }//if

                bool created = this.AdministrationService.SetHoliday(request.holiday, request.username, request.sessionToken);

                AdministrationResponse r = new AdministrationResponse
                {
                    ResponseMessage = !created ? "Error adding holliday" : "",
                    ResponseValue = created
                };

                return this.Request.CreateResponse(created ? HttpStatusCode.OK : HttpStatusCode.InternalServerError, r);
            }//try
            catch (Exception)
            {
                return base.CreateUnknownErrorResponse();
            }
        }
    }

    
}