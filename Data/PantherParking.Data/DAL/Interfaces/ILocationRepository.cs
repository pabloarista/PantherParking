namespace PantherParking.Data.DAL.Interfaces
{
    public interface ILocationRepository
    {
        LocationResponse CheckIn(CheckIn data);
        LocationResponse CheckOut(CheckIn data);
    }
}