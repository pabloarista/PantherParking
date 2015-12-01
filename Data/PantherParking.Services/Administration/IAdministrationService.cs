using System;

namespace PantherParking.Services.Administration
{
    public interface IAdministrationService
    {

        bool SetAcademicCalendar(DateTime begin, DateTime end, string username, string sessionToken);
        bool SetHoliday(DateTime holiday, string username, string sessionToken);
    }
}