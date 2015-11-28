using PantherParking.Data.DAL.Interfaces;
using PantherParking.Data.Models;

namespace PantherParking.Data.DAL.Repositories
{
    public class LoginRepository : BaseRepository, ILoginRepository
    {
        public LoginResponse Login(User userData)
        {
#warning login and return User model
            return null;
        }

        public LoginResponse Logout(User userData)
        {
#warning logout user from data store
            return false;
        }

        public bool ValidateSession(string token)
        {
#warning ensure token corresponds to this user
            return false;
        }
    }
}