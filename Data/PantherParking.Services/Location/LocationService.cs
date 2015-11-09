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
        public bool CheckIn(string username, int lot)
        {
            return this.locationRepository.CheckIn(username, lot);
        }

        public bool CheckOut(string username)
        {
            return this.locationRepository.CheckOut(username);
        }
    }
}