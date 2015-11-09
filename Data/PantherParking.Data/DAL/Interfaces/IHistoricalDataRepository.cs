namespace PantherParking.Data.DAL.Interfaces
{
    public interface IHistoricalDataRepository
    {
        int[] GetLastFiveWeeks();
        int[] GetWeeklyHistory(int weekID);
        string GetColor(int lot);
        int GetSpacesAvailable(int lot);
    }
}