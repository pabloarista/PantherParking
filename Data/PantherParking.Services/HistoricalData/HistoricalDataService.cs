using PantherParking.Data.DAL.Interfaces;

namespace PantherParking.Services.HistoricalData
{
    public class HistoricalDataService : IHistoryicalDataService
    {
        private readonly IHistoricalDataRepository historicalDataRepository;

        public HistoricalDataService(IHistoricalDataRepository historicalDataRepository)
        {
            this.historicalDataRepository = historicalDataRepository;
        }

        public int[] GetLastFiveWeeks()
        {
            return this.historicalDataRepository.GetLastFiveWeeks();
        }

        public int[] GetWeeklyHistory(int weekID)
        {
            return this.historicalDataRepository.GetWeeklyHistory(weekID);
        }

        public string GetColor(int lot)
        {
            return this.GetColor(lot);
        }

        public int GetSpacesAvailable(int lot)
        {
            return this.historicalDataRepository.GetSpacesAvailable(lot);
        }
    }
}