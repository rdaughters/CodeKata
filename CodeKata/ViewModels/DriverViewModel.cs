using System;
using CodeKata.Models;

namespace CodeKata.ViewModels
{
    public class DriverViewModel : BaseViewModel
    {
        private Driver _driver;

        /// <summary>
        /// Name of the driver.
        /// </summary>
        public string Name
        {
            get
            {
                if (_driver == null)
                    return "";
                return _driver.Name;
            }
        }

        /// <summary>
        /// String formatted summary of the travel details.
        /// </summary>
        public string TravelDetails
        {
            get
            {
                if (_driver == null)
                    return "";

                return string.Format("{0} miles @ {1} mph", Math.Round(_driver.TotalMilesDriven), Math.Round(_driver.AvgSpeed));
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="driver">The <see cref="Driver"/> object.</param>
        public DriverViewModel(Driver driver)
        {
            _driver = driver;
        }
    }
}
