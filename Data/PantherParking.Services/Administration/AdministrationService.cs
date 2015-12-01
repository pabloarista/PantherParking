using System;
using System.Threading.Tasks;
using PantherParking.Data.DAL.Interfaces;

namespace PantherParking.Services.Administration
{
    public class AdministrationService : IAdministrationService
    {
        private readonly IAdministrationRepository administrationRepository;

        public AdministrationService(IAdministrationRepository administrationRepository)
        {
            this.administrationRepository = administrationRepository;
        }

        public bool SetAcademicCalendar(DateTime begin, DateTime end, string username, string sessionToken)
        {
            return this.administrationRepository.SetAcademicCalendar(begin, end, username, sessionToken);
        }

        public bool SetHoliday(DateTime holiday, string username, string sessionToken)
        {
            return this.administrationRepository.SetHoliday(holiday, username, sessionToken);
        }
    }
}