using PantherParking.Data.DAL.Interfaces;
using PantherParking.Data.Models;
using PantherParking.Data.Models.ResponseModels;

namespace PantherParking.Services.HistoricalData
{
    public class HistoricalDataService : IHistoricalDataService
    {
        private readonly IHistoricalDataRepository historicalDataRepository;

        public HistoricalDataService(IHistoricalDataRepository historicalDataRepository)
        {
            this.historicalDataRepository = historicalDataRepository;
        }
        
        public HistoricalDataResponse GetWeeklyHistory(System.DateTime beginWeek, string garageID, string username, string token)
        {
            return this.historicalDataRepository.GetWeeklyHistory(beginWeek, garageID, username, token);
        }

        public Garage[] GetSpacesAvailable(string sessionToken)
        {
            return this.historicalDataRepository.GetSpacesAvailable(sessionToken);
        }
    }
}