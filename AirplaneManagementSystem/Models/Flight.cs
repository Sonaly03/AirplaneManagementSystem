using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneManagementSystem.Models
{
    public class Flight
    {
        public int FlightNumber { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public int Day { get; set; }
        public int Capacity { get; set; } = 20;
        public Dictionary<string, Order> Orders { get; set; } = new Dictionary<string, Order>();



        public Flight(int flightNumber, string departureCity, string arrivalCity, int day)
        {
            FlightNumber = flightNumber;
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            Day = day;
          
        }

       
        public override string ToString()
        {
            return $"Flight: {FlightNumber}, departure: {DepartureCity}, arrival: {ArrivalCity}, day: {Day}";
        }

    }
}
