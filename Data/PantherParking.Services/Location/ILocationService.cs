using PantherParking.Data.Models;
using PantherParking.Data.Models.ResponseModels;

namespace PantherParking.Services.Location
{
    public interface ILocationService
    {
        LocationResponse CheckIn(CheckIn data);
        LocationResponse CheckOut(CheckIn data);
    }
}