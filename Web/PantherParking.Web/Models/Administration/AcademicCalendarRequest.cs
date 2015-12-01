using System;

namespace PantherParking.Web.Models.Administration
{
    public class AcademicCalendarRequest
    {
        public DateTime begin { get; set; }
        public DateTime end { get; set; }
        public string username { get; set; }
        public string sessionToken { get; set; }
    }
}