using PantherParking.Data.DAL.Interfaces;
using PantherParking.Data.Models.ResponseModels;

namespace PantherParking.Data.DAL.Repositories
{
    public class HistoricalDataRepository : BaseRepository, IHistoricalDataRepository
    {
        public HistoricalDataResponse GetLastFiveWeeks()
        {
            throw new System.NotImplementedException();
        }

        public HistoricalDataResponse GetWeeklyHistory(int weekID)
        {
            throw new System.NotImplementedException();
        }

        public HistoricalDataResponse GetColor(int lot)
        {
            throw new System.NotImplementedException();
        }

        public HistoricalDataResponse GetSpacesAvailable(int lot)
        {
            throw new System.NotImplementedException();
        }
    }
}