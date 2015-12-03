using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherParking.Data.UnitTests
{
    class LocationRepository: BaseRepository, ILocationRepository
    {
        public LocationResponse CheckIn(CheckIn data)
        {
            ResponseParse<User> r = base.GetObject<User>(data.Token, new Dictionary<string, string>(1) { { "userName", data.Username } });

            if (r == null || r.HttpStatusCode != HttpStatusCode.OK || r.ResponseBody == null)
            {

                return new LocationResponse
                {
                    ResponseValue = false,
                    ResponseMessage = "User was not found! Unable to check in."
                };
            }//if

            User u = r.ResponseBody;
            u.garageID = data.GarageId;

            ResponseParse<ObjectUpdatedResponse> updateResponse = base.UpdateObject(u, data.Token);

            LocationResponse lr = new LocationResponse
            {
                ResponseValue = updateResponse?.ResponseBody != null,
                ResponseMessage = ""
            };
            return lr;
        }

        public LocationResponse CheckOut(CheckIn data)
        {
            ResponseParse<User> r = base.GetObject<User>(data.Token, new Dictionary<string, string>(1) { { "userName", data.Username } });

            if (r == null || r.HttpStatusCode != HttpStatusCode.OK || r.ResponseBody == null)
            {
                return new LocationResponse
                {
                    ResponseValue = false,
                    ResponseMessage = "User was not found! Unable to check in."
                };
            }//if

            User u = r.ResponseBody;
            u.garageID = null;

            ResponseParse<ObjectUpdatedResponse> updateResponse = base.UpdateObject(u, data.Token);

            LocationResponse lr = new LocationResponse
            {
                ResponseValue = updateResponse?.ResponseBody != null,
                ResponseMessage = "",
            };

            return lr;

        }
    }
}
