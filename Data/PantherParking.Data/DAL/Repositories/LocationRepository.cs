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