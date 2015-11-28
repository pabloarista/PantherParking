namespace PantherParking.Services.Location
{
    public interface ILocationService
    {
        LocationResponse CheckIn(CheckIn data);
        LocationResponse CheckOut(CheckIn data);
    }
}