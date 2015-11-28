namespace PantherParking.Data.DAL.Interfaces
{
    public interface IHistoricalDataRepository
    {
        HistoricalDataResponse GetLastFiveWeeks();
        HistoricalDataResponse GetWeeklyHistory(int weekID);
        HistoricalDataResponse GetColor(int lot);
        HistoricalDataResponse GetSpacesAvailable(int lot);
    }
}