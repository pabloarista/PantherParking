using System.Collections.Generic;
using System.Net;
using PantherParking.Data.DAL.Interfaces;
using PantherParking.Data.Models;
using PantherParking.Data.Models.Parse;
using PantherParking.Data.Models.ResponseModels;

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

        public bool CheckIn(string username, string garageID, string token)
        {
            ResponseParse<User> r = base.GetObject<User>(token, new Dictionary<string, string>(1) { { "userName", username } });

            if (r == null || r.HttpStatusCode != HttpStatusCode.OK || r.ResponseBody == null)
            {
                return false;
            }//if

            User u = r.ResponseBody;
            u.garageID = garageID;

            ResponseParse<ObjectUpdatedResponse> updateResponse = base.UpdateObject(u, token);

            return updateResponse?.ResponseBody != null;
        }

        public bool CheckOut(string username, string token)
        {
            ResponseParse<User> r = base.GetObject<User>(token, new Dictionary<string, string>(1) { { "userName", username } });

            if (r == null || r.HttpStatusCode != HttpStatusCode.OK || r.ResponseBody == null)
            {
                return false;
            }//if

            User u = r.ResponseBody;
            u.garageID = null;

            ResponseParse<ObjectUpdatedResponse> updateResponse = base.UpdateObject(u, token);

            return updateResponse?.ResponseBody != null;


        }
    }
}