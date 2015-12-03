using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;
using PantherParking.Data.DAL.Interfaces;
using PantherParking.Data.Models;
using PantherParking.Data.Models.enumerations;
using PantherParking.Data.Models.Parse;
using PantherParking.Data.Models.ResponseModels;

namespace PantherParking.Data.DAL.Repositories
{
    public class RegistrationRepository : BaseRepository, IRegistrationRepository
    {

        public RegistrationResponse Register(User user)
        {
            try
            {
                ResponseDatastore<ObjectGetAllResponse<User>> userExistsParse = this.ValidateUserRegistration(user);

                if (userExistsParse?.ResponseBody?.results?.Length < 1 || string.IsNullOrWhiteSpace(userExistsParse?.ResponseBody?.results?[0]?.username))
                {
                    user.updateModel = false;
                    ResponseDatastore<ObjectCreatedResponse> rp = base.PostResponse<ObjectCreatedResponse>(user, null, DatastoreType.Users);

                    bool created = rp != null && rp.HttpStatusCode == HttpStatusCode.Created;

                    if (created)
                    {
                        user.sessionToken = rp?.ResponseBody?.sessionToken;
                    }//if
                    
                    return new RegistrationResponse
                    {
                        ResponseValue = created,
                        ResponseMessage = created ? "" : "Error registering!",
                        User = created ? user : null,
                        HttpStatusCode = rp?.HttpStatusCode ?? HttpStatusCode.InternalServerError
                    };
                }//if

                return new RegistrationResponse
                {
                    ResponseValue = false,
                    ResponseMessage = "User already exists.",
                    HttpStatusCode = HttpStatusCode.BadRequest
                };
            }//try
            catch (Exception ex)
            {
                ex.Data["User"] = user.ToXml() + "";
                return new RegistrationResponse
                {
                    ResponseValue = false,
                    ResponseMessage = ex.GetBaseException().Message,
                    HttpStatusCode = HttpStatusCode.InternalServerError
                };
            }//catch
        }

        private ResponseDatastore<ObjectGetAllResponse<User>> ValidateUserRegistration(User user)
        {
            try
            {
                ResponseDatastore<ObjectGetAllResponse<User>> r = base.GetObject< ObjectGetAllResponse <User>, User >(null, new Dictionary<string, string>(1) { { "username", user.username } });

                return r;
            }
            catch (Exception ex)
            {
                ex.Data["User"] = user.ToXml() + "";
                return new ResponseDatastore<ObjectGetAllResponse<User>>
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    ResponseBody = null
                };
            }
        }
    }
}