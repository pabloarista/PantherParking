using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using PantherParking.Data.DAL.Repositories;
using PantherParking.Data.Models;
using PantherParking.Data.Models.ResponseModels;
using NUnit.Framework;
namespace PantherParking.Data.Tests
{
    [TestFixture]
    public class LocationRepositoryTest
    {
        private readonly LocationRepository locationRepository;

        public LocationRepositoryTest()
        {
            this.locationRepository = new LocationRepository();
        }

        [TestMethod]
        public void CheckInTest()
        {
            User data = new User
            {
                sessionToken = "",
                garageID = "",
                username = "pantherdude"
            };

            LocationResponse lr = this.locationRepository.CheckIn(data);

            Assert.IsNotNull(lr);

            Assert.IsTrue(lr.ResponseValue);

            Assert.IsTrue(string.IsNullOrWhiteSpace(lr.ResponseMessage));
        }

        [TestMethod]
        public void CheckOutTest()
        {
            User data = new User
            {
                sessionToken = "",
                garageID = "",
                username = "pantherdude"
            };

            LocationResponse lr = this.locationRepository.CheckOut(data);

            Assert.IsNotNull(lr);

            Assert.IsTrue(lr.ResponseValue);

            Assert.IsTrue(string.IsNullOrWhiteSpace(lr.ResponseMessage));
        }
    }
}
