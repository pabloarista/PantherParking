using System;
using PantherParking.Data.DAL.Interfaces;

namespace PantherParking.Data.DAL.Repositories
{
    public class AdministrationRepository : BaseRepository, IAdministrationRepository
    {
        public bool SetStartDate(DateTime begin)
        {
            throw new NotImplementedException();
        }

        public bool SetEndDate(DateTime end)
        {
            throw new NotImplementedException();
        }

        public bool SetHoliday(DateTime holiday)
        {
            throw new NotImplementedException();
        }
    }
}