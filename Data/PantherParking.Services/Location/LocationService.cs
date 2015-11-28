using PantherParking.Data.DAL.Interfaces;

namespace PantherParking.Services.Location
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }
        public bool CheckIn(string username, string garageID, string token)
        {
            return this.locationRepository.CheckIn(username, garageID, token);
        }

        public bool CheckOut(string username, string token)
        {
            return this.locationRepository.CheckOut(username, token);
        }
    }
}