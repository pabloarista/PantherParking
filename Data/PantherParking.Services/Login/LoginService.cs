using PantherParking.Data.DAL.Interfaces;
using PantherParking.Data.Models;

namespace PantherParking.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }


        public User Login(string username, string password)
        {
            return this.loginRepository.Login(username, password);
        }

        public bool Logout(string username)
        {
            return this.loginRepository.Logout(username);
        }

        public bool ValidateSession(string token)
        {
            return this.loginRepository.ValidateSession(token);
        }
    }
}