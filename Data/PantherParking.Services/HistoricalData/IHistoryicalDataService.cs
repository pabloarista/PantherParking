namespace PantherParking.Services.HistoricalData
{
    public interface IHistoryicalDataService
    {
        HistoricalDataResponse GetLastFiveWeeks();
        HistoricalDataResponse GetWeeklyHistory(int weekID);
        HistoricalDataResponse GetColor(int lot);
        HistoricalDataResponse GetSpacesAvailable(int lot);
    }
}