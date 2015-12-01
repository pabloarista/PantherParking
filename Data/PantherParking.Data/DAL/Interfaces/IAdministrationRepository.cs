using System;
using System.Threading.Tasks;

namespace PantherParking.Data.DAL.Interfaces
{
    public interface IAdministrationRepository
    {
        bool SetAcademicCalendar(DateTime begin, DateTime end, string username, string sessionToken);
        bool SetHoliday(DateTime holiday, string username, string sessionToken);
    }
}