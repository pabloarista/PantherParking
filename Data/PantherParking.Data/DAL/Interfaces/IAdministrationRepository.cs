﻿using System;

namespace PantherParking.Data.DAL.Interfaces
{
    public interface IAdministrationRepository
    {
        bool SetStartDate(DateTime begin);
        bool SetEndDate(DateTime end);
        bool SetHoliday(DateTime holiday);
    }
}