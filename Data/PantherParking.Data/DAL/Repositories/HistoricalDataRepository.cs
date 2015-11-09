using PantherParking.Data.DAL.Interfaces;

namespace PantherParking.Data.DAL.Repositories
{
    public class HistoricalDataRepository : BaseRepository, IHistoricalDataRepository
    {
        public int[] GetLastFiveWeeks()
        {
            throw new System.NotImplementedException();
        }

        public int[] GetWeeklyHistory(int weekID)
        {
            throw new System.NotImplementedException();
        }

        public string GetColor(int lot)
        {
            throw new System.NotImplementedException();
        }

        public int GetSpacesAvailable(int lot)
        {
            throw new System.NotImplementedException();
        }
    }
}