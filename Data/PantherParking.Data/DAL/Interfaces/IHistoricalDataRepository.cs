using PantherParking.Data.Models;
using PantherParking.Data.Models.ResponseModels;

namespace PantherParking.Data.DAL.Interfaces
{
    public interface IHistoricalDataRepository
    {
        HistoricalDataResponse GetWeeklyHistory(System.DateTime beginWeek, string garageID, string username, string token);
        Garage[] GetSpacesAvailable(string sessionToken);
    }
}