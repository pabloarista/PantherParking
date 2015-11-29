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
    public class AdministrationController : ApiController
    {
        public IAdministrationService AdministrationService { get; set; }

        //This is the login End Point 
        [Route("api/Admin/AcademicCalendar")]
        public HttpResponseMessage PostAcademicCalendar(AcademicCalendarRequest request)
        {
            bool created = this.AdministrationService.SetAcademicCalendar(request.begin, request.end);
            return this.Request.CreateResponse(created ? HttpStatusCode.OK : HttpStatusCode.InternalServerError, created);
        }

        //This is the login End Point 
        [Route("api/Admin/Holiday")]
        public HttpResponseMessage PostHoliday(HolidayRequest request)
        {
            bool created = this.AdministrationService.SetHoliday(request.holiday);
            return this.Request.CreateResponse(created ? HttpStatusCode.OK : HttpStatusCode.InternalServerError, created);
        }
    }

    
}