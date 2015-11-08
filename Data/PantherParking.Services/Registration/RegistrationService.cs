using PantherParking.Data.DAL.Interfaces;

namespace PantherParking.Services.Registration
{
    public class RegistrationService : IRegistrationService
    {
        private IRegistrationRepository registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            this.registrationRepository = registrationRepository;
        }
        public bool CheckDuplicateRegistration(string email, string username)
        {
            return this.registrationRepository.CheckDuplicateRegistration(email, username);
        }

        public bool Register(string email, string username, string password, string passwordConfirm)
        {
            return this.registrationRepository.Register(email, username, password, passwordConfirm);
        }
    }
}