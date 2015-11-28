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

        public bool SetAcademicCalendar(DateTime begin, DateTime end)
        {
            return this.administrationRepository.SetAcademicCalendar(begin, end);
        }

        public bool SetHoliday(DateTime holiday)
        {
            return this.administrationRepository.SetHoliday(holiday);
        }
    }
}