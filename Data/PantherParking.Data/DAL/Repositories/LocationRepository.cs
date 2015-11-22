using PantherParking.Data.DAL.Interfaces;

namespace PantherParking.Data.DAL.Repositories
{
    public class LocationRepository : BaseRepository, ILocationRepository
    {
        public LocationResponse CheckIn(CheckIn data)
        {
            //Pablo this was here before, I dodnt want to delete it in case you actually put it on purpose
            throw new System.NotImplementedException();
        }

        public LocationResponse CheckOut(CheckIn data)
        {
            //Pablo this was here before, I dodnt want to delete it in case you actually put it on purpose
            throw new System.NotImplementedException();
        }
    }
}