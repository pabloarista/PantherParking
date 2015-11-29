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
        private bool CheckDuplicateRegistration(string email)
        {
            try
            {
                ResponseParse<User> r = base.GetObject<User>(null, new Dictionary<string, string>(1) { { "email", email } });

                return r != null && r.HttpStatusCode == HttpStatusCode.OK && r.ResponseBody != null;
            }
            catch (Exception ex)
            {
                ex.Data["Email"] = email;
                return false;
            }
        }

        public RegistrationResponse Register(User user)
        {
            try
            {
                bool validUser = this.ValidateUserRegistration(user);

                if (validUser)
                {

                    string url = $"{BaseRepository.ParseUrlPrefix}users/";

                    ResponseParse<ObjectCreatedResponse> rp = base.GetRestApiResponse<ObjectCreatedResponse>(url, HttpMethod.Post, user, user.token);

                    bool created = rp != null && rp.HttpStatusCode == HttpStatusCode.Created;

                    return new RegistrationResponse
                    {
                        ResponseValue = created,
                        ResponseMessage = created ? "" : "Error registering user."
                    };
                }//if

                return new RegistrationResponse
                {
                    ResponseValue = false,
                    ResponseMessage = "User already exists."
                };
            }
            catch (Exception ex)
            {
                ex.Data["User"] = user.ToXml() + "";
                throw;
            }
        }

        private bool ValidateUserRegistration(User user)
        {
            try
            {
                bool isNewUser = this.CheckDuplicateRegistration(user.email);

                return isNewUser;
            }//try
            catch (Exception ex)
            {
                ex.Data["User"] = user.ToXml() + "";
                return false;
            }
        }
    }
}