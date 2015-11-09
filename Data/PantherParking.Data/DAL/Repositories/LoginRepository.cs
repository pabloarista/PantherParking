using PantherParking.Data.DAL.Interfaces;
using PantherParking.Data.Models;

namespace PantherParking.Data.DAL.Repositories
{
    public class LoginRepository : BaseRepository, ILoginRepository
    {
        public User Login(string username, string password)
        {
#warning login and return User model
            return null;
        }

        public bool Logout(string username)
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