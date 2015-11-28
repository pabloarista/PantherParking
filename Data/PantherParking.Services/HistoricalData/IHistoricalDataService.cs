using PantherParking.Data.Models.ResponseModels;

namespace PantherParking.Services.HistoricalData
{
    public interface IHistoricalDataService
    {
        HistoricalDataResponse GetLastFiveWeeks();
        HistoricalDataResponse GetWeeklyHistory(int weekID);
        HistoricalDataResponse GetColor(int lot);
        HistoricalDataResponse GetSpacesAvailable(int lot);
    }
}