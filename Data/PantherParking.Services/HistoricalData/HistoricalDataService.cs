using PantherParking.Data.DAL.Interfaces;

namespace PantherParking.Services.HistoricalData
{
    public class HistoricalDataService : IHistoricalDataService
    {
        private readonly IHistoricalDataRepository historicalDataRepository;

        public HistoricalDataService(IHistoricalDataRepository historicalDataRepository)
        {
            this.historicalDataRepository = historicalDataRepository;
        }

        public HistoricalDataResponse[] GetLastFiveWeeks()
        {
            return this.historicalDataRepository.GetLastFiveWeeks();
        }

        public HistoricalDataResponse[] GetWeeklyHistory(int weekID)
        {
            return this.historicalDataRepository.GetWeeklyHistory(weekID);
        }

        public HistoricalDataResponse GetColor(int lot)
        {
            return this.GetColor(lot);
        }

        public HistoricalDataResponse GetSpacesAvailable(int lot)
        {
            return this.historicalDataRepository.GetSpacesAvailable(lot);
        }
    }
}