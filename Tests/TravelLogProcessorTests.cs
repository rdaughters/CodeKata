using System;
using System.Collections.Generic;
using CodeKata.Models;
using CodeKata.Services;
using NUnit.Framework;

namespace Tests
{
    public class TravelLogProcessorTests
    {
        TravelLogProcessor travelLogProcessor;

        [SetUp]
        public void Setup()
        {
            travelLogProcessor = new TravelLogProcessor();
        }

        [Test]
        public void ProcessTravelLog_EmptyLogReturnsEmptyList()
        {
            var drivers = travelLogProcessor.ProcessTravelLog("");

            Assert.AreEqual(drivers.Count, 0);
        }

        [Test]
        public void ProcessTravelLog_IgnoreJunkCommands()
        {
            var drivers = travelLogProcessor.ProcessTravelLog("Passenger Bob");

            Assert.AreEqual(drivers.Count, 0);
        }

        [Test]
        public void ProcessTravelLog_DriverAdded()
        {
            var drivers = travelLogProcessor.ProcessTravelLog("Driver Dan");

            Assert.AreEqual(drivers.Count, 1);
            Assert.AreEqual(drivers[0].Name, "Dan");
        }

        [Test]
        public void ProcessTravelLog_IgnoreDuplicateDrivers()
        {
            var drivers = travelLogProcessor.ProcessTravelLog("Driver Dan\nDriver Dan");

            Assert.AreEqual(drivers.Count, 1);
        }

        [Test]
        public void ProcessTravelLog_IgnoreNotEnoughTripArgs()
        {
            var drivers = travelLogProcessor.ProcessTravelLog("Driver Dan\nTrip");

            Assert.AreEqual(drivers.Count, 1);
            Assert.AreEqual(drivers[0].Trips.Count, 0);
        }

        [Test]
        public void ProcessTravelLog_TripAdded()
        {
            var drivers = travelLogProcessor.ProcessTravelLog("Driver Dan\nTrip Dan 07:15 07:45 17.3");

            Assert.AreEqual(drivers.Count, 1);
            Assert.AreEqual(drivers[0].Trips.Count, 1);
        }

        [Test]
        public void ProcessTravelLog_IgnoresAvgMpgLessThen5()
        {
            var drivers = travelLogProcessor.ProcessTravelLog("Driver Dan\nTrip Dan 07:15 07:45 1");

            Assert.AreEqual(drivers.Count, 1);
            Assert.AreEqual(drivers[0].Trips.Count, 0);
        }

        [Test]
        public void ProcessTravelLog_IgnoresAvgMpgGreaterThen100()
        {
            var drivers = travelLogProcessor.ProcessTravelLog("Driver Dan\nTrip Dan 07:15 07:45 10000");

            Assert.AreEqual(drivers.Count, 1);
            Assert.AreEqual(drivers[0].Trips.Count, 0);
        }
    }
}
