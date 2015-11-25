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
            Task<bool> result = this.administrationRepository.SetAcademicCalendar(begin, end);

            return result.Result;
        }

        public bool SetHoliday(DateTime holiday)
        {
            Task<bool> result = this.administrationRepository.SetHoliday(holiday);
            return result.Result;
        }
    }
}