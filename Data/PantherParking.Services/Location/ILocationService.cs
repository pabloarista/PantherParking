using PantherParking.Data.Models;
using PantherParking.Data.Models.ResponseModels;

namespace PantherParking.Services.Location
{
    public interface ILocationService
    {
        LocationResponse CheckIn(User data);
        LocationResponse CheckOut(User data);
    }
}