using System;
using System.Collections.Generic;
using System.Net;
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
            catch (Exception e)
            {
                return false;
            }
        }

        public RegistrationResponse Register(User user)
        {
            try
            {
                var response = validateUserRegistration(user);

                if (response.ResponseValue)
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
            catch (Exception e)
            {
                throw;
            }
        }

        private RegistrationResponse validateUserRegistration(User user)
        {

            throw new NotImplementedException();
            //try
            //{
            //    RegistrationResponse response = new RegistrationResponse();
            //    bool isNewUser = CheckDuplicateRegistration(user.email);
            //    bool passwordIsMatched = user.Password.Equals(user.tempPassword);
            //    user.tempPassword = null;
            //    if (isNewUser == passwordIsMatched)
            //    {
            //        response.ResponseValue = true;
            //        response.ResponseMessage = "SUCESS: User has been validated";
            //    }
            //    else
            //    {
            //        response.ResponseValue = true;
            //        if (!isNewUser)
            //            response.ResponseMessage = "ERROR: User has been taken";
            //        else
            //            response.ResponseMessage = "ERROR: Passwords don't match";
            //    }

            //    return response;
            //}
            //catch (Exception e)
            //{
            //    throw;
            //}
        }
    }
}