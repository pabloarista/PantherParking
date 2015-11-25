using System;
using System.Threading.Tasks;

namespace PantherParking.Data.DAL.Interfaces
{
    public interface IAdministrationRepository
    {
        Task<bool> SetAcademicCalendar(DateTime begin, DateTime end);
        Task<bool> SetHoliday(DateTime holiday);
    }
}