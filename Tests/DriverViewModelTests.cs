using System;
using CodeKata.Models;
using CodeKata.ViewModels;
using NUnit.Framework;

namespace Tests
{
    public class DriverViewModelTests
    {
        private DriverViewModel _viewModel;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NameProperty_GetReturnsDriverName()
        {
            _viewModel = new DriverViewModel(new CodeKata.Models.Driver("Ryan"));

            Assert.AreEqual("Ryan", _viewModel.Name);
        }

        [Test]
        public void NameProperty_GetReturnsEmptyStringOnNullDriver()
        {
            _viewModel = new DriverViewModel(null);

            Assert.AreEqual("", _viewModel.Name);
        }

        [Test]
        public void TravelDetailsProperty_GetReturnsFormattedString()
        {
            Driver driver = new Driver("Ryan");
            Trip trip = new Trip(DateTime.Parse("07:00"), DateTime.Parse("08:00"), 30);
            driver.Trips.Add(trip);
            _viewModel = new DriverViewModel(driver);

            Assert.AreEqual("30 miles @ 30 mph", _viewModel.TravelDetails);
        }

        [Test]
        public void TavelDetailsProperty_GetReturnsEmptyStringOnNullDriver()
        {
            _viewModel = new DriverViewModel(null);

            Assert.AreEqual("", _viewModel.TravelDetails);
        }
    }
}