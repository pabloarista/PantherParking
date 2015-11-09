namespace PantherParking.Services.Location
{
    public interface ILocationService
    {
        bool CheckIn(string username, int lot);
        bool CheckOut(string username);
    }
}