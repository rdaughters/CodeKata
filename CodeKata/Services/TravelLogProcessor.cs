using System;
using System.Collections.Generic;
using System.Linq;
using CodeKata.Models;

namespace CodeKata.Services
{
    public class TravelLogProcessor : ITravelLogProcessor
    {
        /// <summary>
        /// Process a log file containing a set of commands.
        /// </summary>
        /// <param name="travelLog">The travel log to process.</param>
        /// <returns>A list of <see cref="Driver"/> objects.</returns>
        public List<Driver> ProcessTravelLog(string travelLog)
        {
            // NOTE: Assuming Driver name will be unique in log file
            Dictionary<string, Driver> drivers = new Dictionary<string, Driver>();

            string[] commands = travelLog.Split('\n');
            for (int i = 0; i < commands.Length; i++)
            {
                string[] args = commands[i].Split(' ');
                ProcessCommandLine(drivers, args);
            }

            return drivers.Values.ToList();
        }

        /// <summary>
        /// Processes a single line from a travel log.
        /// </summary>
        /// <param name="drivers">A dictionary containing <see cref="Driver"/> objects.</param>
        /// <param name="args">The args of the line to process.</param>
        private void ProcessCommandLine(Dictionary<string, Driver> drivers, string[] args)
        {
            // must be a minimum of 2 args for either command
            if (args.Length >= 2)
            {
                if (args[0].Equals("Driver"))
                    ProcessDriverCommand(drivers, args);
                else if (args[0].Equals("Trip"))
                    ProcessTripCommand(drivers, args);
            }
        }

        /// <summary>
        /// Processes a "Driver" command. Adds any new drivers to the given driver dictionary.
        /// </summary>
        /// <param name="drivers">A dictionary containing <see cref="Driver"/> objects.</param>
        /// <param name="args">The Driver command args.</param>
        private void ProcessDriverCommand(Dictionary<string, Driver> drivers, string[] args)
        {
            if (args.Length >= 2)
            {
                // check if driver already exists
                if (drivers.ContainsKey(args[1]))
                    return;

                // driver doesn't exist - add new driver
                drivers.Add(args[1], new Driver(args[1]));
            }
        }

        /// <summary>
        /// Processes a "Trip" command. Adds any trips to the corresponding <see cref="Driver"/>
        /// in the drivers dictionary.
        /// </summary>
        /// <remarks>
        /// Ignores trips where there is no <see cref="Driver"/> in the drivers dictionary. Also,
        /// ignores trips that have a <see cref="Trip.AvgMph"/> less than 5 or greater than 100.
        /// </remarks>
        /// <param name="drivers">A dictionary containing <see cref="Driver"/> objects.</param>
        /// <param name="args">The Trip command args.</param>
        private void ProcessTripCommand(Dictionary<string, Driver> drivers, string[] args)
        {
            // must be 5 args for a Trip command
            if (args.Length == 5)
            {
                // ensure a Driver exists for this Trip - else ignore the Trip
                if (drivers.ContainsKey(args[1]))
                {
                    // trip parameters to be parsed
                    DateTime startTime;
                    DateTime stopTime;
                    double milesDriven;

                    // attempt to parse Trip parameters - return on failure
                    if (!DateTime.TryParse(args[2], out startTime))
                        return;

                    if (!DateTime.TryParse(args[3], out stopTime))
                        return;

                    if (!Double.TryParse(args[4], out milesDriven))
                        return;

                    // parsing successful - create new trip and add to drivers dict
                    Trip newTrip = new Trip(startTime, stopTime, milesDriven);
                    
                    if (newTrip.AvgMph >= 5.0 && newTrip.AvgMph <= 100)
                        drivers[args[1]].Trips.Add(newTrip);
                }
            }
        }
    }
}
