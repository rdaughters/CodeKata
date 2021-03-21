using System;
using CodeKata.Models;
using NUnit.Framework;

namespace Tests
{
    public class DriverTests
    {
        private Driver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new Driver("Ryan");
        }

        [Test]
        public void TotalMilesDrivenProperty_ReturnsZeroOnEmptyTrip()
        {
            Assert.AreEqual(_driver.TotalMilesDriven, 0.0);
        }

        [Test]
        public void TotalMilesDrivenProperty_ReturnsTotalMiles()
        {
            Trip trip = new Trip(DateTime.Parse("07:00"), DateTime.Parse("08:00"), 30);
            Trip trip1 = new Trip(DateTime.Parse("07:00"), DateTime.Parse("08:00"), 30);

            _driver.Trips.Add(trip);
            _driver.Trips.Add(trip1);

            Assert.AreEqual(_driver.TotalMilesDriven, 60);
        }

        [Test]
        public void AvgSpeedProperty_ReturnsZeroOnEmptyTrip()
        {
            Assert.AreEqual(_driver.AvgSpeed, 0.0);
        }

        [Test]
        public void AvgSpeedProperty_ReturnsAvgSpeed()
        {
            Trip trip = new Trip(DateTime.Parse("07:00"), DateTime.Parse("08:00"), 30);
            Trip trip1 = new Trip(DateTime.Parse("07:00"), DateTime.Parse("08:00"), 30);

            _driver.Trips.Add(trip);
            _driver.Trips.Add(trip1);

            Assert.AreEqual(_driver.AvgSpeed, 30.0);
        }
    }
}
