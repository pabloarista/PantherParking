using System;
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
            try
            {
                ResponseParse<User> r = base.GetObject<User>(data.Token, new Dictionary<string, string>(1) { { "userName", data.Username } });

                if (r == null
                    || r.HttpStatusCode != HttpStatusCode.OK
                    || r.ResponseBody == null
                    || !string.IsNullOrWhiteSpace(r.ResponseBody.garageID))
                {
                    return new LocationResponse
                    {
                        ResponseValue = false,
                        ResponseMessage =
                            r == null
                            ? "User was not found! Unable to check in."
                            : "User is already checked in! Unable to check in until the user checks out of the previous parking garage!"
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
            }//try
            catch (Exception ex)
            {
                ex.Data["Checkin Data"] = data.ToXml() + "";
                return new LocationResponse
                {
                    ResponseMessage = ex.GetBaseException().Message,
                    ResponseValue = false
                };
            }//catch
        }

        public LocationResponse CheckOut(CheckIn data)
        {
            try
            {
                ResponseParse<User> r = base.GetObject<User>(data.Token, new Dictionary<string, string>(1) { { "userName", data.Username } });

                if (r == null
                    || r.HttpStatusCode != HttpStatusCode.OK
                    || r.ResponseBody == null
                    || !string.IsNullOrWhiteSpace(r.ResponseBody.garageID))
                {
                    return new LocationResponse
                    {
                        ResponseValue = false,
                        ResponseMessage =
                            r == null
                            ? "User was not found! Unable to check out."
                            : "User is not checked in! Unable to check out!"
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
            }//try
            catch (Exception ex)
            {
                ex.Data["Checkin Data"] = data.ToXml() + "";
                return new LocationResponse
                {
                    ResponseMessage = ex.GetBaseException().Message,
                    ResponseValue = false
                };
            }//catch

        }
    }
}