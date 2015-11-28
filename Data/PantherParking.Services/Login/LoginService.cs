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


        public LoginResponse Login(User userData)
        {
            return this.loginRepository.Login(username, password);
        }

        public LoginResponse Logout(User userData)
        {
            return this.loginRepository.Logout(username);
        }

        public bool ValidateSession(string token)
        {
            return this.loginRepository.ValidateSession(token);
        }
    }
}