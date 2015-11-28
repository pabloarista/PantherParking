namespace PantherParking.Data.DAL.Interfaces
{
    public interface ILocationRepository
    {
        bool CheckIn(string username, string garageID, string token);
        bool CheckOut(string username, string token);
    }
}