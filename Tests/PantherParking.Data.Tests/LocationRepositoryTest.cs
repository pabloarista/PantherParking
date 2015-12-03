using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PantherParking.Data.UnitTests
{
    [TestFixture]
    public class LocationRepositoryTest
    {
        private readonly LocationRepository locationRepository;

        public LocationRepositoryTest()
        {
            this.locationRepository = new LocationRepository();
        }

        [Test]
        public void SunnyCheckInTest()
        {
            CheckIn data = new CheckIn
            {
                Token = Guid.NewGuid() + "",
                GarageId = "PG5",
                Username = "pantherdude"
            };

            LocationResponse lr = this.locationRepository.CheckIn(data);

            Assert.IsNotNull(lr);

            Assert.IsTrue(lr.ResponseValue);

            Assert.IsTrue(string.IsNullOrWhiteSpace(lr.ResponseMessage));
        }

        [Test]
        public void RainyCheckInTest()
        {
            CheckIn data = new CheckIn
            {
                Token = "",
                GarageId = "PG5",
                Username = "Whatever"
            };

            LocationResponse lr = this.locationRepository.CheckIn(data);

            Assert.IsNotNull(lr);

            Assert.IsFalse(lr.ResponseValue);
        }

        [Test]
        public void SunnyCheckOutTest()
        {
            CheckIn data = new CheckIn
            {
                Token = Guid.NewGuid() + "",
                GarageId = "PG5",
                Username = "pantherdude"
            };

            LocationResponse lr = this.locationRepository.CheckOut(data);

            Assert.IsNotNull(lr);

            Assert.IsTrue(lr.ResponseValue);

            Assert.IsTrue(string.IsNullOrWhiteSpace(lr.ResponseMessage));
        }

        [Test]
        public void RainyCheckOutTest()
        {
            CheckIn data = new CheckIn
            {
                Token = "",
                GarageId = "PG5",
                Username = "Whatever"
            };

            LocationResponse lr = this.locationRepository.CheckOut(data);

            Assert.IsNotNull(lr);

            Assert.IsFalse(lr.ResponseValue);
        }
    }
}
