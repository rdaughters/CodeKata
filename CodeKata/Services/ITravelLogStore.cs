using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeKata.Models;

namespace CodeKata.Services
{
    public interface ITravelLogStore
    {
        Task<IEnumerable<TravelLog>> GetTravelLogs();
    }
}
