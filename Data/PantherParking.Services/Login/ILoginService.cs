using PantherParking.Data.Models;
using PantherParking.Data.Models.ResponseModels;

namespace PantherParking.Services.Login
{
    public interface ILoginService
    {
        LoginResponse Login(User userData);
        LoginResponse Logout(User userData);
        bool ValidateSession(string token);
    }
}