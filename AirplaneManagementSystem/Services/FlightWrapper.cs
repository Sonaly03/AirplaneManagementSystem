using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirplaneManagementSystem.Models;

namespace AirplaneManagementSystem.Services
{
    public class FlightsWrapper
    {
        // This property will map to the 'flights' array in the JSON
        public Flight[] Flights { get; set; }
    }
}

