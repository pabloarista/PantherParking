namespace PantherParking.Services.Location
{
    public interface ILocationService
    {
        bool CheckIn(string username, string garageID, string token);
        bool CheckOut(string username, string token);
    }
}