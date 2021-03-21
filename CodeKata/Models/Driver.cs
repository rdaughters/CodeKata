using System;
using System.Collections.Generic;

namespace CodeKata.Models
{
    public class Driver
    {
        /// <summary>
        /// Name of the Driver
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// List of <see cref="Trip"/> objects the driver has taken.
        /// </summary>
        public List<Trip> Trips { get; } = new List<Trip>();

        /// <summary>
        /// Total miles driven by the Driver.
        /// </summary>
        public double TotalMilesDriven
        {
            get
            {
                double totalMilesDriven = 0.0;

                foreach (Trip trip in Trips)
                {
                    totalMilesDriven += trip.MilesDriven;
                }

                return totalMilesDriven;
            }
        }

        /// <summary>
        /// Average speed across all <see cref="Trips"/>.
        /// </summary>
        public double AvgSpeed
        {
            get
            {
                double totalSpeed = 0.0;

                foreach (Trip trip in Trips)
                {
                    totalSpeed += trip.AvgMph;
                }

                if (totalSpeed != 0.0)
                    return totalSpeed / Trips.Count;

                return totalSpeed;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">The name of the driver.</param>
        public Driver(string name)
        {
            Name = name;
        }
    }
}
