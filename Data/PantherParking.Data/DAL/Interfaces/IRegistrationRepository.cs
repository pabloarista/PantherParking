namespace PantherParking.Data.DAL.Interfaces
{
    public interface IRegistrationRepository
    {
        bool CheckDuplicateRegistration(string email, string username);
        bool Register(string email, string username, string password, string passwordConfirm);
    }
}