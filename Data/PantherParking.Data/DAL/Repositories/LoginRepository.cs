﻿using System;
using PantherParking.Data.DAL.Interfaces;
using PantherParking.Data.Models;
using PantherParking.Data.Models.ResponseModels;

namespace PantherParking.Data.DAL.Repositories
{
    public class LoginRepository : BaseRepository, ILoginRepository
    {
        public LoginResponse Login(User userData)
        {
#warning login and return User model
            return null;
        }

        public LoginResponse Logout(User userData)
        {
#warning logout user from data store
            throw new NotImplementedException();
        }

        public bool ValidateSession(string token)
        {
#warning ensure token corresponds to this user
            throw new NotImplementedException();
        }
    }
}