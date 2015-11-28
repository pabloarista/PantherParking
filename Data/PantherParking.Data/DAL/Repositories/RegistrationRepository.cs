using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PantherParking.Data.DAL.Interfaces;
using PantherParking.Data.Models;
using PantherParking.Data.Models.ResponseModels;
using Parse;

namespace PantherParking.Data.DAL.Repositories
{
    public class RegistrationRepository : BaseRepository, IRegistrationRepository
    {
        public async Task<bool> CheckDuplicateRegistration(string email)
        {
            try
            {
                Task<IEnumerable<ParseUser>> duplicated = ParseUser.Query
                            .WhereEqualTo("Email", email)
                            .FindAsync();
                switch (duplicated.Status)
                {
                    case TaskStatus.Created:
                        return await Task.FromResult(true);
                    case TaskStatus.WaitingForActivation:
                    case TaskStatus.WaitingToRun:
                    case TaskStatus.Running:
                    case TaskStatus.WaitingForChildrenToComplete:
                    case TaskStatus.RanToCompletion:
                    case TaskStatus.Canceled:
                    case TaskStatus.Faulted:
                    default:
                        return await Task.FromResult(false);
                }
            }
            catch (Exception e)
            {
#warning TODO:log exception
                return await Task.FromResult(false);
            }
        }

        public async Task<RegistrationResponse> Register(string email, string username, string password, string passwordConfirm)
        {
            try
            {
                RegistrationResponse response = new RegistrationResponse();
                var user = new ParseUser()
                {
                    Username = username,
                    Password = password,
                    Email = email,
                };
                // Adding other fields
                user["AdminUser"] = false;
                user["Locked"] = false;
                user["LastLoginDateTime"] = new DateTime();
                user["LastFailedLoginDateTime"] = null;
                user["NumberOfFailedLogins"] = 0;
                user["Token"] = null;
                user["tempPassword"] = passwordConfirm;

                response = validateUserRegistration();

                if (response.ResponseValue)
                {
                    await user.SignUpAsync();
                    return response;
                }
                else
                {
                    return response;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public RegistrationResponse validateUserRegistration(ParseUser user)
        {
            try
            {
                RegistrationResponse response = new RegistrationResponse();
                bool isNewUser = CheckDuplicateRegistration(user.Email);
                bool passwordIsMatched = user.Password.Equals(user.tempPassword);
                user.tempPassword = null;
                if (isNewUser == passwordIsMatched)
                {
                    response.ResponseValue = true;
                    response.ResponseMessage = "SUCESS: User has been validated";
                }
                else
                {
                    response.ResponseValue = true;
                    if (!isNewUser)
                        response.ResponseMessage = "ERROR: User has been taken";
                    else
                        response.ResponseMessage = "ERROR: Passwords don't match";
                }

                return response;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}