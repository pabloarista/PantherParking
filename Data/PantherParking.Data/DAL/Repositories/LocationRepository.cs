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
        public LocationResponse CheckIn(User data)
        {
            try
            {
                //ResponseDatastore<User> rr = br.GetObject<User>("", new Dictionary<string, string>(1) { { "username", u.username } });

                ResponseDatastore<ObjectGetAllResponse<User>> r = base.GetObject<ObjectGetAllResponse<User>,User>(data.sessionToken, new Dictionary<string, string>(1) { { "username", data.username } });

                if (r == null
                    || r.HttpStatusCode != HttpStatusCode.OK
                    || r.ResponseBody == null
                    || !string.IsNullOrWhiteSpace(r.ResponseBody?.results?[0]?.garageID))
                {
                    return new LocationResponse
                    {
                        ResponseValue = false,
                        ResponseMessage =
                            r == null
                            ? "User was not found! Unable to check in."
                            : "User is already checked in! Unable to check in until the user checks out of the previous parking garage!",
                        HttpStatusCode = HttpStatusCode.BadRequest
                    };
                }//if

                User u = r.ResponseBody.results?[0];
                u.garageID = data.garageID;

                ResponseDatastore<ObjectUpdatedResponse> updateResponse = base.UpdateObject(u, data.sessionToken);

                LocationResponse lr = new LocationResponse
                {
                    ResponseValue = updateResponse?.ResponseBody != null,
                    ResponseMessage = "",
                    HttpStatusCode = updateResponse?.HttpStatusCode ?? HttpStatusCode.InternalServerError
                };
                return lr;
            }//try
            catch (Exception ex)
            {
                ex.Data["Checkin Data"] = data.ToXml() + "";
                return new LocationResponse
                {
                    ResponseMessage = ex.GetBaseException().Message,
                    ResponseValue = false,
                    HttpStatusCode = HttpStatusCode.InternalServerError
                };
            }//catch
        }

        public LocationResponse CheckOut(User data)
        {
            try
            {
                ResponseDatastore<ObjectGetAllResponse<User>> r = base.GetObject<ObjectGetAllResponse<User>,User>(data.sessionToken, new Dictionary<string, string>(1) { { "userName", data.username } });

                if (r == null
                    || r.HttpStatusCode != HttpStatusCode.OK
                    || r.ResponseBody == null
                    || !string.IsNullOrWhiteSpace(r.ResponseBody?.results?[0]?.garageID))
                {
                    return new LocationResponse
                    {
                        ResponseValue = false,
                        ResponseMessage =
                            r == null
                            ? "User was not found! Unable to check out."
                            : "User is not checked in! Unable to check out!",
                        HttpStatusCode = HttpStatusCode.InternalServerError
                    };
                }//if

                User u = r.ResponseBody?.results?[0];
                u.garageID = null;

                ResponseDatastore<ObjectUpdatedResponse> updateResponse = base.UpdateObject(u, data.sessionToken);

                LocationResponse lr = new LocationResponse
                {
                    ResponseValue = updateResponse?.ResponseBody != null,
                    ResponseMessage = "",
                    HttpStatusCode = updateResponse?.HttpStatusCode ?? HttpStatusCode.InternalServerError,
                };

                return lr;
            }//try
            catch (Exception ex)
            {
                ex.Data["Checkin Data"] = data.ToXml() + "";
                return new LocationResponse
                {
                    ResponseMessage = ex.GetBaseException().Message,
                    ResponseValue = false,
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                };
            }//catch

        }
    }
}