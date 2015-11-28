using System.Threading.Tasks;
using PantherParking.Data.Models;
using PantherParking.Data.Models.ResponseModels;
using Parse;

namespace PantherParking.Data.DAL.Interfaces
{
    public interface IRegistrationRepository
    {
        bool CheckDuplicateRegistration(string email, string username);
        RegistrationResponse Register(User user);
    }
}