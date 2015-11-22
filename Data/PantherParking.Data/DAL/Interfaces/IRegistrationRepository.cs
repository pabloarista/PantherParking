namespace PantherParking.Data.DAL.Interfaces
{
    public interface IRegistrationRepository
    {
        RegistrationResponse Register(User userData);
    }
}