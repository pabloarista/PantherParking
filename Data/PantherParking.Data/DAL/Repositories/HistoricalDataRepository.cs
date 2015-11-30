using PantherParking.Data.DAL.Interfaces;
using PantherParking.Data.Models.ResponseModels;

namespace PantherParking.Data.DAL.Repositories
{
    public class HistoricalDataRepository : BaseRepository, IHistoricalDataRepository
    {
        public HistoricalDataResponse GetLastFiveWeeks()
        {
            return default(HistoricalDataResponse);
        }

        public HistoricalDataResponse GetWeeklyHistory(int weekID)
        {
            return default(HistoricalDataResponse);
        }

        public HistoricalDataResponse GetColor(int lot)
        {
            return default(HistoricalDataResponse);
        }

        public HistoricalDataResponse GetSpacesAvailable(int lot)
        {
            return default(HistoricalDataResponse);
        }
    }
}