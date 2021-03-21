using System;
namespace CodeKata.Models
{
    public class Trip
    {
        /// <summary>
        /// Trip start time.
        /// </summary>
        public DateTime StartTime { get; private set; }

        /// <summary>
        /// Trip stop time.
        /// </summary>
        public DateTime StopTime { get; private set; }

        /// <summary>
        /// Miles driven.
        /// </summary>
        public double MilesDriven { get; private set; }

        /// <summary>
        /// Average mph.
        /// </summary>
        public double AvgMph
        {
            get
            {
                if (StopTime < StartTime || (StopTime - StartTime).TotalHours == 0.0)
                    return 0.0;

                return MilesDriven / (StopTime - StartTime).TotalHours;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="startTime">The start time.</param>
        /// <param name="stopTime">The stop time.</param>
        /// <param name="milesDriven">The total number of miles driven.</param>
        public Trip(DateTime startTime, DateTime stopTime, double milesDriven)
        {
            StartTime = startTime;
            StopTime = stopTime;
            MilesDriven = milesDriven;
        }
    }
}
