namespace PantherParking.Services.Registration
{
    public interface IRegistrationService
    {
        RegistrationResponse Register(User userData);
    }
}