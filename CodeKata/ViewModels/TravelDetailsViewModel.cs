using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CodeKata.Models;
using CodeKata.Services;

namespace CodeKata.ViewModels
{
    public class TravelDetailsViewModel
    {
        private TravelLog _travelLog;
        private ITravelLogProcessor _travelLogProcessor;

        /// <summary>
        /// Title of the travel log.
        /// </summary>
        public string Title { get { return _travelLog.Title; } }

        /// <summary>
        /// A list of Drivers.
        /// </summary>
        public ObservableCollection<DriverViewModel> Drivers { get; } = new ObservableCollection<DriverViewModel>();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="travelLog">The travel log to display.</param>
        /// <param name="travelLogProcessor">A <see cref="ITravelLogProcessor"/> used to process the travel log.</param>
        public TravelDetailsViewModel(TravelLog travelLog, ITravelLogProcessor travelLogProcessor)
        {
            _travelLog = travelLog;
            _travelLogProcessor = travelLogProcessor;

            ProcessTravelLog(_travelLogProcessor);
        }

        /// <summary>
        /// Process the <see cref="_travelLog"/>.
        /// </summary>
        /// <param name="travelLogProcessor">The <see cref="ITravelLogProcessor"/> to use to process the travel log.</param>
        public void ProcessTravelLog(ITravelLogProcessor travelLogProcessor)
        {
            var drivers = travelLogProcessor.ProcessTravelLog(_travelLog.Log).OrderByDescending(x => x.TotalMilesDriven);

            foreach (Driver driver in drivers)
            {
                Drivers.Add(new DriverViewModel(driver));
            }
        }
    }
}
