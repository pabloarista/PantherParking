using System;

namespace PantherParking.Services.Administration
{
    public interface IAdministrationService
    {

        bool SetStartDate(DateTime begin);
        bool SetEndDate(DateTime end);
        bool SetHoliday(DateTime holiday);
    }
}