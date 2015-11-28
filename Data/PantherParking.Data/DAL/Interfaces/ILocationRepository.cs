using PantherParking.Data.Models;
using PantherParking.Data.Models.ResponseModels;

namespace PantherParking.Data.DAL.Interfaces
{
    public interface ILocationRepository
    {
        LocationResponse CheckIn(CheckIn data);
        LocationResponse CheckOut(CheckIn data);
    }
}