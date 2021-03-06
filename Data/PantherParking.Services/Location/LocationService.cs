﻿using PantherParking.Data.DAL.Interfaces;
using PantherParking.Data.Models;
using PantherParking.Data.Models.ResponseModels;

namespace PantherParking.Services.Location
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }
        public LocationResponse CheckIn(User data)
        {
            return this.locationRepository.CheckIn(data);
        }

        public LocationResponse CheckOut(User data)
        {
            return this.locationRepository.CheckOut(data);
        }
    }
}