using System;
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

        public bool SetStartDate(DateTime begin)
        {
            return this.administrationRepository.SetStartDate(begin);
        }

        public bool SetEndDate(DateTime end)
        {
            return this.administrationRepository.SetEndDate(end);
        }

        public bool SetHoliday(DateTime holiday)
        {
            return this.administrationRepository.SetHoliday(holiday);
        }
    }
}