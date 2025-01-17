//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;
//using AirplaneManagementSystem.Models;

//namespace AirplaneManagementSystem.Services
//{
//    internal class DataLoader
//    {
//        private readonly string flightSchedulePath = "C:\\Users\\ssona\\source\\repos\\AirplaneManagementSystem\\AirplaneManagementSystem\\Data\\flightSchedules.json";

//        private readonly string orderSchedulePath = "C:\\Users\\ssona\\source\\repos\\AirplaneManagementSystem\\AirplaneManagementSystem\\Data\\coding-assigment-orders.json";

//        private List<Flight> Flights;
//        private Dictionary<string, Order> Orders;

//        public static JsonSerializerOptions options = new JsonSerializerOptions
//        {
//            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
//        };

//        public List<Flight> LoadFlights(string flightSchedulePath, string orderSchedulePath)
//        {
//            try
//            {

//                var flightJsonContent = File.ReadAllText(flightSchedulePath);


//                var flightsWrapper = JsonSerializer.Deserialize<FlightsWrapper>(flightJsonContent, options);

//                if (flightsWrapper != null)
//                {
//                    int currentDay = 1;
//                    foreach (var flight in flightsWrapper.Flights)
//                    {
//                        flight.Day = currentDay;
//                        Flights.Add(flight);

//                        if (flight.FlightNumber == 3)
//                        {
//                            currentDay++;
//                        }
//                    }
//                }
//                Console.WriteLine($"Loaded {Flights.Count} flights");

//                return Flights;


//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error loading flight schedule and orders: {ex.Message}");
//            }
//        }

//        public Dictionary<string, Order> LoadOrders(string orderSchedulePath)
//        {
//            try
//            {

//                var orderJsonContent = File.ReadAllText(orderSchedulePath);
//                Orders = JsonSerializer.Deserialize<Dictionary<string, Order>>(orderJsonContent, options);
//                Console.WriteLine($"Loaded {Orders.Count} orders");
//                return Orders;

//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error loading flight schedule and orders: {ex.Message}");
//            }
//        }

//    }
//}
