using PantherParking.Data.Models;
using PantherParking.Data.Models.ResponseModels;

namespace PantherParking.Services.Registration
{
    public interface IRegistrationService
    {
        RegistrationResponse Register(User userData);
    }
}