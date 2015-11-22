using System;
using System.Threading.Tasks;

namespace PantherParking.Data.DAL.Interfaces
{
    public interface IAdministrationRepository
    {
        Task<bool> SetStartDate(DateTime begin);
        bool SetEndDate(DateTime end);
        bool SetHoliday(DateTime holiday);
    }
}