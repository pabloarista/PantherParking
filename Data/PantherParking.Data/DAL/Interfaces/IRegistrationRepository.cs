using PantherParking.Data.Models;
using PantherParking.Data.Models.ResponseModels;

namespace PantherParking.Data.DAL.Interfaces
{
    public interface IRegistrationRepository
    {
        RegistrationResponse Register(User userData);
    }
}