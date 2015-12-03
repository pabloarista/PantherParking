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
        public static void Main2()
        {
            //BaseRepository br = new BaseRepository();
            //dynamic response = br.RetrieveRestApiResponse<object>(BaseRepository.ParseUrlPrefix + "classes/JsonTest", HttpMethod.Post,
            //    new {foo = "bar"}, null, false);

            LoginRepository br = new LoginRepository();

            User u = new User
            {
                username = "test@me.com",
                adminUser = false,
                email = "test@me.com",
                garageID = "",
                password = "test",
                updateModel = false
            };

            var r = br.Login(u);


        }

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

                User u = response?.ResponseBody;

#warning TODO:need to find out the response when login fails.
                LoginResponse lr = new LoginResponse
                {
                    User = response?.ResponseBody,
                    ResponseMessage = response?.ResponseBody == null
                        ? "Login failed"
                        : "",
                    ResponseValue = response?.ResponseBody != null,
                    HttpStatusCode = response?.HttpStatusCode ?? HttpStatusCode.InternalServerError,
                };
                return lr;
            } //try
            catch (Exception ex)
            {
                ex.Data["User Login Data"] = userData.ToXml() + "";
                return new LoginResponse
                {
                    ResponseMessage = ex.GetBaseException().Message,
                    ResponseValue = false,
                    User = null,
                    HttpStatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        public LoginResponse Logout(User userData)
        {

            ResponseDatastore<ObjectGetAllResponse<User>> r = base.GetObject<ObjectGetAllResponse<User>,User>(null,
                new Dictionary<string, string>(1) {{"username", userData.username}});
            if (r != null && r.HttpStatusCode == HttpStatusCode.OK && r.ResponseBody?.results?.Length > 0)
            {
                User u = r.ResponseBody?.results?[0];
                u.sessionToken = null;
#warning TODO: can we make the expiration field nullable? or will parse not like a nullable date field?

#warning will we be able to null out a token without a token?

                 ResponseDatastore<User> rr = base.PostResponse<User>(null, userData.sessionToken, DatastoreType.Login);

                ResponseDatastore<ObjectUpdatedResponse> updateResponse = base.UpdateObject(u, null);

                LoginResponse lr = new LoginResponse
                {
                    ResponseValue = updateResponse?.ResponseBody != null,
                    ResponseMessage = updateResponse?.ResponseBody == null
                        ? "Error logging out"
                        : "",
                    HttpStatusCode = updateResponse?.HttpStatusCode ?? HttpStatusCode.InternalServerError
                };
                return lr;
            } //if
            return new LoginResponse
            {
                ResponseMessage = "User does not exist",
                ResponseValue = false,
                HttpStatusCode = HttpStatusCode.BadRequest
            };
        }

        public bool ValidateSession(string sessionToken, string username)
        {
            return true;
#warning ensure token corresponds to this user
            /** ideas to note:
            Normally there is some sort of unique identifier for a website app calling directly the web pages (when not useing REST), we have to come up with some alternatives
            -Supposedly there's some sort of client id per request for REST. Not sure if Danny knows about this.
            -Another idea is to have a 2nd session token per request that expires after x minutes and that also is valid only once
            -Another idea would be to have the User information in the header (username) and this get's hashed and we get this value to confirm (or will a TSL encrypted header not be possible to extract when capturing packets? Not sure if we even have time to do a proper test that the headers are not encrypted by key/value pair, but this is another alternate scenario
            */
            ResponseDatastore<ObjectGetAllResponse<User>> r = base.GetObject<ObjectGetAllResponse<User>,User>(null,
                new Dictionary<string, string>(1) {{"username", username}});
            User u = r?.ResponseBody?.results?[0];
            return u?.sessionToken == sessionToken;
        }
    }
}