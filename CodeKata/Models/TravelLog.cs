using System;
namespace CodeKata.Models
{
    public class TravelLog
    {
        /// <summary>
        /// Title of the travel log.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// A string containing the travel log commands
        /// </summary>
        public string Log { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="title">Title of the travel log.</param>
        public TravelLog(string title)
        {
            Title = title;
        }
    }
}
