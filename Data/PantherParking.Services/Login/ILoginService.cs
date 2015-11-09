using PantherParking.Data.Models;

namespace PantherParking.Services.Login
{
    public interface ILoginService
    {
        User Login(string username, string password);
        bool Logout(string username);
        bool ValidateSession(string token);
    }
}