using System;
using PantherParking.Data.Models;
using PantherParking.Data.Models.ResponseModels;

namespace PantherParking.Data.DAL.Interfaces
{
    public interface ILoginRepository
    {
        LoginResponse Login(User userData);
        LoginResponse Logout(User userData);
        bool ValidateSession(string sessionToken, string username);
    }
}