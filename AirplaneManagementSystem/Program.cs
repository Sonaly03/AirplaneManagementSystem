using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirplaneManagementSystem.Services;

namespace AirplaneManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string flightSchedulePath = "C:\\Users\\ssona\\source\\repos\\AirplaneManagementSystem\\AirplaneManagementSystem\\Data\\flightSchedules.json";
       
            string orderSchedulePath = "C:\\Users\\ssona\\source\\repos\\AirplaneManagementSystem\\AirplaneManagementSystem\\Data\\coding-assigment-orders.json"; 

            var flightService = new FlightServices();

         
            flightService.LoadFlightAndOrders(flightSchedulePath, orderSchedulePath);

            
            flightService.DisplayFlightSchedule();

            
            flightService.AssignOrdersToFlights();

          
        }
    }
}
