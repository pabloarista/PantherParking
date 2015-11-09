namespace PantherParking.Services.HistoricalData
{
    public interface IHistoryicalDataService
    {
        int[] GetLastFiveWeeks();
        int[] GetWeeklyHistory(int weekID);
        string GetColor(int lot);
        int GetSpacesAvailable(int lot);
    }
}