﻿namespace PantherParking.Data.DAL.Interfaces
{
    public interface ILocationRepository
    {
        bool CheckIn(string username, int lot);
        bool CheckOut(string username);
    }
}