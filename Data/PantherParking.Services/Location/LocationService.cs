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
        public LocationResponse CheckIn(CheckIn data)
        {
            return this.locationRepository.CheckIn(username, lot);
        }

        public LocationResponse CheckOut(CheckIn data)
        {
            return this.locationRepository.CheckOut(username);
        }
    }
}