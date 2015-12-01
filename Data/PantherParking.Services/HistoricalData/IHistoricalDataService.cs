using PantherParking.Data.Models;
using PantherParking.Data.Models.ResponseModels;

namespace PantherParking.Services.HistoricalData
{
    public interface IHistoricalDataService
    {
        HistoricalDataResponse GetWeeklyHistory(System.DateTime beginWeek, string garageID, string username,
            string token);
        Garage[] GetSpacesAvailable(string sessionToken);
    }
}