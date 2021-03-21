using System;
using CodeKata.Models;
using NUnit.Framework;

namespace Tests
{
    public class TripTests
    {
        private Trip _trip;

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void AvgMphProperty_ReturnsZeroWhenStopIsLessThenStart()
        {
            _trip = new Trip(DateTime.Parse("07:00"), DateTime.Parse("06:00"), 30);

            Assert.AreEqual(_trip.AvgMph, 0.0);
        }

        [Test]
        public void AvgMphProperty_ReturnsZeroWhenStartAndStopAreTheSame()
        {
            _trip = new Trip(DateTime.Parse("07:00"), DateTime.Parse("07:00"), 30);

            Assert.AreEqual(_trip.AvgMph, 0.0);
        }

        [Test]
        public void AvgMphProperty_ReturnsAvgMpg()
        {
            _trip = new Trip(DateTime.Parse("07:00"), DateTime.Parse("07:30"), 60);

            Assert.AreEqual(_trip.AvgMph, 120.0);
        }
    }
}
