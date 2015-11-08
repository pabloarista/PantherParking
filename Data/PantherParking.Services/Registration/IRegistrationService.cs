namespace PantherParking.Services.Registration
{
    public interface IRegistrationService
    {
        bool CheckDuplicateRegistration(string email, string username);
        bool Register(string email, string username, string password, string passwordConfirm);
    }
}