using System;
using System.Threading.Tasks;

namespace PantherParking.Data.DAL.Interfaces
{
    public interface IAdministrationRepository
    {
        bool SetAcademicCalendar(DateTime begin, DateTime end);
        bool SetHoliday(DateTime holiday);
    }
}