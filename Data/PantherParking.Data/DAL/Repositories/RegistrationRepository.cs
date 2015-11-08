using PantherParking.Data.DAL.Interfaces;

namespace PantherParking.Data.DAL.Repositories
{
    public class RegistrationRepository : BaseRepository, IRegistrationRepository
    {
        public bool CheckDuplicateRegistration(string email, string username)
        {
#warning check in data store if email or username is being used
            return false;
        }

        public bool Register(string email, string username, string password, string passwordConfirm)
        {
#warning register user. ensure passwords match
            return true;
        }
    }
}