using System;

namespace PantherParking.Services.Administration
{
    public interface IAdministrationService
    {

        bool SetAcademicCalendar(DateTime begin, DateTime end);
        bool SetHoliday(DateTime holiday);
    }
}