using System;
using System.Collections.Generic;
using CodeKata.Models;

namespace CodeKata.Services
{
    public interface ITravelLogProcessor
    {
        List<Driver> ProcessTravelLog(string travelLog);
    }
}
