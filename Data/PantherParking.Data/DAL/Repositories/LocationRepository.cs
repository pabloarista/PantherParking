using PantherParking.Data.DAL.Interfaces;

namespace PantherParking.Data.DAL.Repositories
{
    public class LocationRepository : BaseRepository, ILocationRepository
    {
        public bool CheckIn(string username, int lot)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckOut(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}