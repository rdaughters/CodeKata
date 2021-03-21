using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using CodeKata.Models;

namespace CodeKata.Services
{
    public class TravelLogStore : ITravelLogStore
    {
        /// <summary>
        /// Gets a list of <see cref="TravelLog"/> objects.
        /// </summary>
        /// <remarks>
        /// Input files are found under CodeKata.Files folder. To add another input file
        /// add the file under the Files folder and set the build action to "EmbeddedResource".
        /// Then follow the pattern for exampleLog and lotr to process and add the new
        /// input file.
        /// </remarks>
        /// <returns>A list of <see cref="TravelLog"/> objects.</returns>
        public async Task<IEnumerable<TravelLog>> GetTravelLogs()
        {
            List<TravelLog> logs = new List<TravelLog>();

            TravelLog exampleLog = new TravelLog("Example");
            exampleLog.Log = await ReadTravelLog("Example.txt");
            logs.Add(exampleLog);

            TravelLog lotr = new TravelLog("Lord of the Rings");
            lotr.Log = await ReadTravelLog("LOTR.txt");
            logs.Add(lotr);

            // add more logs here and follow pattern above

            return logs;
        }

        /// <summary>
        /// Reads a travel log input file.
        /// </summary>
        /// <param name="fileName">The file name.</param>
        /// <returns>A string containing all text from the file.</returns>
        private async Task<string> ReadTravelLog(string fileName)
        {
            var assembly = typeof(TravelLogStore).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(string.Format("CodeKata.Files.{0}", fileName));

            if (stream == null)
                return "";

            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = await reader.ReadToEndAsync();
            }

            return text;
        }
    }
}
