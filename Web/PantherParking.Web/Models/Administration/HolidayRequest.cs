using System;

namespace PantherParking.Web.Models.Administration
{
    public class HolidayRequest
    {
        public DateTime holiday { get; set; }
        public string username { get; set; }
        public string sessionToken { get; set; }
    }
}