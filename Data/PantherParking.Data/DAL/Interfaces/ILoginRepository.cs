﻿using System;
using PantherParking.Data.Models;

namespace PantherParking.Data.DAL.Interfaces
{
    public interface ILoginRepository
    {
        User Login(string username, string password);
        bool Logout(string username);
        bool ValidateSession(string token);
    }
}