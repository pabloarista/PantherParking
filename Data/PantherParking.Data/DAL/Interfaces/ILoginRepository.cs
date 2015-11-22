﻿using System;
using PantherParking.Data.Models;

namespace PantherParking.Data.DAL.Interfaces
{
    public interface ILoginRepository
    {
        LoginResponse Login(User userData);
        LoginResponse Logout(User userData);
        bool ValidateSession(string token);
    }
}