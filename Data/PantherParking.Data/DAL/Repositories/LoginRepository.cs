using System;
using System.Collections.Generic;
using System.Net;
using PantherParking.Data.DAL.Interfaces;
using PantherParking.Data.Models;
using PantherParking.Data.Models.Parse;
using PantherParking.Data.Models.ResponseModels;

namespace PantherParking.Data.DAL.Repositories
{
    public class LoginRepository : BaseRepository, ILoginRepository
    {
        public LoginResponse Login(User userData)
        {
            try
            {
#warning TODO:all responses should just use the generic ResponseDataStore<Type>
                RequestLogin rl = new RequestLogin
                {
                    username = userData.username,
                    password = userData.password
                };
                ResponseDatastore<User> response = base.GetResponse<User>(rl, null, DatastoreType.Login);

#warning TODO:need to find out the response when login fails.
                LoginResponse lr = new LoginResponse
                {
                    User = response?.ResponseBody,
                    ResponseMessage = response?.ResponseBody == null ? "Login failed" : "",
                    ResponseValue = response?.ResponseBody != null
                };
                return lr;
            }//try
            catch (Exception ex)
            {
                ex.Data["User Login Data"] = userData.ToXml() + "";
                return new LoginResponse
                {
                    ResponseMessage = ex.GetBaseException().Message,
                    ResponseValue = false,
                    User = null,
                };
            }
        }

        public LoginResponse Logout(User userData)
        {

            ResponseDatastore<User> r = base.GetObject<User>(null, new Dictionary<string, string>(1) { { "username", userData.username } });
            if (r != null && r.HttpStatusCode == HttpStatusCode.OK && r.ResponseBody != null)
            {
                User u = r.ResponseBody;
                u.sessionToken = null;
#warning TODO: can we make the expiration field nullable? or will parse not like a nullable date field?

#warning will we be able to null out a token without a token?
                ResponseDatastore<ObjectUpdatedResponse> updateResponse = base.UpdateObject(u, null);

                LoginResponse lr = new LoginResponse
                {
                    ResponseValue = updateResponse?.ResponseBody != null,
                    ResponseMessage = updateResponse?.ResponseBody == null ? "Error logging out" : "" 
                };
                return lr;
            }//if
            return new LoginResponse
            {
                ResponseMessage = "User does not exist",
                ResponseValue = false
            };
        }

        public bool ValidateSession(string token)
        {
#warning ensure token corresponds to this user
            /** ideas to note:
            Normally there is some sort of unique identifier for a website app calling directly the web pages (when not useing REST), we have to come up with some alternatives
            -Supposedly there's some sort of client id per request for REST. Not sure if Danny knows about this.
            -Another idea is to have a 2nd session token per request that expires after x minutes and that also is valid only once
            -Another idea would be to have the User information in the header (username) and this get's hashed and we get this value to confirm (or will a TSL encrypted header not be possible to extract when capturing packets? Not sure if we even have time to do a proper test that the headers are not encrypted by key/value pair, but this is another alternate scenario
            */

            throw new NotImplementedException();
        }
    }
}